using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagement.Models;

namespace HotelManagement.Data;

/// <summary>
/// Seed demo: phòng theo tầng (101–110, …) trừ các số bị loại bởi <see cref="IsExcludedRoomNumber"/>.
/// Chạy sau Migrate; soft-delete phòng loại trừ; không tạo lại các số đó.
/// </summary>
public static class DemoHotelRoomsSeed
{
    /// <summary>Loại phòng — tên khớp khi tìm trong DB.</summary>
    public const string TypeStandard = "Standard";

    public const string TypeVip = "VIP";
    public const string TypeLuxury = "Luxury";

    public static void EnsureSeed(HotelDbContext db)
    {
        SoftDeleteExcludedRooms(db);

        var branch = db.Branches.OrderBy(b => b.Id).FirstOrDefault();
        if (branch == null)
        {
            branch = new Branch
            {
                HouseNumber = "1",
                StreetName = "Đường Biển Demo",
                Commune = "Phường Trung tâm",
                City = "Nha Trang",
                Country = "Việt Nam",
                Phone = "0258-000-000",
                Floors = new List<Floor>(),
                Users = new List<Userr>()
            };
            db.Branches.Add(branch);
            db.SaveChanges();
        }

        var floors = EnsureFloors(db, branch.Id);
        var types = EnsureRoomTypes(db);

        // 10 phòng/tầng: bỏ số đuôi 4 và 13 (vd. không có 104, 113); mỗi tầng lấy đủ 10 số hợp lệ.
        for (var floorIndex = 0; floorIndex < 3; floorIndex++)
        {
            var floor = floors[floorIndex];
            var floorNum = floorIndex + 1;
            var numbers = TenRoomNumbersForFloor(floorNum);
            for (var i = 0; i < numbers.Count; i++)
            {
                var name = numbers[i].ToString();
                var slot = i + 1;

                var existing = db.Rooms.FirstOrDefault(r => r.Name == name);
                if (existing != null)
                {
                    if (existing.SoftDelete != null && !IsExcludedRoomNumber(name))
                    {
                        existing.SoftDelete = null;
                        existing.UpdateAt = DateTime.Now;
                    }

                    continue;
                }

                var kind = RoomKindForSlot(floorNum, slot);
                var idType = kind switch
                {
                    0 => types.standardId,
                    1 => types.vipId,
                    _ => types.luxuryId
                };

                db.Rooms.Add(new Room
                {
                    Name = name,
                    Status = "available",
                    IdRoomType = idType,
                    IdFloor = floor.Id,
                    CreateAt = DateTime.Now
                });
            }
        }

        db.SaveChanges();
    }

    /// <summary>10 số phòng hợp lệ cho tầng (bỏ đuôi 4 và 13).</summary>
    private static List<int> TenRoomNumbersForFloor(int floorNum)
    {
        var prefix = floorNum * 100;
        var list = new List<int>();
        for (var tail = 1; list.Count < 10 && tail < 100; tail++)
        {
            var num = prefix + tail;
            if (IsExcludedRoomNumber(num.ToString()))
                continue;
            list.Add(num);
        }

        return list;
    }

    /// <summary>
    /// Phòng bị loại: số <c>4</c>, <c>13</c>, hoặc số ≥100 có hai chữ số cuối là <c>04</c>/<c>4</c> hoặc <c>13</c> (vd. 104, 113).
    /// </summary>
    public static bool IsExcludedRoomNumber(string? roomName)
    {
        if (string.IsNullOrWhiteSpace(roomName))
            return false;
        var s = roomName.Trim();
        if (!int.TryParse(s, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture,
                out var n))
            return false;
        if (n == 4 || n == 13)
            return true;
        if (n >= 100)
        {
            var tail = n % 100;
            if (tail == 4 || tail == 13)
                return true;
        }

        return false;
    }

    private static void SoftDeleteExcludedRooms(HotelDbContext db)
    {
        var now = DateTime.Now;
        var victims = db.Rooms.Where(r => r.SoftDelete == null).ToList()
            .Where(r => IsExcludedRoomNumber(r.Name))
            .ToList();
        foreach (var r in victims)
        {
            r.SoftDelete = now;
            r.UpdateAt = now;
        }

        if (victims.Count > 0)
            db.SaveChanges();
    }

    /// <summary>0 = Standard, 1 = VIP, 2 = Luxury. Tầng 1–2: 5+3+2; Tầng 3: 5+4+1.</summary>
    private static int RoomKindForSlot(int floorNum, int slot)
    {
        if (floorNum is < 1 or > 3 || slot is < 1 or > 10)
            return 0;

        if (floorNum < 3)
        {
            if (slot <= 5) return 0;
            if (slot <= 8) return 1;
            return 2;
        }

        if (slot <= 5) return 0;
        if (slot <= 9) return 1;
        return 2;
    }

    private static List<Floor> EnsureFloors(HotelDbContext db, int branchId)
    {
        var names = new[] { "Tầng 1", "Tầng 2", "Tầng 3" };
        var list = new List<Floor>();
        foreach (var nm in names)
        {
            var f = db.Floors.FirstOrDefault(x => x.IdBranch == branchId && x.Name == nm);
            if (f == null)
            {
                f = new Floor
                {
                    Name = nm,
                    IdBranch = branchId,
                    Rooms = new List<Room>()
                };
                db.Floors.Add(f);
                db.SaveChanges();
            }

            list.Add(f);
        }

        return list;
    }

    private static (int standardId, int vipId, int luxuryId) EnsureRoomTypes(HotelDbContext db)
    {
        var standard = db.RoomTypes.FirstOrDefault(t => t.SoftDelete == null && t.Name == TypeStandard);
        if (standard == null)
        {
            standard = new RoomType
            {
                Name = TypeStandard,
                Code = "STD",
                UnitPrice = 800_000m,
                MaxNumber = 2,
                MaxAdults = 2,
                MaxChildren = 0,
                BedTypeDescription = "1 giường đôi",
                Bed = 1,
                CreateAt = DateTime.Now,
                Rooms = new List<Room>()
            };
            db.RoomTypes.Add(standard);
            db.SaveChanges();
        }

        var vip = db.RoomTypes.FirstOrDefault(t => t.SoftDelete == null && t.Name == TypeVip);
        if (vip == null)
        {
            vip = new RoomType
            {
                Name = TypeVip,
                Code = "DLX",
                UnitPrice = 1_500_000m,
                MaxNumber = 3,
                MaxAdults = 2,
                MaxChildren = 1,
                BedTypeDescription = "1 giường đôi + sofa bed",
                Bed = 2,
                CreateAt = DateTime.Now,
                Rooms = new List<Room>()
            };
            db.RoomTypes.Add(vip);
            db.SaveChanges();
        }

        var luxury = db.RoomTypes.FirstOrDefault(t => t.SoftDelete == null && t.Name == TypeLuxury);
        if (luxury == null)
        {
            luxury = new RoomType
            {
                Name = TypeLuxury,
                Code = "SUI",
                UnitPrice = 2_800_000m,
                MaxNumber = 4,
                MaxAdults = 2,
                MaxChildren = 2,
                BedTypeDescription = "2 giường đơn + phòng khách",
                Bed = 2,
                CreateAt = DateTime.Now,
                Rooms = new List<Room>()
            };
            db.RoomTypes.Add(luxury);
            db.SaveChanges();
        }

        return (standard.Id, vip.Id, luxury.Id);
    }
}
