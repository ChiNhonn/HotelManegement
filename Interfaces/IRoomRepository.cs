using QuanLyKhachSan.Models;
using QuanLyKhachSan.DTOs;

namespace QuanLyKhachSan.Repositories
{
    public interface IRoomRepository
    {
        List<PhongView> GetAll();
        void Add(Room room);
        void Update(Room room);
        void Delete(int Id);
        List<PhongView> Search(string keyword);
        List<PhongView> GetByRoomType(int roomTypeId);
        List<PhongView> GetByStatus(string status);
        Room GetById(int Id);
        Room GetByName(string Name);
    }
}
