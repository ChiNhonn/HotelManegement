using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Helpers;

namespace HotelManagement.CustomControls;

/// <summary>
/// Trang xem-tất-cả tái sử dụng cho mọi danh sách dạng bảng:
/// có nút "Quay lại", thanh tìm kiếm, bộ lọc, (tuỳ chọn) nút "Thêm" và phân trang 20 dòng/trang.
/// </summary>
public sealed class usPaginatedListPage : UserControl
{
    public sealed class ColumnSpec
    {
        public string Name { get; init; } = "";
        public string HeaderText { get; init; } = "";
        public int MinWidth { get; init; } = 100;
        public int FillWeight { get; init; } = 20;
        public bool IsImage { get; init; }
    }

    public const int PageSize = 20;

    private readonly Panel _pnlHeader = new();
    private readonly Button _btnBack = new();
    private readonly Label _lblTitle = new();
    private readonly Panel _pnlToolbar = new();
    private readonly TextBox _txtSearch = new();
    private readonly Label _lblSearchHint = new();
    private readonly ComboBox _cboFilter = new();
    private readonly Button _btnAdd = new();
    private readonly DataGridView _dgv = new();
    private readonly Panel _pnlFooter = new();
    private readonly Button _btnPrev = new();
    private readonly Button _btnNext = new();
    private readonly Label _lblPageInfo = new();
    private readonly Label _lblTotal = new();

    private List<object[]> _allRows = new();
    private List<object[]> _viewRows = new();
    private int _pageIndex;
    private bool _initialLoaded;

    public string PageTitle { get; set; } = "Danh sách";
    public IReadOnlyList<ColumnSpec> Columns { get; set; } = Array.Empty<ColumnSpec>();
    public Func<List<object[]>>? Loader { get; set; }

    /// <summary>Khi gán, ComboBox bộ lọc sẽ hiển thị (option đầu là "Tất cả").</summary>
    public IReadOnlyList<string>? FilterOptions { get; set; }

    /// <summary>(row, filterIndex) — true để giữ dòng. filterIndex = 0 là "Tất cả" (luôn pass).</summary>
    public Func<object[], int, bool>? FilterPredicate { get; set; }

    public string? AddButtonText { get; set; }
    public Action? OnAddClicked { get; set; }

    /// <summary>Callback khi bấm "Quay lại".</summary>
    public Action? OnBackClicked { get; set; }

    public Action<DataGridView, DataGridViewCellPaintingEventArgs>? OnCellPainting { get; set; }
    public Action<DataGridView, DataGridViewCellFormattingEventArgs>? OnCellFormatting { get; set; }

    public usPaginatedListPage()
    {
        BuildUi();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (_initialLoaded) return;
        _initialLoaded = true;

        _lblTitle.Text = PageTitle;
        BuildColumns();
        ConfigureFilter();
        ConfigureAddButton();
        LayoutToolbar();
        LayoutFooter();
        Reload();
    }

    public void Reload()
    {
        _allRows = Loader?.Invoke() ?? new List<object[]>();
        _pageIndex = 0;
        ApplyFilters();
    }

    private void BuildUi()
    {
        Dock = DockStyle.Fill;
        BackColor = Color.FromArgb(241, 245, 249);
        Font = new Font("Segoe UI", 9.5f);
        DoubleBuffered = true;

        BuildHeader();
        BuildToolbar();
        BuildGrid();
        BuildFooter();

        Controls.Add(_dgv);
        Controls.Add(_pnlFooter);
        Controls.Add(_pnlToolbar);
        Controls.Add(_pnlHeader);
    }

    private void BuildHeader()
    {
        _pnlHeader.Dock = DockStyle.Top;
        _pnlHeader.Height = 56;
        _pnlHeader.BackColor = Color.White;
        _pnlHeader.Padding = new Padding(20, 12, 20, 10);

        _btnBack.Text = "‹  Quay lại";
        _btnBack.Size = new Size(110, 32);
        _btnBack.FlatStyle = FlatStyle.Flat;
        _btnBack.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        _btnBack.BackColor = Color.White;
        _btnBack.ForeColor = Color.FromArgb(51, 65, 85);
        _btnBack.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
        _btnBack.Cursor = Cursors.Hand;
        _btnBack.Location = new Point(20, 12);
        _btnBack.Click += (_, _) => OnBackClicked?.Invoke();

        _lblTitle.AutoSize = true;
        _lblTitle.Location = new Point(150, 14);
        _lblTitle.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
        _lblTitle.ForeColor = Color.FromArgb(51, 65, 85);
        _lblTitle.Text = "Danh sách";

        _pnlHeader.Controls.Add(_btnBack);
        _pnlHeader.Controls.Add(_lblTitle);
    }

    private void BuildToolbar()
    {
        _pnlToolbar.Dock = DockStyle.Top;
        _pnlToolbar.Height = 64;
        _pnlToolbar.BackColor = Color.FromArgb(241, 245, 249);
        _pnlToolbar.Padding = new Padding(20, 12, 20, 12);

        _txtSearch.Font = new Font("Segoe UI", 10.5f);
        _txtSearch.BorderStyle = BorderStyle.FixedSingle;
        _txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        _txtSearch.Location = new Point(20, 18);
        _txtSearch.Size = new Size(420, 30);
        _txtSearch.TextChanged += (_, _) =>
        {
            _pageIndex = 0;
            ApplyFilters();
        };

        _lblSearchHint.Text = "Tìm kiếm…";
        _lblSearchHint.AutoSize = false;
        _lblSearchHint.Size = new Size(120, 20);
        _lblSearchHint.Location = new Point(28, 23);
        _lblSearchHint.ForeColor = Color.FromArgb(148, 163, 184);
        _lblSearchHint.BackColor = Color.White;
        _lblSearchHint.Font = new Font("Segoe UI", 10f);
        _lblSearchHint.Click += (_, _) => _txtSearch.Focus();
        _txtSearch.GotFocus += (_, _) => _lblSearchHint.Visible = false;
        _txtSearch.LostFocus += (_, _) => _lblSearchHint.Visible = _txtSearch.Text.Length == 0;

        _cboFilter.Font = new Font("Segoe UI", 10f);
        _cboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        _cboFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _cboFilter.Size = new Size(200, 30);
        _cboFilter.SelectedIndexChanged += (_, _) =>
        {
            _pageIndex = 0;
            ApplyFilters();
        };

        _btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _btnAdd.Size = new Size(170, 32);
        _btnAdd.FlatStyle = FlatStyle.Flat;
        _btnAdd.FlatAppearance.BorderSize = 0;
        _btnAdd.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
        _btnAdd.BackColor = Color.FromArgb(21, 100, 55);
        _btnAdd.ForeColor = Color.White;
        _btnAdd.Cursor = Cursors.Hand;
        _btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
        _btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
        _btnAdd.TextAlign = ContentAlignment.MiddleCenter;
        _btnAdd.Padding = new Padding(10, 0, 12, 0);
        _btnAdd.UseVisualStyleBackColor = false;
        _btnAdd.Click += (_, _) =>
        {
            OnAddClicked?.Invoke();
            Reload();
        };

        _pnlToolbar.Controls.Add(_txtSearch);
        _pnlToolbar.Controls.Add(_lblSearchHint);
        _pnlToolbar.Controls.Add(_cboFilter);
        _pnlToolbar.Controls.Add(_btnAdd);

        _pnlToolbar.Resize += (_, _) => LayoutToolbar();
    }

    private void ConfigureFilter()
    {
        _cboFilter.Items.Clear();
        if (FilterOptions != null && FilterOptions.Count > 0)
        {
            foreach (var opt in FilterOptions) _cboFilter.Items.Add(opt);
            _cboFilter.SelectedIndex = 0;
            _cboFilter.Visible = true;
        }
        else
        {
            _cboFilter.Visible = false;
        }
    }

    private void ConfigureAddButton()
    {
        if (!string.IsNullOrWhiteSpace(AddButtonText))
        {
            _btnAdd.Text = AddButtonText;
            _btnAdd.Visible = true;
            _btnAdd.Image?.Dispose();
            _btnAdd.Image = Mdl2Icons.Create('\uE710', Color.White, 18, 0.62f);
        }
        else
        {
            _btnAdd.Visible = false;
        }
    }

    private void LayoutToolbar()
    {
        var right = _pnlToolbar.ClientSize.Width - 20;
        if (_btnAdd.Visible)
        {
            _btnAdd.Left = right - _btnAdd.Width;
            _btnAdd.Top = 16;
            right = _btnAdd.Left - 12;
        }

        if (_cboFilter.Visible)
        {
            _cboFilter.Left = right - _cboFilter.Width;
            _cboFilter.Top = 18;
            right = _cboFilter.Left - 12;
        }

        _txtSearch.Width = Math.Max(180, right - _txtSearch.Left);
        _lblSearchHint.Left = _txtSearch.Left + 8;
    }

    private void BuildGrid()
    {
        _dgv.Dock = DockStyle.Fill;
        _dgv.BackgroundColor = Color.White;
        _dgv.BorderStyle = BorderStyle.None;
        _dgv.AllowUserToAddRows = false;
        _dgv.AllowUserToDeleteRows = false;
        _dgv.AllowUserToResizeRows = false;
        _dgv.AllowUserToOrderColumns = false;
        _dgv.AllowUserToResizeColumns = false;
        _dgv.ReadOnly = true;
        _dgv.MultiSelect = false;
        _dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _dgv.RowHeadersVisible = false;
        _dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        _dgv.GridColor = Color.FromArgb(241, 245, 249);
        _dgv.ScrollBars = ScrollBars.Vertical;
        _dgv.EnableHeadersVisualStyles = false;
        _dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        _dgv.ColumnHeadersHeight = 44;
        _dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        _dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
        _dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
        _dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
        _dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 8, 12, 8);
        _dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
        _dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(51, 65, 85);
        _dgv.DefaultCellStyle.BackColor = Color.White;
        _dgv.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
        _dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
        _dgv.DefaultCellStyle.Padding = new Padding(10, 6, 10, 6);
        _dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
        _dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
        _dgv.RowTemplate.Height = 44;
        _dgv.TabStop = false;
        _dgv.CellPainting += (s, ev) => OnCellPainting?.Invoke(_dgv, ev);
        _dgv.CellFormatting += (s, ev) => OnCellFormatting?.Invoke(_dgv, ev);
    }

    private void BuildColumns()
    {
        _dgv.Columns.Clear();
        foreach (var spec in Columns)
        {
            DataGridViewColumn col = spec.IsImage
                ? new DataGridViewImageColumn { ImageLayout = DataGridViewImageCellLayout.Zoom }
                : new DataGridViewTextBoxColumn();
            col.Name = spec.Name;
            col.HeaderText = spec.HeaderText;
            col.MinimumWidth = spec.MinWidth;
            col.FillWeight = Math.Max(1, spec.FillWeight);
            col.SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgv.Columns.Add(col);
        }
        _dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void BuildFooter()
    {
        _pnlFooter.Dock = DockStyle.Bottom;
        _pnlFooter.Height = 54;
        _pnlFooter.BackColor = Color.White;
        _pnlFooter.Padding = new Padding(20, 10, 20, 10);

        _lblTotal.AutoSize = true;
        _lblTotal.Font = new Font("Segoe UI", 9.5f);
        _lblTotal.ForeColor = Color.FromArgb(71, 85, 105);
        _lblTotal.Text = "0 dòng";
        _lblTotal.Location = new Point(20, 18);

        _btnPrev.Text = "‹ Trang trước";
        _btnPrev.Size = new Size(120, 32);
        _btnPrev.FlatStyle = FlatStyle.Flat;
        _btnPrev.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        _btnPrev.BackColor = Color.White;
        _btnPrev.Cursor = Cursors.Hand;
        _btnPrev.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _btnPrev.Click += (_, _) =>
        {
            if (_pageIndex > 0)
            {
                _pageIndex--;
                Render();
            }
        };

        _btnNext.Text = "Trang sau ›";
        _btnNext.Size = new Size(120, 32);
        _btnNext.FlatStyle = FlatStyle.Flat;
        _btnNext.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        _btnNext.BackColor = Color.White;
        _btnNext.Cursor = Cursors.Hand;
        _btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _btnNext.Click += (_, _) =>
        {
            var totalPages = Math.Max(1, (int)Math.Ceiling(_viewRows.Count / (double)PageSize));
            if (_pageIndex < totalPages - 1)
            {
                _pageIndex++;
                Render();
            }
        };

        _lblPageInfo.AutoSize = false;
        _lblPageInfo.Size = new Size(120, 30);
        _lblPageInfo.TextAlign = ContentAlignment.MiddleCenter;
        _lblPageInfo.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
        _lblPageInfo.ForeColor = Color.FromArgb(51, 65, 85);
        _lblPageInfo.Text = "1 / 1";
        _lblPageInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;

        _pnlFooter.Controls.Add(_lblTotal);
        _pnlFooter.Controls.Add(_btnPrev);
        _pnlFooter.Controls.Add(_lblPageInfo);
        _pnlFooter.Controls.Add(_btnNext);
        _pnlFooter.Resize += (_, _) => LayoutFooter();
    }

    private void LayoutFooter()
    {
        var right = _pnlFooter.ClientSize.Width - 20;
        _btnNext.Left = right - _btnNext.Width;
        _btnNext.Top = 11;
        _lblPageInfo.Left = _btnNext.Left - _lblPageInfo.Width - 4;
        _lblPageInfo.Top = 12;
        _btnPrev.Left = _lblPageInfo.Left - _btnPrev.Width - 4;
        _btnPrev.Top = 11;
    }

    private void ApplyFilters()
    {
        var search = _txtSearch.Text?.Trim() ?? "";
        var filterIdx = _cboFilter.Visible && _cboFilter.SelectedIndex >= 0 ? _cboFilter.SelectedIndex : 0;

        IEnumerable<object[]> q = _allRows;

        if (FilterPredicate != null && filterIdx > 0)
            q = q.Where(r => FilterPredicate(r, filterIdx));

        if (search.Length > 0)
            q = q.Where(r => RowMatchesSearch(r, search));

        _viewRows = q.ToList();
        _pageIndex = Math.Min(_pageIndex, Math.Max(0, (int)Math.Ceiling(_viewRows.Count / (double)PageSize) - 1));
        Render();
    }

    private static bool RowMatchesSearch(object[] row, string search)
    {
        foreach (var cell in row)
        {
            if (cell is null) continue;
            if (cell is Image) continue;
            var s = cell.ToString();
            if (!string.IsNullOrEmpty(s)
                && s.Contains(search, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }

    private void Render()
    {
        _dgv.SuspendLayout();
        _dgv.Rows.Clear();

        var totalPages = Math.Max(1, (int)Math.Ceiling(_viewRows.Count / (double)PageSize));
        if (_pageIndex >= totalPages) _pageIndex = totalPages - 1;
        if (_pageIndex < 0) _pageIndex = 0;

        var start = _pageIndex * PageSize;
        var end = Math.Min(_viewRows.Count, start + PageSize);
        for (var i = start; i < end; i++)
        {
            _dgv.Rows.Add(_viewRows[i]);
        }

        _lblTotal.Text = _viewRows.Count == _allRows.Count
            ? $"{_viewRows.Count:N0} dòng"
            : $"{_viewRows.Count:N0} / {_allRows.Count:N0} dòng";
        _lblPageInfo.Text = $"{_pageIndex + 1} / {totalPages}";

        _btnPrev.Enabled = _pageIndex > 0;
        _btnNext.Enabled = _pageIndex < totalPages - 1;

        _dgv.ResumeLayout();

        if (_dgv.Rows.Count > 0)
        {
            _dgv.ClearSelection();
            _dgv.CurrentCell = null;
        }

        LayoutFooter();
    }
}
