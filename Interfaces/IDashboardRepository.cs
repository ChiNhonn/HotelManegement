using System;
using System.Collections.Generic;
using HotelManagement.Models;

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
}
