using HotelManagement.Models;
using HotelManagement.ViewModels;
namespace HotelManagement.Repositories
{
    public interface IRoomRepository
    {
        List<RoomView> GetAll();
        void Add(Room room);
        void Update(Room room);
        void Delete(int Id);
        List<RoomView> Search(string keyword);
        List<RoomView> GetByRoomType(int roomTypeId);
        List<RoomView> GetByStatus(string status);
        List<RoomView> GetFiltered(string? keyword, int? idFloor, int? idRoomType);
        Room? GetById(int Id);
        Room? GetByName(string Name);
        List<Floor> GetAllFloors();

        /// <summary>Thêm nhiều phòng trong một lần lưu.</summary>
        int BulkInsertRooms(IReadOnlyList<Room> rooms);

        /// <summary>Chuyển phòng đang dọn về trống; xóa hạn dọn.</summary>
        void ReleaseRoomAfterHousekeeping(int roomId);
    }
}
