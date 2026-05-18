using HotelManagement.Helpers;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data;

/// <summary>Tạo tài khoản admin mặc định nếu chưa có (mật khẩu đã hash BCrypt).</summary>
public static class AuthSeed
{
    public const string DefaultAdminUsername = "admin";
    public const string DefaultAdminPassword = "admin123";

    public static void EnsureDefaultAdmin(HotelDbContext db)
    {
        var exists = db.Users.Any(u =>
            u.SoftDelete == null &&
            u.UserName != null &&
            u.UserName.ToLower() == DefaultAdminUsername);

        if (exists)
            return;

        var branchId = db.Branches.OrderBy(b => b.Id).Select(b => b.Id).FirstOrDefault();
        if (branchId == 0)
            return;

        var user = new Userr
        {
            FullName = "Quản trị viên",
            UserName = DefaultAdminUsername,
            Password = PasswordHelper.HashPassword(DefaultAdminPassword),
            Role = "admin",
            CreateAt = DateTime.Now,
            IdBranch = branchId
        };

        db.Users.Add(user);
        db.SaveChanges();

        db.UserProfiles.Add(new UserProfile
        {
            IdUser = user.Id,
            Email = "admin@hotel.local",
            Phone = "0000000000",
            CitizenId = "",
            City = "",
            Commune = "",
            Country = "Việt Nam",
            HouseNumber = "",
            StreetName = "",
            CreateAt = DateTime.Now
        });
        db.SaveChanges();
    }
}
