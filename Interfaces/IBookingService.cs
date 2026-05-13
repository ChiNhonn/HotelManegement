using HotelManagement.ViewModels;

namespace HotelManagement.Interfaces;

public interface IBookingService
{
    /// <summary>Tạo đơn đặt phòng + khách, cập nhật phòng sang occupied.</summary>
    void CreateReservation(ReservationRequest request);

    /// <param name="forRoomId">Ưu tiên dòng chi tiết gắn phòng này (sơ đồ đặt phòng).</param>
    BookingDetailsDto GetBookingDetails(int orderId, int? forRoomId = null);

    /// <summary>Trả phòng tại ngày thực tế (có thể sớm hơn ngày trả dự kiến).</summary>
    void CheckoutEarly(int orderId, DateTime actualCheckoutDate);

    /// <summary>Cập nhật đơn: không đổi số phòng, hạng phòng, đơn giá đêm trên dòng phòng.</summary>
    void UpdateBooking(ReservationUpdateRequest request);
}
