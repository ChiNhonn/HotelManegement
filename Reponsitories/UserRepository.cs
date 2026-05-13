using HotelManagement.Data;
using HotelManagement.Models;
using HotelManagement.Interfaces;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Services;
namespace HotelManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HotelDbContext _context;

        public UserRepository(HotelDbContext context)
        {
            _context = context;
        }

        public Userr Login(string username, string passwordHash)
        {
            return _context.Users
                .Include(x => x.UserProfile)
                .FirstOrDefault(x =>
                    x.UserName == username &&
                    x.Password == passwordHash);
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