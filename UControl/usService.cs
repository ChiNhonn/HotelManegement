using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Forms;
using HotelManagement.Helpers;
using HotelManagement.Interfaces;
using HotelManagement.ViewModels;

namespace HotelManagement.CustomControls;

public partial class usService : UserControl
{
    private readonly IServiceModuleService _svc;
    private bool _loaded;
    private OperationFulfillmentPanel? _opsFulfillment;

    private RadioButton radOrderCtxRoom = null!;
    private RadioButton radOrderCtxWalkIn = null!;
    private RadioButton radChargeFolio = null!;
    private RadioButton radChargeImmediate = null!;
    private FlowLayoutPanel flowPayNowMethods = null!;
    private RadioButton radPayCash = null!;
    private RadioButton radPayTransfer = null!;

    public usService(IServiceModuleService svc)
    {
        _svc = svc ?? throw new ArgumentNullException(nameof(svc));
        InitializeComponent();
    }

    /// <summary>Đặt tab chính lên « Vận hành » (dùng từ Dashboard / nhắc nhở).</summary>
    public void SelectOperationsTab()
    {
        if (tabMain.TabPages.Contains(tabOps))
            tabMain.SelectedTab = tabOps;
    }

    private void usService_Load(object? sender, EventArgs e)
    {
        if (_loaded) return;
        _loaded = true;

        StyleGrid(dgvCategories);
        StyleGrid(dgvServices);
        StyleGrid(dgvPackages);
        StyleGrid(dgvPriceRules);
        StyleGrid(dgvPay);
        StyleGrid(dgvReport);
        dgvPay.RowTemplate.Height = 42;

        _opsFulfillment = new OperationFulfillmentPanel(_svc)
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(0),
            Padding = new Padding(0)
        };
        cardTracking.Controls.Add(_opsFulfillment);
        _opsFulfillment.BringToFront();

        dgvOrders.Visible = false;
        pnlTrackingToolbar.Visible = false;
        pnlTrackingHeader.Visible = false;

        ApplyFlatTabs(tabMain, inCard: false, itemWidth: 150, itemHeight: 34);
        ApplyFlatTabs(tabCatalogRight, inCard: true, itemWidth: 130, itemHeight: 30);
        ApplyFlatTabs(tabSvcCategories, inCard: true, itemWidth: 110, itemHeight: 28);

        ControlBorderSuppress.RemoveNativeBorder(tabMain);
        ControlBorderSuppress.RemoveNativeBorder(tabCatalogRight);
        ControlBorderSuppress.RemoveNativeBorder(tabSvcCategories);

        // Style các nút phụ (Sửa/Xóa/Lọc) và nút hành động chính cho đồng bộ với dashboard.
        StyleSecondaryButton(btnAddCategory);
        StyleSecondaryButton(btnEditCategory);
        StyleSecondaryButton(btnDeleteCategory, danger: true);
        StyleSecondaryButton(btnAddService);
        StyleSecondaryButton(btnEditService);
        StyleSecondaryButton(btnToggleService);
        StyleSecondaryButton(btnDeleteService, danger: true);
        StyleSecondaryButton(btnAddPackage);
        StyleSecondaryButton(btnEditPackage);
        StyleSecondaryButton(btnDeletePackage, danger: true);
        StyleSecondaryButton(btnAddPriceRule);
        StyleSecondaryButton(btnEditPriceRule);
        StyleSecondaryButton(btnDeletePriceRule, danger: true);
        StyleSecondaryButton(btnMarkPending);
        StyleSecondaryButton(btnMarkInProgress);
        StyleSecondaryButton(btnCancelOrder, danger: true);
        StyleSecondaryButton(btnReloadOps);
        StyleSecondaryButton(btnReloadPayment);
        StylePrimaryButton(btnMarkCompleted);
        StylePrimaryButton(btnPlaceOrder);
        StylePrimaryButton(btnCollectCash);
        StylePrimaryButton(btnCollectTransfer);
        StylePrimaryButton(btnRunReport);

        dgvCategories.SelectionChanged += (_, _) => ReloadServicesGrid();
        tabMain.SelectedIndexChanged += (_, _) =>
        {
            if (tabMain.SelectedTab == tabPayment) ReloadPayment();
            else if (tabMain.SelectedTab == tabOps) _opsFulfillment?.Reload();
        };

        WireChargeEntryPanel();

        cmbOrderStatus.Items.Add("Tất cả");
        foreach (var status in ServiceOrderStatus.All)
            cmbOrderStatus.Items.Add(new StatusPick(status, ServiceOrderStatus.ToDisplay(status)));
        cmbOrderStatus.DisplayMember = nameof(StatusPick.Label);
        cmbOrderStatus.SelectedIndex = 0;

        dtpFrom.Value = DateTime.Today.AddDays(-30);
        dtpTo.Value = DateTime.Today;
        cmbReportType.Items.Add("Doanh thu theo loại");
        cmbReportType.Items.Add("Tần suất theo giờ");
        cmbReportType.SelectedIndex = 0;

        ReloadCatalog();
        ReloadOps();

        SyncComboRenderedHeights(cmbStay, cmbOrderStatus);
    }

    private void WireChargeEntryPanel()
    {
        pnlChargeInner.Controls.Clear();

        var slateLabel = Color.FromArgb(71, 85, 105);
        var slateTitle = Color.FromArgb(51, 65, 85);
        var bodyText = Color.FromArgb(30, 41, 59);
        var labelFont = new Font("Segoe UI", 9f, FontStyle.Bold);
        var radioFont = new Font("Segoe UI", 9.5f);

        const int rowH = 50;
        const int labelColW = 128;

        var card = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.White,
            Padding = new Padding(12, 10, 12, 10),
            Margin = new Padding(0),
            BorderStyle = BorderStyle.None
        };

        FlowLayoutPanel CreateRadioFlow(Color surfaceBg, params RadioButton[] radios)
        {
            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Margin = new Padding(0),
                Padding = new Padding(0, 4, 0, 4),
                BackColor = surfaceBg
            };
            foreach (var r in radios)
            {
                r.Margin = new Padding(0, 0, 16, 0);
                r.AutoSize = true;
                r.FlatStyle = FlatStyle.Standard;
                r.UseVisualStyleBackColor = true;
                r.ForeColor = bodyText;
                flow.Controls.Add(r);
            }
            return flow;
        }

        TableLayoutPanel CreateChargeRow(string caption, FlowLayoutPanel radios)
        {
            var row = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 1,
                Dock = DockStyle.Fill,
                Height = rowH,
                Margin = new Padding(0),
                Padding = new Padding(0),
                BackColor = Color.White
            };
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, labelColW));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            row.RowStyles.Add(new RowStyle(SizeType.Absolute, rowH));
            var lbl = new Label
            {
                Text = caption,
                Font = labelFont,
                ForeColor = slateLabel,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.White,
                AutoSize = false,
                Margin = new Padding(0)
            };
            radios.Dock = DockStyle.Fill;
            row.Controls.Add(lbl, 0, 0);
            row.Controls.Add(radios, 1, 0);
            return row;
        }

        var lblHdr = new Label
        {
            Text = "Thanh toán dự kiến",
            Dock = DockStyle.Top,
            Height = 22,
            Margin = new Padding(0, 0, 0, 6),
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
            ForeColor = slateTitle,
            TextAlign = ContentAlignment.MiddleLeft
        };

        radOrderCtxRoom = new RadioButton
        {
            Text = "Từ phòng / khách lưu trú",
            Font = radioFont,
            Checked = true,
            TabStop = true,
            AutoSize = true,
            ForeColor = bodyText,
            FlatStyle = FlatStyle.Standard,
            UseVisualStyleBackColor = true
        };
        radOrderCtxWalkIn = new RadioButton
        {
            Text = "Trực tiếp tại quầy",
            Font = radioFont,
            TabStop = true,
            AutoSize = true,
            ForeColor = bodyText,
            FlatStyle = FlatStyle.Standard,
            UseVisualStyleBackColor = true
        };

        radChargeFolio = new RadioButton
        {
            Text = "Gộp vào hóa đơn phòng",
            Font = radioFont,
            Checked = true,
            TabStop = true,
            AutoSize = true,
            ForeColor = bodyText,
            FlatStyle = FlatStyle.Standard,
            UseVisualStyleBackColor = true
        };
        radChargeImmediate = new RadioButton
        {
            Text = "Thanh toán ngay",
            Font = radioFont,
            TabStop = true,
            AutoSize = true,
            ForeColor = bodyText,
            FlatStyle = FlatStyle.Standard,
            UseVisualStyleBackColor = true
        };

        radPayCash = new RadioButton
        {
            Text = "Tiền mặt",
            Font = radioFont,
            Checked = true,
            TabStop = true,
            AutoSize = true,
            ForeColor = bodyText,
            FlatStyle = FlatStyle.Standard,
            UseVisualStyleBackColor = true
        };
        radPayTransfer = new RadioButton
        {
            Text = "Chuyển khoản",
            Font = radioFont,
            TabStop = true,
            AutoSize = true,
            ForeColor = bodyText,
            FlatStyle = FlatStyle.Standard,
            UseVisualStyleBackColor = true
        };

        flowPayNowMethods = CreateRadioFlow(Color.White, radPayCash, radPayTransfer);

        var rowSrc = CreateChargeRow("Nguồn đặt", CreateRadioFlow(Color.White, radOrderCtxRoom, radOrderCtxWalkIn));
        rowSrc.Margin = new Padding(0, 0, 0, 10);

        var rowCharge = CreateChargeRow("Thanh toán", CreateRadioFlow(Color.White, radChargeFolio, radChargeImmediate));
        rowCharge.Margin = new Padding(0, 0, 0, 10);

        var rowMethod = CreateChargeRow("Tiền mặt / CK", flowPayNowMethods);
        rowMethod.Margin = new Padding(0);

        var outerRows = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3,
            Margin = new Padding(0),
            Padding = new Padding(0),
            BackColor = Color.White
        };
        // AutoSize rows 0–1 so bottom Margin on rows isn’t clipped by a fixed Absolute height.
        outerRows.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        outerRows.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        outerRows.RowStyles.Add(new RowStyle(SizeType.Absolute, 0));

        outerRows.Controls.Add(rowSrc, 0, 0);
        outerRows.Controls.Add(rowCharge, 0, 1);
        outerRows.Controls.Add(rowMethod, 0, 2);

        card.Controls.Add(outerRows);

        var outer = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 2,
            Margin = new Padding(0),
            Padding = new Padding(0),
            BackColor = Color.FromArgb(241, 245, 249)
        };
        outer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        outer.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        outer.Controls.Add(lblHdr, 0, 0);
        outer.Controls.Add(card, 0, 1);

        pnlChargeInner.Controls.Add(outer);

        void SyncChargeEntryUi(object? s, EventArgs e)
        {
            var walkIn = radOrderCtxWalkIn.Checked;
            radChargeFolio.Enabled = !walkIn;
            if (walkIn)
                radChargeImmediate.Checked = true;

            var immediate = radChargeImmediate.Checked;

            outerRows.RowStyles[2].SizeType = SizeType.Absolute;
            outerRows.RowStyles[2].Height = immediate ? rowH : 0;
            rowMethod.Visible = immediate;

            if (immediate && !radPayCash.Checked && !radPayTransfer.Checked)
                radPayCash.Checked = true;

            outerRows.PerformLayout();
            card.PerformLayout();
            outer.PerformLayout();
        }

        radOrderCtxRoom.CheckedChanged += SyncChargeEntryUi;
        radOrderCtxWalkIn.CheckedChanged += SyncChargeEntryUi;
        radChargeFolio.CheckedChanged += SyncChargeEntryUi;
        radChargeImmediate.CheckedChanged += SyncChargeEntryUi;
        SyncChargeEntryUi(null, EventArgs.Empty);
    }

    /// <summary>Bảng theo phong cách "clean / flat":
    /// header xám nhạt + chia cột, body trắng, chỉ kẻ dưới mỗi hàng.</summary>
    private static void StyleGrid(DataGridView dgv)
    {
        dgv.BackgroundColor = Color.White;
        dgv.BorderStyle = BorderStyle.None;
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
        dgv.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
        dgv.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
        dgv.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
        dgv.AdvancedColumnHeadersBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Single;
        dgv.GridColor = Color.FromArgb(229, 231, 235);
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.AllowUserToResizeRows = false;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.RowHeadersVisible = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect = false;
        dgv.EnableHeadersVisualStyles = false;
        dgv.ColumnHeadersHeight = 36;
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
        dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 249, 250);
        dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
        dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
        dgv.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
        dgv.DefaultCellStyle.BackColor = Color.White;
        dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
        dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
        dgv.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
        dgv.RowTemplate.Height = 38;
    }

    private static void StylePrimaryButton(Button btn)
    {
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.BackColor = Color.FromArgb(59, 130, 246);
        btn.ForeColor = Color.White;
        btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        btn.Cursor = Cursors.Hand;
        btn.UseVisualStyleBackColor = false;
        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
        btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(29, 78, 216);
    }

    /// <summary>ComboBox.Flat + font lớn dễ bị clip dọc; ép chiều cao theo font thực tế và DPI.</summary>
    private static void SyncComboRenderedHeights(params ComboBox[] combos)
    {
        foreach (var c in combos)
        {
            var h = c.PreferredHeight;
            var target = Math.Max(h + 2, 31);
            c.Height = target;
        }
    }

    /// <summary>Outline button (nền trắng, viền & chữ màu brand/đỏ).
    /// btn-sm: cao 28, padding ngang ~12.</summary>
    private static void StyleSecondaryButton(Button btn, bool danger = false)
    {
        btn.FlatStyle = FlatStyle.Flat;
        btn.BackColor = Color.White;
        btn.UseVisualStyleBackColor = false;
        btn.Cursor = Cursors.Hand;
        btn.Font = new Font("Segoe UI", 9f);
        btn.Height = 28;
        btn.Padding = new Padding(6, 0, 6, 0);
        var accent = danger ? Color.FromArgb(220, 38, 38) : Color.FromArgb(59, 130, 246);
        btn.ForeColor = accent;
        btn.FlatAppearance.BorderColor = danger ? Color.FromArgb(252, 165, 165) : Color.FromArgb(191, 219, 254);
        btn.FlatAppearance.BorderSize = 1;
        btn.FlatAppearance.MouseOverBackColor = danger
            ? Color.FromArgb(254, 242, 242)
            : Color.FromArgb(239, 246, 255);
    }

    /// <summary>Vẽ tabs tối giản theo phong cách flat (no box, gạch dưới khi active).</summary>
    private static void ApplyFlatTabs(TabControl tc, bool inCard, int itemWidth = 140, int itemHeight = 32)
    {
        tc.DrawMode = TabDrawMode.OwnerDrawFixed;
        tc.SizeMode = TabSizeMode.Fixed;
        // FlatButtons — giảm khung 3D / viền đậm mặc định của TabControl quanh vùng nội dung tab.
        tc.Appearance = TabAppearance.FlatButtons;
        tc.ItemSize = new Size(itemWidth, itemHeight);
        tc.Padding = new Point(18, 6);

        var bg = inCard ? Color.White : Color.FromArgb(241, 245, 249);
        var underline = Color.FromArgb(59, 130, 246);
        var inkActive = Color.FromArgb(15, 23, 42);
        var inkIdle = Color.FromArgb(100, 116, 139);

        tc.DrawItem -= TabHandler;
        tc.DrawItem += TabHandler;

        void TabHandler(object? sender, DrawItemEventArgs e)
        {
            if (sender is not TabControl t || e.Index < 0 || e.Index >= t.TabPages.Count) return;
            var g = e.Graphics;
            var rect = t.GetTabRect(e.Index);
            var active = e.Index == t.SelectedIndex;

            using (var bgBrush = new SolidBrush(bg))
                g.FillRectangle(bgBrush, rect);

            var text = t.TabPages[e.Index].Text;
            using var font = new Font("Segoe UI", 10f, active ? FontStyle.Bold : FontStyle.Regular);
            var color = active ? inkActive : inkIdle;
            TextRenderer.DrawText(g, text, font, rect, color,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix);

            if (active)
            {
                using var pen = new Pen(underline, 2.5f);
                int y = rect.Bottom - 2;
                g.DrawLine(pen, rect.X + 14, y, rect.Right - 14, y);
            }
        }
    }

    private int? SelectedCategoryId() =>
        dgvCategories.CurrentRow?.Cells["Id"].Value is int id ? id : null;

    private void ReloadCatalog()
    {
        var cats = _svc.GetCategories();
        dgvCategories.DataSource = cats.Select(c => new
        {
            c.Id,
            c.Name,
            c.SortOrder,
            SoDichVu = c.ServiceCount,
            c.Description
        }).ToList();

        HideIdColumn(dgvCategories);
        LocalizeHeaders(dgvCategories,
            ("Name", "Tên phân loại"),
            ("SortOrder", "Thứ tự"),
            ("SoDichVu", "Số dịch vụ"),
            ("Description", "Mô tả"));

        ReloadServicesGrid();
        ReloadPackagesGrid();
        ReloadPriceRulesGrid();
    }

    private void ReloadServicesGrid()
    {
        var rows = _svc.GetServices(SelectedCategoryId(), null, chkShowHidden.Checked);
        dgvServices.DataSource = rows.Select(s => new
        {
            s.Id,
            s.Name,
            s.CategoryName,
            s.Unit,
            Gia = s.UnitPrice.ToString("N0"),
            TonKho = s.TrackInventory ? s.StockQuantity.ToString() : "—",
            An = s.IsHidden ? "Có" : ""
        }).ToList();
        HideIdColumn(dgvServices);
        LocalizeHeaders(dgvServices,
            ("Name", "Tên dịch vụ"),
            ("CategoryName", "Phân loại"),
            ("Unit", "Đơn vị"),
            ("Gia", "Giá bán"),
            ("TonKho", "Tồn kho"),
            ("An", "Đã ẩn"));
    }

    private void ReloadPackagesGrid()
    {
        var rows = _svc.GetPackages(null, chkShowHidden.Checked);
        dgvPackages.DataSource = rows.Select(p => new
        {
            p.Id,
            p.Name,
            GiaGoi = p.PackagePrice.ToString("N0"),
            p.ItemsSummary,
            An = p.IsHidden ? "Có" : ""
        }).ToList();
        HideIdColumn(dgvPackages);
        LocalizeHeaders(dgvPackages,
            ("Name", "Tên gói"),
            ("GiaGoi", "Giá gói"),
            ("ItemsSummary", "Dịch vụ trong gói"),
            ("An", "Đã ẩn"));
    }

    private void ReloadPriceRulesGrid()
    {
        int? serviceFilter = null;
        var catId = SelectedCategoryId();
        if (catId.HasValue)
            serviceFilter = _svc.GetServices(catId, null, true).FirstOrDefault()?.Id;

        var rows = _svc.GetPriceRules(serviceFilter);
        dgvPriceRules.DataSource = rows.Select(r => new
        {
            r.Id,
            r.ServiceName,
            r.RuleName,
            Loai = r.RuleTypeDisplay,
            Gia = r.Price.ToString("N0"),
            r.ScheduleSummary,
            r.Priority
        }).ToList();
        HideIdColumn(dgvPriceRules);
        LocalizeHeaders(dgvPriceRules,
            ("ServiceName", "Dịch vụ"),
            ("RuleName", "Tên quy tắc"),
            ("Loai", "Loại"),
            ("Gia", "Giá"),
            ("ScheduleSummary", "Lịch áp dụng"),
            ("Priority", "Ưu tiên"));
    }

    private static void HideIdColumn(DataGridView dgv)
    {
        if (dgv.Columns.Contains("Id"))
            dgv.Columns["Id"]!.Visible = false;
    }

    private static void LocalizeHeaders(DataGridView dgv, params (string Field, string Header)[] map)
    {
        foreach (var (field, header) in map)
        {
            if (dgv.Columns.Contains(field))
                dgv.Columns[field]!.HeaderText = header;
        }
    }

    private void ReloadOps()
    {
        var stays = _svc.GetActiveStays(null);
        cmbStay.DisplayMember = nameof(ActiveStayRow.Display);
        cmbStay.DataSource = stays.Count > 0
            ? stays
            : new[] { new ActiveStayRow { OrderId = 0, RoomId = 0, RoomName = "—", GuestName = "Chưa có khách lưu trú" } };

        BuildCategoryTabs();
        LoadCatalogList();
        ReloadOrderTracking();
    }

    private void BuildCategoryTabs()
    {
        tabSvcCategories.TabPages.Clear();
        tabSvcCategories.TabPages.Add(new TabPage("Tất cả") { Tag = null });
        foreach (var c in _svc.GetCategoriesForPicker())
            tabSvcCategories.TabPages.Add(new TabPage(c.Name) { Tag = c.Id });
        tabSvcCategories.SelectedIndex = 0;
    }

    private void LoadCatalogList()
    {
        int? catId = tabSvcCategories.SelectedTab?.Tag as int?;
        var items = _svc.GetCatalogItemsForOrder(catId, null);
        lstCatalog.DataSource = items;
        lstCatalog.DisplayMember = nameof(ServiceCatalogItemPick.Name);
    }

    private void ReloadOrderTracking()
    {
        _opsFulfillment?.Reload();
    }

    private void ReloadPayment()
    {
        var rows = _svc.GetOrdersAwaitingPayment();
        dgvPay.DataSource = rows.Select(o => new
        {
            o.Id,
            o.RoomName,
            o.ItemName,
            SoTien = o.LineTotal.ToString("N0"),
            o.GuestName,
            Luc = o.CreateAt.ToString("dd/MM HH:mm")
        }).ToList();
        HideIdColumn(dgvPay);
        LocalizeHeaders(dgvPay,
            ("RoomName", "Phòng"),
            ("ItemName", "Dịch vụ / Gói"),
            ("SoTien", "Số tiền"),
            ("GuestName", "Khách"),
            ("Luc", "Thời điểm"));
    }

    private int? SelectedOrderId() =>
        _opsFulfillment?.TryGetSelectedServiceOrderId();

    private void SetOrderStatus(string status)
    {
        if (SelectedOrderId() is not int id) return;
        try
        {
            _svc.UpdateServiceOrderStatus(id, status, null);
            ReloadOrderTracking();
            if (tabMain.SelectedTab == tabPayment) ReloadPayment();
        }
        catch (Exception ex) { ShowError(ex); }
    }

    private void ShowError(Exception ex) =>
        MessageBox.Show(ex.Message, "Dịch vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

    private void btnAddCategory_Click(object sender, EventArgs e) => EditCategory(null);
    private void btnEditCategory_Click(object sender, EventArgs e) => EditSelectedCategory();
    private void btnDeleteCategory_Click(object sender, EventArgs e) => DeleteSelectedCategory();
    private void btnAddService_Click(object sender, EventArgs e) => EditService(null);
    private void btnEditService_Click(object sender, EventArgs e) => EditSelectedService();
    private void btnToggleService_Click(object sender, EventArgs e) => ToggleServiceHidden();
    private void btnDeleteService_Click(object sender, EventArgs e) => DeleteSelectedService();
    private void chkShowHidden_CheckedChanged(object sender, EventArgs e) { ReloadServicesGrid(); ReloadPackagesGrid(); }
    private void btnAddPackage_Click(object sender, EventArgs e) => EditPackage(null);
    private void btnEditPackage_Click(object sender, EventArgs e) => EditSelectedPackage();
    private void btnDeletePackage_Click(object sender, EventArgs e) => DeleteSelectedPackage();
    private void btnAddPriceRule_Click(object sender, EventArgs e) => EditPriceRule(null);
    private void btnEditPriceRule_Click(object sender, EventArgs e) => EditSelectedPriceRule();
    private void btnDeletePriceRule_Click(object sender, EventArgs e) => DeleteSelectedPriceRule();
    private void tabSvcCategories_SelectedIndexChanged(object sender, EventArgs e) => LoadCatalogList();
    private void cmbOrderStatus_SelectedIndexChanged(object sender, EventArgs e) => ReloadOrderTracking();
    private void btnMarkPending_Click(object sender, EventArgs e) => SetOrderStatus(ServiceOrderStatus.Pending);
    private void btnMarkInProgress_Click(object sender, EventArgs e) => SetOrderStatus(ServiceOrderStatus.InProgress);
    private void btnMarkCompleted_Click(object sender, EventArgs e) => SetOrderStatus(ServiceOrderStatus.Completed);
    private void btnCancelOrder_Click(object sender, EventArgs e) => CancelOrder();
    private void btnReloadOps_Click(object sender, EventArgs e) => ReloadOps();
    private void btnCollectCash_Click(object sender, EventArgs e) => CollectPayment("Tiền mặt");
    private void btnCollectTransfer_Click(object sender, EventArgs e) => CollectPayment("Chuyển khoản");
    private void btnReloadPayment_Click(object sender, EventArgs e) => ReloadPayment();

    private void btnPlaceOrder_Click(object sender, EventArgs e)
    {
        if (cmbStay.SelectedItem is not ActiveStayRow stay || stay.OrderId == 0)
        {
            MessageBox.Show("Chọn phòng đang lưu trú.", "Vận hành", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (lstCatalog.SelectedItem is not ServiceCatalogItemPick pick)
        {
            MessageBox.Show("Chọn dịch vụ hoặc gói.", "Vận hành", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var charge = radChargeImmediate.Checked ? ServiceChargeMode.Immediate : ServiceChargeMode.Folio;
        string? notes = null;
        if (charge == ServiceChargeMode.Immediate)
        {
            var method = radPayCash.Checked ? "Tiền mặt" : "Chuyển khoản";
            notes = radOrderCtxWalkIn.Checked
                ? $"Quầy · thu ngay · {method}"
                : $"Thu ngay · {method}";
        }

        try
        {
            _svc.PlaceServiceOrder(
                stay.OrderId,
                stay.RoomId,
                pick.ServiceId,
                pick.PackageId,
                (int)numQty.Value,
                charge,
                notes,
                null);
            ReloadOrderTracking();
            MessageBox.Show("Đã ghi nhận yêu cầu dịch vụ.", "Vận hành", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) { ShowError(ex); }
    }

    private void CollectPayment(string method)
    {
        if (dgvPay.CurrentRow?.Cells["Id"].Value is not int id) return;
        try
        {
            _svc.PostImmediatePayment(id, method, null);
            ReloadPayment();
            ReloadOrderTracking();
            MessageBox.Show("Đã ghi nhận thanh toán.", "Thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) { ShowError(ex); }
    }

    private void CancelOrder()
    {
        if (SelectedOrderId() is not int id) return;
        var name = _opsFulfillment?.TryGetSelectedLineSummary() ?? "";
        using var dlg = new ServiceCancelForm(name);
        if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
        try
        {
            _svc.CancelServiceOrder(id, dlg.Reason, dlg.CancellationFee, null);
            ReloadOrderTracking();
        }
        catch (Exception ex) { ShowError(ex); }
    }

    private void btnRunReport_Click(object sender, EventArgs e)
    {
        if (cmbReportType.SelectedIndex == 0)
        {
            var rows = _svc.GetRevenueReport(dtpFrom.Value, dtpTo.Value, SelectedCategoryId());
            dgvReport.DataSource = rows.Select(r => new
            {
                r.CategoryName,
                r.OrderCount,
                DoanhThu = r.Revenue.ToString("N0"),
                PhiHuy = r.CancelFees.ToString("N0")
            }).ToList();
            LocalizeHeaders(dgvReport,
                ("CategoryName", "Phân loại"),
                ("OrderCount", "Số lượt"),
                ("DoanhThu", "Doanh thu"),
                ("PhiHuy", "Phí hủy"));
            return;
        }

        var usage = _svc.GetUsageReport(dtpFrom.Value, dtpTo.Value);
        dgvReport.DataSource = usage.Select(r => new
        {
            KhungGio = $"{r.Hour:00}:00",
            r.ServiceName,
            HoanThanh = r.CompletedCount,
            DaHuy = r.CancelledCount
        }).ToList();
        LocalizeHeaders(dgvReport,
            ("KhungGio", "Khung giờ"),
            ("ServiceName", "Dịch vụ"),
            ("HoanThanh", "Hoàn thành"),
            ("DaHuy", "Đã hủy"));
    }

    private void EditCategory(ServiceCategoryEditModel? model)
    {
        using var dlg = new ServiceCategoryEditForm(model);
        if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
        try { _svc.SaveCategory(dlg.Model); ReloadCatalog(); }
        catch (Exception ex) { ShowError(ex); }
    }

    private void EditSelectedCategory()
    {
        if (dgvCategories.CurrentRow?.Cells["Id"].Value is not int id) return;
        var model = _svc.GetCategoryForEdit(id);
        if (model != null) EditCategory(model);
    }

    private void DeleteSelectedCategory()
    {
        if (dgvCategories.CurrentRow?.Cells["Id"].Value is not int id) return;
        if (MessageBox.Show("Xóa phân loại này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        try { _svc.DeleteCategory(id); ReloadCatalog(); }
        catch (Exception ex) { ShowError(ex); }
    }

    private void EditService(ServiceEditModel? model)
    {
        var categories = _svc.GetCategories();
        if (model == null)
            model = new ServiceEditModel { CategoryId = SelectedCategoryId() ?? categories.FirstOrDefault()?.Id };

        using var dlg = new ServiceEditForm(model, categories);
        if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
        try { _svc.SaveService(dlg.Model); ReloadCatalog(); }
        catch (Exception ex) { ShowError(ex); }
    }

    private void EditSelectedService()
    {
        if (dgvServices.CurrentRow?.Cells["Id"].Value is not int id) return;
        var model = _svc.GetServiceForEdit(id);
        if (model != null) EditService(model);
    }

    private void ToggleServiceHidden()
    {
        if (dgvServices.CurrentRow?.Cells["Id"].Value is not int id) return;
        var row = _svc.GetServiceForEdit(id);
        if (row == null) return;
        try { _svc.SetServiceHidden(id, !row.IsHidden); ReloadServicesGrid(); }
        catch (Exception ex) { ShowError(ex); }
    }

    private void DeleteSelectedService()
    {
        if (dgvServices.CurrentRow?.Cells["Id"].Value is not int id) return;
        if (MessageBox.Show("Xóa dịch vụ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        try { _svc.DeleteService(id); ReloadCatalog(); }
        catch (Exception ex) { ShowError(ex); }
    }

    private void EditPackage(ServicePackageEditModel? model)
    {
        var services = _svc.GetServices(null, null, true);
        model ??= new ServicePackageEditModel();
        using var dlg = new ServicePackageEditForm(model, services);
        if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
        try { _svc.SavePackage(dlg.Model); ReloadPackagesGrid(); }
        catch (Exception ex) { ShowError(ex); }
    }

    private void EditSelectedPackage()
    {
        if (dgvPackages.CurrentRow?.Cells["Id"].Value is not int id) return;
        var model = _svc.GetPackageForEdit(id);
        if (model != null) EditPackage(model);
    }

    private void DeleteSelectedPackage()
    {
        if (dgvPackages.CurrentRow?.Cells["Id"].Value is not int id) return;
        if (MessageBox.Show("Xóa gói?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        try { _svc.DeletePackage(id); ReloadPackagesGrid(); }
        catch (Exception ex) { ShowError(ex); }
    }

    private void EditPriceRule(ServicePriceRuleEditModel? model)
    {
        var services = _svc.GetServices(null, null, true);
        model ??= new ServicePriceRuleEditModel();
        using var dlg = new ServicePriceRuleEditForm(model, services);
        if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
        try { _svc.SavePriceRule(dlg.Model); ReloadPriceRulesGrid(); }
        catch (Exception ex) { ShowError(ex); }
    }

    private void EditSelectedPriceRule()
    {
        if (dgvPriceRules.CurrentRow?.Cells["Id"].Value is not int id) return;
        var model = _svc.GetPriceRuleForEdit(id);
        if (model != null) EditPriceRule(model);
    }

    private void DeleteSelectedPriceRule()
    {
        if (dgvPriceRules.CurrentRow?.Cells["Id"].Value is not int id) return;
        if (MessageBox.Show("Xóa quy tắc giá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        try { _svc.DeletePriceRule(id); ReloadPriceRulesGrid(); }
        catch (Exception ex) { ShowError(ex); }
    }

    private sealed record StatusPick(string Value, string Label);
}
