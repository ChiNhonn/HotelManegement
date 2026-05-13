namespace HotelManagement.Helpers;

/// <summary>Trạng thái vận hành phòng (khóa sơ đồ / mở lại) — map sang cột Status DB.</summary>
public enum RoomOperationalMode
{
    /// <summary>Mở phòng: gỡ inactive / out_of_order / maintenance-lock về trống.</summary>
    Active = 0,

    /// <summary>Tạm ngưng — <c>inactive</c> (ô xám trên sơ đồ).</summary>
    Inactive = 1,

    /// <summary>Hỏng / khóa — <c>out_of_order</c> (ô xám).</summary>
    OutOfOrder = 2
}
