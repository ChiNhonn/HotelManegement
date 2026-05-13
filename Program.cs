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
        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();
        services.AddDbContext<HotelDbContext>(options =>
            options.UseSqlServer(
                @"Server=.\SQLEXPRESS01;Database=HotelManagement;Trusted_Connection=True;TrustServerCertificate=True;"));

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

        var rootProvider = services.BuildServiceProvider();
        _rootScope = rootProvider.CreateScope();
        ServiceProvider = _rootScope.ServiceProvider;

        Application.ApplicationExit += (_, _) =>
        {
            _rootScope?.Dispose();
            _rootScope = null;
            (rootProvider as IDisposable)?.Dispose();
        };

        try
        {
            using (var migrateScope = rootProvider.CreateScope())
            {
                var db = migrateScope.ServiceProvider.GetRequiredService<HotelDbContext>();
                db.Database.Migrate();
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

        Application.Run(ServiceProvider.GetRequiredService<LoginForm>());
    }
}
