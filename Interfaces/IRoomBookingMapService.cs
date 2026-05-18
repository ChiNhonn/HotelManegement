using System;
using System.Collections.Generic;
using HotelManagement.ViewModels;

namespace HotelManagement.Interfaces;

/// <summary>Nghiệp vụ sơ đồ đặt phòng (ghép repository → view model ô phòng).</summary>
public interface IRoomBookingMapService
{
    DashboardMiniRoomStatus GetMiniRoomStatusAsOf(DateTime asOfDate);

    /// <summary>Lọc danh sách ô theo toolbar (trạng thái / hạng / từ khóa).</summary>
    DashboardMiniRoomStatus ApplyViewFilters(DashboardMiniRoomStatus full, RoomBookingMapFilterCriteria criteria);

    /// <summary>Hạng phòng có trong dữ liệu ngày (đổ combo), đã sắp xếp tên.</summary>
    IReadOnlyList<RoomBookingMapRoomTypeOption> GetRoomTypeFilterOptions(DashboardMiniRoomStatus full);

    /// <summary>Hàng/cột lưới WinForms + các cell hợp lệ trong biên.</summary>
    RoomBookingMapGridLayout BuildTileGridLayout(DashboardMiniRoomStatus filtered);
}
