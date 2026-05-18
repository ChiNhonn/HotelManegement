using HotelManagement.Helpers;

using HotelManagement.Models;

using HotelManagement.Repositories;

using HotelManagement.ViewModels;



namespace HotelManagement.Services

{

    public class RoomTypeService : IRoomTypeService

    {

        private readonly IRoomTypeRepository _roomTypeRepo;



        public RoomTypeService(IRoomTypeRepository roomTypeRepo)

        {

            _roomTypeRepo = roomTypeRepo;

        }



        private static void NormalizeAndSync(RoomType roomType)

        {

            roomType.Code = string.IsNullOrWhiteSpace(roomType.Code) ? null : roomType.Code.Trim().ToUpperInvariant();

            if (roomType.MaxAdults < 1)

                throw new Exception("Cần ít nhất 1 người lớn.");

            if (roomType.MaxChildren < 0)

                throw new Exception("Số trẻ em không hợp lệ.");

            if (roomType.MaxAdults + roomType.MaxChildren > 50)

                throw new Exception("Tổng sức chứa vượt quá giới hạn (50).");



            roomType.MaxNumber = roomType.MaxAdults + roomType.MaxChildren;

            roomType.Bed = Math.Max(1, roomType.MaxAdults);

        }



        public void Add(RoomType roomType)

        {

            if (string.IsNullOrWhiteSpace(roomType.Name))

                throw new Exception("Tên loại phòng không được để trống.");



            var existingName = _roomTypeRepo.GetByName(roomType.Name.Trim());

            if (existingName != null)

                throw new Exception("Tên loại phòng đã tồn tại.");



            NormalizeAndSync(roomType);

            roomType.Name = roomType.Name.Trim();



            if (!string.IsNullOrWhiteSpace(roomType.Code))

            {

                var dupCode = _roomTypeRepo.GetByCode(roomType.Code);

                if (dupCode != null)

                    throw new Exception($"Mã «{roomType.Code}» đã được dùng cho loại phòng khác.");

            }



            if (roomType.UnitPrice < 0)

                throw new Exception("Giá không hợp lệ.");



            if (roomType.DescriptionRoom != null && !string.IsNullOrWhiteSpace(roomType.DescriptionRoom.ImageUrl))

                roomType.DescriptionRoom.ImageUrl = Path.GetFileName(roomType.DescriptionRoom.ImageUrl.Trim());



            _roomTypeRepo.Add(roomType);

        }



        public void Delete(int roomTypeId)

        {

            var existing = _roomTypeRepo.GetById(roomTypeId);

            if (existing == null)

                throw new Exception("Loại phòng không tồn tại");



            int count = _roomTypeRepo.CheckPhong(roomTypeId);

            if (count > 0)

                throw new Exception($"Loại phòng '{existing.Name}' đang có {count} phòng, không thể xóa.");



            var img = existing.DescriptionRoom?.ImageUrl;

            _roomTypeRepo.Delete(roomTypeId);

            RoomTypeImageStorage.TryDeleteStoredFile(img);

        }



        public void Update(RoomType roomType)

        {

            var existing = _roomTypeRepo.GetById(roomType.Id);

            if (existing == null)

                throw new Exception("Loại phòng không tồn tại");



            if (string.IsNullOrWhiteSpace(roomType.Name))

                throw new Exception("Tên loại phòng không được để trống.");



            var duplicate = _roomTypeRepo.GetByName(roomType.Name.Trim());

            if (duplicate != null && duplicate.Id != roomType.Id)

                throw new Exception("Tên loại phòng đã tồn tại");



            NormalizeAndSync(roomType);

            roomType.Name = roomType.Name.Trim();



            if (!string.IsNullOrWhiteSpace(roomType.Code))

            {

                var dupCode = _roomTypeRepo.GetByCode(roomType.Code);

                if (dupCode != null && dupCode.Id != roomType.Id)

                    throw new Exception($"Mã «{roomType.Code}» đã được dùng cho loại phòng khác.");

            }



            if (roomType.UnitPrice < 0)

                throw new Exception("Giá không hợp lệ.");



            var oldImg = existing.DescriptionRoom?.ImageUrl;

            if (roomType.DescriptionRoom != null && !string.IsNullOrWhiteSpace(roomType.DescriptionRoom.ImageUrl))

                roomType.DescriptionRoom.ImageUrl = Path.GetFileName(roomType.DescriptionRoom.ImageUrl.Trim());



            _roomTypeRepo.Update(roomType);



            var newImg = roomType.DescriptionRoom?.ImageUrl;

            if (!string.Equals(oldImg, newImg, StringComparison.OrdinalIgnoreCase))

                RoomTypeImageStorage.TryDeleteStoredFile(oldImg);

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

            if (string.IsNullOrWhiteSpace(keyword))

                return GetAllWithRoomCount();

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



        public RoomType? GetByName(string name)

        {

            return _roomTypeRepo.GetByName(name);

        }



        public RoomType? GetById(int roomTypeId)

        {

            return _roomTypeRepo.GetById(roomTypeId);

        }

    }

}

