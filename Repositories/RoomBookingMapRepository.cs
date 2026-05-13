using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Repositories;

public sealed class RoomBookingMapRepository : IRoomBookingMapRepository
{
    private readonly HotelDbContext _db;

    public RoomBookingMapRepository(HotelDbContext db)
    {
        _db = db;
    }

    public IReadOnlyList<RoomBookingMapRoomRow> GetActiveRoomsWithTypes()
    {
        return _db.Rooms.AsNoTracking()
            .Where(r => r.SoftDelete == null)
            .Include(r => r.RoomType)
            .Select(r => new RoomBookingMapRoomRow
            {
                Id = r.Id,
                Name = r.Name ?? "",
                Status = r.Status ?? "",
                IdFloor = r.IdFloor,
                IdRoomType = r.IdRoomType,
                TypeName = r.RoomType != null ? r.RoomType.Name : null,
                NightlyPrice = r.RoomType != null ? r.RoomType.UnitPrice : 0m
            })
            .ToList();
    }

    public Dictionary<int, (string GuestName, int OrderId)> GetGuestStayMapForDate(DateTime day)
    {
        var orders = _db.Orders.AsNoTracking()
            .Include(o => o.Customer)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Room)
            .Where(o => o.SoftDelete == null
                        && o.DateCheckIn.Date <= day
                        && (o.DateCheckOut == null || day < o.DateCheckOut.Value.Date))
            .ToList()
            .Where(o => !IsCancelled(o.Status) && !IsCheckoutDone(o.Status))
            .OrderByDescending(o => o.Id)
            .ToList();

        var map = new Dictionary<int, (string GuestName, int OrderId)>();
        foreach (var o in orders)
        {
            foreach (var od in o.OrderDetails ?? Enumerable.Empty<OrderDetail>())
            {
                if (od.IdRoom == null) continue;
                var rid = od.IdRoom.Value;
                var name = o.Customer?.FullName?.Trim();
                if (string.IsNullOrWhiteSpace(name))
                    name = o.Customer != null ? $"Khách #{o.IdCustomer}" : "Khách";
                if (!map.ContainsKey(rid))
                    map[rid] = (name, o.Id);
            }
        }

        return map;
    }

    private static bool IsCancelled(string? status) =>
        status != null && (status.Contains("hủy", StringComparison.OrdinalIgnoreCase)
                           || status.Equals("cancelled", StringComparison.OrdinalIgnoreCase)
                           || status.Equals("canceled", StringComparison.OrdinalIgnoreCase));

    private static bool IsCheckoutDone(string? status)
    {
        if (string.IsNullOrWhiteSpace(status)) return false;
        var s = status.Trim().ToLowerInvariant();
        if (s is "checked_out" or "checkedout" or "completed" or "done") return true;
        return status.Contains("đã trả", StringComparison.OrdinalIgnoreCase);
    }
}
