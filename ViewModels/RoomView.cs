namespace HotelManagement.ViewModels
{
    /// <summary>
    /// Row for room list grid: matches DB columns Name, Status, IdRoomType, IdFloor (+ joined type/floor names).
    /// </summary>
    public class RoomView
    {
        public int RoomId { get; set; }

        public string RoomNumber { get; set; } = "";

        public string RoomTypeName { get; set; } = "";

        /// <summary>Floor name from Floors (Floor.Name).</summary>
        public string FloorName { get; set; } = "";

        /// <summary>Localized status label for display.</summary>
        public string StatusDisplay { get; set; } = "";

        /// <summary>Raw Status in DB (for filters / operations).</summary>
        public string? StatusDb { get; set; }

        public int? IdFloor { get; set; }
        public int? IdRoomType { get; set; }
    }
}
