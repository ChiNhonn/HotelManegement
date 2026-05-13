using QuanLyKhachSan.DTOs;
using QuanLyKhachSan.Models;
using QuanLyKhachSan.Repositories;
using System;
using System.Text.RegularExpressions;

namespace QuanLyKhachSan.Services
{
    public class RegisterService
    {
        // 1. Khai báo đúng Interface Repository
        private readonly IUserRepository _taiKhoanRepository;

        // Truyền repository vào 
        public RegisterService(IUserRepository taiKhoanRepository)
        {
            _taiKhoanRepository = taiKhoanRepository;
        }

        /// <summary>
        /// Hàm xử lý logic đăng ký tài khoản
        /// </summary>
        // 2.truyền vào RegisterDTO
        public (bool IsSuccess, string Message) RegisterUser(RegisterDTO dto)
        {
            // KIỂM TRA ĐẦU VÀO
            if (string.IsNullOrWhiteSpace(dto.Username) ||
                string.IsNullOrWhiteSpace(dto.Password) ||
                string.IsNullOrWhiteSpace(dto.Phone) ||
                string.IsNullOrWhiteSpace(dto.Email))
            {
                return (false, "Vui lòng nhập đầy đủ thông tin.");
            }

            if (dto.Password.Length < 6)
            {
                return (false, "Mật khẩu phải có từ 6 ký tự trở lên.");
            }

            if (!IsValidEmail(dto.Email))
            {
                return (false, "Định dạng email không hợp lệ.");
            }

            try
            {
                // 3. GỌI HÀM TỪ TaiKhoanRepository 
                if (_taiKhoanRepository.KiemTraTenDangNhapTonTai(dto.Username))
                {
                    return (false, "Tên đăng nhập này đã tồn tại. Vui lòng chọn tên khác.");
                }

                // 4. MAPPING SANG MODEL TaiKhoan 
                var newAccount = new TaiKhoan
                {
                    TenDangNhap = dto.Username,
                    MatKhauHash = HashPassword(dto.Password),
                    SoDienThoai = dto.Phone,
                    Email = dto.Email,

                    // Tạm thời lấy Username làm tên hiển thị
                    HoTenHienThi = dto.Username,

                    // Phân quyền mặc định khi đăng ký mới (Bạn có thể đổi thành "NhanVien" hoặc "KhachHang" tùy hệ thống)
                    VaiTro = "KhachHang",

                    // Gán trạng thái tài khoản là đang hoạt động
                    TrangThai = "HoatDong",

                    // Ghi nhận thời gian tạo tài khoản ngay thời điểm hiện tại
                    NgayTao = DateTime.Now,
                    NgayCapNhat = DateTime.Now
                };

                // 5. LƯU XUỐNG DATABASE
                bool isSaved = _taiKhoanRepository.ThemTaiKhoan(newAccount);

                if (isSaved)
                {
                    return (true, "Đăng ký tài khoản thành công!");
                }
                else
                {
                    return (false, "Có lỗi xảy ra khi lưu dữ liệu. Vui lòng thử lại sau.");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi hệ thống: {ex.Message}");
            }
        }

        // --- CÁC HÀM HỖ TRỢ (HELPER METHODS) ---

        private bool IsValidEmail(string email)
        {
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }

        private string HashPassword(string password)
        {
            // Tạm thời trả về mật khẩu gốc. Sau này bạn nên thêm mã hóa (MD5/SHA256) vào đây.
            return password;
        }
    }
}