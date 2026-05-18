using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
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
        take = Math.Clamp(take, 1, 50);
        scanBatch = Math.Clamp(scanBatch, take, 200);
        return _db.Payments.AsNoTracking()
            .Include(p => p.Bill!)
            .ThenInclude(b => b.User)
            .Where(p => p.SoftDelete == null && p.IdBill != null)
            .OrderByDescending(p => p.CreateAt)
            .Take(scanBatch)
            .AsEnumerable()
            .Where(p => p.Bill != null
                        && p.Bill.SoftDelete == null
                        && IsPaymentSuccess(p.Status))
            .Take(take)
            .ToList();
    }

    public IReadOnlyList<StaffPayout> LoadRecentStaffPayouts(int take)
    {
        take = Math.Clamp(take, 1, 100);
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

    private static bool IsPaymentSuccess(string? status)
    {
        if (string.IsNullOrWhiteSpace(status)) return false;
        var s = status.Trim().ToLowerInvariant();
        return s is "success" or "successful" or "succeeded" or "paid" or "completed" or "done";
    }
}
