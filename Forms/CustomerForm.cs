using DocumentFormat.OpenXml.Drawing;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using HotelManagement.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace HotelManagement.Forms
{
    public partial class CustomerForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public CustomerForm(IMyDbContext dbContext, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            SetupDataGridView();

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void CustomerForm_Load(object sender, EventArgs e)
        {
            cboFilter.Items.Clear();
            cboFilter.Items.Add("Tất cả trạng thái"); // Sẽ tương ứng với Index 0
            cboFilter.Items.Add("Đang ở");            // Sẽ tương ứng với Index 1
            cboFilter.Items.Add("Đã đi");             // Sẽ tương ứng với Index 2

            cboFilter.DropDownStyle = ComboBoxStyle.DropDownList;

            cboFilter.SelectedIndex = 0;

            cboSapXep.Items.Clear();
            cboSapXep.Items.Add("Mặc định"); // Tương ứng Index 0
            cboSapXep.Items.Add("Cũ nhất");       // Tương ứng Index 1
            cboSapXep.Items.Add("Mới nhất");      // Tương ứng Index 2

            cboSapXep.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSapXep.SelectedIndex = 0;

            await LoadData();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnAddCustomer_Click(object sender, EventArgs e)
        {
            bool isAdd = true;
            bool isEdit = false;
            using (var scope = _serviceProvider.CreateScope())
            {
                var customerServices = scope.ServiceProvider.GetRequiredService<ICustomerServices>();
                var infoCustomerForm = new InfoCustomerForm(isEdit, isAdd);
                DialogResult result = infoCustomerForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    bool addResult = await customerServices.Add(infoCustomerForm.Customer);
                    if (addResult)
                    {
                        await LoadData();
                        MessageBox.Show("Khách hàng đã được thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra khi thêm khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                else
                {
                    MessageBox.Show("Người dùng đã hủy thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SetupDataGridView()
        {
            dgvCustomer.AutoGenerateColumns = false;
            dgvCustomer.ScrollBars = ScrollBars.Both;
            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 1. Cấu hình các thuộc tính chung cho Grid
            dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomer.ReadOnly = true;
            dgvCustomer.AllowUserToAddRows = false;
            dgvCustomer.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // 2. TẠO CÁC CỘT DỮ LIỆU BẰNG CODE

            // Cột Id (Ẩn)
            var colId = new DataGridViewTextBoxColumn();
            colId.Name = "Id";
            colId.DataPropertyName = "Id";
            colId.Visible = false;
            dgvCustomer.Columns.Add(colId);

            // Cột Số CCCD
            var colNo = new DataGridViewTextBoxColumn();
            colNo.Name = "No";
            colNo.DataPropertyName = "No";
            colNo.HeaderText = "Số CCCD";
            colNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCustomer.Columns.Add(colNo);

            // Cột Họ và tên
            var colFullName = new DataGridViewTextBoxColumn();
            colFullName.Name = "FullName";
            colFullName.DataPropertyName = "FullName";
            colFullName.HeaderText = "Họ và tên";
            colFullName.Width = 150;
            dgvCustomer.Columns.Add(colFullName);

            // Cột Ngày sinh
            var colBirthDay = new DataGridViewTextBoxColumn();
            colBirthDay.Name = "BirthDay";
            colBirthDay.DataPropertyName = "BirthDay";
            colBirthDay.HeaderText = "Ngày sinh";
            dgvCustomer.Columns.Add(colBirthDay);

            // Cột Giới tính
            var colGender = new DataGridViewTextBoxColumn();
            colGender.Name = "Gender";
            colGender.DataPropertyName = "Gender";
            colGender.HeaderText = "Giới tính";
            dgvCustomer.Columns.Add(colGender);

            // Cột Xã
            var colXa = new DataGridViewTextBoxColumn();
            colXa.Name = "Xa";
            colXa.DataPropertyName = "Xa";
            colXa.HeaderText = "Xã";
            dgvCustomer.Columns.Add(colXa);

            // Cột Huyện
            var colHuyen = new DataGridViewTextBoxColumn();
            colHuyen.Name = "Huyen";
            colHuyen.DataPropertyName = "Huyen";
            colHuyen.HeaderText = "Huyện";
            dgvCustomer.Columns.Add(colHuyen);

            // Cột Tỉnh
            var colTinh = new DataGridViewTextBoxColumn();
            colTinh.Name = "Tinh";
            colTinh.DataPropertyName = "Tinh";
            colTinh.HeaderText = "Tỉnh";
            dgvCustomer.Columns.Add(colTinh);

            // Cột Quốc tịch
            var colCountry = new DataGridViewTextBoxColumn();
            colCountry.Name = "Country";
            colCountry.DataPropertyName = "Country";
            colCountry.HeaderText = "Quốc tịch";
            dgvCustomer.Columns.Add(colCountry);

            // Cột Trạng thái
            var colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "Status";
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "Trạng thái";
            dgvCustomer.Columns.Add(colStatus);

            // Cột VIP
            var colVip = new DataGridViewTextBoxColumn();
            colVip.Name = "Vip";
            colVip.DataPropertyName = "Vip";
            colVip.HeaderText = "VIP";
            dgvCustomer.Columns.Add(colVip);


            // 3. THÊM CÁC CỘT NÚT BẤM THAO TÁC
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.Name = "btnEdit";
            btnEdit.HeaderText = "Thao tác sửa";
            btnEdit.Text = "Sửa";
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.Width = 60;
            dgvCustomer.Columns.Add(btnEdit);

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "btnSoftDelete";
            btnDelete.HeaderText = "Thao tác xóa";
            btnDelete.Text = "Xóa";
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.Width = 60;
            dgvCustomer.Columns.Add(btnDelete);
        }

        private async void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dgvCustomer.Columns[e.ColumnIndex].Name;

            var selectedCustomer = dgvCustomer.Rows[e.RowIndex].DataBoundItem as Customer;

            if (selectedCustomer == null) return;

            if (columnName == "btnEdit")
            {
                bool isAdd = false;
                bool isEdit = true;
                using (var scope = _serviceProvider.CreateScope())
                {
                    var customerServices = scope.ServiceProvider.GetRequiredService<ICustomerServices>();
                    var infoCustomerForm = new InfoCustomerForm(isEdit, isAdd, selectedCustomer);
                    DialogResult result = infoCustomerForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        bool updateResult = await customerServices.Update(infoCustomerForm.Customer);
                        if (updateResult)
                        {
                            await LoadData();
                            MessageBox.Show("Khách hàng đã được cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi xảy ra khi cập nhật khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    else
                    {
                        MessageBox.Show("Người dùng đã hủy thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (columnName == "btnSoftDelete")
            {
                int customerId = selectedCustomer.Id;

                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa khách hàng: {selectedCustomer.FullName}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var customerServices = scope.ServiceProvider.GetRequiredService<ICustomerServices>();

                        bool isDeleted = await customerServices.SoftDelete(customerId);

                        if (isDeleted)
                        {
                            MessageBox.Show("Đã xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            await LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra khi xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private async Task LoadData()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<IMyDbContext>())
                {
                    var allCustomers = await context.Customers.Where(c => c.SoftDelete == null).ToListAsync();

                    if (allCustomers != null)
                    {
                        lblPeople.Text = allCustomers.Count.ToString();
                        lblVIP.Text = allCustomers.Count(c => c.Vip == 1).ToString();
                        lblInHouse.Text = allCustomers.Count(c => c.Status != null && c.Status.Contains("Đang ở")).ToString();
                        lblLeave.Text = allCustomers.Count(c => c.Status != null && c.Status.Contains("Đã đi")).ToString();
                    }

                    var query = context.Customers.Where(c => c.SoftDelete == null).AsQueryable();

                    string keyword = txtFind.Text.Trim(); 
                    if (!string.IsNullOrEmpty(keyword))
                    {query = query.Where(c => c.FullName.Contains(keyword));
                    }

                    if (cboFilter.SelectedIndex == 1)
                    {
                        query = query.Where(c => c.Status == "Đang ở");
                    }
                    else if (cboFilter.SelectedIndex == 2)
                    {
                        query = query.Where(c => c.Status == "Đã đi");
                    }

                    if (cboSapXep.SelectedIndex == 1)
                    {
                        query = query.OrderBy(c => c.Id);
                    }
                    else if (cboSapXep.SelectedIndex == 2)
                    {
                        query = query.OrderByDescending(c => c.Id);
                    }

                    int limit = (int)numShow.Value;
                    if (limit > 0)
                    {
                        query = query.Take(limit);
                    }

                    var gridCustomers = await query.ToListAsync();
                    dgvCustomer.DataSource = gridCustomers;
                }
            }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu khách hàng đang hiển thị trực tiếp từ DataGridView
            var customers = dgvCustomer.DataSource as List<Customer>;

            if (customers == null || customers.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.Title = "Chọn nơi lưu báo cáo khách hàng";
                sfd.FileName = "BaoCaoKhachHang_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var customerServices = scope.ServiceProvider.GetRequiredService<ICustomerServices>();
                        bool isSuccess = customerServices.ExportCustomersToExcel(customers, sfd.FileName);

                        if (isSuccess)
                        {
                            DialogResult result = MessageBox.Show(
                                "Xuất báo cáo thành công! Bạn có muốn mở file lên xem ngay không?",
                                "Thành công",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                                {
                                    FileName = sfd.FileName,
                                    UseShellExecute = true
                                });
                            }
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra trong quá trình xuất file.\nFile có thể đang được mở bởi chương trình khác.", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private async void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void cboSapXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void numShow_ValueChanged(object sender, EventArgs e)
        {
            await LoadData();
        }

        private void txtFind_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private async void txtFind_TextChanged(object sender, EventArgs e)
        {
            await LoadData();
        }
    }
}
