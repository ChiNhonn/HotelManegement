namespace HotelManagement.Helpers;

public static class RoomBookingRules
{
    /// <summary>Phòng có thể nhận đặt lịch mới (theo trạng thái phòng).</summary>
    public static bool IsRoomBookable(string? roomStatusDb)
    {
        if (string.IsNullOrWhiteSpace(roomStatusDb))
            return true;

        var kind = RoomStatusMap.ClassifyPhysicalKind(roomStatusDb);
        return kind is RoomPhysicalStatusKind.Vacant or RoomPhysicalStatusKind.Unknown;
    }

    public static string? BookableBlockReason(string? roomStatusDb, string? floorStatusDb)
    {
        if (FloorStatusMap.IsLockedForBooking(floorStatusDb))
            return "Tầng đang bảo trì hoặc đóng, không thể đặt phòng.";

        if (!IsRoomBookable(roomStatusDb))
            return "Phòng không ở trạng thái sẵn sàng để đặt.";

        return null;
    }
}
