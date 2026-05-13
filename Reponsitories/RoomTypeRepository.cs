using HotelManagement.Models;
using HotelManagement.ViewModels;
using HotelManagement.Data;
namespace HotelManagement.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private HotelDbContext _context;
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
            var lp = _context.LoaiPhongs.Find(maLoaiPhong);
            if(lp == null)
                throw new Exception("Không tìm thấy loại phòng");

            _context.LoaiPhongs.Remove(lp);
            _context.SaveChanges();
        }
        public int CheckPhong(int maLoaiPhong)
        {
            return _context.Phongs.Count(p => p.MaLoaiPhong == maLoaiPhong);
        }
        public void Update(RoomType lp)
        {
            var existing = _context.LoaiPhongs.Find(lp.MaLoaiPhong);
            if(existing == null)
                throw new Exception("Không tìm thấy loại phòng");
            existing.TenLoaiPhong = lp.TenLoaiPhong;
            existing.SucChuaToiDa = lp.SucChuaToiDa;
            existing.GiaCoBan = lp.GiaCoBan;
            existing.MoTa = lp.MoTa;
            _context.SaveChanges();
        }
        public List<RoomType> GetAll()
        {
            return _context.LoaiPhongs.ToList();
        }
        public List<RoomTypeView> GetAllWithRoomCount()
        {
            return _context.LoaiPhongs.Select(lp => new RoomTypeView
            {
                MaLoaiPhong = lp.MaLoaiPhong,
                TenLoaiPhong = lp.TenLoaiPhong,
                SucChuaToiDa = lp.SucChuaToiDa,
                Gia = lp.GiaCoBan,
                SoLuongPhong = _context.Phongs.Count(p => p.MaLoaiPhong == lp.MaLoaiPhong),
                MoTa = lp.MoTa
            }).ToList();
        }
        public List<RoomTypeView> Search(string keyword)
        {
            return _context.LoaiPhongs.Where(lp => lp.TenLoaiPhong.Contains(keyword) || lp.MoTa.Contains(keyword)).Select(lp => new RoomTypeView
            {
                MaLoaiPhong = lp.MaLoaiPhong,
                TenLoaiPhong = lp.TenLoaiPhong,
                SucChuaToiDa = lp.SucChuaToiDa,
                Gia = lp.GiaCoBan,
                SoLuongPhong = _context.Phongs.Count(p => p.MaLoaiPhong == lp.MaLoaiPhong),
                MoTa = lp.MoTa
            }).ToList();
        }
        public List<RoomTypeView> GetByRoomType(int roomTypeId)
        {
            return _context.LoaiPhongs.Where(lp => lp.MaLoaiPhong == roomTypeId).Select(lp => new RoomTypeView
            {
                MaLoaiPhong = lp.MaLoaiPhong,
                TenLoaiPhong = lp.TenLoaiPhong,
                SucChuaToiDa = lp.SucChuaToiDa,
                Gia = lp.GiaCoBan,
                SoLuongPhong = _context.Phongs.Count(p => p.MaLoaiPhong == lp.MaLoaiPhong),
                MoTa = lp.MoTa
            }).ToList();
        }
        public List<RoomTypeView> GetByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _context.LoaiPhongs.Where(lp => lp.GiaCoBan >= minPrice && lp.GiaCoBan <= maxPrice).Select(lp => new RoomTypeView
            {
                MaLoaiPhong = lp.MaLoaiPhong,
                TenLoaiPhong = lp.TenLoaiPhong,
                SucChuaToiDa = lp.SucChuaToiDa,
                Gia = lp.GiaCoBan,
                SoLuongPhong = _context.Phongs.Count(p => p.MaLoaiPhong == lp.MaLoaiPhong),
                MoTa = lp.MoTa
            }).ToList();
        }
        public RoomType GetByName(string tenLoaiPhong)
        {
            return _context.LoaiPhongs.FirstOrDefault(lp => lp.TenLoaiPhong == tenLoaiPhong);
        }
        public RoomType GetById(int maLoaiPhong)
        {
            return _context.LoaiPhongs.Find(maLoaiPhong);
        }
    }
}
