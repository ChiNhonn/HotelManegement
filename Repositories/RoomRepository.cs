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
                    RoomId = p.Id,
                    RoomNumber = p.Name,
                    RoomTypeName = p.RoomType != null ? p.RoomType.Name : "",
                    FloorName = p.Floor != null ? p.Floor.Name : "",
                    StatusDisplay = RoomStatusMap.ToDisplay(p.Status),
                    StatusDb = p.Status,
                    IdFloor = p.IdFloor,
                    IdRoomType = p.IdRoomType,
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

        public void Delete(int roomId)
        {
            var phong = _context.Rooms.FirstOrDefault(x => x.Id == roomId && x.SoftDelete == null);
            if (phong == null)
                throw new Exception("Không tìm thấy phòng");

            phong.SoftDelete = DateTime.Now;
            phong.UpdateAt = DateTime.Now;
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
                    RoomId = p.Id,
                    RoomNumber = p.Name,
                    RoomTypeName = p.RoomType != null ? p.RoomType.Name : "",
                    FloorName = p.Floor != null ? p.Floor.Name : "",
                    StatusDisplay = RoomStatusMap.ToDisplay(p.Status),
                    StatusDb = p.Status,
                    IdFloor = p.IdFloor,
                    IdRoomType = p.IdRoomType,
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
                    RoomId = p.Id,
                    RoomNumber = p.Name,
                    RoomTypeName = p.RoomType != null ? p.RoomType.Name : "",
                    FloorName = p.Floor != null ? p.Floor.Name : "",
                    StatusDisplay = RoomStatusMap.ToDisplay(p.Status),
                    StatusDb = p.Status,
                    IdFloor = p.IdFloor,
                    IdRoomType = p.IdRoomType,
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
                    RoomId = p.Id,
                    RoomNumber = p.Name,
                    RoomTypeName = p.RoomType != null ? p.RoomType.Name : "",
                    FloorName = p.Floor != null ? p.Floor.Name : "",
                    StatusDisplay = RoomStatusMap.ToDisplay(p.Status),
                    StatusDb = p.Status,
                    IdFloor = p.IdFloor,
                    IdRoomType = p.IdRoomType,
                })
                .ToList();
        }

        public List<RoomView> GetFiltered(string? keyword, int? idFloor, int? idRoomType)
        {
            IQueryable<Room> q = ActiveRooms.AsNoTracking()
                .Include(p => p.RoomType)
                .Include(p => p.Floor);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var k = keyword.Trim();
                q = q.Where(p => p.Name.Contains(k));
            }

            if (idFloor is > 0)
                q = q.Where(p => p.IdFloor == idFloor);
            if (idRoomType is > 0)
                q = q.Where(p => p.IdRoomType == idRoomType);

            return q
                .OrderBy(p => p.Name)
                .Select(p => new RoomView
                {
                    RoomId = p.Id,
                    RoomNumber = p.Name,
                    RoomTypeName = p.RoomType != null ? p.RoomType.Name : "",
                    FloorName = p.Floor != null ? p.Floor.Name : "",
                    StatusDisplay = RoomStatusMap.ToDisplay(p.Status),
                    StatusDb = p.Status,
                    IdFloor = p.IdFloor,
                    IdRoomType = p.IdRoomType,
                })
                .ToList();
        }

        public int BulkInsertRooms(IReadOnlyList<Room> rooms)
        {
            if (rooms.Count == 0)
                return 0;

            foreach (var r in rooms)
            {
                r.Status = RoomStatusMap.ToDatabase(r.Status);
                _context.Rooms.Add(r);
            }

            _context.SaveChanges();
            return rooms.Count;
        }

        public Room? GetById(int roomId)
        {
            return _context.Rooms
                .Include(r => r.RoomType)
                .Include(r => r.Floor)
                .FirstOrDefault(x => x.Id == roomId && x.SoftDelete == null);
        }

        public Room? GetByName(string roomNumber)
        {
            return _context.Rooms.FirstOrDefault(x => x.Name == roomNumber && x.SoftDelete == null);
        }

        public void ReleaseRoomAfterHousekeeping(int roomId)
        {
            var r = _context.Rooms.FirstOrDefault(x => x.Id == roomId && x.SoftDelete == null);
            if (r == null)
                throw new InvalidOperationException("Không tìm thấy phòng.");
            if (RoomStatusMap.ClassifyPhysicalKind(r.Status) != RoomPhysicalStatusKind.Cleaning)
                throw new InvalidOperationException("Phòng không ở trạng thái dọn phòng.");

            r.Status = "available";
            r.UpdateAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
