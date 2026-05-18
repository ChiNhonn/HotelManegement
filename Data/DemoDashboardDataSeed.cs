using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagement.Helpers;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data;

/// <summary>
/// Seed dữ liệu giả phục vụ kiểm thử trang Dashboard:
/// khách hàng, đơn đặt phòng (đang chờ / đã thanh toán online / quá giờ trả phòng),
/// hóa đơn + thanh toán, chi trả nhân sự, dịch vụ phụ chưa thanh toán, và một vài phòng cần dọn.
/// Idempotent: nhận diện bản ghi đã tạo bằng <see cref="DemoMarker"/> trong <c>Note</c> / <c>Note</c> staff payouts.
/// </summary>
public static class DemoDashboardDataSeed
{
    public const string DemoMarker = "[DEMO]";

    public static void EnsureSeed(HotelDbContext db)
    {
        EnsureDemoUser(db);
        EnsureDemoServices(db);
        EnsureDemoStaffPayouts(db);
        EnsureDemoRoomsNeedingCleaning(db);
        EnsureDemoOrdersAndBills(db);
    }

    private static Userr EnsureDemoUser(HotelDbContext db)
    {
        var existing = db.Users.FirstOrDefault(u => u.UserName == "admin" && u.SoftDelete == null);
        if (existing != null) return existing;

        existing = db.Users.FirstOrDefault(u => u.UserName == "demo" && u.SoftDelete == null);
        if (existing != null) return existing;

        var branchId = db.Branches.OrderBy(b => b.Id).Select(b => (int?)b.Id).FirstOrDefault();

        var user = new Userr
        {
            FullName = "Lễ tân Demo",
            UserName = "demo",
            Password = PasswordHelper.HashPassword("Demo@123"),
            Role = "Employee",
            CreateAt = DateTime.Now,
            IdBranch = branchId
        };
        db.Users.Add(user);
        db.SaveChanges();
        return user;
    }

    private static void EnsureDemoServices(HotelDbContext db)
    {
        var categories = new (string Name, int Sort, (string Name, decimal Price, string Unit, bool Stock, int Qty)[] Services)[]
        {
            ("F&B — Ẩm thực", 1, new[]
            {
                ("Bữa sáng buffet", 150_000m, "suất", false, 0),
                ("Room service — Phở bò", 95_000m, "tô", false, 0),
            }),
            ("Spa & Massage", 2, new[]
            {
                ("Massage body 60 phút", 450_000m, "lần", false, 0),
            }),
            ("Dịch vụ phòng", 3, new[]
            {
                ("Giặt ủi nhanh", 80_000m, "kg", false, 0),
                ("Đón sân bay", 350_000m, "chuyến", false, 0),
            }),
            ("Minibar", 4, new[]
            {
                ("Nước suối 500ml", 25_000m, "chai", true, 48),
                ("Bia lon", 35_000m, "lon", true, 36),
            }),
        };

        foreach (var (catName, sort, services) in categories)
        {
            var category = db.ServiceCategories.FirstOrDefault(c => c.Name == catName && c.SoftDelete == null);
            if (category == null)
            {
                category = new ServiceCategory
                {
                    Name = catName,
                    SortOrder = sort,
                    Description = $"{DemoMarker} Danh mục demo",
                    CreateAt = DateTime.Now
                };
                db.ServiceCategories.Add(category);
                db.SaveChanges();
            }

            foreach (var (name, price, unit, stock, qty) in services)
            {
                if (db.Services.Any(s => s.Name == name && s.SoftDelete == null)) continue;
                db.Services.Add(new Service
                {
                    Name = name,
                    UnitPrice = price,
                    Unit = unit,
                    IdServiceCategory = category.Id,
                    TrackInventory = stock,
                    StockQuantity = qty,
                    Description = DemoMarker,
                    CreateAt = DateTime.Now
                });
            }
        }

        db.SaveChanges();
    }

    private static void EnsureDemoStaffPayouts(HotelDbContext db)
    {
        var hasDemo = db.StaffPayouts.Any(p => p.Note != null && p.Note.Contains(DemoMarker));
        if (hasDemo) return;

        var now = DateTime.Now;
        var rows = new[]
        {
            new StaffPayout { UserName = "admin",    Amount = 1_200_000m, StatusLabel = "Thành công", CreateAt = now.AddHours(-1),  Note = DemoMarker + " Mua văn phòng phẩm" },
            new StaffPayout { UserName = "thuhuyen", Amount =   800_000m, StatusLabel = "Thành công", CreateAt = now.AddHours(-4),  Note = DemoMarker + " Bồi dưỡng ca đêm" },
            new StaffPayout { UserName = "hoanglan", Amount =   450_000m, StatusLabel = "Thành công", CreateAt = now.AddHours(-8),  Note = DemoMarker + " Phí giặt ủi đối tác" },
            new StaffPayout { UserName = "minhduc",  Amount = 1_750_000m, StatusLabel = "Thành công", CreateAt = now.AddDays(-1),   Note = DemoMarker + " Sửa máy điều hòa P.207" },
            new StaffPayout { UserName = "demo",     Amount =   300_000m, StatusLabel = "Thành công", CreateAt = now.AddDays(-2),   Note = DemoMarker + " Mua nước tinh khiết" },
        };

        db.StaffPayouts.AddRange(rows);
        db.SaveChanges();
    }

    private static void EnsureDemoRoomsNeedingCleaning(HotelDbContext db)
    {
        // Chỉ đổi trạng thái phòng chưa-được-dùng-cho-demo: chọn 2 phòng "available" đầu tiên
        var rooms = db.Rooms
            .Where(r => r.SoftDelete == null
                        && (r.Status == "available" || r.Status == "vacant" || r.Status == "free"))
            .OrderBy(r => r.Name)
            .Take(2)
            .ToList();

        if (rooms.Count == 0) return;

        var changed = false;
        foreach (var r in rooms)
        {
            r.Status = "needs_cleaning";
            r.UpdateAt = DateTime.Now;
            changed = true;
        }

        if (changed) db.SaveChanges();
    }

    private static void EnsureDemoOrdersAndBills(HotelDbContext db)
    {
        var hasDemo = db.Orders.Any(o => o.Note != null && o.Note.Contains(DemoMarker));
        if (hasDemo) return;

        var user = db.Users
            .Where(u => u.SoftDelete == null && (u.UserName == "admin" || u.UserName == "demo"))
            .OrderBy(u => u.Id)
            .FirstOrDefault();

        var availableRooms = db.Rooms
            .Include(r => r.RoomType)
            .Where(r => r.SoftDelete == null)
            .OrderBy(r => r.Name)
            .ToList();

        if (availableRooms.Count < 5) return;

        var customers = EnsureDemoCustomers(db);
        var bfast = db.Services.FirstOrDefault(s => s.Name == "Bữa sáng buffet" && s.SoftDelete == null);

        var now = DateTime.Now;
        var today = DateTime.Today;

        var roomA = availableRooms[0];
        var pendingOnline = BuildOrder(
            customer: customers[0],
            user: user,
            room: roomA,
            guests: 2,
            checkIn: today.AddDays(1).AddHours(14),
            checkOut: today.AddDays(3).AddHours(12),
            deposit: 500_000m,
            status: "Pending",
            note: DemoMarker + " Đơn online vừa thanh toán",
            createdAt: now.AddMinutes(-25));
        AttachPaidBill(pendingOnline, 1_700_000m, "vnpay", "success", now.AddMinutes(-22));

        var roomB = availableRooms[1];
        var pendingDeposit = BuildOrder(
            customer: customers[1],
            user: user,
            room: roomB,
            guests: 1,
            checkIn: today.AddHours(15),
            checkOut: today.AddDays(2).AddHours(12),
            deposit: null,
            status: "Pending",
            note: DemoMarker + " Đơn chờ thanh toán",
            createdAt: now.AddHours(-3));

        var roomC = availableRooms[2];
        var overdue = BuildOrder(
            customer: customers[2],
            user: user,
            room: roomC,
            guests: 2,
            checkIn: today.AddDays(-2).AddHours(14),
            checkOut: now.AddHours(-2),
            deposit: 500_000m,
            status: "checked_in",
            note: DemoMarker + " Khách quá giờ trả phòng",
            createdAt: now.AddDays(-2).AddHours(-1));
        var overdueBill = AttachPaidBill(overdue, 3_200_000m, "cash", "success", now.AddDays(-2));
        if (bfast != null)
        {
            overdueBill.BillDetails ??= new List<BillDetail>();
            overdueBill.BillDetails.Add(new BillDetail
            {
                Product = "Dịch vụ chưa thanh toán",
                Quantity = 2,
                UnitPrice = bfast.UnitPrice,
                SubTotal = bfast.UnitPrice * 2,
                IdService = bfast.Id
            });
            overdueBill.Status = "Pending";
        }

        var roomD = availableRooms[3];
        var todayCheckin = BuildOrder(
            customer: customers[3],
            user: user,
            room: roomD,
            guests: 2,
            checkIn: today.AddHours(13),
            checkOut: today.AddDays(1).AddHours(12),
            deposit: 1_000_000m,
            status: "checked_in",
            note: DemoMarker + " Khách nhận phòng hôm nay",
            createdAt: now.AddHours(-6));
        AttachPaidBill(todayCheckin, 950_000m, "card", "success", now.AddHours(-5));

        var roomE = availableRooms[Math.Min(4, availableRooms.Count - 1)];
        var departingToday = BuildOrder(
            customer: customers[4],
            user: user,
            room: roomE,
            guests: 1,
            checkIn: today.AddDays(-1).AddHours(14),
            checkOut: today.AddHours(20),
            deposit: 600_000m,
            status: "checked_in",
            note: DemoMarker + " Khách trả phòng trong ngày",
            createdAt: now.AddDays(-1).AddHours(-2));
        AttachPaidBill(departingToday, 1_250_000m, "momo", "success", now.AddHours(-9));

        db.Orders.AddRange(pendingOnline, pendingDeposit, overdue, todayCheckin, departingToday);
        db.SaveChanges();
    }

    private static Order BuildOrder(
        Customer customer,
        Userr? user,
        Room room,
        int guests,
        DateTime checkIn,
        DateTime? checkOut,
        decimal? deposit,
        string status,
        string note,
        DateTime createdAt)
    {
        var unitPrice = room.RoomType?.UnitPrice ?? 800_000m;
        return new Order
        {
            IdCustomer = customer.Id,
            Customer = customer,
            IdUser = user?.Id,
            DateCheckIn = checkIn,
            DateCheckOut = checkOut,
            DepositAmount = deposit,
            Status = status,
            Number = guests,
            Note = note,
            CreateAt = createdAt,
            OrderDetails = new List<OrderDetail>
            {
                new OrderDetail
                {
                    NameOrder = $"Phòng {room.Name}",
                    UnitPrice = unitPrice,
                    Quantity = guests,
                    IdRoom = room.Id,
                    IdCustomer = customer.Id
                }
            }
        };
    }

    private static List<Customer> EnsureDemoCustomers(HotelDbContext db)
    {
        var sample = new (string FullName, string CitizenId, string Phone, string Email)[]
        {
            ("Nguyễn Thị Hồng",    "079200000111", "0901111222", "hong.nguyen@example.com"),
            ("Trần Văn Nam",       "079200000222", "0902222333", "nam.tran@example.com"),
            ("Lê Quỳnh Anh",       "079200000333", "0903333444", "anh.le@example.com"),
            ("Phạm Đức Mạnh",      "079200000444", "0904444555", "manh.pham@example.com"),
            ("Hoàng Thu Trang",    "079200000555", "0905555666", "trang.hoang@example.com"),
        };

        var list = new List<Customer>(sample.Length);
        foreach (var (fullName, cccd, phone, email) in sample)
        {
            var c = db.Customers.FirstOrDefault(x => x.CitizenId == cccd && x.SoftDelete == null);
            if (c == null)
            {
                c = new Customer
                {
                    FullName = fullName,
                    CitizenId = cccd,
                    Phone = phone,
                    Email = email,
                    CreateAt = DateTime.Now
                };
                db.Customers.Add(c);
                db.SaveChanges();
            }

            list.Add(c);
        }

        return list;
    }

    private static Bill AttachPaidBill(Order order, decimal total, string method, string paymentStatus, DateTime occurredAt)
    {
        var bill = new Bill
        {
            CreateAt = occurredAt,
            TotalAmount = total,
            Discount = 0m,
            Tax = 0m,
            Status = "Paid",
            IdUser = order.IdUser,
            Payments = new List<Payment>
            {
                new Payment
                {
                    Method = method,
                    Status = paymentStatus,
                    CreateAt = occurredAt
                }
            },
            BillDetails = new List<BillDetail>()
        };

        bill.Order = order;
        order.Bill = bill;
        return bill;
    }
}
