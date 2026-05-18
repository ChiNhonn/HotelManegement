using System;
using System.Collections.Generic;

namespace HotelManagement.ViewModels
{
    // Class tổng hợp thông tin chi tiết của 1 hóa đơn
    public class BillDetailView
    {
        public int BillId { get; set; }
        public string CustomerName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal DepositAmount { get; set; } // Tiền cọc từ Order
        public decimal TotalAmount { get; set; } // Tổng thanh toán

        // Danh sách các dịch vụ, tiền phòng, phụ thu...
        public List<BillItemView> Items { get; set; } = new List<BillItemView>();
    }

    // Class chi tiết từng dòng trong hóa đơn (từ bảng BillDetails)
    public class BillItemView
    {
        public string Product { get; set; } // Tên phòng, tên dịch vụ, tên đồ hỏng
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
    }
}