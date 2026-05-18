namespace HotelManagement.ViewModels;

/// <summary>Chỉ số dashboard trong ngày hiện tại (theo giờ máy).</summary>
public sealed class DashboardTodayMetrics
{
    public int VacantRooms { get; init; }
    public int ArrivalsToday { get; init; }
    public int DeparturesToday { get; init; }
    public decimal RevenueToday { get; init; }
}
