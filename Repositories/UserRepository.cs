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
            catch
            {
                transaction.Rollback();
                return false;
            }
        }
    }
}