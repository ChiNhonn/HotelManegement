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
        public List<string> ExistingCCCDs { get; set; } = new List<string>();
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
                txtNo.Text = customer.CCCD;
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
                numVip.Value = customer.Vip;
                txtStatus.Text = customer.Status;
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
            txtNo.KeyDown += ChuyenO_KeyDown;
            txtFullName.KeyDown += ChuyenO_KeyDown;
            dtpBirthDay.KeyDown += ChuyenO_KeyDown;
            txtXa.KeyDown += ChuyenO_KeyDown;
            txtHuyen.KeyDown += ChuyenO_KeyDown;
            txtTinh.KeyDown += ChuyenO_KeyDown;
            txtCountry.KeyDown += ChuyenO_KeyDown;

            txtFullName.Leave += TxtFullName_Leave;

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

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNo.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtXa.Text) ||
                string.IsNullOrWhiteSpace(txtHuyen.Text) ||
                string.IsNullOrWhiteSpace(txtTinh.Text) ||
                string.IsNullOrWhiteSpace(txtCountry.Text) ||
                numVip.Value <= 0 ||
                string.IsNullOrWhiteSpace(txtStatus.Text) ||
                (!rbNam.Checked && !rbNu.Checked))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả thông tin khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ExistingCCCDs != null && ExistingCCCDs.Contains(txtNo.Text.Trim()))
            {
                MessageBox.Show("Số CCCD này đã tồn tại trong hệ thống. Vui lòng kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngaySinh = dtpBirthDay.Value;
            DateTime homNay = DateTime.Today;
            int tuoi = homNay.Year - ngaySinh.Year;

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
                CCCD = txtNo.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                BirthDay = dtpBirthDay.Value,
                Gender = rbNam.Checked ? 1 : 0,
                Xa = txtXa.Text.Trim(),
                Huyen = txtHuyen.Text.Trim(),
                Tinh = txtTinh.Text.Trim(),
                Country = txtCountry.Text.Trim(),
                Vip = (int)numVip.Value,
                Status = txtStatus.Text.Trim(),
                SoftDelete = null
            };

            this.DialogResult = DialogResult.OK;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNo.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtXa.Text) ||
                string.IsNullOrWhiteSpace(txtHuyen.Text) ||
                string.IsNullOrWhiteSpace(txtTinh.Text) ||
                string.IsNullOrWhiteSpace(txtCountry.Text) ||
                numVip.Value <= 0 ||
                string.IsNullOrWhiteSpace(txtStatus.Text) ||
                (!rbNam.Checked && !rbNu.Checked))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả thông tin khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ExistingCCCDs != null &&
                txtNo.Text.Trim() != _loadedForEdit?.CCCD &&
                ExistingCCCDs.Contains(txtNo.Text.Trim()))
            {
                MessageBox.Show("Số CCCD này đã thuộc về một khách hàng khác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngaySinh = dtpBirthDay.Value;
            DateTime homNay = DateTime.Today;
            int tuoi = homNay.Year - ngaySinh.Year;

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
                CCCD = txtNo.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                BirthDay = dtpBirthDay.Value,
                Gender = rbNam.Checked ? 1 : 0,
                Xa = txtXa.Text.Trim(),
                Huyen = txtHuyen.Text.Trim(),
                Tinh = txtTinh.Text.Trim(),
                Country = txtCountry.Text.Trim(),
                Vip = (int)numVip.Value,
                Status = txtStatus.Text.Trim(),
                UpdateAt = DateTime.Now
            };
            this.DialogResult = DialogResult.OK;
        }

        private void btnScanCCCD_Click(object sender, EventArgs e)
        {
            using (ScanCCCDForm scanForm = new ScanCCCDForm())
            {
                if (scanForm.ShowDialog() == DialogResult.OK)
                {
                    var result = scanForm.ExtractData;

                    if (result != null)
                    {
                        var textInfo = System.Globalization.CultureInfo.CurrentCulture.TextInfo;

                        txtNo.Text = result.Id;
                        txtFullName.Text = result.FullName;

                        if (!string.IsNullOrWhiteSpace(result.BirthDay))
                        {
                            dtpBirthDay.Value = DateTime.ParseExact(result.BirthDay, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        }

                        if (string.Equals(result.Gender, "Nam", StringComparison.OrdinalIgnoreCase))
                        {
                            rbNam.Checked = true;
                            rbNu.Checked = false;
                        }
                        else
                        {
                            rbNu.Checked = true;
                            rbNam.Checked = false;
                        }

                        txtXa.Text = !string.IsNullOrWhiteSpace(result.Xa)
                            ? textInfo.ToTitleCase(result.Xa.ToLower().Trim())
                            : "";

                        txtHuyen.Text = !string.IsNullOrWhiteSpace(result.Huyen)
                            ? textInfo.ToTitleCase(result.Huyen.ToLower().Trim())
                            : "";

                        txtTinh.Text = !string.IsNullOrWhiteSpace(result.Tinh)
                            ? textInfo.ToTitleCase(result.Tinh.ToLower().Trim())
                            : "";

                        txtCountry.Text = result.Country;

                        MessageBox.Show("Đã lấy thông tin CCCD thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
    }
    }
}
