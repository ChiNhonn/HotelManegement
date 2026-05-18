using HotelManagement.Interfaces;
using HotelManagement.ViewModels;
using System;
using System.Windows.Forms;

namespace HotelManagement.Forms
{
    public partial class BillDetailDialogForm : Form
    {
        private readonly IBillService _billService;
        private int _billId;

        // Constructor GIỜ CHỈ YÊU CẦU IBillService (Để DI Container tự inject chuẩn chỉ)
        public BillDetailDialogForm(IBillService billService)
        {
            InitializeComponent();

            _billService = billService ?? throw new ArgumentNullException(nameof(billService));

            // Đăng ký các sự kiện (Events)
            this.Load += BillDetailDialogForm_Load;
            this.btnClose.Click += btnClose_Click;
        }

        /// <summary>
        /// Hàm Setup dùng để hứng mã ID hóa đơn từ usBill truyền sang trước khi hiển thị Form
        /// </summary>
        public void Setup(int billId)
        {
            _billId = billId;
        }

        private void BillDetailDialogForm_Load(object sender, EventArgs e)
        {
            // 1. Gọi Service để lấy toàn bộ dữ liệu chi tiết của hóa đơn này bằng _billId đã nhận từ Setup
            var data = _billService.GetBillDetail(_billId);

            // 2. Kiểm tra nếu có dữ liệu thì tiến hành đổ lên giao diện
            if (data != null)
            {
                LoadDataToUI(data);
            }
            else
            {
                MessageBox.Show("Không tìm thấy chi tiết cho hóa đơn này!", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Tắt form nếu lỗi
            }
        }

        private void LoadDataToUI(BillDetailView data)
        {
            // --- KHU VỰC HEADER (Thông tin chung) ---
            lblTitle.Text = $"CHI TIẾT HÓA ĐƠN #{data.BillId:D5}";
            lblCustomerName.Text = $"Khách hàng: {data.CustomerName}";
            lblCheckIn.Text = $"Ngày vào: {data.CheckIn:dd/MM/yyyy HH:mm}";

            string checkOutText = data.CheckOut.HasValue ? data.CheckOut.Value.ToString("dd/MM/yyyy HH:mm") : "Chưa trả phòng";
            lblCheckOut.Text = $"Ngày ra: {checkOutText}";

            // --- KHU VỰC BODY (Lưới danh sách dịch vụ) ---
            dgvBillItems.DataSource = data.Items;

            // Tùy chỉnh Header tiếng Việt và định dạng tiền tệ cho DataGridView
            if (dgvBillItems.Columns["Product"] != null)
                dgvBillItems.Columns["Product"].HeaderText = "Nội dung (Phòng / Dịch vụ)";

            if (dgvBillItems.Columns["Quantity"] != null)
                dgvBillItems.Columns["Quantity"].HeaderText = "Số lượng";

            if (dgvBillItems.Columns["UnitPrice"] != null)
            {
                dgvBillItems.Columns["UnitPrice"].HeaderText = "Đơn giá";
                dgvBillItems.Columns["UnitPrice"].DefaultCellStyle.Format = "N0"; // Thêm dấu phẩy hàng nghìn
            }

            if (dgvBillItems.Columns["SubTotal"] != null)
            {
                dgvBillItems.Columns["SubTotal"].HeaderText = "Thành tiền";
                dgvBillItems.Columns["SubTotal"].DefaultCellStyle.Format = "N0"; // Thêm dấu phẩy hàng nghìn
            }

            // --- KHU VỰC FOOTER (Thanh toán tổng) ---
            lblDiscount.Text = $"Giảm giá: - {data.Discount:N0} VNĐ";
            lblTax.Text = $"Thuế VAT: + {data.Tax:N0} VNĐ";
            lblDeposit.Text = $"Đã cọc: - {data.DepositAmount:N0} VNĐ";
            lblTotal.Text = $"TỔNG THANH TOÁN: {data.TotalAmount:N0} VNĐ";
        }

        // Sự kiện khi bấm nút "ĐÓNG LẠI"
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}