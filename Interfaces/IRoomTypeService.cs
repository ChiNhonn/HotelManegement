using QuanLyKhachSan.Models;
using QuanLyKhachSan.DTOs;

namespace QuanLyKhachSan.Services
{
    public interface IRoomTypeService
    {
        void Add(RoomType rt);
        void Delete(int Id);
        void Update(RoomType rt);
        List<RoomType> GetAll();
        List<LoaiPhongView> GetAllWithRoomCount();
        List<LoaiPhongView> Search(string keyword);
        List<LoaiPhongView> GetByRoomType(int roomTypeId);
        List<LoaiPhongView> GetByPriceRange(decimal minPrice, decimal maxPrice);
        RoomType GetById(int Id);
        RoomType GetByName(string Name);
    }
}
