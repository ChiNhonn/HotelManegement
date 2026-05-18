using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using HotelManagement.Models;

namespace HotelManagement.Forms
{

    public partial class InfoCustomerForm : Form
    {
        public Customer Customer { get; private set; }
        private int _customerId = 0;
        /// <summary>Bản gốc khi mở form sửa — giữ CCCD/SĐT/email và metadata không có trên UI.</summary>
        private Customer _loadedForEdit;

        public InfoCustomerForm(bool isEditMode, bool isAddMode, Customer customer = null)
        {
            InitializeComponent();
            SetupValidationEvents();
            if (isEditMode)
            {
                btnThem.Visible = false;
                btnScanCCCD.Visible = false;
            }
            else if (isAddMode)
            {
                btnSua.Visible = false;
            }
            if (customer != null)
            {
                _loadedForEdit = customer;
                _customerId = customer.Id;
                txtNo.Text = customer.No ?? "";
                txtFullName.Text = customer.FullName;
                dtpBirthDay.Value = customer.BirthDay;
                if (customer.Gender == 1)
                {
                    rbNam.Checked = true;
                }
                else
                {
                    rbNu.Checked = true;
                }
                txtXa.Text = customer.Xa;
                txtHuyen.Text = customer.Huyen;
                txtTinh.Text = customer.Tinh;
                txtCountry.Text = customer.Country;
            }
        }


        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InfoCustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void SetupValidationEvents()
        {
            // 1. Sự kiện tự động nhảy ô khi nhấn Enter
            txtNo.KeyDown += ChuyenO_KeyDown;
            txtFullName.KeyDown += ChuyenO_KeyDown;
            dtpBirthDay.KeyDown += ChuyenO_KeyDown;
            txtXa.KeyDown += ChuyenO_KeyDown;
            txtHuyen.KeyDown += ChuyenO_KeyDown;
            txtTinh.KeyDown += ChuyenO_KeyDown;
            txtCountry.KeyDown += ChuyenO_KeyDown;

            // 2. Sự kiện viết hoa chữ cái đầu khi rời khỏi ô Họ Tên
            txtFullName.Leave += TxtFullName_Leave;

            // 3. Sự kiện chỉ cho phép nhập số vào ô CCCD
            txtNo.KeyPress += TxtNo_KeyPress;
        }


        // Xử lý tự động nhảy sang ô tiếp theo khi nhấn Enter
        private void ChuyenO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        // Xử lý chuẩn hóa Họ và Tên
        private void TxtFullName_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                txtFullName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtFullName.Text.ToLower().Trim());
            }
        }

        // Xử lý chặn nhập chữ và khoảng trắng vào ô CCCD
        private void TxtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Xử lý Validate khi bấm nút Thêm
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            // 1. KIỂM TRA ĐIỀN ĐẦY ĐỦ THÔNG TIN
            if (string.IsNullOrWhiteSpace(txtNo.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtXa.Text) ||
                string.IsNullOrWhiteSpace(txtHuyen.Text) ||
                string.IsNullOrWhiteSpace(txtTinh.Text) ||
                string.IsNullOrWhiteSpace(txtCountry.Text) ||
                (!rbNam.Checked && !rbNu.Checked))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả thông tin khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. KIỂM TRA ĐỘ TUỔI (Phải >= 18 tuổi)
            DateTime ngaySinh = dtpBirthDay.Value;
            DateTime homNay = DateTime.Today;
            int tuoi = homNay.Year - ngaySinh.Year;

            // Trừ đi 1 tuổi nếu chưa tới ngày sinh nhật trong năm nay
            if (ngaySinh.Date > homNay.AddYears(-tuoi))
            {
                tuoi--;
            }

            if (tuoi < 18)
            {
                MessageBox.Show("Khách hàng phải từ 18 tuổi trở lên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Customer = new Customer
            {
                No = txtNo.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                BirthDay = dtpBirthDay.Value,
                Gender = rbNam.Checked ? 1 : 0,
                Xa = txtXa.Text.Trim(),
                Huyen = txtHuyen.Text.Trim(),
                Tinh = txtTinh.Text.Trim(),
                Country = txtCountry.Text.Trim(),
                Status = "Đang ở",
                SoftDelete = null
            };

            this.DialogResult = DialogResult.OK;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // 1. KIỂM TRA ĐIỀN ĐẦY ĐỦ THÔNG TIN
            if (string.IsNullOrWhiteSpace(txtNo.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtXa.Text) ||
                string.IsNullOrWhiteSpace(txtHuyen.Text) ||
                string.IsNullOrWhiteSpace(txtTinh.Text) ||
                string.IsNullOrWhiteSpace(txtCountry.Text) ||
                (!rbNam.Checked && !rbNu.Checked))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả thông tin khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. KIỂM TRA ĐỘ TUỔI (Phải >= 18 tuổi)
            DateTime ngaySinh = dtpBirthDay.Value;
            DateTime homNay = DateTime.Today;
            int tuoi = homNay.Year - ngaySinh.Year;

            // Trừ đi 1 tuổi nếu chưa tới ngày sinh nhật trong năm nay
            if (ngaySinh.Date > homNay.AddYears(-tuoi))
            {
                tuoi--;
            }

            if (tuoi < 18)
            {
                MessageBox.Show("Khách hàng phải từ 18 tuổi trở lên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Customer = new Customer
            {
                Id = _customerId,
                No = txtNo.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                BirthDay = dtpBirthDay.Value,
                Gender = rbNam.Checked ? 1 : 0,
                Xa = txtXa.Text.Trim(),
                Huyen = txtHuyen.Text.Trim(),
                Tinh = txtTinh.Text.Trim(),
                Country = txtCountry.Text.Trim(),
                Status = "Đang ở",
                SoftDelete = null,
                CitizenId = _loadedForEdit?.CitizenId,
                Phone = _loadedForEdit?.Phone,
                Email = _loadedForEdit?.Email,
                CreateAt = _loadedForEdit?.CreateAt ?? DateTime.Now,
                Vip = _loadedForEdit?.Vip ?? 0
            };
            this.DialogResult = DialogResult.OK;
        }
    }
}
