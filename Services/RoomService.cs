using HotelManagement.Helpers;
using HotelManagement.Models;
using HotelManagement.Repositories;
using HotelManagement.ViewModels;

namespace HotelManagement.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepo;

        public RoomService(IRoomRepository roomRepo)
        {
            _roomRepo = roomRepo;
        }

        public List<RoomView> GetAll() => _roomRepo.GetAll();

        public List<Floor> GetAllFloors() => _roomRepo.GetAllFloors();

        public void Add(Room phong)
        {
            if (string.IsNullOrWhiteSpace(phong.SoPhong))
                throw new Exception("Chưa nhập số phòng!");

            phong.Status = RoomStatusMap.ToDatabase(phong.Status);

            var existing = _roomRepo.GetByName(phong.SoPhong);
            if (existing != null)
                throw new Exception("Số phòng đã tồn tại!");

            _roomRepo.Add(phong);
        }

        public void Update(Room phong)
        {
            if (phong.MaPhong <= 0)
                throw new Exception("Mã phòng không hợp lệ!");
            if (string.IsNullOrWhiteSpace(phong.SoPhong))
                throw new Exception("Chưa nhập số phòng!");

            phong.Status = RoomStatusMap.ToDatabase(phong.Status);

            var existingPhong = _roomRepo.GetById(phong.MaPhong);
            if (existingPhong == null)
                throw new Exception("Phòng không tồn tại!");

            var checkTrung = _roomRepo.GetByName(phong.SoPhong);
            if (checkTrung != null && checkTrung.MaPhong != phong.MaPhong)
                throw new Exception("Số phòng đã tồn tại!");

            _roomRepo.Update(phong);
        }

        public void Delete(int maPhong) => _roomRepo.Delete(maPhong);

        public List<RoomView> Search(string keyword) => _roomRepo.Search(keyword);

        public List<RoomView> GetByRoomType(int roomTypeId)
        {
            if (roomTypeId == 0)
                return _roomRepo.GetAll();

            return _roomRepo.GetByRoomType(roomTypeId);
        }

        public List<RoomView> GetByStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status) || status == "--Chọn trạng thái--")
                return _roomRepo.GetAll();

            return _roomRepo.GetByStatus(status);
        }

        public Room? GetById(int maPhong) => _roomRepo.GetById(maPhong);
    }
}
