using QuanLyKhachSan.Models;
using QuanLyKhachSan.Data;
using QuanLyKhachSan.DTOs;

namespace QuanLyKhachSan.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private QuanLyKhachSanContext _context;
        public RoomTypeRepository(QuanLyKhachSanContext context)
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
        public List<LoaiPhongView> GetAllWithRoomCount()
        {
            return _context.LoaiPhongs.Select(lp => new LoaiPhongView
            {
                MaLoaiPhong = lp.MaLoaiPhong,
                TenLoaiPhong = lp.TenLoaiPhong,
                SucChuaToiDa = lp.SucChuaToiDa,
                Gia = lp.GiaCoBan,
                SoLuongPhong = _context.Phongs.Count(p => p.MaLoaiPhong == lp.MaLoaiPhong),
                MoTa = lp.MoTa
            }).ToList();
        }
        public List<LoaiPhongView> Search(string keyword)
        {
            return _context.LoaiPhongs.Where(lp => lp.TenLoaiPhong.Contains(keyword) || lp.MoTa.Contains(keyword)).Select(lp => new LoaiPhongView
            {
                MaLoaiPhong = lp.MaLoaiPhong,
                TenLoaiPhong = lp.TenLoaiPhong,
                SucChuaToiDa = lp.SucChuaToiDa,
                Gia = lp.GiaCoBan,
                SoLuongPhong = _context.Phongs.Count(p => p.MaLoaiPhong == lp.MaLoaiPhong),
                MoTa = lp.MoTa
            }).ToList();
        }
        public List<LoaiPhongView> GetByRoomType(int roomTypeId)
        {
            return _context.LoaiPhongs.Where(lp => lp.MaLoaiPhong == roomTypeId).Select(lp => new LoaiPhongView
            {
                MaLoaiPhong = lp.MaLoaiPhong,
                TenLoaiPhong = lp.TenLoaiPhong,
                SucChuaToiDa = lp.SucChuaToiDa,
                Gia = lp.GiaCoBan,
                SoLuongPhong = _context.Phongs.Count(p => p.MaLoaiPhong == lp.MaLoaiPhong),
                MoTa = lp.MoTa
            }).ToList();
        }
        public List<LoaiPhongView> GetByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _context.LoaiPhongs.Where(lp => lp.GiaCoBan >= minPrice && lp.GiaCoBan <= maxPrice).Select(lp => new LoaiPhongView
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
