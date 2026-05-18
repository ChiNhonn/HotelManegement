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
        services.AddDbContext<HotelDbContext>(options =>
<<<<<<< HEAD
            options.UseSqlServer(
                @"Server=.\SQLEXPRESS01;Database=HotelManagement;Trusted_Connection=True;TrustServerCertificate=True;"));
        services.AddScoped<IMyDbContext>(sp => sp.GetRequiredService<HotelDbContext>());
=======
            options.UseSqlServer(connectionString, sql =>
            {
                sql.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(8),
                    errorNumbersToAdd: null);
                sql.CommandTimeout(180);
            }));

>>>>>>> Thongke

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
<<<<<<< HEAD
        services.AddScoped<IBranchService, BranchService>();
=======
        services.AddScoped<IBranchRepository, BranchRepository>();
        services.AddScoped<IBranchService, BranchService>();

        services.AddTransient<usBookRoom>();

>>>>>>> Thongke
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
            using (var migrateScope = rootProvider.CreateScope())
            {
                var db = migrateScope.ServiceProvider.GetRequiredService<HotelDbContext>();
<<<<<<< HEAD
=======
                db.Database.SetCommandTimeout(180);
>>>>>>> Thongke
                DatabaseMigrationHelper.Migrate(db);
                ServiceModuleDatabaseEnsurer.EnsureSchema(db);
                FloorSchemaPatcher.EnsureFloorStatusColumn(db);
<<<<<<< HEAD
                DemoHotelRoomsSeed.EnsureSeed(db);

                var resetCustomers = string.Equals(
                    Environment.GetEnvironmentVariable("HOTEL_RESET_CUSTOMERS"),
                    "1",
                    StringComparison.OrdinalIgnoreCase);
                if (resetCustomers)
                {
                    DemoCustomerBookingReset.ClearAllCustomersOrdersAndBills(db);
                }

                DemoDashboardDataSeed.EnsureSeed(db, skipDemoOrdersAndBills: resetCustomers);
                AuthSeed.EnsureDefaultAdmin(db);
=======
                ServiceModuleDatabaseEnsurer.EnsureSchema(db);
                AuthSeed.EnsureDefaultAdmin(db);
                DemoHotelRoomsSeed.EnsureSeed(db);
                DemoDashboardDataSeed.EnsureSeed(db);
>>>>>>> Thongke
            }
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

        Application.Run(ServiceProvider.GetRequiredService<LoginForm>());
    }
}
