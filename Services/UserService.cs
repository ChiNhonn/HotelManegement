using QuanLyKhachSan.Repositories;
using QuanLyKhachSan.Models;
using QuanLyKhachSan.Helpers;
namespace QuanLyKhachSan.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _taikhoan;
        public UserService(IUserRepository repo)
        {
            _taikhoan = repo;
        }
        public TaiKhoan DangNhap(string username, string password)
        {
            string hash = PasswordHelpes.PasswordHash(password);
            return _taikhoan.DangNhap(username, hash);
        }
    }
}
