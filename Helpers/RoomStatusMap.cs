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
        ["out_of_order"] = "Hỏng / Khóa",
        ["inactive"] = "Ngưng dùng",
    };

    private static readonly Dictionary<string, string> ViToDb = new()
    {
        ["Sẵn sàng"] = "available",
        ["Đang ở"] = "occupied",
        ["Bảo trì"] = "maintenance",
        ["Hỏng / Khóa"] = "out_of_order",
        ["Ngưng dùng"] = "inactive",
    };

    private static readonly Dictionary<string, string> EnUiToDb = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Available"] = "available",
        ["Occupied"] = "occupied",
        ["Maintenance"] = "maintenance",
        ["Out of order"] = "out_of_order",
        ["Disabled"] = "inactive",
    };

    private static readonly Dictionary<string, string> DbToEn = new(StringComparer.OrdinalIgnoreCase)
    {
        ["available"] = "Available",
        ["vacant"] = "Available",
        ["free"] = "Available",
        ["occupied"] = "Occupied",
        ["in_use"] = "Occupied",
        ["busy"] = "Occupied",
        ["booked"] = "Occupied",
        ["maintenance"] = "Maintenance",
        ["repair"] = "Maintenance",
        ["out_of_order"] = "Out of order",
        ["inactive"] = "Disabled",
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
        if (EnUiToDb.TryGetValue(s, out db))
            return db;

        if (DbToVi.ContainsKey(s))
            return s.ToLowerInvariant();

        return s.ToLowerInvariant();
    }

    /// <summary>English label for room status dropdowns (Forms).</summary>
    public static string ToDisplayEnglish(string? statusFromDb)
    {
        if (string.IsNullOrWhiteSpace(statusFromDb))
            return "";

        var s = statusFromDb.Trim();
        if (DbToEn.TryGetValue(s, out var en))
            return en;

        if (EnUiToDb.ContainsKey(s))
            return s;

        return s;
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

    /// <summary>Phân loại trạng thái vật lý cho sơ đồ mini (ưu tiên bảo trì → dọn → có khách → trống).</summary>
    public static RoomPhysicalStatusKind ClassifyPhysicalKind(string? status)
    {
        if (string.IsNullOrWhiteSpace(status))
            return RoomPhysicalStatusKind.Unknown;

        var s = status.Trim();
        var lower = s.ToLowerInvariant();

        if (lower is "inactive" || lower.Contains("ngưng") || lower.Contains("ngung"))
            return RoomPhysicalStatusKind.Maintenance;

        if (lower.Contains("maint") || lower.Contains("repair") || lower is "out_of_order" or "ooo"
            || lower.Contains("broken") || lower.Contains("hỏng") || lower.Contains("hong")
            || lower.Contains("bảo trì") || lower.Contains("bao tri"))
            return RoomPhysicalStatusKind.Maintenance;

        if (lower is "dirty" or "cleaning" or "needs_cleaning" || lower.Contains("need_clean")
            || lower.Contains("housekeep") || lower.Contains("cần dọn") || lower.Contains("can don")
            || lower.Contains("đang dọn") || lower.Contains("dang don"))
            return RoomPhysicalStatusKind.Cleaning;

        if (lower is "occupied" or "in_use" or "busy" or "booked" or "checked_in" or "checkedin"
            || lower.Contains("checked in") || lower.Contains("có khách") || lower.Contains("co khach")
            || lower.Contains("đang ở") || lower.Contains("dang o"))
            return RoomPhysicalStatusKind.Occupied;

        if (lower is "available" or "vacant" or "free" or "empty"
            || lower.Contains("trống") || lower.Contains("trong") || lower.Contains("sẵn sàng")
            || lower.Contains("san sang"))
            return RoomPhysicalStatusKind.Vacant;

        if (DbToVi.TryGetValue(s, out _))
        {
            var canonical = ToDatabase(s).ToLowerInvariant();
            return ClassifyPhysicalKind(canonical);
        }

        return RoomPhysicalStatusKind.Unknown;
    }

    /// <summary>Nhóm vận hành (mở / ngưng / hỏng) để hiển thị trên lưới quản lý phòng.</summary>
    public static string OperationalUiLabel(string? statusFromDb)
    {
        if (string.IsNullOrWhiteSpace(statusFromDb))
            return "Đang mở";

        var lower = statusFromDb.Trim().ToLowerInvariant();
        if (lower == "inactive")
            return "Ngưng dùng";
        if (lower is "out_of_order" or "ooo")
            return "Hỏng / Khóa";

        var kind = ClassifyPhysicalKind(statusFromDb);
        if (kind == RoomPhysicalStatusKind.Maintenance)
            return "Bảo trì";

        return "Đang mở";
    }

    public static RoomOperationalMode DeriveOperationalMode(string? statusFromDb)
    {
        if (string.IsNullOrWhiteSpace(statusFromDb))
            return RoomOperationalMode.Active;
        var l = statusFromDb.Trim().ToLowerInvariant();
        if (l == "inactive")
            return RoomOperationalMode.Inactive;
        if (l is "out_of_order" or "ooo")
            return RoomOperationalMode.OutOfOrder;
        return RoomOperationalMode.Active;
    }
}
