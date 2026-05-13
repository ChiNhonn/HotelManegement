using System;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Forms;
using HotelManagement.Helpers;
using HotelManagement.Services;
using HotelManagement.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagement.CustomControls;

public partial class usRoom : UserControl
{
    private readonly IRoomService _roomService;
    private readonly IRoomTypeService _roomTypeService;
    private readonly IFloorService _floorService;
    private bool _syncingOperationalUi;
    private bool _suspendFilterReload;

    public usRoom(IRoomService roomService, IRoomTypeService roomTypeService, IFloorService floorService)
    {
        _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
        _roomTypeService = roomTypeService ?? throw new ArgumentNullException(nameof(roomTypeService));
        _floorService = floorService ?? throw new ArgumentNullException(nameof(floorService));
        InitializeComponent();
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
    }

    private void TxtSearch_TextChanged(object? sender, EventArgs e) => ReloadGrid();

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
        if (_syncingOperationalUi || !IsHandleCreated)
            return;

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

    private int? GetSelectedFloorFilterId() =>
        (cmbFilterFloor.SelectedItem as FloorListItem)?.Id;

    private int? GetSelectedRoomTypeFilterId() =>
        (cmbFilterRoomType.SelectedItem as RoomTypeFilterPick)?.Id;

    private void ReloadGrid()
    {
        var keyword = string.IsNullOrWhiteSpace(txtSearch.Text) ? null : txtSearch.Text;
        var list = _roomService.GetFiltered(keyword, GetSelectedFloorFilterId(), GetSelectedRoomTypeFilterId());

        dgvRooms.Rows.Clear();
        foreach (var r in list)
        {
            var rowIdx = dgvRooms.Rows.Add();
            var row = dgvRooms.Rows[rowIdx];
            row.Cells["colRoomNumber"].Value = r.RoomNumber;
            row.Cells["colRoomTypeName"].Value = r.RoomTypeName;
            row.Cells["colFloorName"].Value = r.FloorName;
            row.Cells["colStatusDisplay"].Value = r.StatusDisplay;
            row.Cells["colOperational"].Value = RoomStatusMap.OperationalUiLabel(r.StatusDb);
            row.Tag = r;
        }

        SyncOperationalComboFromGrid();
    }

    private RoomView? GetSelectedRoom()
        => dgvRooms.CurrentRow?.Tag as RoomView;

    private void BtnAddRoom_Click(object? sender, EventArgs e)
    {
        try
        {
            var dlg = Program.ServiceProvider.GetRequiredService<AddRoomDialogForm>();
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK)
                return;
            _suspendFilterReload = true;
            LoadFilterCombos();
            _suspendFilterReload = false;
            ReloadGrid();
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
            MessageBox.Show("Chọn một phòng trong danh sách.", "Sửa phòng", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return;
        }

        try
        {
            using var dlg = new UpdateRoomDialogForm(_roomService, _roomTypeService, sel.RoomId);
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK)
                return;
            ReloadGrid();
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

        if (MessageBox.Show(
                $"Xóa (ẩn) phòng «{sel.RoomNumber}» khỏi hệ thống?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
            return;

        try
        {
            _roomService.Delete(sel.RoomId);
            ReloadGrid();
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
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK)
                return;
            _suspendFilterReload = true;
            LoadFilterCombos();
            _suspendFilterReload = false;
            ReloadGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Tạo hàng loạt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void ReloadRoomTypesGrid()
    {
        var keyword = string.IsNullOrWhiteSpace(txtRoomTypeSearch.Text)
            ? null
            : txtRoomTypeSearch.Text.Trim();

        var list = string.IsNullOrEmpty(keyword)
            ? _roomTypeService.GetAllWithRoomCount()
            : _roomTypeService.Search(keyword);

        dgvRoomTypes.DataSource = null;
        dgvRoomTypes.DataSource = list;
    }

    private RoomTypeView? GetSelectedRoomTypeView()
    {
        if (dgvRoomTypes.CurrentRow?.DataBoundItem is RoomTypeView v)
            return v;
        return null;
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
            var dlg = Program.ServiceProvider.GetRequiredService<AddRoomTypeDiaLogForm>();
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK)
                return;
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
            using var dlg = new UpdateRoomTypeDialogForm(_roomTypeService, sel.RoomTypeId);
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK)
                return;
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
        var list = string.IsNullOrEmpty(keyword)
            ? _floorService.GetAllGridRows()
            : _floorService.SearchGrid(keyword);

        dgvFloors.DataSource = null;
        dgvFloors.DataSource = list;
    }

    private FloorView? GetSelectedFloorView()
    {
        if (dgvFloors.CurrentRow?.DataBoundItem is FloorView v)
            return v;
        return null;
    }

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
            using var dlg = new FloorEditDialogForm(_floorService, null);
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK)
                return;
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
            MessageBox.Show("Chọn một tầng trong danh sách.", "Tầng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            using var dlg = new FloorEditDialogForm(_floorService, sel.FloorId);
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK)
                return;
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
            MessageBox.Show(
                $"Tầng «{sel.FloorName}» đang có {sel.RoomCount} phòng. Chỉ xóa được khi không còn phòng.",
                "Tầng",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        if (MessageBox.Show(
                $"Xóa tầng «{sel.FloorName}»?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
            return;

        try
        {
            _floorService.Delete(sel.FloorId);
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

        if (MessageBox.Show(
                $"Xóa loại phòng «{sel.TypeName}»? Chỉ được xóa khi không còn phòng nào thuộc loại này.",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
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
}
