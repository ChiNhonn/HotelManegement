using System;
using System.Linq;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data;

/// <summary>
/// Xóa dữ liệu khách / đặt phòng / hóa đơn để test lại (dev).
/// Kích hoạt một lần qua biến môi trường <c>HOTEL_RESET_CUSTOMERS=1</c> trong <see cref="Program"/>.
/// </summary>
public static class DemoCustomerBookingReset
{
    /// <summary>
    /// Xóa vĩnh viễn: khách (SoftDelete null), đơn hoạt động, chi tiết đơn, hóa đơn &amp; chi tiết &amp; thanh toán gắn đơn,
    /// ServiceOrders của các đơn đó; gỡ liên kết CK đến ServiceOrder; đặt phòng liên quan về <c>available</c>.
    /// </summary>
    public static void ClearAllCustomersOrdersAndBills(HotelDbContext db)
    {
        var strategy = db.Database.CreateExecutionStrategy();
        strategy.Execute(() =>
        {
            using var tx = db.Database.BeginTransaction();
            try
            {
                var orderIds = db.Orders.AsNoTracking()
                    .Where(o => o.SoftDelete == null)
                    .Select(o => o.Id)
                    .ToList();

                var roomIds = db.OrderDetails.AsNoTracking()
                    .Where(od => od.IdOrder != null && orderIds.Contains(od.IdOrder.Value) && od.IdRoom != null)
                    .Select(od => od.IdRoom!.Value)
                    .Distinct()
                    .ToList();

                db.BankTransferInbounds
                    .Where(x => x.MatchedServiceOrderId != null && x.SoftDelete == null)
                    .ExecuteUpdate(s => s.SetProperty(x => x.MatchedServiceOrderId, (int?)null));

                if (orderIds.Count > 0)
                {
                    db.ServiceOrders.Where(so => orderIds.Contains(so.IdOrder)).ExecuteDelete();

                    var billIds = db.Bills.AsNoTracking()
                        .Where(b => b.SoftDelete == null
                                    && b.IdOrder != null
                                    && orderIds.Contains(b.IdOrder.Value))
                        .Select(b => b.Id)
                        .ToList();

                    if (billIds.Count > 0)
                    {
                        db.BillDetails.Where(bd => bd.IdBill != null && billIds.Contains(bd.IdBill.Value)).ExecuteDelete();
                        db.Payments.Where(p => p.IdBill != null && billIds.Contains(p.IdBill.Value)).ExecuteDelete();
                        db.Bills.Where(b => billIds.Contains(b.Id)).ExecuteDelete();
                    }

                    db.OrderDetails.Where(od => od.IdOrder != null && orderIds.Contains(od.IdOrder.Value)).ExecuteDelete();
                    db.Orders.Where(o => orderIds.Contains(o.Id)).ExecuteDelete();
                }

                db.Customers.Where(c => c.SoftDelete == null).ExecuteDelete();

                var now = DateTime.Now;
                foreach (var rid in roomIds)
                {
                    var room = db.Rooms.FirstOrDefault(r => r.Id == rid && r.SoftDelete == null);
                    if (room == null)
                        continue;
                    room.Status = "available";
                    room.UpdateAt = now;
                }

                db.SaveChanges();
                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        });
    }
}
