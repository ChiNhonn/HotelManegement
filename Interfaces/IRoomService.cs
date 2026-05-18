using HotelManagement.Models;
using HotelManagement.ViewModels;
using HotelManagement.Helpers;

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
        List<RoomView> GetFiltered(string? keyword, int? idFloor, int? idRoomType);
        void SetOperationalStatus(int roomId, RoomOperationalMode mode);
        int BulkCreateRooms(int? idFloor, int idRoomType, int startInclusive, int endInclusive, string? prefix);
        Room? GetById(int Id);
        List<Floor> GetAllFloors();

        void ReleaseRoomAfterHousekeeping(int roomId);
    }
}
