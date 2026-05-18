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

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IRoomTypeService, RoomTypeService>();

        services.AddTransient<LoginForm>();
        services.AddTransient<MainForm>();
        services.AddTransient<RegisterForm>();
        services.AddTransient<usRoom>();
        services.AddTransient<AddRoomDialogForm>();
        services.AddTransient<AddRoomTypeDiaLogForm>();
        services.AddTransient<CustomerForm>();

        ServiceProvider = services.BuildServiceProvider();
        var main = ServiceProvider.GetRequiredService<CustomerForm>();

        Application.Run(main);
    }
}
