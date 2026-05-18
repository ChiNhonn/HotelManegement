using HotelManagement.Interfaces;
using HotelManagement.ViewModels;

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

        // Trích xuất ra danh sách ID (int) từ danh sách BillView
        List<int> billIds = selectedBills.Select(b => b.Id).ToList();

        // Gọi tầng Repository xử lý DB
        _billRepository.MergeBills(billIds);
    }
    public BillDetailView GetBillDetail(int billId)
    {
        // 1. Gọi Repository để lấy dữ liệu gốc (Entity)
        var bill = _billRepository.GetBillWithDetails(billId);

        if (bill == null) return null; // Trả về null nếu không tìm thấy hóa đơn

        // 2. Chuyển đổi danh sách BillDetails sang BillItemView
        var itemViewModels = new List<BillItemView>();

        if (bill.BillDetails != null)
        {
            itemViewModels = bill.BillDetails.Select(bd => new BillItemView
            {
                Product = bd.Product,
                Quantity = bd.Quantity,
                UnitPrice = bd.UnitPrice,
                SubTotal = bd.SubTotal
            }).ToList();
        }

        // 3. Map toàn bộ thông tin sang BillDetailViewModel
        return new BillDetailView
        {
            BillId = bill.Id,
            CustomerName = (bill.Order != null && bill.Order.Customer != null) ? bill.Order.Customer.FullName : "Khách lẻ",
            CheckIn = bill.Order != null ? bill.Order.DateCheckIn : DateTime.MinValue,
            CheckOut = bill.Order?.DateCheckOut,
            Discount = bill.Discount,
            Tax = bill.Tax,
            DepositAmount = bill.Order?.DepositAmount ?? 0,
            TotalAmount = bill.TotalAmount,
            Items = itemViewModels
        };
    }
}