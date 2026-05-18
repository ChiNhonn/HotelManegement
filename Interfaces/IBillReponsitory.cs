using HotelManagement.Models;
using HotelManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Interfaces
{
    public interface IBillRepository
    {
        List<BillView> GetAllBills();
        List<BillView> GetBillsByStatus(string status);
        List<BillView> GetBillsByDateRange(DateTime fromDate, DateTime toDate);
        List<BillView> SearchBills(string keyword);
        void MergeBills(List<int> billIds);
        Bill GetBillWithDetails(int billId);

        /// <summary>Id các dòng BillDetail đã thu tiền « thanh toán ngay » (ImmediatePaidAt).</summary>
        HashSet<int> GetBillDetailIdsWithImmediatePayment(IReadOnlyCollection<int> billDetailIds);
    }
}
