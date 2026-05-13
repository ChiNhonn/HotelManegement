using HotelManagement.Interfaces;

namespace HotelManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private QuanLyKhachSanContext _context;
        public UserRepository(QuanLyKhachSanContext context)
        {
            _context = context;
        }

        public TaiKhoan DangNhap(string username, string passwordHash)
        {
            return _context.TaiKhoans.FirstOrDefault(x => x.TenDangNhap == username && x.MatKhauHash == passwordHash);
        }

        public bool KiemTraTenDangNhapTonTai(string username)
        {
            return _context.TaiKhoans.Any(x => x.TenDangNhap == username);
        }

        public bool ThemTaiKhoan(TaiKhoan taiKhoanMoi)
        {
            try
            {
                _context.TaiKhoans.Add(taiKhoanMoi);
                int result = _context.SaveChanges();
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
