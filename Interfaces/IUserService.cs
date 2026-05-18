using HotelManagement.Models;
using HotelManagement.ViewModels;

namespace HotelManagement.Interfaces
{
    public interface IUserService
    {
        Userr? Login(string username, string password);

        (bool IsSuccess, string Message)RegisterUser(RegisterView dto);
        void UpdatePassword(string email, string newPassword);
        bool CheckEmailExists(string email);
    }
}