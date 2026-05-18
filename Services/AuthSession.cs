using HotelManagement.Models;

namespace HotelManagement.Services;

/// <summary>Phiên đăng nhập hiện tại (desktop).</summary>
public static class AuthSession
{
    public static Userr? CurrentUser { get; private set; }

    public static void SetUser(Userr user) => CurrentUser = user;

    public static void Clear() => CurrentUser = null;
}
