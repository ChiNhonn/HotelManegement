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

        public void Add(Room room)
        {
            if (string.IsNullOrWhiteSpace(room.Name))
                throw new Exception("Chưa nhập số phòng!");

            room.Status = RoomStatusMap.ToDatabase(room.Status);

            var existing = _roomRepo.GetByName(room.Name);
            if (existing != null)
                throw new Exception("Số phòng đã tồn tại!");

            _roomRepo.Add(room);
        }

        public void Update(Room room)
        {
            if (room.Id <= 0)
                throw new Exception("Mã phòng không hợp lệ!");
            if (string.IsNullOrWhiteSpace(room.Name))
                throw new Exception("Chưa nhập số phòng!");

            room.Status = RoomStatusMap.ToDatabase(room.Status);

            var existingRoom = _roomRepo.GetById(room.Id);
            if (existingRoom == null)
                throw new Exception("Phòng không tồn tại!");

            var checkDuplicate = _roomRepo.GetByName(room.Name);
            if (checkDuplicate != null && checkDuplicate.Id != room.Id)
                throw new Exception("Số phòng đã tồn tại!");

            _roomRepo.Update(room);
        }

        public void Delete(int roomId) => _roomRepo.Delete(roomId);

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

        public Room? GetById(int roomId) => _roomRepo.GetById(roomId);

        public List<RoomView> GetFiltered(string? keyword, int? idFloor, int? idRoomType) =>
            _roomRepo.GetFiltered(keyword, idFloor, idRoomType);

        public void SetOperationalStatus(int roomId, RoomOperationalMode mode)
        {
            var r = _roomRepo.GetById(roomId)
                    ?? throw new InvalidOperationException("Không tìm thấy phòng.");

            var kind = RoomStatusMap.ClassifyPhysicalKind(r.Status);
            if (kind == RoomPhysicalStatusKind.Occupied && mode != RoomOperationalMode.Active)
                throw new InvalidOperationException("Phòng đang có khách, không thể ngưng dùng hoặc khóa.");

            switch (mode)
            {
                case RoomOperationalMode.Inactive:
                    r.Status = "inactive";
                    break;
                case RoomOperationalMode.OutOfOrder:
                    r.Status = "out_of_order";
                    break;
                case RoomOperationalMode.Active:
                    if (kind == RoomPhysicalStatusKind.Occupied)
                        return;
                    var s = r.Status?.Trim().ToLowerInvariant() ?? "";
                    if (s is "inactive" or "out_of_order")
                        r.Status = "available";
                    break;
            }

            _roomRepo.Update(r);
        }

        public int BulkCreateRooms(int? idFloor, int idRoomType, int startInclusive, int endInclusive, string? prefix)
        {
            if (idRoomType <= 0)
                throw new InvalidOperationException("Chọn loại phòng hợp lệ.");
            if (endInclusive < startInclusive)
                throw new InvalidOperationException("Số phòng kết thúc phải ≥ số bắt đầu.");
            if (endInclusive - startInclusive > 500)
                throw new InvalidOperationException("Mỗi lần tối đa 501 phòng.");

            prefix ??= "";

            var existing = _roomRepo.GetAll()
                .Select(x => x.RoomNumber.Trim())
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var toAdd = new List<Room>();
            for (var n = startInclusive; n <= endInclusive; n++)
            {
                var name = string.IsNullOrEmpty(prefix) ? n.ToString() : $"{prefix}{n}";
                if (existing.Contains(name))
                    continue;

                toAdd.Add(new Room
                {
                    Name = name,
                    IdRoomType = idRoomType,
                    IdFloor = idFloor,
                    Status = "available"
                });
                existing.Add(name);
            }

            return _roomRepo.BulkInsertRooms(toAdd);
        }

        public void ReleaseRoomAfterHousekeeping(int roomId) =>
            _roomRepo.ReleaseRoomAfterHousekeeping(roomId);
    }
}
