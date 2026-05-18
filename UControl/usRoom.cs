using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Forms;
using HotelManagement.Helpers;
using HotelManagement.Interfaces; // Đã thêm để dùng IBranchService
using HotelManagement.Services;
using HotelManagement.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagement.CustomControls;

public partial class usRoom : UserControl
{
    private readonly IRoomService _roomService;
    private readonly IRoomTypeService _roomTypeService;
    private readonly IFloorService _floorService;
    private readonly IBranchService _branchService; // Đã thêm

    private bool _syncingOperationalUi;
    private bool _suspendFilterReload;
    private FloorView? _selectedFloor;
    private readonly List<FloorManagementCard> _floorCards = new();

    // Đã thêm IBranchService vào Constructor
    public usRoom(IRoomService roomService, IRoomTypeService roomTypeService, IFloorService floorService, IBranchService branchService)
    {
        _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
        _roomTypeService = roomTypeService ?? throw new ArgumentNullException(nameof(roomTypeService));
        _floorService = floorService ?? throw new ArgumentNullException(nameof(floorService));
        _branchService = branchService ?? throw new ArgumentNullException(nameof(branchService));

        InitializeComponent();

        // 1. Gắn Data Binding và tạo cột cho 2 lưới
        SetupGrid();
        SetupRoomTypesGrid();

        // 2. Chức năng click ra ngoài bỏ chọn lưới (đã sửa lỗi để không ảnh hưởng nút bấm)
        HookOutsideClickClearsGrid(dgvRooms, pnlRoomsRoot);
        HookOutsideClickClearsGrid(dgvRoomTypes, pnlRoomTypesRoot);
        HookOutsideClickClearsGrid(dgvBranches, pnlBranchesRoot);
        WinFormsScrollPan.EnableForPanel(pnlFloorsScroll, flowFloorMgmtLayout, flowFloorMgmtLayout);
        pnlFloorsScroll.Resize += (_, _) => SyncFloorMgmtLayoutWidth();
        pnlFloorsToolbar.MouseDown += (_, e) =>
        {
            if (e.Button == MouseButtons.Left)
                SelectFloor(null);
        };
    }

    private void SetupGrid()
    {
        dgvRooms.AutoGenerateColumns = false;
        dgvRooms.Columns.Clear();

        dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colRoomId",
            DataPropertyName = nameof(RoomView.RoomId),
            Visible = false
        });
        dgvRooms.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRoomNumber", DataPropertyName = nameof(RoomView.RoomNumber), HeaderText = "Số phòng", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, ReadOnly = true });
        dgvRooms.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRoomTypeName", DataPropertyName = nameof(RoomView.RoomTypeName), HeaderText = "Loại phòng", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, ReadOnly = true });
        dgvRooms.Columns.Add(new DataGridViewTextBoxColumn { Name = "colFloorName", DataPropertyName = nameof(RoomView.FloorName), HeaderText = "Tầng", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, ReadOnly = true });
        dgvRooms.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatusDisplay", DataPropertyName = nameof(RoomView.StatusDisplay), HeaderText = "Trạng thái phòng / lưu trú", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, ReadOnly = true });
        dgvRooms.Columns.Add(new DataGridViewTextBoxColumn { Name = "colOperational", DataPropertyName = nameof(RoomView.OperationalDisplay), HeaderText = "Vận hành / khóa", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, ReadOnly = true });

        dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvRooms.AllowUserToAddRows = false;
        dgvRooms.RowHeadersVisible = false;
    }

    private void SetupRoomTypesGrid()
    {
        dgvRoomTypes.AutoGenerateColumns = false;
        dgvRoomTypes.Columns.Clear();

        dgvRoomTypes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRoomTypeId", DataPropertyName = nameof(RoomTypeView.RoomTypeId), HeaderText = "ID", Visible = false });
        dgvRoomTypes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCode", DataPropertyName = nameof(RoomTypeView.Code), HeaderText = "Mã", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
        dgvRoomTypes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTypeName", DataPropertyName = nameof(RoomTypeView.TypeName), HeaderText = "Tên loại", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

        var colPrice = new DataGridViewTextBoxColumn { Name = "colUnitPrice", DataPropertyName = nameof(RoomTypeView.UnitPrice), HeaderText = "Giá", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells };
        colPrice.DefaultCellStyle.Format = "N0";
        dgvRoomTypes.Columns.Add(colPrice);

        dgvRoomTypes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCapacityDisplay", DataPropertyName = nameof(RoomTypeView.CapacityDisplay), HeaderText = "Sức chứa", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
        dgvRoomTypes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTotalMaxGuests", DataPropertyName = nameof(RoomTypeView.TotalMaxGuests), HeaderText = "Tối đa", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
        dgvRoomTypes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRoomCount", DataPropertyName = nameof(RoomTypeView.RoomCount), HeaderText = "Số phòng", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
        dgvRoomTypes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDescription", DataPropertyName = nameof(RoomTypeView.Description), HeaderText = "Mô tả", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        dgvRoomTypes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colBedTypeDescription", DataPropertyName = nameof(RoomTypeView.BedTypeDescription), HeaderText = "Loại giường", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

        dgvRoomTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvRoomTypes.AllowUserToAddRows = false;
        dgvRoomTypes.RowHeadersVisible = false;
        dgvRoomTypes.ReadOnly = true;
    }

    private void usRoom_Load(object? sender, EventArgs e)
    {
        LoadOperationalCombo();
        _suspendFilterReload = true;
        LoadFilterCombos();
        _suspendFilterReload = false;
        ReloadGrid();
        ReloadRoomTypesGrid();
        ReloadFloorsGrid();
        SyncFloorMgmtLayoutWidth();

        // Đã thêm: Load dữ liệu chi nhánh khi mở UserControl
        LoadBranchesData();
    }

    private static void HookOutsideClickClearsGrid(DataGridView grid, Control root)
    {
        void HookControl(Control c)
        {
            if (c == grid)
            {
                c.MouseDown += (_, e) =>
                {
                    if (e.Button != MouseButtons.Left) return;
                    var ht = grid.HitTest(e.X, e.Y);
                    if (ht.RowIndex < 0) ClearGridSelection(grid);
                };
                return;
            }

            // Loại trừ nút bấm, ô nhập liệu để không làm mất dòng đang chọn khi thao tác
            if (!(c is Button || c is TextBox || c is ComboBox || c is NumericUpDown))
            {
                c.MouseDown += (_, e) =>
                {
                    if (e.Button == MouseButtons.Left) ClearGridSelection(grid);
                };
            }

            foreach (Control child in c.Controls)
                HookControl(child);
        }

        HookControl(root);
    }

    private static void ClearGridSelection(DataGridView grid)
    {
        grid.ClearSelection();
        if (grid.CurrentCell != null)
            grid.CurrentCell = null;
    }

    private void SyncFloorMgmtLayoutWidth()
    {
        if (!pnlFloorsScroll.IsHandleCreated) return;
        var w = pnlFloorsScroll.ClientSize.Width - pnlFloorsScroll.Padding.Horizontal - 8;
        flowFloorMgmtLayout.Width = Math.Max(340, w);
    }

    private void BtnRefreshList_Click(object? sender, EventArgs e)
    {
        txtSearch.Clear();
        cmbFilterFloor.SelectedIndex = 0;
        cmbFilterRoomType.SelectedIndex = 0;
        ReloadGrid();
    }

    private void CmbFilterFloor_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_suspendFilterReload || !IsHandleCreated) return;
        ReloadGrid();
    }

    private void CmbFilterRoomType_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_suspendFilterReload || !IsHandleCreated) return;
        ReloadGrid();
    }

    private void CmbOperationalApply_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_syncingOperationalUi || !IsHandleCreated) return;

        var sel = GetSelectedRoom();
        if (sel == null || cmbOperationalApply.SelectedItem is not OperationalPick pick)
            return;

        try
        {
            _roomService.SetOperationalStatus(sel.RoomId, pick.Mode);
            ReloadGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Vận hành / khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            SyncOperationalComboFromGrid();
        }
    }

    private void DgvRooms_SelectionChanged(object? sender, EventArgs e) => SyncOperationalComboFromGrid();

    private void SyncOperationalComboFromGrid()
    {
        _syncingOperationalUi = true;
        try
        {
            var sel = GetSelectedRoom();
            if (sel == null)
            {
                cmbOperationalApply.SelectedIndex = 0;
                return;
            }

            var mode = RoomStatusMap.DeriveOperationalMode(sel.StatusDb);
            for (var i = 0; i < cmbOperationalApply.Items.Count; i++)
            {
                if (cmbOperationalApply.Items[i] is OperationalPick p && p.Mode == mode)
                {
                    cmbOperationalApply.SelectedIndex = i;
                    return;
                }
            }
            cmbOperationalApply.SelectedIndex = 0;
        }
        finally
        {
            _syncingOperationalUi = false;
        }
    }

    private void LoadOperationalCombo()
    {
        cmbOperationalApply.Items.Clear();
        cmbOperationalApply.Items.Add(new OperationalPick(RoomOperationalMode.Active, "Đang mở — hiển thị trên sơ đồ"));
        cmbOperationalApply.Items.Add(new OperationalPick(RoomOperationalMode.Inactive, "Ngưng dùng — ô xám trên sơ đồ"));
        cmbOperationalApply.Items.Add(new OperationalPick(RoomOperationalMode.OutOfOrder, "Hỏng / bảo trì — ô xám trên sơ đồ"));
        cmbOperationalApply.DisplayMember = nameof(OperationalPick.Caption);
        cmbOperationalApply.SelectedIndex = 0;
    }

    private sealed class OperationalPick(RoomOperationalMode mode, string caption)
    {
        public RoomOperationalMode Mode { get; } = mode;
        public string Caption { get; } = caption;
    }

    private void LoadFilterCombos()
    {
        cmbFilterFloor.Items.Clear();
        cmbFilterFloor.Items.Add(new FloorListItem(null, "Tất cả tầng"));
        foreach (var f in _roomService.GetAllFloors().OrderBy(x => x.Name))
            cmbFilterFloor.Items.Add(new FloorListItem(f.Id, f.Name));
        cmbFilterFloor.SelectedIndex = 0;

        cmbFilterRoomType.Items.Clear();
        cmbFilterRoomType.Items.Add(new RoomTypeFilterPick(null, "Tất cả loại"));
        foreach (var t in _roomTypeService.GetAll().OrderBy(x => x.Id))
            cmbFilterRoomType.Items.Add(new RoomTypeFilterPick(t.Id, t.Name));
        cmbFilterRoomType.SelectedIndex = 0;
    }

    private sealed class RoomTypeFilterPick(int? id, string text)
    {
        public int? Id { get; } = id;
        public string Text { get; } = text;
        public override string ToString() => Text;
    }

    private int? GetSelectedFloorFilterId() => (cmbFilterFloor.SelectedItem as FloorListItem)?.Id;
    private int? GetSelectedRoomTypeFilterId() => (cmbFilterRoomType.SelectedItem as RoomTypeFilterPick)?.Id;

    private void ReloadGrid()
    {
        var keyword = string.IsNullOrWhiteSpace(txtSearch.Text) ? null : txtSearch.Text;
        var list = _roomService.GetFiltered(keyword, GetSelectedFloorFilterId(), GetSelectedRoomTypeFilterId());

        dgvRooms.DataSource = null;
        dgvRooms.DataSource = list;

        // Bỏ chọn dòng đầu tiên mặc định
        dgvRooms.ClearSelection();
        dgvRooms.CurrentCell = null;

        SyncOperationalComboFromGrid();
    }

    private void ReloadRoomTypesGrid()
    {
        var keyword = string.IsNullOrWhiteSpace(txtRoomTypeSearch.Text) ? null : txtRoomTypeSearch.Text.Trim();
        var list = string.IsNullOrEmpty(keyword)
            ? _roomTypeService.GetAllWithRoomCount()
            : _roomTypeService.Search(keyword);

        dgvRoomTypes.DataSource = null;
        dgvRoomTypes.DataSource = list;

        // Bỏ chọn dòng đầu tiên mặc định
        dgvRoomTypes.ClearSelection();
        dgvRoomTypes.CurrentCell = null;
    }

    private RoomView? GetSelectedRoom()
    {
        if (dgvRooms.CurrentRow?.DataBoundItem is RoomView v) return v;
        return null;
    }

    private RoomTypeView? GetSelectedRoomTypeView()
    {
        if (dgvRoomTypes.CurrentRow?.DataBoundItem is RoomTypeView v) return v;
        return null;
    }

    private void BtnAddRoom_Click(object? sender, EventArgs e)
    {
        try
        {
            var dlg = Program.ServiceProvider.GetRequiredService<RoomEditDialogForm>();
            dlg.Setup(null);
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
            _suspendFilterReload = true;
            LoadFilterCombos();
            _suspendFilterReload = false;
            ReloadGrid();
            ReloadFloorsGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Thêm phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnEditRoom_Click(object? sender, EventArgs e)
    {
        var sel = GetSelectedRoom();
        if (sel == null)
        {
            MessageBox.Show("Chọn một phòng trong danh sách.", "Sửa phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        try
        {
            var dlg = Program.ServiceProvider.GetRequiredService<RoomEditDialogForm>();
            dlg.Setup(sel.RoomId);
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
            ReloadGrid();
            ReloadFloorsGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Sửa phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnDeleteRoom_Click(object? sender, EventArgs e)
    {
        var sel = GetSelectedRoom();
        if (sel == null)
        {
            MessageBox.Show("Chọn phòng cần xóa.", "Xóa phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MessageBox.Show($"Xóa (ẩn) phòng «{sel.RoomNumber}» khỏi hệ thống?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            return;

        try
        {
            _roomService.Delete(sel.RoomId);
            ReloadGrid();
            ReloadFloorsGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Xóa phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnBulkCreate_Click(object? sender, EventArgs e)
    {
        try
        {
            var dlg = Program.ServiceProvider.GetRequiredService<BulkCreateRoomsDialog>();
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
            _suspendFilterReload = true;
            LoadFilterCombos();
            _suspendFilterReload = false;
            ReloadGrid();
            ReloadFloorsGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Tạo hàng loạt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void TxtRoomTypeSearch_TextChanged(object? sender, EventArgs e) => ReloadRoomTypesGrid();

    private void BtnRoomTypeRefresh_Click(object? sender, EventArgs e)
    {
        txtRoomTypeSearch.Clear();
        ReloadRoomTypesGrid();
    }

    private void BtnRoomTypeAdd_Click(object? sender, EventArgs e)
    {
        try
        {
            var dlg = Program.ServiceProvider.GetRequiredService<RoomTypeEditDialogForm>();
            dlg.Setup(null);
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
            _suspendFilterReload = true;
            LoadFilterCombos();
            _suspendFilterReload = false;
            ReloadRoomTypesGrid();
            ReloadGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Loại phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnRoomTypeEdit_Click(object? sender, EventArgs e)
    {
        var sel = GetSelectedRoomTypeView();
        if (sel == null)
        {
            MessageBox.Show("Chọn một dòng loại phòng.", "Loại phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            var dlg = Program.ServiceProvider.GetRequiredService<RoomTypeEditDialogForm>();

            // 2. CHÈN DÒNG NÀY VÀO: Bắn ID sang để form biết đường load dữ liệu cũ lên
            dlg.Setup(sel.RoomTypeId);

            // 3. Hiển thị form
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;

            _suspendFilterReload = true;
            LoadFilterCombos();
            _suspendFilterReload = false;
            ReloadRoomTypesGrid();
            ReloadGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Loại phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void ReloadFloorsGrid()
    {
        var keyword = string.IsNullOrWhiteSpace(txtFloorSearch.Text) ? null : txtFloorSearch.Text.Trim();
        var list = string.IsNullOrEmpty(keyword) ? _floorService.GetAllGridRows() : _floorService.SearchGrid(keyword);

        flowFloorMgmtLayout.SuspendLayout();
        flowFloorMgmtLayout.Controls.Clear();
        _floorCards.Clear();

        foreach (var floor in list.OrderBy(f => f.FloorName, StringComparer.OrdinalIgnoreCase))
        {
            var card = new FloorManagementCard();
            card.Bind(floor, _selectedFloor?.FloorId == floor.FloorId);
            card.FloorSelected += (_, f) => SelectFloor(f);
            card.ToggleRequested += (_, floorId) => ToggleFloorOperational(floorId);
            flowFloorMgmtLayout.Controls.Add(card);
            _floorCards.Add(card);
        }

        if (flowFloorMgmtLayout.Controls.Count == 0)
        {
            flowFloorMgmtLayout.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.Gray,
                Margin = new Padding(12),
                Text = "Không có tầng phù hợp."
            });
        }

        flowFloorMgmtLayout.ResumeLayout(true);
        SyncFloorMgmtLayoutWidth();
    }

    private void SelectFloor(FloorView? floor)
    {
        _selectedFloor = floor;
        foreach (var card in _floorCards)
            card.Bind(card.Floor, floor?.FloorId == card.Floor.FloorId);
    }

    private FloorView? GetSelectedFloorView() => _selectedFloor;

    private void TxtFloorSearch_TextChanged(object? sender, EventArgs e) => ReloadFloorsGrid();

    private void BtnFloorRefresh_Click(object? sender, EventArgs e)
    {
        txtFloorSearch.Clear();
        ReloadFloorsGrid();
    }

    private void BtnFloorAdd_Click(object? sender, EventArgs e)
    {
        try
        {
            var dlg = Program.ServiceProvider.GetRequiredService<FloorEditDialogForm>();
            dlg.Setup(null);
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
            _suspendFilterReload = true;
            LoadFilterCombos();
            _suspendFilterReload = false;
            ReloadFloorsGrid();
            ReloadGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Tầng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnFloorEdit_Click(object? sender, EventArgs e)
    {
        var sel = GetSelectedFloorView();
        if (sel == null)
        {
            MessageBox.Show("Chọn một tầng trên lưới.", "Tầng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            var dlg = Program.ServiceProvider.GetRequiredService<FloorEditDialogForm>();
            dlg.Setup(sel.FloorId);
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
            _suspendFilterReload = true;
            LoadFilterCombos();
            _suspendFilterReload = false;
            ReloadFloorsGrid();
            ReloadGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Tầng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnFloorDelete_Click(object? sender, EventArgs e)
    {
        var sel = GetSelectedFloorView();
        if (sel == null)
        {
            MessageBox.Show("Chọn tầng cần xóa.", "Tầng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (sel.RoomCount > 0)
        {
            MessageBox.Show($"Tầng «{sel.FloorName}» đang có {sel.RoomCount} phòng. Chỉ xóa được khi không còn phòng.", "Tầng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (MessageBox.Show($"Xóa tầng «{sel.FloorName}»?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            return;

        try
        {
            _floorService.Delete(sel.FloorId);
            SelectFloor(null);
            _suspendFilterReload = true;
            LoadFilterCombos();
            _suspendFilterReload = false;
            ReloadFloorsGrid();
            ReloadGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Tầng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnRoomTypeDelete_Click(object? sender, EventArgs e)
    {
        var sel = GetSelectedRoomTypeView();
        if (sel == null)
        {
            MessageBox.Show("Chọn loại phòng cần xóa.", "Loại phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MessageBox.Show($"Xóa loại phòng «{sel.TypeName}»? Chỉ được xóa khi không còn phòng nào thuộc loại này.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            return;

        try
        {
            _roomTypeService.Delete(sel.RoomTypeId);
            _suspendFilterReload = true;
            LoadFilterCombos();
            _suspendFilterReload = false;
            ReloadRoomTypesGrid();
            ReloadGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Loại phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void ToggleFloorOperational(int floorId)
    {
        var floor = _floorService.GetById(floorId);
        if (floor == null) return;

        var current = FloorStatusMap.DeriveMode(floor.Status);
        var next = current == FloorOperationalMode.Open ? FloorOperationalMode.Maintenance : FloorOperationalMode.Open;

        var msg = next == FloorOperationalMode.Maintenance
            ? $"Khóa tầng «{floor.Name}» (bảo trì/sửa chữa)?\r\nToàn bộ phòng trống trên tầng sẽ không nhận đặt lịch."
            : $"Mở lại tầng «{floor.Name}»?";

        if (MessageBox.Show(msg, "Trạng thái tầng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        try
        {
            _floorService.SetFloorOperationalStatus(floorId, next);
            ReloadFloorsGrid();
            ReloadGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Trạng thái tầng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    // =======================================================
    // VÙNG MỚI THÊM: QUẢN LÝ CHI NHÁNH (BRANCH MANAGEMENT)
    // =======================================================
    #region QUẢN LÝ CHI NHÁNH

    private void LoadBranchesData(string keyword = "")
    {
        try
        {
            var branches = _branchService.GetAllBranches();

            // Xử lý tìm kiếm
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();
                branches = branches.Where(b =>
                    (b.StreetName != null && b.StreetName.ToLower().Contains(keyword)) ||
                    (b.City != null && b.City.ToLower().Contains(keyword)) ||
                    (b.Phone != null && b.Phone.ToLower().Contains(keyword)) ||
                    b.Id.ToString().Contains(keyword)
                ).ToList();
            }

            dgvBranches.DataSource = null;
            dgvBranches.DataSource = branches;

            // =========================================================
            // ĐÃ ẨN CÁC CỘT: ID, Floors, Users, SoftDelete, CreateAt, UpdateAt
            // =========================================================
            if (dgvBranches.Columns["Id"] != null) dgvBranches.Columns["Id"].Visible = false;
            if (dgvBranches.Columns["Floors"] != null) dgvBranches.Columns["Floors"].Visible = false;
            if (dgvBranches.Columns["Users"] != null) dgvBranches.Columns["Users"].Visible = false;
            if (dgvBranches.Columns["SoftDelete"] != null) dgvBranches.Columns["SoftDelete"].Visible = false;
            if (dgvBranches.Columns["CreateAt"] != null) dgvBranches.Columns["CreateAt"].Visible = false;
            if (dgvBranches.Columns["UpdateAt"] != null) dgvBranches.Columns["UpdateAt"].Visible = false;

            // =========================================================
            // ĐỔI TÊN TIẾNG VIỆT CHO CÁC CỘT CÒN LẠI TRÊN GIAO DIỆN
            // =========================================================
            if (dgvBranches.Columns["Phone"] != null) dgvBranches.Columns["Phone"].HeaderText = "SĐT";
            if (dgvBranches.Columns["HouseNumber"] != null) dgvBranches.Columns["HouseNumber"].HeaderText = "Số nhà";
            if (dgvBranches.Columns["StreetName"] != null) dgvBranches.Columns["StreetName"].HeaderText = "Tên đường";
            if (dgvBranches.Columns["Commune"] != null) dgvBranches.Columns["Commune"].HeaderText = "Phường/Xã";
            if (dgvBranches.Columns["City"] != null) dgvBranches.Columns["City"].HeaderText = "Thành phố";
            if (dgvBranches.Columns["Country"] != null) dgvBranches.Columns["Country"].HeaderText = "Quốc gia";

            // Xóa bôi đen dòng đầu tiên
            dgvBranches.ClearSelection();
            if (dgvBranches.CurrentCell != null) dgvBranches.CurrentCell = null;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tải dữ liệu chi nhánh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnBranchRefresh_Click(object? sender, EventArgs e)
    {
        txtBranchSearch.Clear();
        LoadBranchesData();
    }

    private void TxtBranchSearch_TextChanged(object? sender, EventArgs e)
    {
        LoadBranchesData(txtBranchSearch.Text.Trim());
    }

    private void BtnBranchAdd_Click(object? sender, EventArgs e)
    {
        try
        {
            // 1. Gọi đúng Form BranchEditDiaLogForm từ DI Container
            var form = Program.ServiceProvider.GetRequiredService<BranchEditDiaLogForm>();

            // 2. Truyền null để Form biết là đang ở chế độ THÊM MỚI
            form.Setup(null);

            // 3. Hiển thị Form, nếu người dùng bấm Lưu (DialogResult.OK) thì load lại lưới
            if (form.ShowDialog(FindForm()) == DialogResult.OK)
            {
                LoadBranchesData();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không thể mở form thêm chi nhánh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnBranchEdit_Click(object? sender, EventArgs e)
    {
        if (dgvBranches.CurrentRow == null)
        {
            MessageBox.Show("Vui lòng chọn một chi nhánh trên bảng dữ liệu để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            // 2. Lấy ID của chi nhánh đang được chọn từ ô Cell có tên là "Id"
            int branchId = Convert.ToInt32(dgvBranches.CurrentRow.Cells["Id"].Value);

            // 3. Khởi tạo Form và truyền ID sang qua hàm Setup để tự động điền dữ liệu cũ (chế độ SỬA)
            var form = Program.ServiceProvider.GetRequiredService<BranchEditDiaLogForm>();
            form.Setup(branchId);

            // 4. Nếu sửa thành công và đóng form, cập nhật lại lưới ngoài giao diện chính
            if (form.ShowDialog(FindForm()) == DialogResult.OK)
            {
                LoadBranchesData();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không thể mở form sửa chi nhánh: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnBranchDelete_Click(object? sender, EventArgs e)
    {
        // Đã sửa lại thành CurrentRow để tránh lỗi khi người dùng click vào cell thay vì bôi đen cả dòng
        if (dgvBranches.CurrentRow == null)
        {
            MessageBox.Show("Vui lòng chọn một chi nhánh trên lưới để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = Convert.ToInt32(dgvBranches.CurrentRow.Cells["Id"].Value);

        DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa chi nhánh ID: {id} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            try
            {
                _branchService.DeleteBranch(id);
                MessageBox.Show("Xóa chi nhánh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBranchesData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    #endregion

    private void txtSearch_TextChanged(object sender, EventArgs e) => ReloadGrid();
}