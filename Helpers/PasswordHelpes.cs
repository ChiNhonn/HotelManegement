using System;

namespace HotelManagement.Helpers
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return string.Empty;

            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Xác thực mật khẩu: BCrypt hash hoặc plain-text cũ (nhập tay trong SSMS).
        /// <paramref name="upgradeToBcrypt"/> = true khi cần ghi lại hash sau đăng nhập thành công.
        /// </summary>
        public static bool VerifyPassword(
            string inputPassword,
            string storedPassword,
            out bool upgradeToBcrypt)
        {
            upgradeToBcrypt = false;

            if (string.IsNullOrWhiteSpace(inputPassword) || string.IsNullOrWhiteSpace(storedPassword))
                return false;

            if (IsBcryptHash(storedPassword))
                return BCrypt.Net.BCrypt.Verify(inputPassword, storedPassword);

            if (string.Equals(inputPassword, storedPassword, StringComparison.Ordinal))
            {
                upgradeToBcrypt = true;
                return true;
            }

            return false;
        }

        public static bool VerifyPassword(string inputPassword, string storedPassword) =>
            VerifyPassword(inputPassword, storedPassword, out _);

        public static bool IsBcryptHash(string storedPassword) =>
            storedPassword.Length >= 59 &&
            storedPassword.StartsWith("$2", StringComparison.Ordinal);
    }
}