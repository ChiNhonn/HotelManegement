namespace HotelManagement.ViewModels;

/// <summary>Row for floor management grid.</summary>
public class FloorView
{
    public int FloorId { get; set; }

    public string FloorName { get; set; } = "";

    public string BranchDisplayName { get; set; } = "";

    public int RoomCount { get; set; }

    public int? IdBranch { get; set; }

    /// <summary>Giá trị DB: open, maintenance, closed.</summary>
    public string StatusDb { get; set; } = "open";

    public string StatusDisplay { get; set; } = "";

    public bool IsLockedForBooking { get; set; }
}
