using ClosedXML.Excel;
using HotelManagement.Forms;
using HotelManagement.Interfaces;
using HotelManagement.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing; // Thêm thư viện dùng để in ấn
using System.Linq;
using System.Windows.Forms;

namespace HotelManagement.CustomControls
{
    public partial class usBill : UserControl
    {
        private readonly IBillService _billService;

        // Biến lưu trữ dữ liệu của hóa đơn đang được chọn để in
        private BillDetailView _billToPrint;

        // ==========================================================
        // 1. KHU VỰC KHỞI TẠO (SETUP & INIT)
        // ==========================================================
        public usBill(IBillService billService)
        {
            InitializeComponent();
            _billService = billService;

            SetupDataGridView();
            InitEvents();

            if (cmbFilterStatus.Items.Count > 0)
            {
                cmbFilterStatus.SelectedIndex = 0;
            }

            LoadAllData();
            this.dgvBill.MouseDown += dgvBill_MouseDown;
        }
        private void dgvBill_MouseDown(object sender, MouseEventArgs e)
        {
            var hit = dgvBill.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.None)
            {
                // 1. Xóa bôi xanh
                dgvBill.CurrentCell = null;
                dgvBill.ClearSelection();

                // 2. Hủy đánh dấu toàn bộ CheckBox
                dgvBill.EndEdit(); // Đảm bảo các ô đang sửa được cập nhật giá trị trước
                foreach (DataGridViewRow row in dgvBill.Rows)
                {
                    if (row.Cells["colCheck"].Value != null && (bool)row.Cells["colCheck"].Value == true)
                    {
                        row.Cells["colCheck"].Value = false;
                    }
                }
            }
        }
        private void SetupDataGridView()
        {
            dgvBill.Columns.Clear();
            dgvBill.AutoGenerateColumns = false;
            dgvBill.ReadOnly = false;

            DataGridViewCheckBoxColumn colCheck = new DataGridViewCheckBoxColumn();
            colCheck.Name = "colCheck";
            colCheck.HeaderText = "";
            colCheck.Width = 40;
            colCheck.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colCheck.ReadOnly = false;
            dgvBill.Columns.Add(colCheck);

            dgvBill.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMaHD", HeaderText = "Mã HĐ", DataPropertyName = "BillID", ReadOnly = true });
            dgvBill.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPhong", HeaderText = "Phòng", DataPropertyName = "RoomName", ReadOnly = true });
            dgvBill.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTenKH", HeaderText = "Khách Hàng", DataPropertyName = "CustomerName", ReadOnly = true });
            dgvBill.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNgayLap", HeaderText = "Ngày Lập", DataPropertyName = "CreatedDate", ReadOnly = true });
            dgvBill.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTongTien", HeaderText = "Tổng Tiền", DataPropertyName = "TotalAmount", ReadOnly = true });
            dgvBill.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTrangThai", HeaderText = "Trạng Thái", DataPropertyName = "Status", ReadOnly = true });

            dgvBill.Columns["colTongTien"].DefaultCellStyle.Format = "N0";
            dgvBill.Columns["colTongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBill.Columns["colNgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            dgvBill.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBill.BringToFront();
        }

        private void InitEvents()
        {
            cmbFilterStatus.SelectedIndexChanged += CmbFilterStatus_SelectedIndexChanged;
            dtpFromDate.ValueChanged += DtpDate_ValueChanged;
            dtpToDate.ValueChanged += DtpDate_ValueChanged;
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        // ==========================================================
        // 2. KHU VỰC HÀM XỬ LÝ DỮ LIỆU DÙNG CHUNG (CORE/HELPERS)
        // ==========================================================
        private void LoadAllData()
        {
            try
            {
                var data = _billService.GetAllBills();

                if (data == null || data.Count == 0)
                {
                    MessageBox.Show("Kết nối SQL thành công nhưng không tìm thấy dữ liệu hóa đơn nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvBill.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message + "\n" + ex.InnerException?.Message, "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<BillView> GetSelectedBills()
        {
            List<BillView> selectedList = new List<BillView>();
            dgvBill.EndEdit();

            foreach (DataGridViewRow row in dgvBill.Rows)
            {
                var isChecked = row.Cells["colCheck"].Value;

                if (isChecked != null && (bool)isChecked == true)
                {
                    if (row.DataBoundItem is BillView bill)
                    {
                        selectedList.Add(bill);
                    }
                }
            }
            return selectedList;
        }

        // ==========================================================
        // 3. KHU VỰC BỘ LỌC VÀ TÌM KIẾM
        // ==========================================================
        private void CmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedStatus = cmbFilterStatus.SelectedItem?.ToString() ?? "Tất cả";
                dgvBill.DataSource = _billService.GetBillsByStatus(selectedStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc trạng thái: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DtpDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value;
                DateTime toDate = dtpToDate.Value;

                if (fromDate.Date > toDate.Date)
                {
                    MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvBill.DataSource = _billService.GetBillsByDateRange(fromDate, toDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc ngày: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text;
                var result = _billService.SearchBills(keyword);
                dgvBill.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cmbFilterStatus.SelectedIndexChanged -= CmbFilterStatus_SelectedIndexChanged;
            dtpFromDate.ValueChanged -= DtpDate_ValueChanged;
            dtpToDate.ValueChanged -= DtpDate_ValueChanged;
            txtSearch.TextChanged -= txtSearch_TextChanged;

            try
            {
                if (cmbFilterStatus.Items.Count > 0)
                    cmbFilterStatus.SelectedIndex = 0;

                dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtpToDate.Value = DateTime.Now;
                txtSearch.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi reset giao diện: " + ex.Message);
            }
            finally
            {
                cmbFilterStatus.SelectedIndexChanged += CmbFilterStatus_SelectedIndexChanged;
                dtpFromDate.ValueChanged += DtpDate_ValueChanged;
                dtpToDate.ValueChanged += DtpDate_ValueChanged;
                txtSearch.TextChanged += txtSearch_TextChanged;
            }

            LoadAllData();
        }

        // ==========================================================
        // 4. KHU VỰC NÚT BẤM XỬ LÝ NGHIỆP VỤ (ACTIONS)
        // ==========================================================

        private void btnMergeBills_Click(object sender, EventArgs e)
        {
            var selectedBills = GetSelectedBills();

            if (selectedBills.Count < 2)
            {
                MessageBox.Show("Vui lòng tích chọn ít nhất 2 hóa đơn để thực hiện ghép bill!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string firstCustomer = selectedBills[0].CustomerName;
            foreach (var bill in selectedBills)
            {
                if (bill.CustomerName != firstCustomer)
                {
                    MessageBox.Show("Không thể ghép các hóa đơn của các khách hàng khác nhau!", "Lỗi hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (bill.Status == "Đã thanh toán")
                {
                    MessageBox.Show($"Hóa đơn {bill.BillID} đã thanh toán, không thể thực hiện ghép nữa!", "Lỗi hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            decimal totalAmount = selectedBills.Sum(b => b.TotalAmount);
            string billIdsText = string.Join(", ", selectedBills.Select(b => b.BillID));

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn ghép các hóa đơn [{billIdsText}] lại không?\nTổng tiền sau khi gộp sẽ là: {totalAmount:N0} VND",
                                                  "Xác nhận ghép hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _billService.MergeBills(selectedBills);
                    MessageBox.Show("Ghép hóa đơn thành công dưới Database!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi ghép hóa đơn: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            var selectedBills = GetSelectedBills();

            if (selectedBills.Count == 0)
            {
                MessageBox.Show("Vui lòng tích chọn ít nhất 1 hóa đơn để xuất Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "DanhSachHoaDon.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("Hóa Đơn");

                            string[] headers = { "Mã HĐ", "Phòng", "Khách Hàng", "Ngày Lập", "Tổng Tiền", "Trạng Thái" };
                            for (int i = 0; i < headers.Length; i++)
                            {
                                ws.Cell(1, i + 1).Value = headers[i];
                                ws.Cell(1, i + 1).Style.Font.Bold = true;
                                ws.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                            }

                            int rowIndex = 2;
                            foreach (var bill in selectedBills)
                            {
                                ws.Cell(rowIndex, 1).Value = bill.BillID;
                                ws.Cell(rowIndex, 2).Value = bill.RoomName;
                                ws.Cell(rowIndex, 3).Value = bill.CustomerName;

                                ws.Cell(rowIndex, 4).Value = bill.CreatedDate;
                                ws.Cell(rowIndex, 4).Style.DateFormat.Format = "dd/MM/yyyy HH:mm";

                                ws.Cell(rowIndex, 5).Value = bill.TotalAmount;
                                ws.Cell(rowIndex, 5).Style.NumberFormat.Format = "#,##0";

                                ws.Cell(rowIndex, 6).Value = bill.Status;
                                rowIndex++;
                            }

                            ws.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show($"Đã xuất {selectedBills.Count} hóa đơn ra file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            var selectedBills = GetSelectedBills();

            if (selectedBills.Count == 0)
            {
                MessageBox.Show("Vui lòng tích chọn ít nhất 1 hóa đơn để xuất file PDF!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuestPDF.Settings.License = LicenseType.Community;

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF Document|*.pdf", FileName = "DanhSachHoaDon.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        QuestPDF.Fluent.Document.Create(container =>
                        {
                            container.Page(page =>
                            {
                                page.Size(PageSizes.A4);
                                page.Margin(1.5f, Unit.Centimetre);
                                page.PageColor(Colors.White);

                                page.DefaultTextStyle(x => x.FontFamily("Arial").FontSize(10.5f));

                                page.Header().Column(column =>
                                {
                                    column.Item().AlignCenter().Text("BÁO CÁO DANH SÁCH HÓA ĐƠN KHÁCH SẠN")
                                        .Bold().FontSize(18).FontColor(Colors.Blue.Darken3);

                                    column.Item().PaddingTop(5).PaddingBottom(15).AlignCenter()
                                        .Text($"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm}")
                                        .Italic().FontSize(10).FontColor(Colors.Grey.Medium);
                                });

                                page.Content().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.ConstantColumn(60);
                                        columns.ConstantColumn(70);
                                        columns.RelativeColumn(2);
                                        columns.RelativeColumn(1.8f);
                                        columns.RelativeColumn(1.5f);
                                        columns.RelativeColumn(1.5f);
                                    });

                                    table.Header(header =>
                                    {
                                        string[] headers = { "Mã HĐ", "Phòng", "Khách Hàng", "Ngày Lập", "Tổng Tiền", "Trạng Thái" };
                                        foreach (var t in headers)
                                        {
                                            header.Cell().Background(Colors.Blue.Darken2)
                                                        .Border(1).BorderColor(Colors.Blue.Darken3)
                                                        .Padding(6).AlignCenter().AlignMiddle()
                                                        .Text(t).Bold().FontColor(Colors.White);
                                        }
                                    });

                                    foreach (var bill in selectedBills)
                                    {
                                        static IContainer FormatDataCell(IContainer c) => c.BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(6).AlignMiddle();

                                        table.Cell().Element(FormatDataCell).AlignCenter().Text(bill.BillID);
                                        table.Cell().Element(FormatDataCell).AlignCenter().Text(bill.RoomName);
                                        table.Cell().Element(FormatDataCell).Text(bill.CustomerName);
                                        table.Cell().Element(FormatDataCell).AlignCenter().Text(bill.CreatedDate.ToString("dd/MM/yyyy HH:mm"));
                                        table.Cell().Element(FormatDataCell).AlignRight().Text(bill.TotalAmount.ToString("N0")).Bold();

                                        var cellStatus = table.Cell().Element(FormatDataCell);

                                        if (bill.Status == "Đã thanh toán")
                                            cellStatus.AlignCenter().Text(bill.Status).FontColor(Colors.Green.Darken2).Bold();
                                        else if (bill.Status == "Chưa thanh toán")
                                            cellStatus.AlignCenter().Text(bill.Status).FontColor(Colors.Orange.Darken3).Bold();
                                        else
                                            cellStatus.AlignCenter().Text(bill.Status).FontColor(Colors.Grey.Darken1);
                                    }
                                });

                                page.Footer().AlignCenter().Text(x =>
                                {
                                    x.CurrentPageNumber();
                                    x.Span(" / ");
                                    x.TotalPages();
                                });
                            });
                        })
                        .GeneratePdf(sfd.FileName);

                        MessageBox.Show($"Đã xuất {selectedBills.Count} hóa đơn ra file PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi kết xuất PDF: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            bool isAllChecked = true;
            foreach (DataGridViewRow row in dgvBill.Rows)
            {
                if (row.Cells["colCheck"].Value == null || (bool)row.Cells["colCheck"].Value == false)
                {
                    isAllChecked = false;
                    break;
                }
            }

            bool newState = !isAllChecked;

            foreach (DataGridViewRow row in dgvBill.Rows)
            {
                row.Cells["colCheck"].Value = newState;
            }
        }

        // ==========================================================
        // 5. KHU VỰC IN HÓA ĐƠN (PRINT BILL)
        // ==========================================================


        // Logic vẽ hóa đơn
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int startX = 50;
            int startY = 50;
            int offset = 0;

            Font fontTitle = new Font("Arial", 18, FontStyle.Bold);
            Font fontHeader = new Font("Arial", 12, FontStyle.Bold);
            Font fontRegular = new Font("Arial", 10, FontStyle.Regular);
            Font fontBold = new Font("Arial", 10, FontStyle.Bold);

            // HEADER
            g.DrawString("KHÁCH SẠN HOTEL MANAGEMENT", fontHeader, Brushes.Black, startX, startY + offset);
            offset += 30;
            g.DrawString("Địa chỉ: 123 Đường ABC, Quận X, TP.HCM", fontRegular, Brushes.Black, startX, startY + offset);
            offset += 40;

            g.DrawString("HÓA ĐƠN THANH TOÁN", fontTitle, Brushes.Black, startX + 220, startY + offset);
            offset += 40;

            // THÔNG TIN KHÁCH
            g.DrawString($"Mã HĐ: #{_billToPrint.BillId:D5}", fontBold, Brushes.Black, startX, startY + offset);
            offset += 25;
            g.DrawString($"Khách hàng: {_billToPrint.CustomerName}", fontRegular, Brushes.Black, startX, startY + offset);
            offset += 25;
            g.DrawString($"Ngày vào: {_billToPrint.CheckIn:dd/MM/yyyy HH:mm}", fontRegular, Brushes.Black, startX, startY + offset);
            g.DrawString($"Ngày ra: {(_billToPrint.CheckOut.HasValue ? _billToPrint.CheckOut.Value.ToString("dd/MM/yyyy HH:mm") : "N/A")}", fontRegular, Brushes.Black, startX + 350, startY + offset);
            offset += 30;

            g.DrawLine(new Pen(System.Drawing.Color.Black, 1), startX, startY + offset, startX + 700, startY + offset);
            offset += 15;

            // BẢNG DỊCH VỤ
            g.DrawString("Nội dung", fontBold, Brushes.Black, startX, startY + offset);
            g.DrawString("SL", fontBold, Brushes.Black, startX + 350, startY + offset);
            g.DrawString("Đơn giá", fontBold, Brushes.Black, startX + 450, startY + offset);
            g.DrawString("Thành tiền", fontBold, Brushes.Black, startX + 580, startY + offset);
            offset += 25;

            g.DrawLine(new Pen(System.Drawing.Color.Gray, 1), startX, startY + offset, startX + 700, startY + offset);
            offset += 15;

            if (_billToPrint.Items != null)
            {
                foreach (var item in _billToPrint.Items)
                {
                    string productName = item.Product.Length > 40 ? item.Product.Substring(0, 40) + "..." : item.Product;
                    g.DrawString(productName, fontRegular, Brushes.Black, startX, startY + offset);
                    g.DrawString(item.Quantity.ToString(), fontRegular, Brushes.Black, startX + 350, startY + offset);
                    g.DrawString(item.UnitPrice.ToString("N0"), fontRegular, Brushes.Black, startX + 450, startY + offset);
                    g.DrawString(item.SubTotal.ToString("N0"), fontRegular, Brushes.Black, startX + 580, startY + offset);
                    offset += 25;
                }
            }

            g.DrawLine(new Pen(System.Drawing.Color.Black, 1), startX, startY + offset, startX + 700, startY + offset); offset += 20;

            // FOOTER (Thanh toán)
            int rightAlignX = startX + 400;

            g.DrawString($"Giảm giá:", fontRegular, Brushes.Black, rightAlignX, startY + offset);
            g.DrawString($"- {_billToPrint.Discount:N0} VNĐ", fontRegular, Brushes.Black, rightAlignX + 150, startY + offset);
            offset += 25;

            g.DrawString($"Thuế VAT:", fontRegular, Brushes.Black, rightAlignX, startY + offset);
            g.DrawString($"+ {_billToPrint.Tax:N0} VNĐ", fontRegular, Brushes.Black, rightAlignX + 150, startY + offset);
            offset += 25;

            g.DrawString($"Đã cọc:", fontRegular, Brushes.Black, rightAlignX, startY + offset);
            g.DrawString($"- {_billToPrint.DepositAmount:N0} VNĐ", fontRegular, Brushes.Black, rightAlignX + 150, startY + offset);
            offset += 25;

            g.DrawString($"TỔNG THANH TOÁN:", fontHeader, Brushes.Black, rightAlignX - 30, startY + offset);
            g.DrawString($"{_billToPrint.TotalAmount:N0} VNĐ", fontHeader, Brushes.Red, rightAlignX + 150, startY + offset);
            offset += 50;

            g.DrawString("Cảm ơn Quý khách và hẹn gặp lại!", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, startX + 250, startY + offset);
        }

        private void dgvBill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedBill = dgvBill.Rows[e.RowIndex].DataBoundItem as BillView;

                if (selectedBill != null)
                {
                    var formDetail = Program.ServiceProvider.GetRequiredService<BillDetailDialogForm>();
                    formDetail.Setup(selectedBill.Id);

                    formDetail.ShowDialog();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var selectedBills = GetSelectedBills();

            if (selectedBills.Count == 0)
            {
                MessageBox.Show("Vui lòng tích chọn 1 hóa đơn để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedBills.Count > 1)
            {
                MessageBox.Show("Bạn chỉ có thể in từng hóa đơn một. Vui lòng bỏ chọn bớt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lấy chi tiết hóa đơn từ cơ sở dữ liệu dựa vào ID đã chọn
                int billIdToPrint = selectedBills[0].Id;
                _billToPrint = _billService.GetBillDetail(billIdToPrint);

                if (_billToPrint == null)
                {
                    MessageBox.Show("Không thể lấy dữ liệu chi tiết của hóa đơn này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thiết lập in ấn
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += PrintDocument_PrintPage;

                PrintPreviewDialog printPreview = new PrintPreviewDialog
                {
                    Document = pd,
                    Width = 800,
                    Height = 600,
                    ShowIcon = false,
                    Text = "Xem trước hóa đơn"
                };

                printPreview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuẩn bị in: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}