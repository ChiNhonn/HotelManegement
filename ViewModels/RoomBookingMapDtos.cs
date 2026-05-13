using System.Collections.Generic;

namespace HotelManagement.ViewModels;

/// <summary>Dòng phòng + loại phòng đọc từ DB cho màn Quản lý đặt phòng.</summary>
public sealed class RoomBookingMapRoomRow
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public string Status { get; init; } = "";
    public int? IdFloor { get; init; }
    public int? IdRoomType { get; init; }
    public string? TypeName { get; init; }
    public decimal NightlyPrice { get; init; }
}

/// <summary>Bộ lọc cục bộ trên sơ đồ (toolbar) — không truy vấn DB.</summary>
public sealed class RoomBookingMapFilterCriteria
{
    public RoomBookingMapStatusFilterKind StatusFilter { get; init; }
    public int? RoomTypeId { get; init; }
    public string? SearchText { get; init; }
}

public enum RoomBookingMapStatusFilterKind
{
    All = 0,
    VacantOnly = 1,
    CleaningOnly = 2
}

/// <summary>Một hạng phòng hiển thị trong combobox lọc.</summary>
public sealed class RoomBookingMapRoomTypeOption
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
}

/// <summary>Kích thước lưới ô và danh sách cell nằm trong lưới (để view chỉ vẽ control).</summary>
public sealed class RoomBookingMapGridLayout
{
    public int RowCount { get; init; }
    public int ColumnCount { get; init; }
    public int MinimumWidth { get; init; }
    public int MinimumHeight { get; init; }
    public IReadOnlyList<DashboardMiniRoomCell> CellsInGrid { get; init; } = System.Array.Empty<DashboardMiniRoomCell>();
}
