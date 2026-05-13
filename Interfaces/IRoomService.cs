using HotelManagement.Models;
using HotelManagement.ViewModels;
namespace HotelManagement.Services
{
    public interface IRoomService
    {
        List<RoomView> GetAll();
        void Add(Room room);
        void Update(Room room);
        void Delete(int Id);
        List<RoomView> Search(string keyword);
        List<RoomView> GetByRoomType(int roomTypeId);
        List<RoomView> GetByStatus(string status);
        Room GetById(int Id);
    }
}
