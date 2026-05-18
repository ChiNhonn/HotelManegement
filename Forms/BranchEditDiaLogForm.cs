using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Interfaces;

namespace HotelManagement.Forms
{
    public partial class BranchEditDiaLogForm : Form
    {
        private readonly IBranchService _branchService;
        private int? _branchId;

        public BranchEditDiaLogForm(IBranchService branchService)
        {
            _branchService = branchService ?? throw new ArgumentNullException(nameof(branchService));
            InitializeComponent();
            txtPhone.PlaceholderText = "VD: 0901234567";
            txtHouseNumber.PlaceholderText = "VD: 123A";
            txtStreetName.PlaceholderText = "VD: Nguyễn Văn Linh";
            txtCommune.PlaceholderText = "VD: Phường Bến Nghé";
            txtCity.PlaceholderText = "VD: TP. Hồ Chí Minh";
            txtCountry.PlaceholderText = "VD: Việt Nam";
        }

        public void Setup(int? branchId)
        {
            _branchId = branchId;

        }

        private void BranchEditDiaLogForm_Load(object sender, EventArgs e)
        {
            if (_branchId.HasValue)
            {
                this.Text = "Chỉnh sửa thông tin Chi nhánh";
                LoadBranchDataForEdit(_branchId.Value);
            }
            else
            {
                this.Text = "Thêm mới Chi nhánh";
                ClearInputs();
            }
        }

        #region CÁC HÀM XỬ LÝ NHẬP LIỆU (VALIDATION & FORMAT) CHUẨN KÉO THẢ

        // Hàm này sẽ được gọi từ giao diện Designer khi nhập Số điện thoại
        private void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Hàm này sẽ được gọi từ giao diện Designer khi nhập Thành phố, Quốc gia
        private void OnlyLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Hàm này sẽ được gọi khi rời chuột (Leave) khỏi ô chữ
        private void AutoCapitalize_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox txt && !string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = FormatTitleCase(txt.Text);
            }
        }

        private string FormatTitleCase(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            TextInfo textInfo = new CultureInfo("vi-VN", false).TextInfo;
            return textInfo.ToTitleCase(text.Trim().ToLower());
        }

        #endregion

        private void LoadBranchDataForEdit(int id)
        {
            try
            {
                var branch = _branchService.GetAllBranches().FirstOrDefault(b => b.Id == id);

                if (branch != null)
                {
                    txtPhone.Text = branch.Phone;
                    txtHouseNumber.Text = branch.HouseNumber;
                    txtStreetName.Text = branch.StreetName;
                    txtCommune.Text = branch.Commune;
                    txtCity.Text = branch.City;
                    txtCountry.Text = branch.Country;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu chi nhánh yêu cầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chi nhánh: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtStreetName.Text) || string.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin bắt buộc: Số điện thoại, Tên đường và Thành phố!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tự động viết hoa chữ đầu trước khi lưu
            txtStreetName.Text = FormatTitleCase(txtStreetName.Text);
            txtCommune.Text = FormatTitleCase(txtCommune.Text);
            txtCity.Text = FormatTitleCase(txtCity.Text);
            txtCountry.Text = FormatTitleCase(txtCountry.Text);

            try
            {
                // 1. TẠO ĐỐI TƯỢNG BRANCH CHỨA DỮ LIỆU TỪ GIAO DIỆN
                var branchToSave = new HotelManagement.Models.Branch
                {
                    // Nếu _branchId là null (đang ở chế độ thêm mới) thì gán Id = 0.
                    // BranchService của bạn sẽ tự hiểu Id = 0 là Add, khác 0 là Update.
                    Id = _branchId ?? 0,

                    Phone = txtPhone.Text.Trim(),
                    HouseNumber = txtHouseNumber.Text.Trim(),
                    StreetName = txtStreetName.Text.Trim(),
                    Commune = txtCommune.Text.Trim(),
                    City = txtCity.Text.Trim(),
                    Country = txtCountry.Text.Trim()
                };

                // 2. GỌI HÀM SAVEBRANCH TỪ SERVICE BẠN VỪA VIẾT
                _branchService.SaveBranch(branchToSave);

                // 3. THÔNG BÁO KẾT QUẢ VÀ ĐÓNG FORM
                if (!_branchId.HasValue)
                {
                    MessageBox.Show("Thêm mới chi nhánh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin chi nhánh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu chi nhánh: " + ex.Message, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ClearInputs()
        {
            txtPhone.Clear();
            txtHouseNumber.Clear();
            txtStreetName.Clear();
            txtCommune.Clear();
            txtCity.Clear();
            txtCountry.Clear();
        }
    }
}