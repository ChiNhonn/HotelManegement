using System;
using System.Collections.Generic;
using HotelManagement.Helpers;

namespace HotelManagement.ViewModels;

/// <summary>Một phòng trong sơ đồ trạng thái mini.</summary>
public sealed class DashboardMiniRoomCell
{
    public int RoomId { get; init; }
    public string Name { get; init; } = "";
    public string RawStatus { get; init; } = "";
    public RoomPhysicalStatusKind Kind { get; init; }

    /// <summary>Tên khách đang lưu trú (theo đơn còn hiệu lực tại ngày xem), nếu có.</summary>
    public string? GuestName { get; init; }

    /// <summary>Mã đơn gắn với lưu trú tại ngày xem (để Trả / Xem / Sửa).</summary>
    public int? ActiveOrderId { get; init; }

    public int? IdRoomType { get; init; }
    public string? RoomTypeName { get; init; }

    /// <summary>Giá một đêm (theo loại phòng).</summary>
    public decimal NightlyPrice { get; init; }

    /// <summary>Hàng lưới 0..2 (tầng 1..3 khi đủ 3 tầng).</summary>
    public int GridRow { get; init; }

    /// <summary>Cột lưới 0..9 trong tầng.</summary>
    public int GridCol { get; init; }
}

/// <summary>Tổng hợp trạng thái vật lý toàn khách sạn (cho UI mini).</summary>
public sealed class DashboardMiniRoomStatus
{
    public IReadOnlyList<DashboardMiniRoomCell> Rooms { get; init; } = new List<DashboardMiniRoomCell>();

    /// <summary>Nhãn tầng theo chỉ số hàng lưới (0 = hàng đầu).</summary>
    public IReadOnlyList<string> FloorRowLabels { get; init; } = Array.Empty<string>();

    public int VacantCount { get; init; }
    public int OccupiedCount { get; init; }
    public int CleaningCount { get; init; }
    public int MaintenanceCount { get; init; }
    public int UnknownCount { get; init; }

    public int TotalRooms => Rooms.Count;
}
