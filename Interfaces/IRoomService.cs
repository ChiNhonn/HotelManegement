using QuanLyKhachSan.Models;
using QuanLyKhachSan.DTOs;
namespace QuanLyKhachSan.Services
{
    public interface IRoomService
    {
        List<PhongView> GetAll();
        void Add(Room room);
        void Update(Room room);
        void Delete(int Id);
        List<PhongView> Search(string keyword);
        List<PhongView> GetByRoomType(int roomTypeId);
        List<PhongView> GetByStatus(string status);
        Room GetById(int Id);
    }
}
