using System;

namespace HotelManagement.ViewModels;

/// <summary>Một lượt đặt chờ lễ tân xác nhận (đặc biệt sau thanh toán online).</summary>
public sealed class DashboardBookingPendingItem
{
    public int OrderId { get; init; }
    public string CustomerName { get; init; } = "";
    public string? Phone { get; init; }
    /// <summary>Tên phòng đã gán hoặc "Chưa gán phòng".</summary>
    public string BookedRoomsSummary { get; init; } = "";
    /// <summary>Hiển thị số khách (ưu tiên trường <c>Number</c> trên đơn nếu &gt; 0).</summary>
    public string GuestCountText { get; init; } = "—";
    public DateTime DateCheckIn { get; init; }
    public string OrderStatus { get; init; } = "";
    /// <summary>True nếu có khoản thanh toán thành công qua kênh online/QR/đội tác.</summary>
    public bool PaidOnline { get; init; }
    /// <summary>Gợi ý hiển thị cột "Thanh toán".</summary>
    public string PaymentHint { get; init; } = "";
    public DateTime CreatedAt { get; init; }
}

/// <summary>Một dòng nhắc việc cho lễ tân.</summary>
public sealed class DashboardReminderItem
{
    /// <summary>Ví dụ: Check-out, Phòng, Dịch vụ.</summary>
    public string Category { get; init; } = "";
    public string Message { get; init; } = "";
    public DateTime? At { get; init; }
}

/// <summary>Giao dịch thanh toán gần đây (dashboard).</summary>
public sealed class DashboardRecentTransactionItem
{
    public string UserName { get; init; } = "";
    public decimal Amount { get; init; }
    public string StatusLabel { get; init; } = "Thành công";
    public DateTime OccurredAt { get; init; }
}
