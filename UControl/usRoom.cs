using QuanLyKhachSan.GUI;
using QuanLyKhachSan.Services;
using QuanLyKhachSan.Models;
using Microsoft.Extensions.DependencyInjection;
using QuanLyKhachSan.DTOs;

namespace HotelManagement.UserControl
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
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            var them = _serviceProvider.GetRequiredService<ThemPhongDialogForm>();
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
            dsLoaiPhongView.Insert(0, new LoaiPhongView { MaLoaiPhong = 0, TenLoaiPhong = "--Chọn loại phòng--" });
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
            //Day la cua tab Phong
            dgvDSPhong.Columns["MaPhong"].Visible = false;
            dgvDSPhong.Columns["SoPhong"].HeaderText = "Số Phòng";
            dgvDSPhong.Columns["LoaiPhong"].HeaderText = "Loại Phòng";
            dgvDSPhong.Columns["Tang"].HeaderText = "Tầng";
            dgvDSPhong.Columns["TrangThai"].HeaderText = "Trạng Thái";
            dgvDSPhong.Columns["GhiChu"].HeaderText = "Ghi Chú";
            //Day la cua tab LoaiPhong
            dgvDSLoaiPhong.Columns["MaLoaiPhong"].Visible = false;
            dgvDSLoaiPhong.Columns["TenLoaiPhong"].HeaderText = "Tên Loại Phòng";
            dgvDSLoaiPhong.Columns["SucChuaToiDa"].HeaderText = "Sức Chứa Tối Đa";
            dgvDSLoaiPhong.Columns["Gia"].DefaultCellStyle.Format = "C0";
            dgvDSLoaiPhong.Columns["Gia"].HeaderText = "Giá Cơ Bản";
            dgvDSLoaiPhong.Columns["SoLuongPhong"].HeaderText = "Số Lượng Phòng";
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
            using (var sua = ActivatorUtilities.CreateInstance<SuaPhongDialogForm>(_serviceProvider, maPhong))
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

            LoaiPhongView lpv = (LoaiPhongView)cboLoaiPhong.SelectedItem;

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
            var formthemloai = _serviceProvider.GetRequiredService<ThemLPhongDiaLogForm>();
            if (formthemloai.ShowDialog() == DialogResult.OK)
            {
                loadPhong();
                var loaiphong = formthemloai.Tag as RoomType;
                if (loaiphong != null)
                {
                    var frmThemPhong = _serviceProvider.GetRequiredService<ThemPhongDialogForm>();
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
            using (var sua = ActivatorUtilities.CreateInstance<SuaLPhongDialogForm>(_serviceProvider, maLoaiPhong))
            {
                if (sua.ShowDialog() == DialogResult.OK)
                {
                    loadPhong();
                }
            }
        }
    }
}
