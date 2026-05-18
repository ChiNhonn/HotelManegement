using System.IO;
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

        private static RoomTypeView MapRow(RoomType lp, int roomCount) => new()
        {
            RoomTypeId = lp.Id,
            Code = string.IsNullOrWhiteSpace(lp.Code) ? "—" : lp.Code!,
            TypeName = lp.Name,
            UnitPrice = lp.UnitPrice,
            CapacityDisplay = $"{lp.MaxAdults} NL / {lp.MaxChildren} TE",
            TotalMaxGuests = lp.MaxNumber,
            RoomCount = roomCount,
            Description = lp.DescriptionRoom?.Content ?? "",
            BedTypeDescription = lp.BedTypeDescription
        };

        public void Add(RoomType lp)
        {
            _context.Add(lp);
            _context.SaveChanges();
        }

        public void Delete(int roomTypeId)
        {
            var lp = _context.RoomTypes.Find(roomTypeId);
            if (lp == null)
                throw new Exception("Không tìm thấy loại phòng");

            _context.RoomTypes.Remove(lp);
            _context.SaveChanges();
        }

        public int CheckPhong(int roomTypeId)
        {
            return _context.Rooms.Count(p => p.IdRoomType == roomTypeId && p.SoftDelete == null);
        }

        public void Update(RoomType lp)
        {
            var existing = _context.RoomTypes
                .Include(x => x.DescriptionRoom)
                .FirstOrDefault(x => x.Id == lp.Id);
            if (existing == null)
                throw new Exception("Không tìm thấy loại phòng");

            existing.Name = lp.Name;
            existing.Code = lp.Code;
            existing.UnitPrice = lp.UnitPrice;
            existing.MaxAdults = lp.MaxAdults;
            existing.MaxChildren = lp.MaxChildren;
            existing.MaxNumber = lp.MaxAdults + lp.MaxChildren;
            existing.BedTypeDescription = lp.BedTypeDescription;
            existing.Bed = Math.Max(1, lp.MaxAdults);
            existing.UpdateAt = DateTime.Now;

            var note = lp.DescriptionRoom?.Content;
            var image = lp.DescriptionRoom?.ImageUrl;
            var hasDesc = !string.IsNullOrWhiteSpace(note) || !string.IsNullOrWhiteSpace(image);

            if (hasDesc)
            {
                if (existing.DescriptionRoom == null)
                {
                    existing.DescriptionRoom = new DescriptionRoom();
                    _context.DescriptionRooms.Add(existing.DescriptionRoom);
                }

                existing.DescriptionRoom.Content = string.IsNullOrWhiteSpace(note) ? null : note.Trim();
                existing.DescriptionRoom.ImageUrl = string.IsNullOrWhiteSpace(image) ? null : Path.GetFileName(image.Trim());
                existing.DescriptionRoom.IdRoomType = existing.Id;
            }
            else if (existing.DescriptionRoom != null)
            {
                existing.DescriptionRoom.Content = null;
                existing.DescriptionRoom.ImageUrl = null;
            }

            _context.SaveChanges();
        }

        public List<RoomType> GetAll()
        {
            return _context.RoomTypes.OrderBy(x => x.Id).ToList();
        }

        public List<RoomTypeView> GetAllWithRoomCount()
        {
            var types = _context.RoomTypes
                .AsNoTracking()
                .Include(x => x.DescriptionRoom)
                .OrderBy(lp => lp.Id)
                .ToList();
            return MapWithCounts(types);
        }

        public List<RoomTypeView> Search(string keyword)
        {
            var k = keyword.Trim();
            var types = _context.RoomTypes
                .AsNoTracking()
                .Include(x => x.DescriptionRoom)
                .Where(lp =>
                    lp.Name.Contains(k)
                    || (lp.Code != null && lp.Code.Contains(k))
                    || (lp.BedTypeDescription != null && lp.BedTypeDescription.Contains(k))
                    || (lp.DescriptionRoom != null
                        && lp.DescriptionRoom.Content != null
                        && lp.DescriptionRoom.Content.Contains(k)))
                .OrderBy(lp => lp.Id)
                .ToList();
            return MapWithCounts(types);
        }

        public List<RoomTypeView> GetByRoomType(int roomTypeId)
        {
            var types = _context.RoomTypes
                .AsNoTracking()
                .Include(x => x.DescriptionRoom)
                .Where(lp => lp.Id == roomTypeId)
                .OrderBy(lp => lp.Id)
                .ToList();
            return MapWithCounts(types);
        }

        public List<RoomTypeView> GetByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var types = _context.RoomTypes
                .AsNoTracking()
                .Include(x => x.DescriptionRoom)
                .Where(lp => lp.UnitPrice >= minPrice && lp.UnitPrice <= maxPrice)
                .OrderBy(lp => lp.Id)
                .ToList();
            return MapWithCounts(types);
        }

        private List<RoomTypeView> MapWithCounts(List<RoomType> types)
        {
            if (types.Count == 0)
                return new List<RoomTypeView>();

            var ids = types.Select(t => t.Id).ToList();
            var counts = _context.Rooms
                .AsNoTracking()
                .Where(p => p.SoftDelete == null && p.IdRoomType != null && ids.Contains(p.IdRoomType!.Value))
                .GroupBy(p => p.IdRoomType!.Value)
                .Select(g => new { Id = g.Key, C = g.Count() })
                .ToDictionary(x => x.Id, x => x.C);

            return types.Select(lp => MapRow(lp, counts.TryGetValue(lp.Id, out var c) ? c : 0)).ToList();
        }

        public RoomType? GetByName(string typeName)
        {
            return _context.RoomTypes.FirstOrDefault(lp => lp.Name == typeName);
        }

        public RoomType? GetByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;

            var c = code.Trim();
            return _context.RoomTypes.FirstOrDefault(lp => lp.Code == c);
        }

        public RoomType? GetById(int roomTypeId)
        {
            return _context.RoomTypes
                .Include(x => x.DescriptionRoom)
                .FirstOrDefault(x => x.Id == roomTypeId);
        }
    }
}
