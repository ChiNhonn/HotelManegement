using HotelManagement.ViewModels;

namespace HotelManagement.Interfaces;

public interface IBookingService
{
    /// <summary>Tạo đơn đặt phòng + khách, cập nhật phòng sang occupied.</summary>
    void CreateReservation(ReservationRequest request);

    /// <param name="forRoomId">Ưu tiên dòng chi tiết gắn phòng này (sơ đồ đặt phòng).</param>
    BookingDetailsDto GetBookingDetails(int orderId, int? forRoomId = null);

    /// <summary>Trả phòng tại ngày thực tế (có thể sớm hơn ngày trả dự kiến). Trả về mã hóa đơn để thu tiền.</summary>
    int CheckoutEarly(int orderId, DateTime actualCheckoutDate);

    /// <summary>Mã hóa đơn gắn đơn đặt phòng (tạo nếu chưa có).</summary>
    int GetBillIdForOrder(int orderId);

    /// <summary>
    /// Sau khi thu tiền hóa đơn (dashboard): chốt đêm ở, trả phòng, đánh dấu phòng cần dọn.
    /// Bỏ qua nếu đơn đã trả / đã hủy.
    /// </summary>
    void CompleteStayAfterPayment(int orderId);

    /// <summary>Cập nhật đơn: không đổi số phòng, hạng phòng, đơn giá đêm trên dòng phòng.</summary>
    void UpdateBooking(ReservationUpdateRequest request);
}
