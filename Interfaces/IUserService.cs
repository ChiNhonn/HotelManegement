using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.Services
{
    public interface IUserService
    {
        Userr Login(string username, string password);
    }
}
