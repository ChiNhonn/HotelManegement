using HotelManagement.Models;
using HotelManagement.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.Forms
{
    public partial class UpdateRoomTypeDialogForm : Form
    {
        private readonly IRoomService _phongService;
        private readonly IRoomTypeService _loaiPhongService;
        private int _maLoaiPhong;
        public UpdateRoomTypeDialogForm(IRoomService phongService, IRoomTypeService loaiPhongService, int maLoaiPhong)
        {
            InitializeComponent();
            _phongService = phongService;
            _loaiPhongService = loaiPhongService;
            _maLoaiPhong = maLoaiPhong;
        }
        public void loadData()
        {
            var loaiphong = _loaiPhongService.GetById(_maLoaiPhong);
            if (loaiphong != null)
            {
                txtThemLoaiPhong.Text = loaiphong.TenLoaiPhong;
                numGia.Value = loaiphong.GiaCoBan;
                numSucChuaToiDa.Value = loaiphong.SucChuaToiDa;
                txtMoTa.Text = loaiphong.MoTa;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var sua = new RoomType
            {
                MaLoaiPhong = _maLoaiPhong,
                TenLoaiPhong = txtThemLoaiPhong.Text,
                SucChuaToiDa = (byte)numSucChuaToiDa.Value,
                GiaCoBan = numGia.Value,
                MoTa = txtMoTa.Text
            };
            try
            {
                _loaiPhongService.Update(sua);
                MessageBox.Show("Sửa loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa loại phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SuaLPhongDialogForm_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
