using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        if (!string.IsNullOrEmpty(status) && status != "Tất cả")
        {
            switch (status)
            {
                case "Đã thanh toán":
                    query = query.Where(b =>
                        b.Status == "Paid" || b.Status == "paid" || b.Status == "Completed" || b.Status == "completed"
                        || b.Payments.Any(p => p.SoftDelete == null &&
                            (p.Status == "Paid" || p.Status == "paid" || p.Status == "Success" || p.Status == "success"
                             || p.Status == "Successful" || p.Status == "successful"
                             || p.Status == "Completed" || p.Status == "completed" || p.Status == "Done" || p.Status == "done")));
                    break;
                case "Chưa thanh toán":
                    query = query.Where(b =>
                        (b.Status != "Paid" && b.Status != "paid" && b.Status != "Completed" && b.Status != "completed")
                        && !b.Payments.Any(p => p.SoftDelete == null &&
                            (p.Status == "Paid" || p.Status == "paid" || p.Status == "Success" || p.Status == "success"
                             || p.Status == "Successful" || p.Status == "successful"
                             || p.Status == "Completed" || p.Status == "completed" || p.Status == "Done" || p.Status == "done")));
                    break;
                default:
                    query = query.Where(b => b.Status == status);
                    break;
            }
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

    // Hàm phụ trợ: map Bill → BillView (tiền còn phải thu, trạng thái hiển thị tiếng Việt).
    private List<BillView> ProjectToBillView(IQueryable<Bill> query)
    {
        var bills = query
            .AsNoTracking()
            .Include(b => b.Order!).ThenInclude(o => o.Customer)
            .Include(b => b.Order!).ThenInclude(o => o.OrderDetails!).ThenInclude(od => od.Room)
            .Include(b => b.BillDetails!)
            .Include(b => b.Payments!)
            .OrderByDescending(b => b.CreateAt)
            .ToList();

        var detailIds = bills
            .SelectMany(b => b.BillDetails ?? Enumerable.Empty<BillDetail>())
            .Select(d => d.Id)
            .Distinct()
            .ToList();

        var immediatePaid = GetBillDetailIdsWithImmediatePayment(detailIds);

        return bills.Select(b => MapBillToView(b, immediatePaid)).ToList();
    }

    private static BillView MapBillToView(Bill b, HashSet<int> immediatePaidDetailIds)
    {
        var fullyPaid = BillIsFullyPaid(b);

        var lineOthers = (b.BillDetails ?? Enumerable.Empty<BillDetail>())
            .Where(d => !immediatePaidDetailIds.Contains(d.Id))
            .Sum(d => d.SubTotal);

        var displayTotal = fullyPaid ? 0m : Math.Max(0m, lineOthers - b.Discount + b.Tax);

        var displayStatus = fullyPaid ? "Đã thanh toán"
            : string.Equals(b.Status, "Pending", StringComparison.OrdinalIgnoreCase) ? "Chưa thanh toán"
            : (b.Status ?? "");

        var roomName = (b.Order?.OrderDetails != null && b.Order.OrderDetails.Any(od => od.Room != null))
            ? b.Order.OrderDetails.Where(od => od.Room != null).Select(od => od.Room!.Name).FirstOrDefault() ?? "N/A"
            : "N/A";

        return new BillView
        {
            Id = b.Id,
            BillID = "HD" + b.Id,
            CustomerName = (b.Order != null && b.Order.Customer != null) ? b.Order.Customer.FullName : "Khách lẻ",
            CreatedDate = b.CreateAt,
            TotalAmount = displayTotal,
            Status = displayStatus,
            RoomName = roomName
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

    private static bool BillIsFullyPaid(Bill b) =>
        BillStatusLooksPaid(b.Status)
        || (b.Payments != null && b.Payments.Any(p => p.SoftDelete == null && PaymentLooksSuccessful(p.Status)));

    public HashSet<int> GetBillDetailIdsWithImmediatePayment(IReadOnlyCollection<int> billDetailIds)
    {
        if (billDetailIds == null || billDetailIds.Count == 0)
            return new HashSet<int>();

        var ids = billDetailIds.Distinct().ToList();

        return _context.ServiceOrders.AsNoTracking()
            .Where(so => so.SoftDelete == null
                         && so.ImmediatePaidAt != null
                         && so.IdBillDetail != null
                         && ids.Contains(so.IdBillDetail.Value))
            .Select(so => so.IdBillDetail!.Value)
            .ToHashSet();
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
            .Include(b => b.Order!)
                .ThenInclude(o => o.Customer)
            .Include(b => b.BillDetails!)
            .Include(b => b.Payments!)
            .FirstOrDefault(b => b.Id == billId);
    }
}