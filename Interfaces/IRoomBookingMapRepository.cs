using HotelManagement.ViewModels;

namespace HotelManagement.Interfaces;

/// <summary>Truy vấn dữ liệu thô cho sơ đồ đặt phòng (tách khỏi dashboard).</summary>
public interface IRoomBookingMapRepository
{
    IReadOnlyList<RoomBookingMapFloorRow> GetActiveFloorsOrdered();

    IReadOnlyList<RoomBookingMapRoomRow> GetActiveRoomsWithTypes();

    /// <summary>Phòng → (tên khách, mã đơn) đang lưu trú tại <paramref name="day"/>.</summary>
    Dictionary<int, (string GuestName, int OrderId)> GetGuestStayMapForDate(DateTime day);
}
