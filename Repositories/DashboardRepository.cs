using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagement.Data;
using HotelManagement.Helpers;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Repositories;

public sealed class DashboardRepository : IDashboardRepository
{
    private readonly HotelDbContext _db;

    public DashboardRepository(HotelDbContext db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public int CountVacantRooms() =>
        _db.Rooms.AsNoTracking()
            .Count(r => r.SoftDelete == null
                        && (r.Status == "available" || r.Status == "vacant" || r.Status == "free"
                            || r.Status == "Available" || r.Status == "Vacant" || r.Status == "Free"));

    public int CountArrivalsBetween(DateTime startInclusive, DateTime endExclusive) =>
        _db.Orders.AsNoTracking()
            .Count(o => o.SoftDelete == null
                        && o.DateCheckIn >= startInclusive && o.DateCheckIn < endExclusive);

    public int CountDeparturesBetween(DateTime startInclusive, DateTime endExclusive) =>
        _db.Orders.AsNoTracking()
            .Count(o => o.SoftDelete == null
                        && o.DateCheckOut != null
                        && o.DateCheckOut >= startInclusive && o.DateCheckOut < endExclusive);

    public decimal SumBillTotalBetween(DateTime startInclusive, DateTime endExclusive) =>
        _db.Bills.AsNoTracking()
            .Where(b => b.SoftDelete == null && b.CreateAt >= startInclusive && b.CreateAt < endExclusive)
            .Sum(b => (decimal?)b.TotalAmount) ?? 0m;

    public IReadOnlyList<Order> LoadOrdersForPendingDashboard(DateTime createdSince) =>
        _db.Orders.AsNoTracking()
            .Where(o => o.SoftDelete == null && o.CreateAt >= createdSince)
            .Include(o => o.Customer)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Room)
            .Include(o => o.Bill)
            .ThenInclude(b => b!.Payments)
            .OrderByDescending(o => o.CreateAt)
            .ToList();

    public IReadOnlyList<Payment> LoadRecentSuccessfulPayments(int take, int scanBatch = 80)
    {
        take = Math.Clamp(take, 1, 1000);
        scanBatch = Math.Clamp(scanBatch, Math.Max(take, 50), 2000);

        var billPayments = _db.Payments.AsNoTracking()
            .Include(p => p.Bill!)
                .ThenInclude(b => b.User)
            .Include(p => p.Bill!)
                .ThenInclude(b => b.Order!)
                .ThenInclude(o => o!.Customer)
            .Include(p => p.Bill!)
                .ThenInclude(b => b.Order!)
                .ThenInclude(o => o!.OrderDetails!)
                .ThenInclude(od => od.Room)
            .Where(p => p.SoftDelete == null && p.IdBill != null)
            .OrderByDescending(p => p.CreateAt)
            .Take(scanBatch)
            .AsEnumerable()
            .Where(p => p.Bill != null
                        && p.Bill.SoftDelete == null
                        && IsPaymentSuccess(p.Status))
            .ToList();

        var standalone = _db.Payments.AsNoTracking()
            .Where(p => p.SoftDelete == null
                        && p.IdBill == null
                        && p.Amount != null
                        && p.Amount.Value > 0m)
            .OrderByDescending(p => p.CreateAt)
            .Take(scanBatch)
            .AsEnumerable()
            .Where(p => IsPaymentSuccess(p.Status))
            .ToList();

        return billPayments
            .Concat(standalone)
            .OrderByDescending(p => p.CreateAt)
            .Take(take)
            .ToList();
    }

    public IReadOnlyList<StaffPayout> LoadRecentStaffPayouts(int take)
    {
        take = Math.Clamp(take, 1, 1000);
        return _db.StaffPayouts.AsNoTracking()
            .Where(p => p.SoftDelete == null)
            .OrderByDescending(p => p.CreateAt)
            .Take(take)
            .ToList();
    }

    public void AddStaffPayout(StaffPayout payout) => _db.StaffPayouts.Add(payout);

    public void SaveChanges() => _db.SaveChanges();

    public IReadOnlyList<Order> LoadOverdueCheckoutsForReminders(DateTime asOf) =>
        _db.Orders.AsNoTracking()
            .Include(o => o.Customer)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Room)
            .Where(o => o.SoftDelete == null
                        && o.DateCheckOut != null
                        && o.DateCheckOut < asOf)
            .ToList();

    public IReadOnlyList<Room> LoadRoomsForHousekeepingScan() =>
        _db.Rooms.AsNoTracking()
            .Where(r => r.SoftDelete == null)
            .OrderBy(r => r.Name)
            .ToList();

    public IReadOnlyList<BillDetail> LoadBillDetailsForServiceReminderScan() =>
        _db.BillDetails.AsNoTracking()
            .Include(bd => bd.Service)
            .Include(bd => bd.Bill)
            .ThenInclude(b => b!.Order)
            .ThenInclude(o => o!.Customer)
            .Include(bd => bd.Bill)
            .ThenInclude(b => b!.Order)
            .ThenInclude(o => o!.OrderDetails)
            .ThenInclude(od => od.Room)
            .Where(bd => bd.IdService != null && bd.IdBill != null)
            .Where(bd => bd.Bill!.SoftDelete == null && bd.Bill.Order != null && bd.Bill.Order.SoftDelete == null)
            .ToList();

    public IReadOnlyList<ServiceOrder> LoadOpenServiceOrdersForReminders() =>
        _db.ServiceOrders.AsNoTracking()
            .Include(o => o.Order!)
            .ThenInclude(ord => ord.Customer)
            .Include(o => o.Order!)
            .ThenInclude(ord => ord.OrderDetails!)
            .ThenInclude(od => od.Room)
            .Include(o => o.Room)
            .Where(o => o.SoftDelete == null
                && (o.Status == ServiceOrderStatus.Pending || o.Status == ServiceOrderStatus.InProgress))
            .OrderByDescending(o => o.CreateAt)
            .ToList();

    public IReadOnlyList<DashboardBillPickRow> LoadBillsForManualPaymentPick(int take = 80)
    {
        take = Math.Clamp(take, 1, 200);
        // Trước đây chỉ lấy N bill mới nhất rồi lọc client — nếu N bill đó đều đã Paid
        // thì dù trong DB vẫn còn hóa đơn Pending cũ, dialog « Thêm giao dịch » rỗng.
        // Lọc « chưa có khoản thanh toán thành công » ngay trong truy vấn, bổ sung lọc chuỗi trạng thái tiếng Việt sau.
        var fetch = Math.Clamp(take * 25, 120, 800);
        var bills = _db.Bills.AsNoTracking()
            .Include(b => b.Order!)
                .ThenInclude(o => o.Customer)
            .Include(b => b.Order!)
                .ThenInclude(o => o.OrderDetails!)
                .ThenInclude(od => od.Room)
            .Where(b => b.SoftDelete == null && b.IdOrder != null)
            .Where(b => !_db.Payments.Any(p => p.SoftDelete == null
                && p.IdBill == b.Id
                && p.Status != null
                && (p.Status == "Paid" || p.Status == "paid"
                    || p.Status == "Success" || p.Status == "success"
                    || p.Status == "Successful" || p.Status == "successful"
                    || p.Status == "Completed" || p.Status == "completed"
                    || p.Status == "Succeeded" || p.Status == "succeeded"
                    || p.Status == "Done" || p.Status == "done")))
            .OrderByDescending(b => b.CreateAt)
            .Take(fetch)
            .AsEnumerable()
            .Where(b => !IsBillPaidStatus(b.Status))
            .Take(take)
            .Select(MapBillPickRow)
            .ToList();

        return bills;
    }

    public void RecordManualBillPayment(int billId, string method, string? note = null)
    {
        method = string.IsNullOrWhiteSpace(method) ? "Tiền mặt" : method.Trim();
        if (method.Length > 100)
            method = method[..100];

        var bill = _db.Bills
                .Include(b => b.Payments)
                .FirstOrDefault(b => b.Id == billId && b.SoftDelete == null)
            ?? throw new InvalidOperationException("Không tìm thấy hóa đơn.");

        if (IsBillPaidStatus(bill.Status))
            throw new InvalidOperationException("Hóa đơn đã được đánh dấu thanh toán.");

        foreach (var p in bill.Payments ?? Enumerable.Empty<Payment>())
        {
            if (p.SoftDelete != null) continue;
            if (IsPaymentSuccess(p.Status))
                throw new InvalidOperationException("Đã có khoản thanh toán thành công trên hóa đơn này.");
        }

        _db.Payments.Add(new Payment
        {
            IdBill = bill.Id,
            Method = method,
            Status = "Paid",
            CreateAt = DateTime.Now,
            Note = NormalizePaymentNote(note)
        });

        bill.Status = "Paid";

        MarkImmediateServiceOrdersPaidForBill(bill.Id);

        _db.SaveChanges();
    }

    public void RecordStandalonePayment(decimal amount, string method, string? note = null)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Số tiền phải lớn hơn 0.");

        method = string.IsNullOrWhiteSpace(method) ? "Tiền mặt" : method.Trim();
        if (method.Length > 100)
            method = method[..100];

        amount = decimal.Round(amount, 2, MidpointRounding.AwayFromZero);

        _db.Payments.Add(new Payment
        {
            IdBill = null,
            Amount = amount,
            Method = method,
            Status = "Paid",
            CreateAt = DateTime.Now,
            Note = NormalizePaymentNote(note)
        });

        _db.SaveChanges();
    }

    /// <summary>Ghi nhận đã thu tiền ngay cho các dòng dịch vụ immediate trên bill (dashboard).</summary>
    private void MarkImmediateServiceOrdersPaidForBill(int billId)
    {
        var detailIds = _db.BillDetails.AsNoTracking()
            .Where(d => d.IdBill == billId)
            .Select(d => d.Id)
            .ToList();
        if (detailIds.Count == 0) return;

        var lines = _db.ServiceOrders
            .Where(so => so.SoftDelete == null
                         && so.IdBillDetail != null
                         && detailIds.Contains(so.IdBillDetail.Value))
            .ToList();

        var now = DateTime.Now;
        foreach (var so in lines)
        {
            if (so.Status != ServiceOrderStatus.Completed) continue;
            if (!IsImmediateChargeMode(so.ChargeMode)) continue;
            if (so.ImmediatePaidAt != null) continue;
            so.ImmediatePaidAt = now;
        }
    }

    private static bool IsImmediateChargeMode(string? mode) =>
        string.Equals(mode?.Trim(), ServiceChargeMode.Immediate, StringComparison.OrdinalIgnoreCase);

    private static DashboardBillPickRow MapBillPickRow(Bill b)
    {
        var order = b.Order!;
        var rooms = SummarizeRooms(order);
        var guest = order.Customer?.FullName?.Trim() ?? "Khách";
        var disp = $"HĐ #{b.Id} · {rooms} · {guest} · {b.TotalAmount:N0} đ";
        var defaultNote = $"{rooms} - {guest}";
        return new DashboardBillPickRow
        {
            BillId = b.Id,
            Display = disp,
            TotalAmount = b.TotalAmount,
            DefaultPaymentNote = defaultNote
        };
    }

    private static string SummarizeRooms(Order o)
    {
        var names = o.OrderDetails?
            .Where(od => od.Room != null && !string.IsNullOrWhiteSpace(od.Room.Name))
            .Select(od => od.Room!.Name.Trim())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(n => n, StringComparer.OrdinalIgnoreCase)
            .ToList();
        if (names == null || names.Count == 0)
            return "Phòng —";
        return names.Count <= 3
            ? string.Join(", ", names)
            : string.Join(", ", names.Take(3)) + "…";
    }

    private static string? NormalizePaymentNote(string? note)
    {
        if (string.IsNullOrWhiteSpace(note))
            return null;
        var t = note.Trim();
        return t.Length <= 500 ? t : t[..500];
    }

    private static bool IsBillPaidStatus(string? status)
    {
        if (string.IsNullOrWhiteSpace(status)) return false;
        var s = status.Trim().ToLowerInvariant();
        return s is "paid" or "completed" or "settled" or "closed"
               || s.Contains("đã thanh toán")
               || s.Contains("đã đóng");
    }

    private static bool IsPaymentSuccess(string? status)
    {
        if (string.IsNullOrWhiteSpace(status)) return false;
        var s = status.Trim().ToLowerInvariant();
        return s is "success" or "successful" or "succeeded" or "paid" or "completed" or "done";
    }
}
