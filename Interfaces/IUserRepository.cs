using HotelManagement.Models;

namespace HotelManagement.Interfaces
{
    public interface IUserRepository
    {
        Userr Login(string username, string passwordHash);

        bool CheckUsernameExists(string username);
        bool Register(Userr user, UserProfile profile);
    }
}
