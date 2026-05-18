using System;
using System.Collections.Generic;
using HotelManagement.Models;
using HotelManagement.ViewModels;

namespace HotelManagement.Interfaces;

public interface IDashboardRepository
{
    int CountVacantRooms();

    int CountArrivalsBetween(DateTime startInclusive, DateTime endExclusive);

    int CountDeparturesBetween(DateTime startInclusive, DateTime endExclusive);

    decimal SumBillTotalBetween(DateTime startInclusive, DateTime endExclusive);

    IReadOnlyList<Order> LoadOrdersForPendingDashboard(DateTime createdSince);

    IReadOnlyList<Payment> LoadRecentSuccessfulPayments(int take, int scanBatch = 80);

    IReadOnlyList<StaffPayout> LoadRecentStaffPayouts(int take);

    void AddStaffPayout(StaffPayout payout);

    void SaveChanges();

    IReadOnlyList<Order> LoadOverdueCheckoutsForReminders(DateTime asOf);

    IReadOnlyList<Room> LoadRoomsForHousekeepingScan();

    IReadOnlyList<BillDetail> LoadBillDetailsForServiceReminderScan();

    /// <summary>Yêu cầu dịch vụ module (chờ / đang làm) để hiển thị trong Nhắc nhở trang chủ.</summary>
    IReadOnlyList<ServiceOrder> LoadOpenServiceOrdersForReminders();

    /// <summary>Hóa đơn chưa đánh dấu đã thanh toán — để lễ tân ghi nhận tiền mặt / CK.</summary>
    IReadOnlyList<DashboardBillPickRow> LoadBillsForManualPaymentPick(int take = 80);

    /// <summary>Ghi một khoản thanh toán thành công và đóng hóa đơn.</summary>
    void RecordManualBillPayment(int billId, string method);

    /// <summary>Ghi nhận khoản thu không gắn hóa đơn (tiền mặt / CK).</summary>
    void RecordStandalonePayment(decimal amount, string method);
}
