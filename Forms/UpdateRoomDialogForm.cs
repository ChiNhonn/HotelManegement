using QuanLyKhachSan.Services;
using QuanLyKhachSan.Models;
using Microsoft.Extensions.DependencyInjection;
namespace HotelManagement.Forms
{
    public partial class UpdateRoomDialogForm : Form
    {
        private readonly IRoomService _phongService;
        private readonly IRoomTypeService _loaiPhongService;
        private int _maPhong;
        public UpdateRoomDialogForm(IRoomService phongService, IRoomTypeService loaiPhongService, int maPhong)
        {
            InitializeComponent();
            _phongService = phongService;
            _loaiPhongService = loaiPhongService;
            _maPhong = maPhong;
        }
        private void loadComboRoomType()
        {
            var ds = _loaiPhongService.GetAll();
            cboLoaiPhong.DataSource = ds;
            cboLoaiPhong.DisplayMember = "TenLoaiPhong";
            cboLoaiPhong.ValueMember = "MaLoaiPhong";
        }
        private void loadStatus()
        {
            cboTrangThai.Items.Add("Sẵn sàng");
            cboTrangThai.Items.Add("Đang ở");
            cboTrangThai.Items.Add("Bảo trì");
            cboTrangThai.SelectedIndex = 0;
        }
        private void loadData()
        {
            var phong = _phongService.GetById(_maPhong);
            if (phong != null)
            {
                txtSoPhong.Text = phong.SoPhong;
                cboLoaiPhong.SelectedValue = phong.MaLoaiPhong;
                cboTrangThai.SelectedItem = phong.TrangThai;
                numTang.Value = (byte)phong.Tang;
                txtMoTa.Text = phong.GhiChu;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var phong = new Room
            {
                MaPhong = _maPhong,
                SoPhong = txtSoPhong.Text,
                MaLoaiPhong = (int)cboLoaiPhong.SelectedValue,
                Tang = (byte)numTang.Value,
                TrangThai = cboTrangThai.SelectedItem.ToString(),
                GhiChu = txtMoTa.Text
            };
            try
            {
                _phongService.Update(phong);
                MessageBox.Show("Cập nhập phòng thành công");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void SuaPhongDialogForm_Load(object sender, EventArgs e)
        {
            loadComboRoomType();
            loadStatus();
            loadData();
        }

        private void txtSoPhong_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoPhong.Text))
            {
                numTang.Value = 0;
                return;
            }
            if (int.TryParse(txtSoPhong.Text, out int soPhong))
            {
                numTang.Value = (soPhong / 100);
            }
        }
    }
}
