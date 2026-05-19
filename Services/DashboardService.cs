using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagement.Helpers;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using HotelManagement.ViewModels;

namespace HotelManagement.Services;

public class DashboardService : IDashboardService
{
    private readonly IDashboardRepository _repo;
    private readonly IRoomBookingMapService _roomBookingMap;

    public DashboardService(IDashboardRepository repo, IRoomBookingMapService roomBookingMap)
    {
        _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        _roomBookingMap = roomBookingMap ?? throw new ArgumentNullException(nameof(roomBookingMap));
    }

    public DashboardTodayMetrics GetTodayMetrics()
    {
        var today = DateTime.Today;
        var tomorrow = today.AddDays(1);

        return new DashboardTodayMetrics
        {
            VacantRooms = _repo.CountVacantRooms(),
            ArrivalsToday = _repo.CountArrivalsBetween(today, tomorrow),
            DeparturesToday = _repo.CountDeparturesBetween(today, tomorrow),
            RevenueToday = _repo.SumBillTotalBetween(today, tomorrow)
        };
    }

    public IReadOnlyList<DashboardBookingPendingItem> GetPendingBookingsAwaitingConfirmation(int take = 5)
    {
        var cutoff = DateTime.Today.AddDays(-90);

        var orders = _repo.LoadOrdersForPendingDashboard(cutoff)
            .Where(o => AwaitsFrontDeskConfirmation(o.Status))
            .ToList();

        var mapped = orders.Select(MapPendingBooking).ToList();
        var sorted = mapped
            .OrderByDescending(x => x.PaidOnline)
            .ThenByDescending(x => x.CreatedAt)
            .AsEnumerable();

        if (take > 0) sorted = sorted.Take(take);
        return sorted.ToList();
    }

    public IReadOnlyList<DashboardReminderItem> GetFrontDeskReminders(int take = 5)
    {
        var now = DateTime.Now;
        var list = new List<DashboardReminderItem>();
        list.AddRange(CollectOverdueCheckouts(now));
        list.AddRange(CollectHousekeepingReminders());
        list.AddRange(CollectOpenModuleServiceOrders(now));
        list.AddRange(CollectPendingServiceReminders(now));
        var sorted = list
            .OrderByDescending(r => r.At ?? DateTime.MinValue)
            .ThenBy(r => r.Category, StringComparer.OrdinalIgnoreCase)
            .AsEnumerable();

        if (take > 0) sorted = sorted.Take(take);
        return sorted.ToList();
    }

    public IReadOnlyList<DashboardRecentTransactionItem> GetRecentTransactions(int take = 10)
    {
        var payments = _repo.LoadRecentSuccessfulPayments(take);
        return payments
            .Select(p =>
            {
                var hasBill = p.IdBill != null && p.Bill != null;
                var title = ResolvePaymentGridTitle(p, hasBill);
                return new DashboardRecentTransactionItem
                {
                    Title = title,
                    UserName = title,
                    Amount = hasBill ? p.Bill!.TotalAmount : (p.Amount ?? 0m),
                    StatusLabel = "Thành công",
                    Method = NormalizePaymentMethod(p.Method),
                    OccurredAt = p.CreateAt
                };
            })
            .ToList();
    }

    private static string ResolvePaymentGridTitle(Payment p, bool hasBill)
    {
        if (!string.IsNullOrWhiteSpace(p.Note))
            return p.Note.Trim();
        if (!hasBill)
            return "Thu trực tiếp";
        return FormatBillPaymentCaption(p.Bill!) ?? "—";
    }

    private static string? FormatBillPaymentCaption(Bill bill)
    {
        if (bill.Order == null)
            return null;
        var rooms = SummarizeRoomsForCaption(bill.Order);
        var guest = bill.Order.Customer?.FullName?.Trim() ?? "Khách";
        return $"{rooms} - {guest}";
    }

    private static string SummarizeRoomsForCaption(Order o)
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

    private static string NormalizePaymentMethod(string? raw)
    {
        if (string.IsNullOrWhiteSpace(raw)) return "Khác";
        var v = raw.Trim();
        var lower = v.ToLowerInvariant();
        if (lower.Contains("tiền mặt") || lower.Contains("cash")) return "Tiền mặt";
        if (lower.Contains("chuyển khoản") || lower.Contains("transfer") || lower.Contains("bank")) return "Chuyển khoản";
        if (lower.Contains("vnpay") || lower.Contains("momo") || lower.Contains("zalopay")
            || lower.Contains("qr") || lower.Contains("online")) return "Online / QR";
        if (lower.Contains("card") || lower.Contains("thẻ")) return "Thẻ";
        return v;
    }

    public IReadOnlyList<DashboardBillPickRow> GetBillsForManualPaymentPick(int take = 80) =>
        _repo.LoadBillsForManualPaymentPick(take);

    public void RecordManualBillPayment(int billId, string method, string? note = null) =>
        _repo.RecordManualBillPayment(billId, method, note);

    public void RecordStandalonePayment(decimal amount, string method, string? note = null) =>
        _repo.RecordStandalonePayment(amount, method, note);

    public IReadOnlyList<DashboardRecentTransactionItem> GetRecentStaffPayouts(int take = 15) =>
        _repo.LoadRecentStaffPayouts(take)
            .Select(p => new DashboardRecentTransactionItem
            {
                Title = p.UserName,
                UserName = p.UserName,
                Amount = p.Amount,
                StatusLabel = p.StatusLabel,
                OccurredAt = p.CreateAt
            })
            .ToList();

    public void RecordStaffPayout(string userName, decimal amount, string? note = null)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("Cần nhập tiêu đề.", nameof(userName));
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Số tiền phải lớn hơn 0.");

        _repo.AddStaffPayout(new StaffPayout
        {
            UserName = userName.Trim(),
            Amount = amount,
            StatusLabel = "Thành công",
            CreateAt = DateTime.Now,
            Note = string.IsNullOrWhiteSpace(note) ? null : note.Trim()
        });
        _repo.SaveChanges();
    }

    public DashboardMiniRoomStatus GetMiniRoomStatus() =>
        _roomBookingMap.GetMiniRoomStatusAsOf(DateTime.Today);

    public DashboardMiniRoomStatus GetMiniRoomStatusAsOf(DateTime asOfDate) =>
        _roomBookingMap.GetMiniRoomStatusAsOf(asOfDate);

    private DashboardBookingPendingItem MapPendingBooking(Order o)
    {
        var (paidOk, onlineOk) = ClassifyPayment(o.Bill);
        var online = paidOk && onlineOk;
        string hint;
        if (paidOk && onlineOk)
            hint = "TT online thành công — cần gọi xác nhận / gán phòng";
        else if (paidOk)
            hint = "Đã thanh toán — chờ xác nhận";
        else
            hint = "Chưa thanh toán / chờ cọc";

        return new DashboardBookingPendingItem
        {
            OrderId = o.Id,
            CustomerName = o.Customer?.FullName?.Trim() ?? $"(Khách #{o.IdCustomer})",
            BookedRoomsSummary = SummarizeBookedRooms(o),
            GuestCountText = FormatGuestCount(o),
            DateCheckIn = o.DateCheckIn,
            OrderStatus = o.Status ?? "",
            PaidOnline = online,
            PaymentHint = hint,
            CreatedAt = o.CreateAt
        };
    }

    private static string SummarizeBookedRooms(Order o)
    {
        var names = o.OrderDetails?
            .Where(od => od.Room != null && !string.IsNullOrWhiteSpace(od.Room.Name))
            .Select(od => od.Room!.Name.Trim())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(n => n, StringComparer.OrdinalIgnoreCase)
            .ToList();
        if (names == null || names.Count == 0)
            return "Chưa gán phòng";
        return string.Join(", ", names);
    }

    private static string FormatGuestCount(Order o)
    {
        if (o.Number > 0)
            return o.Number.ToString();
        var roomLines = o.OrderDetails?.Where(od => od.IdRoom != null).ToList();
        if (roomLines is not { Count: > 0 })
            return "—";
        var sum = roomLines.Sum(od => od.Quantity);
        return sum > 0 ? sum.ToString() : "—";
    }

    private IEnumerable<DashboardReminderItem> CollectOverdueCheckouts(DateTime now)
    {
        var orders = _repo.LoadOverdueCheckoutsForReminders(now)
            .Where(o => !IsCancelled(o.Status) && !IsCheckoutDone(o.Status))
            .ToList();

        foreach (var o in orders)
        {
            var room = PrimaryRoomName(o);
            var guest = o.Customer?.FullName?.Trim() ?? "Khách";
            var roomBit = string.IsNullOrEmpty(room) ? "" : $" — phòng {room}";
            yield return new DashboardReminderItem
            {
                Category = "Check-out",
                Message = $"{guest}{roomBit}: đã quá giờ trả phòng (theo lịch {o.DateCheckOut:dd/MM/yyyy HH:mm}).",
                At = o.DateCheckOut,
                DedupeKey = $"overdue_order:{o.Id}"
            };
        }
    }

    private IEnumerable<DashboardReminderItem> CollectHousekeepingReminders()
    {
        var rooms = _repo.LoadRoomsForHousekeepingScan()
            .Where(r => RoomLooksNeedsCleaning(r.Status))
            .ToList();

        foreach (var r in rooms)
        {
            yield return new DashboardReminderItem
            {
                Category = "Dọn phòng",
                Message = $"Phòng {r.Name}: cần dọn / kiểm tra (trạng thái DB: {r.Status}).",
                At = r.UpdateAt ?? r.CreateAt,
                DedupeKey = $"hk_room:{r.Id}"
            };
        }
    }

    /// <summary>Yêu cầu từ module Dịch vụ (ghi nhận lúc đặt — chưa cần ghi vào BillDetail).</summary>
    private IEnumerable<DashboardReminderItem> CollectOpenModuleServiceOrders(DateTime now)
    {
        foreach (var line in _repo.LoadOpenServiceOrdersForReminders())
        {
            var o = line.Order;
            if (o == null) continue;
            if (IsCancelled(o.Status)) continue;
            if (!GuestStillInHotel(o, now)) continue;

            var room = line.Room?.Name?.Trim();
            if (string.IsNullOrEmpty(room))
                room = PrimaryRoomName(o);

            var guest = o.Customer?.FullName?.Trim() ?? "Khách";
            var statusLbl = ServiceOrderStatus.ToDisplay(line.Status);
            var roomBit = string.IsNullOrEmpty(room) ? "" : $"Phòng {room}: ";

            yield return new DashboardReminderItem
            {
                Category = "Yêu cầu dịch vụ",
                Message = $"{roomBit}{guest} — {line.ItemName} ×{line.Quantity} ({statusLbl}).",
                At = line.CreateAt,
                DedupeKey = $"svc_open:{line.Id}"
            };
        }
    }

    private IEnumerable<DashboardReminderItem> CollectPendingServiceReminders(DateTime now)
    {
        var details = _repo.LoadBillDetailsForServiceReminderScan()
            .Where(bd => !IsPaidBillStatus(bd.Bill!.Status))
            .ToList();

        foreach (var bd in details)
        {
            var o = bd.Bill!.Order!;
            if (IsCancelled(o.Status)) continue;
            if (!GuestStillInHotel(o, now)) continue;

            var room = PrimaryRoomName(o);
            var svc = bd.Service?.Name?.Trim() ?? bd.Product?.Trim() ?? "Dịch vụ";
            var guest = o.Customer?.FullName?.Trim() ?? "Khách";
            var roomBit = string.IsNullOrEmpty(room) ? "" : $"phòng {room} — ";
            yield return new DashboardReminderItem
            {
                Category = "Dịch vụ",
                Message = $"{roomBit}{guest}: {svc} (hóa đơn / dịch vụ chưa xử lý xong).",
                At = bd.Bill.CreateAt,
                DedupeKey = $"bill_svc:{bd.Id}"
            };
        }
    }

    private static string? PrimaryRoomName(Order o)
    {
        if (o.OrderDetails == null) return null;
        return o.OrderDetails
            .Where(od => od.Room != null && !string.IsNullOrWhiteSpace(od.Room.Name))
            .Select(od => od.Room!.Name)
            .FirstOrDefault();
    }

    private static bool AwaitsFrontDeskConfirmation(string? status) => !IsFrontDeskTerminalOrder(status);

    private static bool IsFrontDeskTerminalOrder(string? status)
    {
        if (string.IsNullOrWhiteSpace(status)) return false;
        var s = status.Trim();
        var lower = s.ToLowerInvariant();
        if (lower is "confirmed" or "checked_in" or "checkedin" or "completed" or "done"
            or "cancelled" or "canceled" or "checked_out" or "checkedout")
            return true;
        if (s.Contains("đã xác nhận", StringComparison.OrdinalIgnoreCase)) return true;
        if (s.Contains("đã hủy", StringComparison.OrdinalIgnoreCase)) return true;
        if (s.Contains("hoàn tất", StringComparison.OrdinalIgnoreCase)) return true;
        if (s.Contains("đã trả", StringComparison.OrdinalIgnoreCase)) return true;
        return false;
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

    private static bool IsPaidBillStatus(string? status)
    {
        if (string.IsNullOrWhiteSpace(status)) return false;
        var s = status.Trim().ToLowerInvariant();
        return s is "paid" or "completed" or "settled" or "closed"
               || s.Contains("đã thanh toán")
               || s.Contains("đã đóng");
    }

    private static bool GuestStillInHotel(Order o, DateTime now)
    {
        if (IsCancelled(o.Status)) return false;
        if (o.DateCheckIn > now) return false;
        if (o.DateCheckOut == null) return true;
        return o.DateCheckOut.Value.Date >= now.Date;
    }

    private static (bool paidOk, bool onlineMethod) ClassifyPayment(Bill? bill)
    {
        if (bill?.Payments == null || bill.Payments.Count == 0) return (false, false);

        var paidOk = false;
        var onlineMethod = false;
        foreach (var p in bill.Payments)
        {
            if (p.SoftDelete != null) continue;
            if (!IsPaymentSuccess(p.Status)) continue;
            paidOk = true;
            if (LooksOnlinePaymentMethod(p.Method)) onlineMethod = true;
        }

        return (paidOk, onlineMethod);
    }

    private static bool IsPaymentSuccess(string? status)
    {
        if (string.IsNullOrWhiteSpace(status)) return false;
        var s = status.Trim().ToLowerInvariant();
        return s is "success" or "successful" or "succeeded" or "paid" or "completed" or "done";
    }

    private static bool LooksOnlinePaymentMethod(string? method)
    {
        if (string.IsNullOrWhiteSpace(method)) return false;
        var m = method.ToLowerInvariant();
        return m.Contains("online") || m.Contains("vnpay") || m.Contains("momo") || m.Contains("zalopay")
               || m.Contains("card") || m.Contains("paypal") || m.Contains("stripe") || m.Contains("qr")
               || m.Contains("internet") || m.Contains("web");
    }

    private static bool RoomLooksNeedsCleaning(string? status)
    {
        if (string.IsNullOrWhiteSpace(status)) return false;
        var s = status.Trim().ToLowerInvariant();
        return s.Contains("dirty") || s.Contains("cleaning") || s.Contains("cần dọn")
               || s.Contains("need_clean") || s.Contains("housekeep") || s is "needs_cleaning";
    }
}
