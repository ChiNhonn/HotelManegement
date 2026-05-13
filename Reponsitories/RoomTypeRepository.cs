using HotelManagement.Data;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly HotelDbContext _context;

        public RoomTypeRepository(HotelDbContext context)
        {
            _context = context;
        }

        public void Add(RoomType lp)
        {
            _context.Add(lp);
            _context.SaveChanges();
        }

        public void Delete(int maLoaiPhong)
        {
            var lp = _context.RoomTypes.Find(maLoaiPhong);
            if (lp == null)
                throw new Exception("Không tìm thấy loại phòng");

            _context.RoomTypes.Remove(lp);
            _context.SaveChanges();
        }

        public int CheckPhong(int maLoaiPhong)
        {
            return _context.Rooms.Count(p => p.IdRoomType == maLoaiPhong && p.SoftDelete == null);
        }

        public void Update(RoomType lp)
        {
            var existing = _context.RoomTypes.Find(lp.MaLoaiPhong);
            if (existing == null)
                throw new Exception("Không tìm thấy loại phòng");
            existing.TenLoaiPhong = lp.TenLoaiPhong;
            existing.SucChuaToiDa = lp.SucChuaToiDa;
            existing.GiaCoBan = lp.GiaCoBan;
            existing.MoTa = lp.MoTa;
            _context.SaveChanges();
        }

        public List<RoomType> GetAll()
        {
            return _context.RoomTypes.ToList();
        }

        public List<RoomTypeView> GetAllWithRoomCount()
        {
            return _context.RoomTypes
                .Select(lp => new RoomTypeView
                {
                    MaLoaiPhong = lp.Id,
                    TenLoaiPhong = lp.Name,
                    SucChuaToiDa = (byte)lp.MaxNumber,
                    Gia = lp.UnitPrice,
                    SoLuongPhong = _context.Rooms.Count(p => p.IdRoomType == lp.Id && p.SoftDelete == null),
                    MoTa = lp.DescriptionRoom != null ? lp.DescriptionRoom.Content ?? "" : ""
                }).ToList();
        }

        public List<RoomTypeView> Search(string keyword)
        {
            return _context.RoomTypes
                .Where(lp =>
                    lp.Name.Contains(keyword)
                    || (lp.DescriptionRoom != null
                        && lp.DescriptionRoom.Content != null
                        && lp.DescriptionRoom.Content.Contains(keyword)))
                .Select(lp => new RoomTypeView
                {
                    MaLoaiPhong = lp.Id,
                    TenLoaiPhong = lp.Name,
                    SucChuaToiDa = (byte)lp.MaxNumber,
                    Gia = lp.UnitPrice,
                    SoLuongPhong = _context.Rooms.Count(p => p.IdRoomType == lp.Id && p.SoftDelete == null),
                    MoTa = lp.DescriptionRoom != null ? lp.DescriptionRoom.Content ?? "" : ""
                }).ToList();
        }

        public List<RoomTypeView> GetByRoomType(int roomTypeId)
        {
            return _context.RoomTypes
                .Where(lp => lp.Id == roomTypeId)
                .Select(lp => new RoomTypeView
                {
                    MaLoaiPhong = lp.Id,
                    TenLoaiPhong = lp.Name,
                    SucChuaToiDa = (byte)lp.MaxNumber,
                    Gia = lp.UnitPrice,
                    SoLuongPhong = _context.Rooms.Count(p => p.IdRoomType == lp.Id && p.SoftDelete == null),
                    MoTa = lp.DescriptionRoom != null ? lp.DescriptionRoom.Content ?? "" : ""
                }).ToList();
        }

        public List<RoomTypeView> GetByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _context.RoomTypes
                .Where(lp => lp.UnitPrice >= minPrice && lp.UnitPrice <= maxPrice)
                .Select(lp => new RoomTypeView
                {
                    MaLoaiPhong = lp.Id,
                    TenLoaiPhong = lp.Name,
                    SucChuaToiDa = (byte)lp.MaxNumber,
                    Gia = lp.UnitPrice,
                    SoLuongPhong = _context.Rooms.Count(p => p.IdRoomType == lp.Id && p.SoftDelete == null),
                    MoTa = lp.DescriptionRoom != null ? lp.DescriptionRoom.Content ?? "" : ""
                }).ToList();
        }

        public RoomType? GetByName(string tenLoaiPhong)
        {
            return _context.RoomTypes.FirstOrDefault(lp => lp.Name == tenLoaiPhong);
        }

        public RoomType? GetById(int maLoaiPhong)
        {
            return _context.RoomTypes.Find(maLoaiPhong);
        }
    }
}
