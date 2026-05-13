using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using HotelManagement.Helpers;
using HotelManagement.Interfaces;
using HotelManagement.Services;
using HotelManagement.ViewModels;

namespace HotelManagement.CustomControls;

public partial class usBookRoom : UserControl
{
    private readonly IRoomBookingMapService _bookingMap;
    private readonly IRoomService _roomService;
    private readonly IBookingService _bookingService;
    private DashboardMiniRoomStatus? _cacheFull;
    private DateTime _cacheDay = DateTime.MinValue;
    private bool _populatingRoomTypes;

    public usBookRoom(IRoomBookingMapService bookingMap, IRoomService roomService, IBookingService bookingService)
    {
        _bookingMap = bookingMap ?? throw new ArgumentNullException(nameof(bookingMap));
        _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
        _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
        InitializeComponent();
        cmbStatusFilter.Items.AddRange(new object[] { "Tất cả", "Chỉ phòng trống", "Chỉ đang dọn" });
        cmbStatusFilter.SelectedIndex = 0;
        cmbRoomType.Items.Add(new RoomTypeFilterItem(null, "Tất cả hạng phòng"));
        cmbRoomType.SelectedIndex = 0;
    }

    private sealed class RoomTypeFilterItem
    {
        public int? Id { get; }
        public string Display { get; }
        public RoomTypeFilterItem(int? id, string display)
        {
            Id = id;
            Display = display;
        }

        public override string ToString() => Display;
    }

    private void usBookRoom_Load(object? sender, EventArgs e)
    {
        WireToolbarEvents();
        WinFormsScrollPan.EnableForPanel(scrollRoomTiles, null, tblRoomTiles);

        if (dtpViewDate.Value.Date != DateTime.Today)
            dtpViewDate.Value = DateTime.Today;
        else
            RefreshBookingMap();

        SetSearchCueBanner();
    }

    private const int EmSetcuebanner = 0x1501;

    private void SetSearchCueBanner()
    {
        try
        {
            if (txtSearch.IsHandleCreated)
                SendMessage(txtSearch.Handle, EmSetcuebanner, IntPtr.Zero, "Số phòng hoặc tên khách đang lưu trú");
        }
        catch
        {
            // cue banner tùy phiên bản Windows
        }
    }

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

    private void WireToolbarEvents()
    {
        dtpViewDate.ValueChanged += (_, _) =>
        {
            _cacheFull = null;
            _cacheDay = DateTime.MinValue;
            RefreshBookingMap();
        };

        btnPrevWeek.Click += (_, _) => { dtpViewDate.Value = dtpViewDate.Value.AddDays(-7); };

        btnToday.Click += (_, _) => { dtpViewDate.Value = DateTime.Today; };

        btnNextWeek.Click += (_, _) => { dtpViewDate.Value = dtpViewDate.Value.AddDays(7); };

        cmbStatusFilter.SelectedIndexChanged += (_, _) => RefreshBookingMapLocal();

        cmbRoomType.SelectedIndexChanged += (_, _) =>
        {
            if (!_populatingRoomTypes)
                RefreshBookingMapLocal();
        };

        txtSearch.TextChanged += (_, _) => RefreshBookingMapLocal();
    }

    private RoomBookingMapFilterCriteria CurrentFilterCriteria()
    {
        var status = (RoomBookingMapStatusFilterKind)Math.Clamp(cmbStatusFilter.SelectedIndex, 0, 2);
        int? typeId = cmbRoomType.SelectedItem is RoomTypeFilterItem rt ? rt.Id : null;
        return new RoomBookingMapFilterCriteria
        {
            StatusFilter = status,
            RoomTypeId = typeId,
            SearchText = txtSearch.Text
        };
    }

    private void RefreshBookingMapLocal()
    {
        if (_cacheFull == null || _cacheDay != dtpViewDate.Value.Date)
            RefreshBookingMap();
        else
            RebuildInteractiveTiles(_bookingMap.ApplyViewFilters(_cacheFull, CurrentFilterCriteria()));
    }

    private void RefreshBookingMap()
    {
        try
        {
            var day = dtpViewDate.Value.Date;
            if (_cacheFull == null || _cacheDay != day)
            {
                _cacheFull = _bookingMap.GetMiniRoomStatusAsOf(day);
                _cacheDay = day;
                BindRoomTypeComboFromService();
            }

            RebuildInteractiveTiles(_bookingMap.ApplyViewFilters(_cacheFull, CurrentFilterCriteria()));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Không tải được sơ đồ trạng thái phòng.\n{ex.Message}",
                "The Sea",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    private void OnRoomQuickActionDone()
    {
        _cacheFull = null;
        _cacheDay = DateTime.MinValue;
        RefreshBookingMap();
    }

    /// <summary>Chỉ gắn dữ liệu lên ComboBox; danh sách lấy từ service.</summary>
    private void BindRoomTypeComboFromService()
    {
        if (_cacheFull == null) return;

        var options = _bookingMap.GetRoomTypeFilterOptions(_cacheFull);
        var prevId = cmbRoomType.SelectedItem is RoomTypeFilterItem ri ? ri.Id : null;

        _populatingRoomTypes = true;
        try
        {
            cmbRoomType.Items.Clear();
            cmbRoomType.Items.Add(new RoomTypeFilterItem(null, "Tất cả hạng phòng"));
            foreach (var t in options)
                cmbRoomType.Items.Add(new RoomTypeFilterItem(t.Id, t.Name));

            var restore = 0;
            for (var i = 0; i < cmbRoomType.Items.Count; i++)
            {
                if (cmbRoomType.Items[i] is RoomTypeFilterItem x && x.Id == prevId)
                {
                    restore = i;
                    break;
                }
            }

            cmbRoomType.SelectedIndex = restore;
        }
        finally
        {
            _populatingRoomTypes = false;
        }
    }

    /// <summary>Dựng lưới WinForms và RoomBookingTile — số hàng/cột và cell hợp lệ do service tính.</summary>
    private void RebuildInteractiveTiles(DashboardMiniRoomStatus filtered)
    {
        var layout = _bookingMap.BuildTileGridLayout(filtered);

        scrollRoomTiles.SuspendLayout();
        tblRoomTiles.SuspendLayout();
        try
        {
            tblRoomTiles.Controls.Clear();
            tblRoomTiles.RowStyles.Clear();
            tblRoomTiles.ColumnStyles.Clear();

            tblRoomTiles.RowCount = layout.RowCount;
            tblRoomTiles.ColumnCount = layout.ColumnCount;
            for (var r = 0; r < layout.RowCount; r++)
                tblRoomTiles.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / layout.RowCount));
            for (var c = 0; c < layout.ColumnCount; c++)
                tblRoomTiles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / layout.ColumnCount));

            foreach (var cell in layout.CellsInGrid)
            {
                var tile = new RoomBookingTile(_roomService, _bookingService, () => dtpViewDate.Value.Date,
                    OnRoomQuickActionDone,
                    hint =>
                    {
                        txtSearch.Text = hint;
                        RefreshBookingMapLocal();
                    });
                tile.Bind(cell);
                tblRoomTiles.Controls.Add(tile, cell.GridCol, cell.GridRow);
            }

            tblRoomTiles.MinimumSize = new Size(layout.MinimumWidth, layout.MinimumHeight);
        }
        finally
        {
            tblRoomTiles.ResumeLayout(true);
            scrollRoomTiles.ResumeLayout(true);
        }
    }
}
