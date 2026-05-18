using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

public class BillRepository : IBillRepository
{
    private readonly HotelDbContext _context;

    public BillRepository(HotelDbContext context)
    {
        _context = context;
    }

    private IQueryable<Bill> ActiveBills => _context.Bills.Where(b => b.SoftDelete == null);

    // Hàm lấy tất cả (Không lọc)
    public List<BillView> GetAllBills()
    {
        return ProjectToBillView(ActiveBills);
    }

    // HÀM 1: CHỈ LỌC THEO STATUS
    public List<BillView> GetBillsByStatus(string status)
    {
        var query = ActiveBills.AsNoTracking();

        // Nếu chọn khác "Tất cả" thì lấy chữ tiếng Việt đó đem đi lọc luôn
        if (!string.IsNullOrEmpty(status) && status != "Tất cả")
        {
            query = query.Where(b => b.Status == status);
        }

        return ProjectToBillView(query);
    }

    // HÀM 2: CHỈ LỌC THEO DATETIME
    public List<BillView> GetBillsByDateRange(DateTime fromDate, DateTime toDate)
    {
        var start = fromDate.Date;
        var end = toDate.Date.AddDays(1).AddTicks(-1);

        var query = ActiveBills.AsNoTracking()
                               .Where(b => b.CreateAt >= start && b.CreateAt <= end);

        return ProjectToBillView(query);
    }

    // Hàm phụ trợ (Helper) để gom code Select tránh viết lặp đi lặp lại
    private List<BillView> ProjectToBillView(IQueryable<Bill> query)
    {
        return query
            .Include(b => b.Order).ThenInclude(o => o.Customer)
            .Include(b => b.Order).ThenInclude(o => o.OrderDetails).ThenInclude(od => od.Room)
            .OrderByDescending(b => b.CreateAt)
            .Select(b => new BillView
            {
                Id = b.Id,
                BillID = "HD" + b.Id,
                CustomerName = (b.Order != null && b.Order.Customer != null) ? b.Order.Customer.FullName : "Khách lẻ",
                CreatedDate = b.CreateAt,
                TotalAmount = b.TotalAmount,
                Status = b.Status,
                RoomName = (b.Order != null && b.Order.OrderDetails != null && b.Order.OrderDetails.Any())
                                ? b.Order.OrderDetails.Where(od => od.Room != null).Select(od => od.Room.Name).FirstOrDefault() ?? "N/A"
                                : "N/A"
            })
            .ToList();
    }
    public List<BillView> SearchBills(string keyword)
    {
        // Nếu từ khóa trống, trả về tất cả hóa đơn
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return GetAllBills();
        }

        var k = keyword.Trim().ToLower();

        // Lấy danh sách hóa đơn chưa xóa mềm
        var query = ActiveBills.AsNoTracking();

        // Lưu ý: Vì các trường RoomName và CustomerName được tạo ra ở bước Select (Projection),
        // nên để EF Core có thể dịch xuống SQL, chúng ta sẽ lọc dựa trên các bảng gốc (Bills, Orders, Customers, Rooms)
        query = query.Where(b =>
            // 1. Tìm theo Mã HĐ (Ví dụ nhập "HD1" hoặc "1" đều ra)
            ("hd" + b.Id).Contains(k) ||
            b.Id.ToString().Contains(k) ||

            // 2. Tìm theo Tên khách hàng (Nếu có)
            (b.Order != null && b.Order.Customer != null && b.Order.Customer.FullName.ToLower().Contains(k)) ||

            // 3. Tìm theo Tên phòng (Nếu có phòng trong chi tiết)
            (b.Order != null && b.Order.OrderDetails.Any(od => od.Room != null && od.Room.Name.ToLower().Contains(k)))
        );

        // Chuyển đổi sang List<BillView> thông qua hàm helper đã viết trước đó
        return ProjectToBillView(query);
    }
    public void MergeBills(List<int> billIds)
    {
        if (billIds == null || billIds.Count < 2) return;

        // 1. Lấy ra hóa đơn gốc (Hóa đơn đầu tiên trong danh sách)
        int originalBillId = billIds[0];
        var originalBill = _context.Bills
            .Include(b => b.BillDetails)
            .FirstOrDefault(b => b.Id == originalBillId && b.SoftDelete == null);

        if (originalBill == null) throw new Exception("Không tìm thấy hóa đơn gốc để ghép!");

        decimal newTotalAmount = originalBill.TotalAmount;

        // 2. Duyệt qua các hóa đơn phụ còn lại để gom detail và tiền
        for (int i = 1; i < billIds.Count; i++)
        {
            int subBillId = billIds[i];
            var subBill = _context.Bills
                .Include(b => b.BillDetails)
                .FirstOrDefault(b => b.Id == subBillId && b.SoftDelete == null);

            if (subBill != null)
            {
                // Cộng dồn tổng tiền
                newTotalAmount += subBill.TotalAmount;

                // Chuyển toàn bộ chi tiết (BillDetails) của bill phụ sang bill gốc
                if (subBill.BillDetails != null)
                {
                    foreach (var detail in subBill.BillDetails.ToList())
                    {
                        detail.IdBill = originalBillId; // Đổi ID hóa đơn tham chiếu
                    }
                }

                // Xóa mềm hóa đơn phụ này đi
                subBill.SoftDelete = DateTime.Now;
            }
        }

        // 3. Cập nhật lại tổng tiền cho hóa đơn gốc
        originalBill.TotalAmount = newTotalAmount;

        // 4. Lưu toàn bộ thay đổi xuống Database (Chạy trong 1 Transaction)
        _context.SaveChanges();
    }
    public Bill GetBillWithDetails(int billId)
    {
        return ActiveBills
            .Include(b => b.Order)
                .ThenInclude(o => o.Customer)
            .Include(b => b.BillDetails)
            .FirstOrDefault(b => b.Id == billId);
    }
}