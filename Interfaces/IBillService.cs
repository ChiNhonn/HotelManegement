using HotelManagement.Services;
using HotelManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Interfaces
{
    public interface IBillService
    {
        List<BillView> GetAllBills();
        List<BillView> GetBillsByStatus(string status);
        List<BillView> GetBillsByDateRange(DateTime fromDate, DateTime toDate);
        List<BillView> SearchBills(string keyword);
        void MergeBills(List<BillView> selectedBills);
        BillDetailView GetBillDetail(int billId);
    }
}
