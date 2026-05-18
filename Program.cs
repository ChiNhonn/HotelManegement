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
    public static IServiceProvider ServiceProvider ;


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

        var services = new ServiceCollection();
        services.AddDbContext<IMyDbContext,HotelDbContext>();

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
<<<<<<< HEAD
        services.AddScoped<IFloorService, FloorService>();
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IBranchService, BranchService>();
        services.AddScoped<IServiceModuleService, ServiceModuleService>();

        services.AddTransient<usBookRoom>();
        services.AddTransient<usService>();
=======
        services.AddScoped<ICustomerServices, CustomerServices>();
>>>>>>> quan-ly-khach

        services.AddTransient<LoginForm>();
        services.AddTransient<MainForm>();
        services.AddTransient<RegisterForm>();
        services.AddTransient<usRoom>();
<<<<<<< HEAD
        services.AddTransient<usBill>();
        services.AddTransient<usMainForm>();
        services.AddTransient<ForgetPasswordForm>();
        services.AddTransient<DoiMKForm>();

        services.AddTransient<BulkCreateRoomsDialog>();
        services.AddTransient<RoomEditDialogForm>();
        services.AddTransient<RoomTypeEditDialogForm>();
        services.AddTransient<FloorEditDialogForm>();
        services.AddTransient<BillDetailDialogForm>();
        services.AddTransient<BranchEditDiaLogForm>();
=======
        services.AddTransient<AddRoomDialogForm>();
        services.AddTransient<AddRoomTypeDiaLogForm>();
        services.AddTransient<CustomerForm>();
        services.AddTransient<InfoCustomerForm>();
>>>>>>> quan-ly-khach

        ServiceProvider = services.BuildServiceProvider();
        var main = ServiceProvider.GetRequiredService<CustomerForm>();

<<<<<<< HEAD
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
                DatabaseMigrationHelper.Migrate(db);
                ServiceModuleDatabaseEnsurer.EnsureSchema(db);
                FloorSchemaPatcher.EnsureFloorStatusColumn(db);
                DemoHotelRoomsSeed.EnsureSeed(db);
                DemoDashboardDataSeed.EnsureSeed(db);
                AuthSeed.EnsureDefaultAdmin(db);
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
=======
        Application.Run(main);
>>>>>>> quan-ly-khach
    }
}
