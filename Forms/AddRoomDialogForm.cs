using HotelManagement.Models;
using HotelManagement.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagement.Forms
{
    public partial class AddRoomDialogForm : Form
    {
        public int MaLoaiPhong { get; set; }
        public bool IsFromLoaiPhong { get; set; }
        private readonly IRoomTypeService _roomTypeService;
        private readonly IRoomService _roomService;
        public AddRoomDialogForm(IRoomTypeService loaiPhongService, IRoomService phongService)
        {
            InitializeComponent();
            _roomTypeService = loaiPhongService;
            _roomService = phongService;
        }

        private void loadComboRoomType()
        {
            var ds = _roomTypeService.GetAll();
            cboLoaiPhong.DataSource = ds;
            cboLoaiPhong.DisplayMember = "TenLoaiPhong";
            cboLoaiPhong.ValueMember = "MaLoaiPhong";
            if (IsFromLoaiPhong && MaLoaiPhong > 0)
            {
                cboLoaiPhong.SelectedValue = MaLoaiPhong;
                cboLoaiPhong.Enabled = false;
            }
        }
        private void loadStatus()
        {
            cboTrangThai.Items.Add("Sẵn sàng");
            cboTrangThai.Items.Add("Đang ở");
            cboTrangThai.Items.Add("Bảo trì");
            cboTrangThai.SelectedIndex = 0;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            {
                MessageBox.Show("Chưa nhập số phòng");
                txtSoPhong.Focus();
                return;
            }
            if (!char.IsDigit(txtSoPhong.Text[0]))
            {
                MessageBox.Show("Số phòng phải bắt đầu bằng số!");
                txtSoPhong.Clear();
                txtSoPhong.Focus();
                return;
            }
            var phong = new Room
            {
                SoPhong = txtSoPhong.Text,
                MaLoaiPhong = (int)cboLoaiPhong.SelectedValue,
                Tang = (byte)numTang.Value,
                TrangThai = cboTrangThai.SelectedItem.ToString(),
                GhiChu = txtMoTa.Text
            };
            try
            {
                _roomService.Add(phong);
                MessageBox.Show("Thêm phòng thành công");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ThemPhongDialogForm_Load(object sender, EventArgs e)
        {
            loadComboRoomType();
            loadStatus();
        }

        private void txtSoPhong_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSoPhong.Text))
            {
                numTang.Value = 0;
                return;
            }
            if(int.TryParse(txtSoPhong.Text, out int soPhong))
            {
                numTang.Value = (soPhong / 100);
            }
        }
    }
}
