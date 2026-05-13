using QuanLyKhachSan.DTOs;
using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.Repositories
{
    public interface IRoomTypeRepository
    {
        void Add(RoomType rt);
        void Delete(int Id);
        void Update(RoomType rt);
        int CheckPhong(int Id);
        List<RoomType> GetAll();
        List<LoaiPhongView> GetAllWithRoomCount();
        List<LoaiPhongView> Search(string keyword);
        List<LoaiPhongView> GetByRoomType(int roomTypeId);
        List<LoaiPhongView> GetByPriceRange(decimal minPrice, decimal maxPrice);
        RoomType GetByName(string Name);
        RoomType GetById(int Id);
    }
}
