using HotelManagement.Data;
using HotelManagement.Helpers;
using HotelManagement.Models;
using HotelManagement.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HotelDbContext _context;

        public UserRepository(HotelDbContext context)
        {
            _context = context;
        }

        public Userr? Login(string username, string password)
        {
            var normalized = username.Trim();
            var user = _context.Users
                .Include(x => x.UserProfile)
                .FirstOrDefault(x =>
                    x.SoftDelete == null &&
                    x.UserName != null &&
                    x.UserName.ToLower() == normalized.ToLower());

            if (user == null)
                return null;

            if (!PasswordHelper.VerifyPassword(password, user.Password, out var upgradeToBcrypt))
                return null;

            if (upgradeToBcrypt)
            {
                user.Password = PasswordHelper.HashPassword(password);
                user.UpdateAt = DateTime.Now;
                _context.SaveChanges();
            }

            return user;
        }

        public bool CheckUsernameExists(string username)
        {
            return _context.Users
                .Any(x => x.UserName == username);
        }

        public bool Register(Userr user, UserProfile profile)
        {
            // Tạo Execution Strategy để hỗ trợ Transaction khi bật EnableRetryOnFailure
            var strategy = _context.Database.CreateExecutionStrategy();

            return strategy.Execute(() =>
            {
                using var transaction = _context.Database.BeginTransaction();

                try
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();

                    profile.IdUser = user.Id;

                    _context.UserProfiles.Add(profile);
                    _context.SaveChanges();

                    transaction.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    // Hoàn tác dữ liệu nếu có lỗi
                    transaction.Rollback();

                    // Ném lỗi chi tiết của SQL Server lên trên thay vì nuốt lỗi
                    throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                }
            });
        }

        public void UpdatePassword(string email, string newPassword)
        {
            var normalizedEmail = email.Trim().ToLower();

            // Tìm User dựa vào Email nằm trong bảng UserProfiles liên kết qua IdUser
            var user = _context.Users.FirstOrDefault(u =>
                u.SoftDelete == null &&
                _context.UserProfiles.Any(p => p.Email.ToLower() == normalizedEmail && p.IdUser == u.Id)
            );

            if (user == null)
                throw new Exception("Không tìm thấy tài khoản tương ứng với Email này.");

            // Mã hóa mật khẩu mới trước khi lưu
            user.Password = PasswordHelper.HashPassword(newPassword);
            user.UpdateAt = DateTime.Now;

            // Lưu thay đổi vào DB
            _context.SaveChanges();
        }

        public bool CheckEmailExists(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            var normalizedEmail = email.Trim().ToLower();

            return _context.UserProfiles.Any(p =>
                p.Email.ToLower() == normalizedEmail &&
                _context.Users.Any(u => u.Id == p.IdUser && u.SoftDelete == null)
            );
        }
    }
}