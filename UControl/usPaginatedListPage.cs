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
public partial class usPaginatedListPage : UserControl
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
        InitializeComponent();
        Dock = DockStyle.Fill;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (_initialLoaded) return;
        _initialLoaded = true;

        lblTitle.Text = PageTitle;
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

    private void btnBack_Click(object? sender, EventArgs e) => OnBackClicked?.Invoke();

    private void txtSearch_TextChanged(object? sender, EventArgs e)
    {
        _pageIndex = 0;
        ApplyFilters();
    }

    private void txtSearch_GotFocus(object? sender, EventArgs e) => lblSearchHint.Visible = false;

    private void txtSearch_LostFocus(object? sender, EventArgs e) =>
        lblSearchHint.Visible = txtSearch.Text.Length == 0;

    private void lblSearchHint_Click(object? sender, EventArgs e) => txtSearch.Focus();

    private void cboFilter_SelectedIndexChanged(object? sender, EventArgs e)
    {
        _pageIndex = 0;
        ApplyFilters();
    }

    private void btnAdd_Click(object? sender, EventArgs e)
    {
        OnAddClicked?.Invoke();
        Reload();
    }

    private void btnPrev_Click(object? sender, EventArgs e)
    {
        if (_pageIndex > 0)
        {
            _pageIndex--;
            Render();
        }
    }

    private void btnNext_Click(object? sender, EventArgs e)
    {
        var totalPages = Math.Max(1, (int)Math.Ceiling(_viewRows.Count / (double)PageSize));
        if (_pageIndex < totalPages - 1)
        {
            _pageIndex++;
            Render();
        }
    }

    private void pnlToolbar_Resize(object? sender, EventArgs e) => LayoutToolbar();

    private void pnlFooter_Resize(object? sender, EventArgs e) => LayoutFooter();

    private void dgv_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e) =>
        OnCellPainting?.Invoke(dgv, e);

    private void dgv_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e) =>
        OnCellFormatting?.Invoke(dgv, e);

    private void ConfigureFilter()
    {
        cboFilter.Items.Clear();
        if (FilterOptions != null && FilterOptions.Count > 0)
        {
            foreach (var opt in FilterOptions) cboFilter.Items.Add(opt);
            cboFilter.SelectedIndex = 0;
            cboFilter.Visible = true;
        }
        else
        {
            cboFilter.Visible = false;
        }
    }

    private void ConfigureAddButton()
    {
        if (!string.IsNullOrWhiteSpace(AddButtonText))
        {
            btnAdd.Text = AddButtonText;
            btnAdd.Visible = true;
            btnAdd.Image?.Dispose();
            btnAdd.Image = Mdl2Icons.Create('\uE710', Color.White, 18, 0.62f);
        }
        else
        {
            btnAdd.Visible = false;
        }
    }

    private void LayoutToolbar()
    {
        var right = pnlToolbar.ClientSize.Width - 20;
        if (btnAdd.Visible)
        {
            btnAdd.Left = right - btnAdd.Width;
            btnAdd.Top = 16;
            right = btnAdd.Left - 12;
        }

        if (cboFilter.Visible)
        {
            cboFilter.Left = right - cboFilter.Width;
            cboFilter.Top = 18;
            right = cboFilter.Left - 12;
        }

        txtSearch.Width = Math.Max(180, right - txtSearch.Left);
        lblSearchHint.Left = txtSearch.Left + 8;
    }

    private void BuildColumns()
    {
        dgv.Columns.Clear();
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
            dgv.Columns.Add(col);
        }
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void LayoutFooter()
    {
        var right = pnlFooter.ClientSize.Width - 20;
        btnNext.Left = right - btnNext.Width;
        btnNext.Top = 11;
        lblPageInfo.Left = btnNext.Left - lblPageInfo.Width - 4;
        lblPageInfo.Top = 12;
        btnPrev.Left = lblPageInfo.Left - btnPrev.Width - 4;
        btnPrev.Top = 11;
    }

    private void ApplyFilters()
    {
        var search = txtSearch.Text?.Trim() ?? "";
        var filterIdx = cboFilter.Visible && cboFilter.SelectedIndex >= 0 ? cboFilter.SelectedIndex : 0;

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
        dgv.SuspendLayout();
        dgv.Rows.Clear();

        var totalPages = Math.Max(1, (int)Math.Ceiling(_viewRows.Count / (double)PageSize));
        if (_pageIndex >= totalPages) _pageIndex = totalPages - 1;
        if (_pageIndex < 0) _pageIndex = 0;

        var start = _pageIndex * PageSize;
        var end = Math.Min(_viewRows.Count, start + PageSize);
        for (var i = start; i < end; i++)
        {
            dgv.Rows.Add(_viewRows[i]);
        }

        lblTotal.Text = _viewRows.Count == _allRows.Count
            ? $"{_viewRows.Count:N0} dòng"
            : $"{_viewRows.Count:N0} / {_allRows.Count:N0} dòng";
        lblPageInfo.Text = $"{_pageIndex + 1} / {totalPages}";

        btnPrev.Enabled = _pageIndex > 0;
        btnNext.Enabled = _pageIndex < totalPages - 1;

        dgv.ResumeLayout();

        if (dgv.Rows.Count > 0)
        {
            dgv.ClearSelection();
            dgv.CurrentCell = null;
        }

        LayoutFooter();
    }
}
