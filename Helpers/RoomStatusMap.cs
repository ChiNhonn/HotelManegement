using System.Collections.Generic;

namespace HotelManagement.Helpers;

/// <summary>
/// Map trạng thái phòng giữa giá trị lưu trong DB (tiếng Anh/chuẩn ngắn) và nhãn tiếng Việt trên UI.
/// </summary>
public static class RoomStatusMap
{
    private static readonly Dictionary<string, string> DbToVi = new(StringComparer.OrdinalIgnoreCase)
    {
        ["available"] = "Sẵn sàng",
        ["vacant"] = "Sẵn sàng",
        ["free"] = "Sẵn sàng",
        ["occupied"] = "Đang ở",
        ["in_use"] = "Đang ở",
        ["busy"] = "Đang ở",
        ["booked"] = "Đang ở",
        ["maintenance"] = "Bảo trì",
        ["repair"] = "Bảo trì",
        ["out_of_order"] = "Bảo trì",
    };

    private static readonly Dictionary<string, string> ViToDb = new()
    {
        ["Sẵn sàng"] = "available",
        ["Đang ở"] = "occupied",
        ["Bảo trì"] = "maintenance",
    };

    public static string ToDisplay(string? statusFromDb)
    {
        if (string.IsNullOrWhiteSpace(statusFromDb))
            return "";

        var s = statusFromDb.Trim();
        if (DbToVi.TryGetValue(s, out var vi))
            return vi;

        if (ViToDb.ContainsKey(s))
            return s;

        return s;
    }

    public static string ToDatabase(string? uiLabelOrRaw)
    {
        if (string.IsNullOrWhiteSpace(uiLabelOrRaw))
            return "available";

        var s = uiLabelOrRaw.Trim();
        if (ViToDb.TryGetValue(s, out var db))
            return db;

        if (DbToVi.ContainsKey(s))
            return s.ToLowerInvariant();

        return s.ToLowerInvariant();
    }

    /// <summary>Lọc theo UI: khớp cả giá trị DB và tiếng Việt / chuỗi nhập tay.</summary>
    public static bool MatchesFilter(string? dbStatus, string filterFromUi)
    {
        var disp = ToDisplay(dbStatus);
        var dbFromFilter = ToDatabase(filterFromUi);
        return string.Equals(dbStatus, filterFromUi, StringComparison.OrdinalIgnoreCase)
               || string.Equals(dbStatus, dbFromFilter, StringComparison.OrdinalIgnoreCase)
               || string.Equals(disp, filterFromUi, StringComparison.Ordinal)
               || string.Equals(dbStatus, dbFromFilter, StringComparison.OrdinalIgnoreCase);
    }
}
