using HotelManagement.Models;
using HotelManagement.ViewModels;
using HotelManagement.Data;
namespace HotelManagement.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private HotelDbContext _context;
        public RoomRepository(HotelDbContext context)
        {
            _context = context;
        }
        public List<RoomView> GetAll()
        {
            return _context.Phongs.Select(p => new RoomView
            {
                MaPhong = p.MaPhong,
                SoPhong = p.SoPhong,
                LoaiPhong = p.MaLoaiPhongNavigation.TenLoaiPhong,
                Tang = p.Tang,
                TrangThai = p.TrangThai,
                GhiChu = p.GhiChu
            }).ToList();
        }
        public void Add(Room phong)
        {
            _context.Phongs.Add(phong);
            _context.SaveChanges();
        }
        public void Update(Room phong)
        {
            var data = _context.Phongs.FirstOrDefault(x => x.MaPhong == phong.MaPhong);
            if (data != null)
            {
                data.SoPhong = phong.SoPhong;
                data.MaLoaiPhong = phong.MaLoaiPhong;
                data.Tang = phong.Tang;
                data.TrangThai = phong.TrangThai;
                data.GhiChu = phong.GhiChu;
                _context.SaveChanges();
            }
        }
        public void Delete(int maPhong)
        {
            var phong = _context.Phongs.Find(maPhong);
            if(phong == null)
                throw new Exception("Không tìm thấy phòng");

            _context.Phongs.Remove(phong);
            _context.SaveChanges();
        }
        public List<RoomView> Search(string keyword)
        {
            return _context.Phongs.Where(x => x.SoPhong.Contains(keyword) || x.GhiChu.Contains(keyword)).Select(p => new RoomView
            {
                MaPhong = p.MaPhong,
                SoPhong = p.SoPhong,
                LoaiPhong = p.MaLoaiPhongNavigation.TenLoaiPhong,
                Tang = p.Tang,
                TrangThai = p.TrangThai,
                GhiChu = p.GhiChu
            }).ToList();
        }
        public List<RoomView> GetByRoomType(int roomTypeId)
        {
            return _context.Phongs.Where(p => p.MaLoaiPhong == roomTypeId).Select(p => new RoomView
            {
                MaPhong = p.MaPhong,
                SoPhong = p.SoPhong,
                LoaiPhong = p.MaLoaiPhongNavigation.TenLoaiPhong,
                Tang = p.Tang,
                TrangThai = p.TrangThai,
                GhiChu = p.GhiChu
            }).ToList();
        }
        public List<RoomView> GetByStatus(string status)
        {
            return _context.Phongs.Where(p => p.TrangThai == status).Select(p => new RoomView
            {
                MaPhong = p.MaPhong,
                SoPhong = p.SoPhong,
                LoaiPhong = p.MaLoaiPhongNavigation.TenLoaiPhong,
                Tang = p.Tang,
                TrangThai = p.TrangThai,
                GhiChu = p.GhiChu
            }).ToList();
        }
        public Room GetById(int maPhong)
        {
            return _context.Phongs.FirstOrDefault(x => x.MaPhong == maPhong);
        }
        public Room GetByName(string soPhong)
        {
            return _context.Phongs.FirstOrDefault(x => x.SoPhong == soPhong);
        }
    }
}
