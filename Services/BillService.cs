using HotelManagement.Interfaces;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using System.Linq;

public class BillService : IBillService
{
    private readonly IBillRepository _billRepository;

    public BillService(IBillRepository billRepository)
    {
        _billRepository = billRepository;
    }

    public List<BillView> GetAllBills()
    {
        return _billRepository.GetAllBills();
    }

    public List<BillView> GetBillsByStatus(string status)
    {
        return _billRepository.GetBillsByStatus(status);
    }

    public List<BillView> GetBillsByDateRange(DateTime fromDate, DateTime toDate)
    {
        return _billRepository.GetBillsByDateRange(fromDate, toDate);
    }
    public List<BillView> SearchBills(string keyword)
    {
        return _billRepository.SearchBills(keyword);
    }
    public void MergeBills(List<BillView> selectedBills)
    {
        if (selectedBills == null || selectedBills.Count < 2)
        {
            throw new ArgumentException("Phải chọn ít nhất 2 hóa đơn để ghép.");
        }

        List<int> billIds = selectedBills.Select(b => b.Id).ToList();

        _billRepository.MergeBills(billIds);
    }

    public BillDetailView GetBillDetail(int billId)
    {
        var bill = _billRepository.GetBillWithDetails(billId);

        if (bill == null) return null;

        var detailIds = bill.BillDetails?.Select(d => d.Id).ToList() ?? new List<int>();
        var immediatePaidIds = _billRepository.GetBillDetailIdsWithImmediatePayment(detailIds);

        var fullyPaid = BillIsFullyPaidForDetail(bill);

        var itemViewModels = (bill.BillDetails ?? Enumerable.Empty<BillDetail>())
            .OrderBy(d => d.Id)
            .Select(bd =>
            {
                var imm = immediatePaidIds.Contains(bd.Id);
                return new BillItemView
                {
                    Product = imm ? $"{bd.Product} (Đã thanh toán ngay)" : bd.Product,
                    Quantity = bd.Quantity,
                    UnitPrice = bd.UnitPrice,
                    SubTotal = imm ? 0 : bd.SubTotal
                };
            })
            .ToList();

        var lineSum = itemViewModels.Sum(i => i.SubTotal);
        var totalDue = fullyPaid ? 0m : Math.Max(0m, lineSum - bill.Discount + bill.Tax);

        return new BillDetailView
        {
            BillId = bill.Id,
            CustomerName = (bill.Order != null && bill.Order.Customer != null) ? bill.Order.Customer.FullName : "Khách lẻ",
            CheckIn = bill.Order != null ? bill.Order.DateCheckIn : DateTime.MinValue,
            CheckOut = bill.Order?.DateCheckOut,
            Discount = bill.Discount,
            Tax = bill.Tax,
            DepositAmount = bill.Order?.DepositAmount ?? 0,
            TotalAmount = totalDue,
            Items = itemViewModels
        };
    }

    private static bool PaymentLooksSuccessful(string? status)
    {
        if (string.IsNullOrWhiteSpace(status)) return false;
        var s = status.Trim().ToLowerInvariant();
        return s is "success" or "successful" or "succeeded" or "paid" or "completed" or "done";
    }

    private static bool BillStatusLooksPaid(string? status)
    {
        if (string.IsNullOrWhiteSpace(status)) return false;
        var s = status.Trim().ToLowerInvariant();
        return s is "paid" or "completed" or "settled" or "closed"
               || s.Contains("đã thanh toán", StringComparison.OrdinalIgnoreCase)
               || s.Contains("đã đóng", StringComparison.OrdinalIgnoreCase);
    }

    private static bool BillIsFullyPaidForDetail(Bill bill) =>
        BillStatusLooksPaid(bill.Status)
        || (bill.Payments != null && bill.Payments.Any(p => p.SoftDelete == null && PaymentLooksSuccessful(p.Status)));
}
