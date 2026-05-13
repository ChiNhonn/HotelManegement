using HotelManagement.Data;
using HotelManagement.Helpers;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext _context;

        public RoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        private IQueryable<Room> ActiveRooms => _context.Rooms.Where(p => p.SoftDelete == null);

        public List<Floor> GetAllFloors()
        {
            return _context.Floors.AsNoTracking().OrderBy(f => f.Name).ToList();
        }

        public List<RoomView> GetAll()
        {
            return ActiveRooms
                .AsNoTracking()
                .Include(p => p.RoomType)
                .Include(p => p.Floor)
                .Select(p => new RoomView
                {
                    MaPhong = p.Id,
                    SoPhong = p.Name,
                    LoaiPhong = p.RoomType != null ? p.RoomType.Name : "",
                    Tang = p.Floor != null ? p.Floor.Name : "",
                    TrangThai = RoomStatusMap.ToDisplay(p.Status),
                })
                .ToList();
        }

        public void Add(Room phong)
        {
            _context.Rooms.Add(phong);
            _context.SaveChanges();
        }

        public void Update(Room phong)
        {
            var data = _context.Rooms.FirstOrDefault(x => x.Id == phong.Id);
            if (data == null)
                return;

            data.Name = phong.Name;
            data.IdRoomType = phong.IdRoomType;
            data.IdFloor = phong.IdFloor;
            data.Status = phong.Status;
            data.UpdateAt = DateTime.Now;
            _context.SaveChanges();
        }

        public void Delete(int maPhong)
        {
            var phong = _context.Rooms.Find(maPhong);
            if (phong == null)
                throw new Exception("Không tìm thấy phòng");

            _context.Rooms.Remove(phong);
            _context.SaveChanges();
        }

        public List<RoomView> Search(string keyword)
        {
            var k = keyword.Trim();
            return ActiveRooms
                .AsNoTracking()
                .Include(p => p.RoomType)
                .Include(p => p.Floor)
                .Where(x => x.Name.Contains(k))
                .Select(p => new RoomView
                {
                    MaPhong = p.Id,
                    SoPhong = p.Name,
                    LoaiPhong = p.RoomType != null ? p.RoomType.Name : "",
                    Tang = p.Floor != null ? p.Floor.Name : "",
                    TrangThai = RoomStatusMap.ToDisplay(p.Status),
                })
                .ToList();
        }

        public List<RoomView> GetByRoomType(int roomTypeId)
        {
            return ActiveRooms
                .AsNoTracking()
                .Include(p => p.RoomType)
                .Include(p => p.Floor)
                .Where(p => p.IdRoomType == roomTypeId)
                .Select(p => new RoomView
                {
                    MaPhong = p.Id,
                    SoPhong = p.Name,
                    LoaiPhong = p.RoomType != null ? p.RoomType.Name : "",
                    Tang = p.Floor != null ? p.Floor.Name : "",
                    TrangThai = RoomStatusMap.ToDisplay(p.Status),
                })
                .ToList();
        }

        public List<RoomView> GetByStatus(string status)
        {
            return ActiveRooms
                .AsNoTracking()
                .Include(p => p.RoomType)
                .Include(p => p.Floor)
                .Where(p => RoomStatusMap.MatchesFilter(p.Status, status))
                .Select(p => new RoomView
                {
                    MaPhong = p.Id,
                    SoPhong = p.Name,
                    LoaiPhong = p.RoomType != null ? p.RoomType.Name : "",
                    Tang = p.Floor != null ? p.Floor.Name : "",
                    TrangThai = RoomStatusMap.ToDisplay(p.Status),
                })
                .ToList();
        }

        public Room? GetById(int maPhong)
        {
            return _context.Rooms
                .Include(r => r.RoomType)
                .Include(r => r.Floor)
                .FirstOrDefault(x => x.Id == maPhong);
        }

        public Room? GetByName(string soPhong)
        {
            return _context.Rooms.FirstOrDefault(x => x.Name == soPhong && x.SoftDelete == null);
        }
    }
}
