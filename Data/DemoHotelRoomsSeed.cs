using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data;

/// <summary>
/// Seed demo: phòng theo tầng (101–110, …) trừ các số bị loại bởi <see cref="IsExcludedRoomNumber"/>.
/// Chạy sau Migrate; soft-delete phòng loại trừ; không tạo lại các số đó.
/// Đồng thời chuẩn hóa <b>bốn</b> loại phòng (SNG / DBL / DLX / STE) và ẩn các loại demo cũ.
/// </summary>
public static class DemoHotelRoomsSeed
{
    /// <summary>Mã loại phòng chuẩn — tra trong DB sau seed.</summary>
    public const string CodeSingle = "SNG";

    public const string CodeDouble = "DBL";

    public const string CodeDeluxe = "DLX";

    public const string CodeSuite = "STE";

    private sealed record RoomTypeSeedSpec(
        string Code,
        string Name,
        decimal UnitPrice,
        int MaxAdults,
        int MaxChildren,
        string BedTypeDescription,
        string DescriptionContent);

    private static readonly RoomTypeSeedSpec[] CanonicalRoomTypes =
    {
        new(CodeSingle, "Phòng đơn", 480_000m, 1, 0,
            "1 giường đơn",
            "Phòng gọn nhẹ, phù hợp khách đi công tác hoặc nghỉ ngắn ngày."),
        new(CodeDouble, "Phòng đôi", 780_000m, 2, 1,
            "1 giường đôi (Queen)",
            "Không gian ấm cúng cho cặp đôi hoặc gia đình nhỏ có một trẻ em."),
        new(CodeDeluxe, "Deluxe", 1_380_000m, 2, 2,
            "1 giường đôi + sofa giường",
            "Phòng rộng hơn, thiết kế hiện đại và đầy đủ tiện nghi."),
        new(CodeSuite, "Suite", 2_590_000m, 4, 2,
            "Phòng khách riêng + phòng ngủ King",
            "Suite sang trọng với không gian tiếp khách và phòng ngủ tách biệt."),
    };

    private static readonly HashSet<string> CanonicalCodes =
        CanonicalRoomTypes.Select(s => s.Code).ToHashSet(StringComparer.OrdinalIgnoreCase);

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
        var types = EnsureCanonicalRoomTypes(db);

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

                var kind = RoomKindForSlot(slot);
                var idType = kind switch
                {
                    0 => types.singleId,
                    1 => types.doubleId,
                    2 => types.deluxeId,
                    _ => types.suiteId
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

    /// <summary>0 = đơn, 1 = đôi, 2 = deluxe, 3 = suite — phân bổ 3+3+2+2 cho 10 ô.</summary>
    private static int RoomKindForSlot(int slot)
    {
        if (slot is < 1 or > 10)
            return 0;

        if (slot <= 3)
            return 0;
        if (slot <= 6)
            return 1;
        if (slot <= 8)
            return 2;
        return 3;
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
                    Status = "open",
                    Rooms = new List<Room>()
                };
                db.Floors.Add(f);
                db.SaveChanges();
            }

            list.Add(f);
        }

        return list;
    }

    /// <summary>Gộp Suite mã legacy <c>SUI</c> (từ migration cũ) sang mã chuẩn <see cref="CodeSuite"/>.</summary>
    private static void NormalizeLegacySuiteAlias(HotelDbContext db)
    {
        var ste = db.RoomTypes.FirstOrDefault(t => t.SoftDelete == null && t.Code == CodeSuite);
        // Không dùng string.Equals(..., OrdinalIgnoreCase) — EF Core không dịch được sang SQL.
        var sui = db.RoomTypes.FirstOrDefault(t =>
            t.SoftDelete == null && t.Code != null && t.Code.ToUpper() == "SUI");

        if (sui == null)
            return;

        if (ste == null)
        {
            sui.Code = CodeSuite;
            sui.UpdateAt = DateTime.Now;
            db.SaveChanges();
            return;
        }

        var now = DateTime.Now;
        foreach (var r in db.Rooms.Where(r => r.IdRoomType == sui.Id && r.SoftDelete == null))
        {
            r.IdRoomType = ste.Id;
            r.UpdateAt = now;
        }

        if (sui.DescriptionRoom != null)
        {
            sui.DescriptionRoom.SoftDelete = now;
            sui.DescriptionRoom.UpdateAt = now;
        }

        sui.SoftDelete = now;
        sui.UpdateAt = now;
        db.SaveChanges();
    }

    private static (int singleId, int doubleId, int deluxeId, int suiteId) EnsureCanonicalRoomTypes(HotelDbContext db)
    {
        NormalizeLegacySuiteAlias(db);

        foreach (var spec in CanonicalRoomTypes)
            UpsertCanonicalRoomType(db, spec);

        db.SaveChanges();

        PruneObsoleteRoomTypes(db);

        var byCode = db.RoomTypes.AsNoTracking()
            .Where(t => t.SoftDelete == null && t.Code != null && CanonicalCodes.Contains(t.Code))
            .ToDictionary(t => t.Code!, StringComparer.OrdinalIgnoreCase);

        if (byCode.Count != CanonicalRoomTypes.Length)
            throw new InvalidOperationException(
                $"Seed loại phòng: thiếu mã chuẩn (cần {CanonicalRoomTypes.Length}, có {byCode.Count}).");

        return (
            byCode[CodeSingle].Id,
            byCode[CodeDouble].Id,
            byCode[CodeDeluxe].Id,
            byCode[CodeSuite].Id);
    }

    private static void UpsertCanonicalRoomType(HotelDbContext db, RoomTypeSeedSpec s)
    {
        var rt = db.RoomTypes
            .Include(x => x.DescriptionRoom)
            .FirstOrDefault(t => t.SoftDelete == null && t.Code == s.Code);

        var maxNum = s.MaxAdults + s.MaxChildren;
        var bed = Math.Max(1, s.MaxAdults);

        if (rt == null)
        {
            rt = new RoomType
            {
                Code = s.Code,
                Name = s.Name,
                UnitPrice = s.UnitPrice,
                MaxAdults = s.MaxAdults,
                MaxChildren = s.MaxChildren,
                MaxNumber = maxNum,
                BedTypeDescription = s.BedTypeDescription,
                Bed = bed,
                CreateAt = DateTime.Now,
                DescriptionRoom = new DescriptionRoom
                {
                    Content = s.DescriptionContent,
                    CreateAt = DateTime.Now
                }
            };
            db.RoomTypes.Add(rt);
            return;
        }

        rt.Name = s.Name;
        rt.UnitPrice = s.UnitPrice;
        rt.MaxAdults = s.MaxAdults;
        rt.MaxChildren = s.MaxChildren;
        rt.MaxNumber = maxNum;
        rt.BedTypeDescription = s.BedTypeDescription;
        rt.Bed = bed;
        rt.UpdateAt = DateTime.Now;

        if (rt.DescriptionRoom == null)
        {
            rt.DescriptionRoom = new DescriptionRoom
            {
                Content = s.DescriptionContent,
                CreateAt = DateTime.Now,
                IdRoomType = rt.Id
            };
            db.DescriptionRooms.Add(rt.DescriptionRoom);
        }
        else
        {
            rt.DescriptionRoom.Content = s.DescriptionContent;
            rt.DescriptionRoom.SoftDelete = null;
            rt.DescriptionRoom.UpdateAt = DateTime.Now;
        }
    }

    /// <summary>Gán phòng sang Deluxe (DLX) rồi ẩn loại không thuộc bộ bốn mã chuẩn.</summary>
    private static void PruneObsoleteRoomTypes(HotelDbContext db)
    {
        var fallbackId = db.RoomTypes.AsNoTracking()
            .Where(t => t.SoftDelete == null && t.Code == CodeDeluxe)
            .Select(t => t.Id)
            .FirstOrDefault();

        if (fallbackId == 0)
            return;

        var keepIds = db.RoomTypes.AsNoTracking()
            .Where(t => t.SoftDelete == null && t.Code != null && CanonicalCodes.Contains(t.Code))
            .Select(t => t.Id)
            .ToHashSet();

        var obsolete = db.RoomTypes
            .Include(t => t.DescriptionRoom)
            .Where(t => t.SoftDelete == null && !keepIds.Contains(t.Id))
            .ToList();

        if (obsolete.Count == 0)
            return;

        var now = DateTime.Now;

        foreach (var o in obsolete)
        {
            var rooms = db.Rooms.Where(r => r.IdRoomType == o.Id && r.SoftDelete == null).ToList();
            foreach (var room in rooms)
            {
                room.IdRoomType = fallbackId;
                room.UpdateAt = now;
            }

            if (o.DescriptionRoom != null)
            {
                o.DescriptionRoom.SoftDelete = now;
                o.DescriptionRoom.UpdateAt = now;
            }

            o.SoftDelete = now;
            o.UpdateAt = now;
        }

        db.SaveChanges();
    }
}
