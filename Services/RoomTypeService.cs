using HotelManagement.Models;
using HotelManagement.Repositories;
using HotelManagement.ViewModels;
namespace HotelManagement.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private IRoomTypeRepository _roomTypeRepo;
        public RoomTypeService(IRoomTypeRepository roomTypeRepo)
        {
            _roomTypeRepo = roomTypeRepo;
        }
        public void Add(RoomType lp)
        {
            var existing = _roomTypeRepo.GetByName(lp.TenLoaiPhong);
            if (existing != null)
                throw new Exception("Tên loại phòng đã tồn tại");
            if (lp.GiaCoBan < 0)
                throw new Exception("Giá không hợp lệ");

            if (lp.SucChuaToiDa <= 0)
                throw new Exception("Sức chứa không hợp lệ");

            _roomTypeRepo.Add(lp);
        }
        public void Delete(int maLoaiPhong)
        {
            var existing = _roomTypeRepo.GetById(maLoaiPhong);
            if (existing == null)
                throw new Exception("Loại phòng không tồn tại");

            int count = _roomTypeRepo.CheckPhong(maLoaiPhong);
            if (count > 0)
                throw new Exception($"Loại phòng '{existing.TenLoaiPhong}' đang có {count} phòng, không thể xóa");
            _roomTypeRepo.Delete(maLoaiPhong);
        }
        public void Update(RoomType lp)
        {
            var existing = _roomTypeRepo.GetById(lp.MaLoaiPhong);
            if (existing == null)
                throw new Exception("Loại phòng không tồn tại");
            if (string.IsNullOrEmpty(lp.TenLoaiPhong))
                throw new Exception("Tên loại phòng không được để trống");
            var duplicate = _roomTypeRepo.GetByName(lp.TenLoaiPhong);
            if (duplicate != null && duplicate.MaLoaiPhong != lp.MaLoaiPhong)
                throw new Exception("Tên loại phòng đã tồn tại");
            if (lp.GiaCoBan < 0)
                throw new Exception("Giá không hợp lệ");
            if (lp.SucChuaToiDa <= 0)
                throw new Exception("Sức chứa không hợp lệ");
            _roomTypeRepo.Update(lp);
        }
        public List<RoomType> GetAll()
        {
            return _roomTypeRepo.GetAll();
        }
        public List<RoomTypeView> GetAllWithRoomCount()
        {
            return _roomTypeRepo.GetAllWithRoomCount();
        }
        public List<RoomTypeView> Search(string keyword)
        {
            return _roomTypeRepo.Search(keyword);
        }
        public List<RoomTypeView> GetByRoomType(int roomTypeId)
        {
            if (roomTypeId == 0)
                return _roomTypeRepo.GetAllWithRoomCount();

            return _roomTypeRepo.GetByRoomType(roomTypeId);
        }
        public List<RoomTypeView> GetByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _roomTypeRepo.GetByPriceRange(minPrice, maxPrice);
        }
        public RoomType GetByName(string tenLoaiPhong)
        {
            return _roomTypeRepo.GetByName(tenLoaiPhong);
        }
        public RoomType GetById(int maLoaiPhong)
        {
            return _roomTypeRepo.GetById(maLoaiPhong);
        }
    }
}
