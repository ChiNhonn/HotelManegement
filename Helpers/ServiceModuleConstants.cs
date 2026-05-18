namespace HotelManagement.Helpers;

public static class ServiceOrderStatus
{
    public const string Pending = "pending";
    public const string InProgress = "in_progress";
    public const string Completed = "completed";
    public const string Cancelled = "cancelled";

    public static string ToDisplay(string status) => status switch
    {
        Pending => "Chờ xử lý",
        InProgress => "Đang thực hiện",
        Completed => "Đã hoàn thành",
        Cancelled => "Đã hủy",
        _ => status
    };

    public static readonly string[] All = { Pending, InProgress, Completed, Cancelled };
}

public static class ServiceChargeMode
{
    public const string Folio = "folio";
    public const string Immediate = "immediate";

    public static string ToDisplay(string mode) => mode switch
    {
        Folio => "Gộp hóa đơn phòng",
        Immediate => "Thanh toán ngay",
        _ => mode
    };
}

public static class ServicePriceRuleType
{
    public const string HappyHour = "happy_hour";
    public const string Peak = "peak";
    public const string OffPeak = "off_peak";

    public static string ToDisplay(string t) => t switch
    {
        HappyHour => "Happy hour",
        Peak => "Cao điểm",
        OffPeak => "Thấp điểm",
        _ => t
    };
}
