using System;
using BCrypt.Net;

namespace HotelManagement.Helpers
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return string.Empty;

            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string inputPassword, string hashedPasswordFromDB)
        {
            if (string.IsNullOrWhiteSpace(inputPassword) || string.IsNullOrWhiteSpace(hashedPasswordFromDB))
                return false;

            return BCrypt.Net.BCrypt.Verify(inputPassword, hashedPasswordFromDB);
        }
    }
}