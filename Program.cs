using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Packaging;
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
    public static IServiceProvider ServiceProvider;

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
        services.AddTransient<PaymentByBankForm>();

        ServiceProvider = services.BuildServiceProvider();
        var main = ServiceProvider.GetRequiredService<CustomerForm>();
        Application.Run(main);

    }
}
