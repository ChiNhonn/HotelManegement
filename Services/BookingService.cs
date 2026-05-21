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

        if (room.IdFloor is int floorId)
        {
            var floor = _db.Floors.AsNoTracking().FirstOrDefault(f => f.Id == floorId);
            if (floor != null && FloorStatusMap.IsLockedForBooking(floor.Status))
                throw new InvalidOperationException(
                    $"Tầng «{floor.Name}» đang {FloorStatusMap.ToDisplay(floor.Status).ToLowerInvariant()}, không thể đặt phòng.");
        }

        var bookBlock = RoomBookingRules.BookableBlockReason(room.Status, null);
        if (bookBlock != null)
            throw new InvalidOperationException(bookBlock);

        if (HasRoomBookingOverlap(r.RoomId, ci, co, null))
            throw new InvalidOperationException("Phòng đã có đơn trùng khoảng thời gian này.");

        var cccd = r.CitizenId.Trim();
        if (cccd.Length > 20)
            throw new InvalidOperationException("CCCD không được quá 20 ký tự.");
        var phone = r.Phone.Trim();
        if (phone.Length > 20)
            throw new InvalidOperationException("Số điện thoại không được quá 20 ký tự.");

        var customer = _db.Customers.FirstOrDefault(x => x.CCCD == cccd && x.SoftDelete == null);
        if (customer == null)
        {
            customer = new Customer
            {
                FullName = r.FullName.Trim(),
                CCCD = cccd,
                CreateAt = DateTime.Now
            };
            _db.Customers.Add(customer);
            _db.SaveChanges();
        }
        else
        {
            customer.FullName = r.FullName.Trim();
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

        SyncRoomChargesIntoBill(order.Id);
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
            CitizenId = o.Customer?.CCCD?.Trim() ?? "",
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

    public int CheckoutEarly(int orderId, DateTime actualCheckoutDate)
    {
        var o = LoadOrderForCheckout(orderId);
        var day = actualCheckoutDate.Date;

        if (OrderStatusHelpers.IsCancelled(o.Status) || OrderStatusHelpers.IsCheckoutDone(o.Status))
            throw new InvalidOperationException("Đơn không còn hiệu lực để trả phòng.");

        var sched = o.DateCheckOut?.Date
                    ?? throw new InvalidOperationException("Đơn chưa có ngày trả dự kiến.");

        if (day < o.DateCheckIn.Date)
            throw new InvalidOperationException("Ngày trả không được trước ngày nhận.");
        if (day > sched)
            throw new InvalidOperationException("Ngày trả không được sau ngày trả dự kiến.");

        ApplyCheckout(o, day);
        return EnsureBillForOrder(o.Id).Id;
    }

    public int GetBillIdForOrder(int orderId) => EnsureBillForOrder(orderId).Id;

    public void CompleteStayAfterPayment(int orderId)
    {
        var o = LoadOrderForCheckout(orderId);
        if (OrderStatusHelpers.IsCancelled(o.Status) || OrderStatusHelpers.IsCheckoutDone(o.Status))
            return;

        var day = DateTime.Today;
        if (day < o.DateCheckIn.Date)
            day = o.DateCheckIn.Date;

        ApplyCheckout(o, day);
    }

    private Order LoadOrderForCheckout(int orderId)
    {
        return _db.Orders
                   .Include(x => x.OrderDetails!)
                   .FirstOrDefault(x => x.Id == orderId && x.SoftDelete == null)
               ?? throw new InvalidOperationException("Không tìm thấy đơn.");
    }

    private void ApplyCheckout(Order o, DateTime day)
    {
        var actualNights = Math.Max(1, (day - o.DateCheckIn.Date).Days);
        var now = DateTime.Now;

        foreach (var od in o.OrderDetails ?? Enumerable.Empty<OrderDetail>())
        {
            if (od.IdRoom is not int rid)
                continue;

            od.Quantity = actualNights;

            var room = _db.Rooms.FirstOrDefault(r => r.Id == rid && r.SoftDelete == null);
            if (room == null)
                continue;

            room.Status = "dirty";
            room.UpdateAt = now;
        }

        o.DateCheckOut = day;
        o.Status = "checked_out";
        o.UpdateAt = now;
        _db.SaveChanges();

        SyncRoomChargesIntoBill(o.Id);
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
            c.CCCD == cccd && c.SoftDelete == null && c.Id != customer.Id);
        if (other != null)
            throw new InvalidOperationException("CCCD đã thuộc khách khác trong hệ thống.");

        customer.FullName = r.FullName.Trim();
        customer.CCCD = cccd;
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

        SyncRoomChargesIntoBill(o.Id);
    }

    /// <summary>
    /// Đảm bảo hóa đơn của đơn có dòng tiền phòng khớp <see cref="OrderDetail"/> (đêm × đơn giá đêm).
    /// Dòng dịch vụ có <see cref="BillDetail.IdService"/> được giữ nguyên.
    /// </summary>
    private void SyncRoomChargesIntoBill(int orderId)
    {
        if (!_db.Orders.Any(o => o.Id == orderId && o.SoftDelete == null))
            return;

        var bill = EnsureBillForOrder(orderId);

        var roomLines = _db.OrderDetails
            .Where(od => od.IdOrder == orderId && od.IdRoom != null)
            .ToList();

        var billDetailRows = _db.BillDetails.Where(d => d.IdBill == bill.Id).ToList();

        foreach (var od in roomLines)
        {
            var product = string.IsNullOrWhiteSpace(od.NameOrder) ? "Tiền phòng" : od.NameOrder.Trim();
            if (product.Length > 255)
                product = product[..255];

            var qty = od.Quantity;
            var unit = od.UnitPrice;
            var sub = unit * qty;

            var bd = billDetailRows.FirstOrDefault(d => d.IdService == null && d.Product == product);
            if (bd == null)
            {
                bd = new BillDetail
                {
                    IdBill = bill.Id,
                    Product = product,
                    Quantity = qty,
                    UnitPrice = unit,
                    SubTotal = sub,
                    IdService = null
                };
                _db.BillDetails.Add(bd);
                billDetailRows.Add(bd);
            }
            else
            {
                bd.Quantity = qty;
                bd.UnitPrice = unit;
                bd.SubTotal = sub;
            }
        }

        _db.SaveChanges();
        RecalculateBillTotal(bill.Id);
    }

    private Bill EnsureBillForOrder(int orderId)
    {
        var bill = _db.Bills.FirstOrDefault(b => b.IdOrder == orderId && b.SoftDelete == null);
        if (bill != null)
            return bill;

        var order = _db.Orders.FirstOrDefault(o => o.Id == orderId && o.SoftDelete == null)
                    ?? throw new InvalidOperationException("Không tìm thấy đơn.");

        bill = new Bill
        {
            IdOrder = orderId,
            IdUser = order.IdUser,
            Status = "Pending",
            CreateAt = DateTime.Now,
            TotalAmount = 0,
            Discount = 0,
            Tax = 0
        };
        _db.Bills.Add(bill);
        _db.SaveChanges();
        return bill;
    }

    private void RecalculateBillTotal(int billId)
    {
        var bill = _db.Bills.Include(b => b.BillDetails).FirstOrDefault(b => b.Id == billId && b.SoftDelete == null);
        if (bill == null)
            return;

        var sub = bill.BillDetails?.Sum(d => d.SubTotal) ?? 0;
        bill.TotalAmount = Math.Max(0, sub - bill.Discount + bill.Tax);
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
