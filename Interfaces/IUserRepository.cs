using HotelManagement.Models;

namespace HotelManagement.Interfaces
{
    public interface IUserRepository
    {
        Userr? Login(string username, string password);

        bool CheckUsernameExists(string username);
        bool Register(Userr user, UserProfile profile);
        void UpdatePassword(string email, string newPassword);
        bool CheckEmailExists(string email);
    }
}
