using HotelManagement.Forms;
using HotelManagement.Models;
using HotelManagement.Services;
using HotelManagement.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelManagement.CustomControls
{
    public partial class usRoom : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRoomService _phongService;
        private readonly IRoomTypeService _loaiPhongService;

        public usRoom(IServiceProvider serviceProvider, IRoomService phongService, IRoomTypeService loaiPhongService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _phongService = phongService;
            _loaiPhongService = loaiPhongService;
            dgvDSPhong.DataBindingComplete += DgvDSPhong_DataBindingComplete;
        }

        private void DgvDSPhong_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvDSPhong.Columns.Count == 0) return;

            if (dgvDSPhong.Columns["MaPhong"] != null)
                dgvDSPhong.Columns["MaPhong"].Visible = false;

            if (dgvDSPhong.Columns["SoPhong"] != null)
                dgvDSPhong.Columns["SoPhong"].HeaderText = "Số phòng";

            if (dgvDSPhong.Columns["LoaiPhong"] != null)
                dgvDSPhong.Columns["LoaiPhong"].HeaderText = "Loại phòng";

            if (dgvDSPhong.Columns["Tang"] != null)
                dgvDSPhong.Columns["Tang"].HeaderText = "Tầng (Floors.Name)";

            if (dgvDSPhong.Columns["TrangThai"] != null)
                dgvDSPhong.Columns["TrangThai"].HeaderText = "Trạng thái";
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            var them = _serviceProvider.GetRequiredService<AddRoomDialogForm>();
            if (them.ShowDialog() == DialogResult.OK)
            {
                loadPhong();

                dgvDSPhong.DataSource = _phongService.GetAll().OrderByDescending(x => x.MaPhong).ToList();
            }
        }
        private void GanSuKienBoChon(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button) continue;

                control.MouseDown += BoChonDGV;
                if (control.HasChildren)
                    GanSuKienBoChon(control);
            }
        }
        private void BoChonDGV(object sender, MouseEventArgs e)
        {
            dgvDSPhong.ClearSelection();
            dgvDSPhong.CurrentCell = null;

            dgvDSLoaiPhong.ClearSelection();
            dgvDSLoaiPhong.CurrentCell = null;
        }
        private void loadPhong()
        {
            dgvDSPhong.DataSource = _phongService.GetAll();

            dgvDSLoaiPhong.DataSource = _loaiPhongService.GetAllWithRoomCount();
            this.BeginInvoke(
                new Action(() =>
                {
                    dgvDSPhong.ClearSelection();
                    dgvDSPhong.CurrentCell = null;

                    dgvDSLoaiPhong.ClearSelection();
                    dgvDSLoaiPhong.CurrentCell = null;
                })
            );
        }

        private void loadComboRoomType()
        {
            var ds = _loaiPhongService.GetAll();
            ds.Insert(0, new RoomType { MaLoaiPhong = 0, TenLoaiPhong = "--Chọn loại phòng--" });
            cboLocLoaiPhong.DataSource = ds;
            cboLocLoaiPhong.DisplayMember = "TenLoaiPhong";
            cboLocLoaiPhong.ValueMember = "MaLoaiPhong";

            var dsLoaiPhongView = _loaiPhongService.GetAllWithRoomCount();
            dsLoaiPhongView.Insert(0, new RoomTypeView { MaLoaiPhong = 0, TenLoaiPhong = "--Chọn loại phòng--" });
            cboLoaiPhong.DataSource = dsLoaiPhongView;
            cboLoaiPhong.DisplayMember = "TenLoaiPhong";
            cboLoaiPhong.ValueMember = "MaLoaiPhong";
        }
        private void loadTrangThai()
        {
            cboLocTrangThai.Items.Add("--Chọn trạng thái--");
            cboLocTrangThai.Items.Add("Sẵn sàng");
            cboLocTrangThai.Items.Add("Đang ở");
            cboLocTrangThai.Items.Add("Bảo trì");
            cboLocTrangThai.SelectedIndex = 0;
        }
        private void loadComboSapXep()
        {
            cboSapXep.Items.Add("--Chọn sắp xếp--");
            cboSapXep.Items.Add("Giá tăng dần");
            cboSapXep.Items.Add("Giá giảm dần");
            cboSapXep.SelectedIndex = 0;
        }
        private void usPhong_Load(object sender, EventArgs e)
        {
            loadPhong();
            loadTrangThai();
            loadComboRoomType();
            loadComboSapXep();
            GanSuKienBoChon(this);
            // Tab Loại phòng — cấu hình cột sau khi đã bind dữ liệu
            if (dgvDSLoaiPhong.Columns["MaLoaiPhong"] != null)
                dgvDSLoaiPhong.Columns["MaLoaiPhong"].Visible = false;
            if (dgvDSLoaiPhong.Columns["TenLoaiPhong"] != null)
                dgvDSLoaiPhong.Columns["TenLoaiPhong"].HeaderText = "Tên Loại Phòng";
            if (dgvDSLoaiPhong.Columns["SucChuaToiDa"] != null)
                dgvDSLoaiPhong.Columns["SucChuaToiDa"].HeaderText = "Sức Chứa Tối Đa";
            if (dgvDSLoaiPhong.Columns["Gia"] != null)
            {
                dgvDSLoaiPhong.Columns["Gia"].DefaultCellStyle.Format = "C0";
                dgvDSLoaiPhong.Columns["Gia"].HeaderText = "Giá Cơ Bản";
            }
            if (dgvDSLoaiPhong.Columns["SoLuongPhong"] != null)
                dgvDSLoaiPhong.Columns["SoLuongPhong"].HeaderText = "Số Lượng Phòng";
            if (dgvDSLoaiPhong.Columns["MoTa"] != null)
                dgvDSLoaiPhong.Columns["MoTa"].HeaderText = "Mô Tả";
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string search = txtTimKiem.Text.Trim();
            if (search == "")
            {
                loadPhong();
                return;
            }
            else
            {
                dgvDSPhong.DataSource = _phongService.Search(search);
            }
        }

        private void cboLocLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLocLoaiPhong.SelectedValue == null) return;

            RoomType lp = (RoomType)cboLocLoaiPhong.SelectedItem;

            int roomTypeId = lp.MaLoaiPhong;
            dgvDSPhong.DataSource = _phongService.GetByRoomType(roomTypeId);
            dgvDSPhong.ClearSelection();
        }
        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string trangthai = cboLocTrangThai.Text;
            if (trangthai == "--Chọn trạng thái--")
            {
                loadPhong();
                return;
            }
            else
            {
                dgvDSPhong.DataSource = _phongService.GetByStatus(trangthai);
            }
        }

        private void dgvDSPhong_MouseDown(object sender, MouseEventArgs e)
        {
            var hit = dgvDSPhong.HitTest(e.X, e.Y);
            if (hit.RowIndex == -1)
            {
                dgvDSPhong.ClearSelection();
                dgvDSPhong.CurrentCell = null;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocLoaiPhong.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndex = 0;
            loadPhong();
            dgvDSPhong.ClearSelection();
            dgvDSPhong.CurrentCell = null;
        }

        private void btnXoaPhong_Click(object sender, EventArgs e)
        {
            if (dgvDSPhong.CurrentRow == null)
            {
                MessageBox.Show("Chưa chọn phòng để xóa");
                return;
            }
            int maPhong = Convert.ToInt32(dgvDSPhong.CurrentRow.Cells["MaPhong"].Value);
            var confirm = MessageBox.Show("Bạn có chắc muốn xóa phòng này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No)
                return;

            try
            {
                _phongService.Delete(maPhong);
                MessageBox.Show("Xóa phòng thành công");
                loadPhong();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if (dgvDSPhong.CurrentRow == null)
            {
                MessageBox.Show("Chưa chọn phòng để chỉnh sửa");
                return;
            }
            int maPhong = Convert.ToInt32(dgvDSPhong.CurrentRow.Cells["MaPhong"].Value);
            using (var sua = ActivatorUtilities.CreateInstance<UpdateRoomDialogForm>(_serviceProvider, maPhong))
            {
                if (sua.ShowDialog() == DialogResult.OK)
                {
                    loadPhong();
                }
            }
        }

        private void txtThanhTimKiem2_TextChanged(object sender, EventArgs e)
        {
            string search = txtThanhTimKiem2.Text.Trim();
            if (search == "")
            {
                loadPhong();
                return;
            }
            else
            {
                dgvDSLoaiPhong.DataSource = _loaiPhongService.Search(search);
            }
        }

        private void cboLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiPhong.SelectedValue == null) return;

            RoomTypeView lpv = (RoomTypeView)cboLoaiPhong.SelectedItem;

            int roomTypeId = lpv.MaLoaiPhong;
            dgvDSLoaiPhong.DataSource = _loaiPhongService.GetByRoomType(roomTypeId);
            dgvDSLoaiPhong.ClearSelection();
        }

        private void cboSapXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = _loaiPhongService.GetAllWithRoomCount();
            if (cboSapXep.Text == "Giá tăng dần")
            {
                list = list.OrderBy(x => x.Gia).ToList();
            }
            else if (cboSapXep.Text == "Giá giảm dần")
            {
                list = list.OrderByDescending(x => x.Gia).ToList();
            }
            dgvDSLoaiPhong.DataSource = list;
            dgvDSLoaiPhong.ClearSelection();
        }

        private void btnLocTheoGia_Click(object sender, EventArgs e)
        {
            decimal giaMin = numGiaMin.Value;
            decimal giaMax = numGiaMax.Value;
            if (giaMin < 0 || giaMax < 0)
            {
                MessageBox.Show("Giá không được âm!");
                return;
            }
            if (giaMin > giaMax)
            {
                MessageBox.Show("Giá tối thiểu không được lớn hơn giá tối đa!");
                return;
            }
            else if (giaMax < giaMin)
            {
                MessageBox.Show("Giá tối đa không được nhỏ hơn giá tối thiểu!");
                return;
            }
            var list = _loaiPhongService.GetByPriceRange(giaMin, giaMax);
            var result = list.Where(x => x.Gia >= giaMin && x.Gia <= giaMax).ToList();
            dgvDSLoaiPhong.DataSource = result;
            dgvDSLoaiPhong.ClearSelection();
            dgvDSLoaiPhong.CurrentCell = null;
        }

        private void btnLamMoi2_Click(object sender, EventArgs e)
        {
            txtThanhTimKiem2.Clear();
            cboLoaiPhong.SelectedIndex = 0;
            cboSapXep.SelectedIndex = 0;
            numGiaMax.Value = 0;
            numGiaMin.Value = 0;
            loadPhong();
            dgvDSLoaiPhong.ClearSelection();
            dgvDSLoaiPhong.CurrentCell = null;
        }

        private void btnThem2_Click(object sender, EventArgs e)
        {
            var formthemloai = _serviceProvider.GetRequiredService<AddRoomTypeDiaLogForm>();
            if (formthemloai.ShowDialog() == DialogResult.OK)
            {
                loadPhong();
                var loaiphong = formthemloai.Tag as RoomType;
                if (loaiphong != null)
                {
                    var frmThemPhong = _serviceProvider.GetRequiredService<AddRoomDialogForm>();
                    frmThemPhong.MaLoaiPhong = loaiphong.MaLoaiPhong;
                    frmThemPhong.IsFromLoaiPhong = true;
                    frmThemPhong.ShowDialog();
                }
            }
            loadPhong();
        }

        private void btnXoa2_Click(object sender, EventArgs e)
        {
            if (dgvDSLoaiPhong.CurrentRow == null)
            {
                MessageBox.Show("Chưa chọn loại phòng để xóa");
                return;
            }
            int maLoaiPhong = Convert.ToInt32(dgvDSLoaiPhong.CurrentRow.Cells["MaLoaiPhong"].Value);
            var confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa loại phòng này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (confirm == DialogResult.No) return;
            try
            {
                _loaiPhongService.Delete(maLoaiPhong);
                MessageBox.Show("Xóa loại phòng thành công");
                loadPhong();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua2_Click(object sender, EventArgs e)
        {
            if (dgvDSLoaiPhong.CurrentRow == null)
            {
                MessageBox.Show("Chưa chọn phòng để chỉnh sửa");
                return;
            }
            int maLoaiPhong = Convert.ToInt32(dgvDSLoaiPhong.CurrentRow.Cells["MaLoaiPhong"].Value);
            using (var sua = ActivatorUtilities.CreateInstance<UpdateRoomTypeDialogForm>(_serviceProvider, maLoaiPhong))
            {
                if (sua.ShowDialog() == DialogResult.OK)
                {
                    loadPhong();
                }
            }
        }
    }
}
