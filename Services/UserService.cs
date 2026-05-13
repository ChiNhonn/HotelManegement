using HotelManagement.Helpers;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using HotelManagement.Repositories;
using System.Text.RegularExpressions;

namespace HotelManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public Userr? Login(string username, string password)
        {
            return _userRepo.Login(username, password);
        }

        public (bool IsSuccess, string Message)
            RegisterUser(RegisterView dto)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(dto.FullName) ||
                string.IsNullOrWhiteSpace(dto.Username) ||
                string.IsNullOrWhiteSpace(dto.Password) ||
                string.IsNullOrWhiteSpace(dto.Phone) ||
                string.IsNullOrWhiteSpace(dto.Email))
            {
                return (false,
                    "Vui lòng nhập đầy đủ thông tin.");
            }

            if (dto.Password.Length < 6)
            {
                return (false,
                    "Mật khẩu phải từ 6 ký tự.");
            }

            if (!IsValidEmail(dto.Email))
            {
                return (false,
                    "Email không hợp lệ.");
            }

            if (_userRepo.CheckUsernameExists(dto.Username))
            {
                return (false,
                    "Tên đăng nhập đã tồn tại.");
            }

            try
            {
                // tạo user
                var newUser = new Userr
                {
                    FullName = dto.FullName,
                    UserName = dto.Username,

                    // hash giống login
                    Password =
                        PasswordHelper.HashPassword(dto.Password),

                    Role = "nhanvien",

                    CreateAt = DateTime.Now,

                    UpdateAt = null,

                    SoftDelete = null,

                    IdBranch = dto.IdBranch > 0 ? dto.IdBranch : null
                };

                // tạo profile
                var profile = new UserProfile
                {
                    Email = dto.Email,

                    Phone = dto.Phone,

                    CitizenId = dto.CitizenId,

                    CreateAt = DateTime.Now,

                    UpdateAt = null,

                    SoftDelete = null,

                    City = "",

                    Commune = "",

                    Country = "Việt Nam",

                    HouseNumber = "",

                    StreetName = ""
                };

                bool result =_userRepo.Register(newUser, profile);

                if (result)
                {
                    return (true,
                        "Đăng ký thành công.");
                }

                return (false,
                    "Đăng ký thất bại.");
            }
            catch (Exception ex)
            {
                return (false,
                    ex.Message);
            }
        }

        private bool IsValidEmail(string email)
        {
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            return regex.IsMatch(email);
        }
    }
}