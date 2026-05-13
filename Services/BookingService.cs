using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagement.Data;
using HotelManagement.Helpers;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services;

public sealed class BookingService : IBookingService
{
    private readonly HotelDbContext _db;

    public BookingService(HotelDbContext db)
    {
        _db = db;
    }

    public void CreateReservation(ReservationRequest r)
    {
        if (string.IsNullOrWhiteSpace(r.FullName))
            throw new InvalidOperationException("Vui lòng nhập họ và tên.");
        if (string.IsNullOrWhiteSpace(r.CitizenId))
            throw new InvalidOperationException("Vui lòng nhập CCCD.");
        if (string.IsNullOrWhiteSpace(r.Phone))
            throw new InvalidOperationException("Vui lòng nhập số điện thoại.");

        var ci = r.CheckIn.Date;
        var co = r.CheckOut.Date;
        if (co <= ci)
            throw new InvalidOperationException("Ngày trả phòng phải sau ngày nhận phòng.");

        if (r.Adults < 1)
            throw new InvalidOperationException("Cần ít nhất 1 người lớn.");

        var room = _db.Rooms
            .Include(x => x.RoomType)
            .FirstOrDefault(x => x.Id == r.RoomId && x.SoftDelete == null);
        if (room == null)
            throw new InvalidOperationException("Không tìm thấy phòng.");

        if (HasRoomBookingOverlap(r.RoomId, ci, co, null))
            throw new InvalidOperationException("Phòng đã có đơn trùng khoảng thời gian này.");

        var cccd = r.CitizenId.Trim();
        if (cccd.Length > 20)
            throw new InvalidOperationException("CCCD không được quá 20 ký tự.");
        var phone = r.Phone.Trim();
        if (phone.Length > 20)
            throw new InvalidOperationException("Số điện thoại không được quá 20 ký tự.");

        var customer = _db.Customers.FirstOrDefault(x => x.CitizenId == cccd && x.SoftDelete == null);
        if (customer == null)
        {
            customer = new Customer
            {
                FullName = r.FullName.Trim(),
                CitizenId = cccd,
                Phone = phone,
                CreateAt = DateTime.Now
            };
            _db.Customers.Add(customer);
            _db.SaveChanges();
        }
        else
        {
            customer.FullName = r.FullName.Trim();
            customer.Phone = phone;
            customer.UpdateAt = DateTime.Now;
            _db.SaveChanges();
        }

        var nights = (co - ci).Days;
        var unitPrice = room.RoomType?.UnitPrice ?? 0m;
        var expectedTotal = unitPrice * nights;

        var note = BookingNoteHelper.ComposeGuestNote(r.Adults, r.Children, r.Note);

        var order = new Order
        {
            DateCheckIn = ci,
            DateCheckOut = co,
            Status = "Confirmed",
            IdCustomer = customer.Id,
            Number = r.Adults + r.Children,
            Note = note,
            DepositAmount = expectedTotal,
            CreateAt = DateTime.Now
        };
        _db.Orders.Add(order);
        _db.SaveChanges();

        var typeName = room.RoomType?.Name?.Trim() ?? "";
        var nameOrder = string.IsNullOrEmpty(typeName)
            ? $"Phòng {room.Name}"
            : $"Phòng {room.Name} — {typeName}";
        if (nameOrder.Length > 100)
            nameOrder = nameOrder[..100];

        var detail = new OrderDetail
        {
            NameOrder = nameOrder,
            UnitPrice = unitPrice,
            Quantity = nights,
            IdOrder = order.Id,
            IdRoom = room.Id,
            IdCustomer = customer.Id
        };
        _db.OrderDetails.Add(detail);

        room.Status = "occupied";
        room.UpdateAt = DateTime.Now;

        _db.SaveChanges();
    }

    public BookingDetailsDto GetBookingDetails(int orderId, int? forRoomId = null)
    {
        var o = _db.Orders.AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.OrderDetails!)
            .ThenInclude(od => od.Room!)
            .ThenInclude(r => r.RoomType)
            .FirstOrDefault(x => x.Id == orderId && x.SoftDelete == null);

        if (o == null)
            throw new InvalidOperationException("Không tìm thấy đơn.");

        var lines = o.OrderDetails?.Where(d => d.IdRoom != null).ToList() ?? new List<OrderDetail>();
        OrderDetail? line = null;
        if (forRoomId.HasValue)
            line = lines.FirstOrDefault(d => d.IdRoom == forRoomId.Value);
        line ??= lines.FirstOrDefault();

        if (line?.Room == null)
            throw new InvalidOperationException("Đơn không gắn phòng hợp lệ.");

        int adults, children;
        string? userNote;
        if (!BookingNoteHelper.TryParseStandardGuestNote(o.Note, out adults, out children, out userNote))
        {
            adults = Math.Max(1, o.Number > 0 ? o.Number : 1);
            children = 0;
            userNote = string.IsNullOrWhiteSpace(o.Note) ? null : o.Note.Trim();
        }

        var ci = o.DateCheckIn.Date;
        var co = o.DateCheckOut?.Date;
        var nights = co.HasValue
            ? Math.Max(1, (co.Value - ci).Days)
            : Math.Max(1, line.Quantity);

        var nightly = line.UnitPrice;
        var expected = nightly * nights;

        return new BookingDetailsDto
        {
            OrderId = o.Id,
            RoomId = line.Room!.Id,
            RoomName = line.Room.Name?.Trim() ?? $"#{line.Room.Id}",
            RoomTypeName = line.Room.RoomType?.Name?.Trim(),
            NightlyPrice = nightly,
            GuestName = o.Customer?.FullName?.Trim() ?? "",
            CitizenId = o.Customer?.CitizenId?.Trim() ?? "",
            Phone = o.Customer?.Phone?.Trim() ?? "",
            CheckIn = o.DateCheckIn,
            CheckOut = o.DateCheckOut,
            Adults = adults,
            Children = children,
            UserNote = userNote,
            Nights = nights,
            ExpectedTotal = expected,
            RawOrderNote = o.Note
        };
    }

    public void CheckoutEarly(int orderId, DateTime actualCheckoutDate)
    {
        var day = actualCheckoutDate.Date;
        var o = _db.Orders
            .Include(x => x.OrderDetails!)
            .FirstOrDefault(x => x.Id == orderId && x.SoftDelete == null);

        if (o == null)
            throw new InvalidOperationException("Không tìm thấy đơn.");

        if (OrderStatusHelpers.IsCancelled(o.Status) || OrderStatusHelpers.IsCheckoutDone(o.Status))
            throw new InvalidOperationException("Đơn không còn hiệu lực để trả phòng.");

        var sched = o.DateCheckOut?.Date
                    ?? throw new InvalidOperationException("Đơn chưa có ngày trả dự kiến.");

        if (day < o.DateCheckIn.Date)
            throw new InvalidOperationException("Ngày trả không được trước ngày nhận.");
        if (day > sched)
            throw new InvalidOperationException("Ngày trả không được sau ngày trả dự kiến.");

        var roomId = o.OrderDetails?.FirstOrDefault(d => d.IdRoom != null)?.IdRoom;
        if (roomId is int rid)
        {
            var room = _db.Rooms.FirstOrDefault(r => r.Id == rid && r.SoftDelete == null);
            if (room != null)
            {
                room.Status = "dirty";
                room.UpdateAt = DateTime.Now;
            }
        }

        o.DateCheckOut = day;
        o.Status = "checked_out";
        o.UpdateAt = DateTime.Now;
        _db.SaveChanges();
    }

    public void UpdateBooking(ReservationUpdateRequest r)
    {
        if (string.IsNullOrWhiteSpace(r.FullName))
            throw new InvalidOperationException("Vui lòng nhập họ và tên.");
        if (string.IsNullOrWhiteSpace(r.CitizenId))
            throw new InvalidOperationException("Vui lòng nhập CCCD.");
        if (string.IsNullOrWhiteSpace(r.Phone))
            throw new InvalidOperationException("Vui lòng nhập số điện thoại.");

        var ci = r.CheckIn.Date;
        var co = r.CheckOut.Date;
        if (co <= ci)
            throw new InvalidOperationException("Ngày trả phòng phải sau ngày nhận phòng.");
        if (r.Adults < 1)
            throw new InvalidOperationException("Cần ít nhất 1 người lớn.");

        var cccd = r.CitizenId.Trim();
        if (cccd.Length > 20)
            throw new InvalidOperationException("CCCD không được quá 20 ký tự.");
        var phone = r.Phone.Trim();
        if (phone.Length > 20)
            throw new InvalidOperationException("Số điện thoại không được quá 20 ký tự.");

        var o = _db.Orders
            .Include(x => x.Customer)
            .Include(x => x.OrderDetails!)
            .FirstOrDefault(x => x.Id == r.OrderId && x.SoftDelete == null);

        if (o == null)
            throw new InvalidOperationException("Không tìm thấy đơn.");
        if (OrderStatusHelpers.IsCancelled(o.Status) || OrderStatusHelpers.IsCheckoutDone(o.Status))
            throw new InvalidOperationException("Đơn không còn chỉnh sửa được.");

        var line = o.OrderDetails?.FirstOrDefault(d => d.IdRoom != null);
        if (line?.IdRoom == null)
            throw new InvalidOperationException("Đơn không gắn phòng hợp lệ.");

        var roomId = line.IdRoom.Value;

        if (HasRoomBookingOverlap(roomId, ci, co, o.Id))
            throw new InvalidOperationException("Phòng đã có đơn trùng khoảng thời gian này.");

        var customer = o.Customer ?? throw new InvalidOperationException("Không tìm thấy khách.");
        var other = _db.Customers.FirstOrDefault(c =>
            c.CitizenId == cccd && c.SoftDelete == null && c.Id != customer.Id);
        if (other != null)
            throw new InvalidOperationException("CCCD đã thuộc khách khác trong hệ thống.");

        customer.FullName = r.FullName.Trim();
        customer.CitizenId = cccd;
        customer.Phone = phone;
        customer.UpdateAt = DateTime.Now;

        var nights = (co - ci).Days;
        var unit = line.UnitPrice;

        o.DateCheckIn = ci;
        o.DateCheckOut = co;
        o.Number = r.Adults + r.Children;
        o.Note = BookingNoteHelper.ComposeGuestNote(r.Adults, r.Children, r.Note);
        o.DepositAmount = unit * nights;
        o.UpdateAt = DateTime.Now;

        line.Quantity = nights;

        _db.SaveChanges();
    }

    private bool HasRoomBookingOverlap(int roomId, DateTime checkIn, DateTime checkOut, int? excludeOrderId)
    {
        var rows = _db.Orders.AsNoTracking()
            .Where(o => o.SoftDelete == null)
            .Where(o => excludeOrderId == null || o.Id != excludeOrderId.Value)
            .Where(o => o.OrderDetails.Any(od => od.IdRoom == roomId))
            .Select(o => new { o.Status, o.DateCheckIn, o.DateCheckOut })
            .ToList();

        foreach (var o in rows)
        {
            if (OrderStatusHelpers.IsCancelled(o.Status) || OrderStatusHelpers.IsCheckoutDone(o.Status))
                continue;
            var oCo = o.DateCheckOut?.Date ?? DateTime.MaxValue.Date;
            if (checkIn < oCo && checkOut > o.DateCheckIn.Date)
                return true;
        }

        return false;
    }

    private static class OrderStatusHelpers
    {
        public static bool IsCancelled(string? status)
        {
            if (string.IsNullOrWhiteSpace(status)) return false;
            return status.Contains("hủy", StringComparison.OrdinalIgnoreCase)
                   || status.Equals("cancelled", StringComparison.OrdinalIgnoreCase)
                   || status.Equals("canceled", StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsCheckoutDone(string? status)
        {
            if (string.IsNullOrWhiteSpace(status)) return false;
            var s = status.Trim().ToLowerInvariant();
            if (s is "checked_out" or "checkedout" or "completed" or "done") return true;
            return status.Contains("đã trả", StringComparison.OrdinalIgnoreCase);
        }
    }
}
