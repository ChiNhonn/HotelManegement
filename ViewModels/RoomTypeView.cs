namespace HotelManagement.ViewModels
{
    public class RoomTypeView
    {
        public int RoomTypeId { get; set; }

        /// <summary>Short code (STD, DLX) or em dash when empty.</summary>
        public string Code { get; set; } = "—";

        public string TypeName { get; set; } = string.Empty;

        public decimal UnitPrice { get; set; }

        /// <summary>Capacity text: adults / children.</summary>
        public string CapacityDisplay { get; set; } = string.Empty;

        /// <summary>Total max guests (MaxNumber).</summary>
        public int TotalMaxGuests { get; set; }

        public int RoomCount { get; set; }

        public string Description { get; set; } = string.Empty;

        public string? BedTypeDescription { get; set; }
    }
}
