using HotelManagement.Models;
using HotelManagement.ViewModels;
namespace HotelManagement.Services
{
    public interface IRoomTypeService
    {
        void Add(RoomType rt);
        void Delete(int Id);
        void Update(RoomType rt);
        List<RoomType> GetAll();
        List<RoomTypeView> GetAllWithRoomCount();
        List<RoomTypeView> Search(string keyword);
        List<RoomTypeView> GetByRoomType(int roomTypeId);
        List<RoomTypeView> GetByPriceRange(decimal minPrice, decimal maxPrice);
        RoomType GetById(int Id);
        RoomType GetByName(string Name);
    }
}
