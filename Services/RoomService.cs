using QuanLyKhachSan.Repositories;
using QuanLyKhachSan.Models;
using QuanLyKhachSan.DTOs;
namespace QuanLyKhachSan.Services
{
    public class RoomService : IRoomService
    {
        private IRoomRepository _phongRepo;
        public RoomService(IRoomRepository Repo)
        {
            _phongRepo = Repo;
        }
        public List<PhongView> GetAll()
        {
            return _phongRepo.GetAll();
        }
        public void Add(Room phong)
        {
            if (string.IsNullOrWhiteSpace(phong.SoPhong))
            {
                throw new Exception("Chưa nhập số phòng!");
            }
            var existing = _phongRepo.GetByName(phong.SoPhong);
            if (existing != null)
            {
                throw new Exception("Số phòng đã tồn tại!");
            }
            _phongRepo.Add(phong);
        }
        public void Update(Room phong)
        {
            if(phong.MaPhong <= 0)
            {
                throw new Exception("Mã phòng không hợp lệ!");
            }
            if(string.IsNullOrWhiteSpace(phong.SoPhong))
            {
                throw new Exception("Chưa nhập số phòng!");
            }
            var existingPhong = _phongRepo.GetById(phong.MaPhong);
            if(existingPhong == null)
            {
                throw new Exception("Phòng không tồn tại!");
            }
            var checkTrung = _phongRepo.GetByName(phong.SoPhong);
            if(checkTrung != null && checkTrung.MaPhong != phong.MaPhong)
            {
                throw new Exception("Số phòng đã tồn tại!");
            }
            _phongRepo.Update(phong);
        }
        public void Delete(int maPhong)
        {
            _phongRepo.Delete(maPhong);
        }
        public List<PhongView> Search(string keyword)
        {
            return _phongRepo.Search(keyword);
        }
        public List<PhongView> GetByRoomType(int roomTypeId)
        {
            if (roomTypeId == 0)
                return _phongRepo.GetAll();

            return _phongRepo.GetByRoomType(roomTypeId);
        }
        public List<PhongView> GetByStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status) || status == "--Chọn trạng thái--")
                return _phongRepo.GetAll();

            return _phongRepo.GetByStatus(status);
        }
        public Room GetById(int maPhong)
        {
            return _phongRepo.GetById(maPhong);
        }
    }
}
