namespace HotelManagement.Helpers;

public static class FloorStatusMap
{
    public static string ToDatabase(FloorOperationalMode mode) => mode switch
    {
        FloorOperationalMode.Maintenance => "maintenance",
        FloorOperationalMode.Closed => "closed",
        _ => "open"
    };

    public static FloorOperationalMode DeriveMode(string? statusFromDb)
    {
        if (string.IsNullOrWhiteSpace(statusFromDb))
            return FloorOperationalMode.Open;

        return statusFromDb.Trim().ToLowerInvariant() switch
        {
            "maintenance" or "maint" or "repair" => FloorOperationalMode.Maintenance,
            "closed" or "inactive" or "locked" => FloorOperationalMode.Closed,
            _ => FloorOperationalMode.Open
        };
    }

    public static string ToDisplay(string? statusFromDb) => DeriveMode(statusFromDb) switch
    {
        FloorOperationalMode.Maintenance => "Bảo trì / sửa chữa",
        FloorOperationalMode.Closed => "Đóng — không đặt phòng",
        _ => "Đang mở"
    };

    public static bool IsLockedForBooking(string? statusFromDb) =>
        DeriveMode(statusFromDb) != FloorOperationalMode.Open;
}
