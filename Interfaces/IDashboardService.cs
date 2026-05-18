using System;
using System.Collections.Generic;
using HotelManagement.ViewModels;

namespace HotelManagement.Interfaces;

public interface IDashboardService
{
    DashboardTodayMetrics GetTodayMetrics();

    /// <summary>Đặt phòng chờ xác nhận (website / thanh toán online vừa thành công…).</summary>
    IReadOnlyList<DashboardBookingPendingItem> GetPendingBookingsAwaitingConfirmation(int take = 5);

    /// <summary>Dọn phòng, dịch vụ chưa xử lý, quá giờ trả phòng (theo dữ liệu hiện có).</summary>
    IReadOnlyList<DashboardReminderItem> GetFrontDeskReminders(int take = 5);

    /// <summary>Sơ đồ trạng thái phòng tổng quan (tỷ lệ + từng phòng).</summary>
    DashboardMiniRoomStatus GetMiniRoomStatus();

    /// <summary>Sơ đồ phòng theo một ngày (kết hợp đơn đặt + trạng thái DB) — xếp lịch / tuần.</summary>
    DashboardMiniRoomStatus GetMiniRoomStatusAsOf(DateTime asOfDate);

    /// <summary>Các khoản thanh toán thành công gần nhất (theo thời điểm <c>Payment</c>).</summary>
    IReadOnlyList<DashboardRecentTransactionItem> GetRecentTransactions(int take = 10);

    /// <summary>Hóa đơn chờ thu để chọn khi «Thêm giao dịch».</summary>
    IReadOnlyList<DashboardBillPickRow> GetBillsForManualPaymentPick(int take = 80);

    /// <summary>Ghi nhận thanh toán (tiền mặt / chuyển khoản) cho một hóa đơn.</summary>
    void RecordManualBillPayment(int billId, string method, string? note = null);

    /// <summary>Ghi nhận khoản thu trực tiếp không gắn hóa đơn.</summary>
    void RecordStandalonePayment(decimal amount, string method, string? note = null);

    /// <summary>Chi trả đã ghi nhận từ dashboard (bảng <c>StaffPayouts</c>).</summary>
    IReadOnlyList<DashboardRecentTransactionItem> GetRecentStaffPayouts(int take = 15);

    /// <summary>Lưu một dòng chi trả mới.</summary>
    void RecordStaffPayout(string userName, decimal amount, string? note = null);
}
