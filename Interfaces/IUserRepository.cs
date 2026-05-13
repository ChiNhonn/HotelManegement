using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.Repositories
{
    public interface IUserRepository
    {
        Userr Login(string username, string passwordHash);

        bool CheckUsernameExists(string username);
        bool AddUser(Userr newUser);
    }
}
