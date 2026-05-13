using QuanLyKhachSan.DTOs;
using QuanLyKhachSan.Models;
using QuanLyKhachSan.Repositories;

namespace QuanLyKhachSan.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private IRoomTypeRepository loaiPhongRepo;
        public RoomTypeService(IRoomTypeRepository loaiPhongRepo)
        {
            this.loaiPhongRepo = loaiPhongRepo;
        }
        public void Add(RoomType lp)
        {
            var existing = loaiPhongRepo.GetByName(lp.TenLoaiPhong);
            if (existing != null)
                throw new Exception("Tên loại phòng đã tồn tại");
            if (lp.GiaCoBan < 0)
                throw new Exception("Giá không hợp lệ");

            if (lp.SucChuaToiDa <= 0)
                throw new Exception("Sức chứa không hợp lệ");

            loaiPhongRepo.Add(lp);
        }
        public void Delete(int maLoaiPhong)
        {
            var existing = loaiPhongRepo.GetById(maLoaiPhong);
            if (existing == null)
                throw new Exception("Loại phòng không tồn tại");

            int count = loaiPhongRepo.CheckPhong(maLoaiPhong);
            if (count > 0)
                throw new Exception($"Loại phòng '{existing.TenLoaiPhong}' đang có {count} phòng, không thể xóa");
            loaiPhongRepo.Delete(maLoaiPhong);
        }
        public void Update(RoomType lp)
        {
            var existing = loaiPhongRepo.GetById(lp.MaLoaiPhong);
            if (existing == null)
                throw new Exception("Loại phòng không tồn tại");
            if (string.IsNullOrEmpty(lp.TenLoaiPhong))
                throw new Exception("Tên loại phòng không được để trống");
            var duplicate = loaiPhongRepo.GetByName(lp.TenLoaiPhong);
            if (duplicate != null && duplicate.MaLoaiPhong != lp.MaLoaiPhong)
                throw new Exception("Tên loại phòng đã tồn tại");
            if (lp.GiaCoBan < 0)
                throw new Exception("Giá không hợp lệ");
            if (lp.SucChuaToiDa <= 0)
                throw new Exception("Sức chứa không hợp lệ");
            loaiPhongRepo.Update(lp);
        }
        public List<RoomType> GetAll()
        {
            return loaiPhongRepo.GetAll();
        }
        public List<LoaiPhongView> GetAllWithRoomCount()
        {
            return loaiPhongRepo.GetAllWithRoomCount();
        }
        public List<LoaiPhongView> Search(string keyword)
        {
            return loaiPhongRepo.Search(keyword);
        }
        public List<LoaiPhongView> GetByRoomType(int roomTypeId)
        {
            if (roomTypeId == 0)
                return loaiPhongRepo.GetAllWithRoomCount();

            return loaiPhongRepo.GetByRoomType(roomTypeId);
        }
        public List<LoaiPhongView> GetByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return loaiPhongRepo.GetByPriceRange(minPrice, maxPrice);
        }
        public RoomType GetByName(string tenLoaiPhong)
        {
            return loaiPhongRepo.GetByName(tenLoaiPhong);
        }
        public RoomType GetById(int maLoaiPhong)
        {
            return loaiPhongRepo.GetById(maLoaiPhong);
        }
    }
}
