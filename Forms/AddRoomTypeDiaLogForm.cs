using HotelManagement.Services;
using HotelManagement.Models;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagement.Forms
{
    public partial class AddRoomTypeDiaLogForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IRoomService _phongService;
        public AddRoomTypeDiaLogForm(IServiceProvider serviceProvider, IRoomTypeService roomTypeService, IRoomService roomService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _roomTypeService = roomTypeService;
            _roomService = roomService;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtThemLoaiPhong.Text))
            {
                MessageBox.Show("Tên loại phòng không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtThemLoaiPhong.Focus();
                return;
            }
            if (txtThemLoaiPhong.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Tên loại phòng không được chứa số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtThemLoaiPhong.Focus();
                return;
            }
            var them = new RoomType
            {
                TenLoaiPhong = txtThemLoaiPhong.Text,
                SucChuaToiDa = (byte)numSucChuaToiDa.Value,
                GiaCoBan = numGia.Value,
                MoTa = txtMoTa.Text
            };
            try
            {
                _roomTypeService.Add(them);
                MessageBox.Show("Thêm loại phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var result = MessageBox.Show("Bạn có muốn thêm phòng cho loại phòng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    this.Tag = them;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.Tag = null;
                    this.DialogResult = DialogResult.OK;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm loại phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
