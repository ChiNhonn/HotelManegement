using HotelManagement.CustomControls;
using HotelManagement.Data;
using HotelManagement.Forms;
using HotelManagement.Interfaces;
using HotelManagement.Repositories;
using HotelManagement.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace HotelManagement;

internal static class Program
{
    /// <summary>Root scoped provider — dùng khi form cần resolve thêm service (giữ pattern project cũ).</summary>
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    private static IServiceScope? _rootScope;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        ApplicationConfiguration.Initialize();

        string connectionString;
        try
        {
            connectionString = DatabaseConnection.ResolveConnectionString();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Lỗi database",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        var services = new ServiceCollection();
        // Tránh đăng ký AddDbContext (IMyDbContext, HotelDbContext) không truyền options — EF cần UseSqlServer + chuỗi kết nối.
        services.AddDbContext<HotelDbContext>(options =>
            options.UseSqlServer(connectionString, sql =>
            {
                sql.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(8),
                    errorNumbersToAdd: null);
                sql.CommandTimeout(180);
            }));
        services.AddScoped<IMyDbContext>(sp => sp.GetRequiredService<HotelDbContext>());

        services.AddScoped<IRoomBookingMapRepository, RoomBookingMapRepository>();
        services.AddScoped<IRoomBookingMapService, RoomBookingMapService>();
        services.AddScoped<IDashboardRepository, DashboardRepository>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
        services.AddScoped<IFloorRepository, FloorRepository>();
        services.AddScoped<IBillRepository, BillRepository>();
        services.AddScoped<IBranchRepository, BranchRepository>();

        services.AddScoped<IBillService, BillService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IRoomTypeService, RoomTypeService>();
        services.AddScoped<IFloorService, FloorService>();
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IBranchService, BranchService>();

        services.AddScoped<IServiceModuleService, ServiceModuleService>();
        services.AddScoped<ICustomerServices, CustomerServices>();

        services.AddTransient<usBookRoom>();
        services.AddTransient<usService>();

        services.AddTransient<LoginForm>();
        services.AddTransient<MainForm>();
        services.AddTransient<RegisterForm>();
        services.AddTransient<usRoom>();
        services.AddTransient<usBill>();
        services.AddTransient<usMainForm>();
        services.AddTransient<ForgetPasswordForm>();
        services.AddTransient<DoiMKForm>();
        services.AddTransient<CustomerForm>();
        services.AddTransient<InfoCustomerForm>();

        services.AddTransient<BulkCreateRoomsDialog>();
        services.AddTransient<RoomEditDialogForm>();
        services.AddTransient<RoomTypeEditDialogForm>();
        services.AddTransient<FloorEditDialogForm>();
        services.AddTransient<BillDetailDialogForm>();
        services.AddTransient<BranchEditDiaLogForm>();

        var rootProvider = services.BuildServiceProvider();
        _rootScope = rootProvider.CreateScope();
        ServiceProvider = _rootScope.ServiceProvider;

        Application.ApplicationExit += (_, _) =>
        {
            BankTransferInboundWebhookHost.Stop();
            _rootScope?.Dispose();
            _rootScope = null;
            (rootProvider as IDisposable)?.Dispose();
        };

        try
        {
            using var migrateScope = rootProvider.CreateScope();
            var db = migrateScope.ServiceProvider.GetRequiredService<HotelDbContext>();
            db.Database.SetCommandTimeout(180);

            DatabaseMigrationHelper.Migrate(db);
            ServiceModuleDatabaseEnsurer.EnsureSchema(db);
            FloorSchemaPatcher.EnsureFloorStatusColumn(db);

            // Luôn chạy: khung chi nhánh / tầng / phòng chuẩn (idempotent).
            DemoHotelRoomsSeed.EnsureSeed(db);

            // CHỈ khi đặt HOTEL_RESET_CUSTOMERS=1 — xóa khách / đơn / bill… (nguy hiểm, không bật nhầm).
            var resetCustomers = EnvFlag("HOTEL_RESET_CUSTOMERS");
            if (resetCustomers)
                DemoCustomerBookingReset.ClearAllCustomersOrdersAndBills(db);

            // Seed dashboard demo (đơn giả, chi trả giả, dịch vụ demo…) — TẮT mặc định để không « làm bẩn » DB thật.
            // Bật lại khi cần: HOTEL_DEMO_SEED=1
            if (EnvFlag("HOTEL_DEMO_SEED"))
                DemoDashboardDataSeed.EnsureSeed(db, skipDemoOrdersAndBills: resetCustomers);

            AuthSeed.EnsureDefaultAdmin(db);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Không thể kết nối hoặc migrate database. Kiểm tra SQL Server và chuỗi kết nối.\n\n{ex.Message}",
                "Lỗi database",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        try
        {
            BankTransferInboundWebhookHost.TryStart(rootProvider.GetRequiredService<IServiceScopeFactory>());
        }
        catch
        {
            // không chặn khởi động
        }

        // Mặc định: LoginForm. Giống project cũ (vào thẳng quản lý khách): HOTEL_START_CUSTOMER_FORM=1
        Form startForm = EnvFlag("HOTEL_START_CUSTOMER_FORM")
            ? ServiceProvider.GetRequiredService<CustomerForm>()
            : ServiceProvider.GetRequiredService<LoginForm>();

        Application.Run(startForm);
    }

    private static bool EnvFlag(string name) =>
        string.Equals(Environment.GetEnvironmentVariable(name), "1", StringComparison.OrdinalIgnoreCase)
        || string.Equals(Environment.GetEnvironmentVariable(name), "true", StringComparison.OrdinalIgnoreCase);
}
