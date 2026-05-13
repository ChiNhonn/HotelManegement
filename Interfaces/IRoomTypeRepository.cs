using HotelManagement.Models;
using HotelManagement.ViewModels;
namespace HotelManagement.Repositories
{
    public interface IRoomTypeRepository
    {
        void Add(RoomType rt);
        void Delete(int Id);
        void Update(RoomType rt);
        int CheckPhong(int Id);
        List<RoomType> GetAll();
        List<RoomTypeView> GetAllWithRoomCount();
        List<RoomTypeView> Search(string keyword);
        List<RoomTypeView> GetByRoomType(int roomTypeId);
        List<RoomTypeView> GetByPriceRange(decimal minPrice, decimal maxPrice);
        RoomType? GetByName(string Name);
        RoomType? GetById(int Id);
    }
}
