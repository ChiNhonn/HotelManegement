namespace HotelManagement.CustomControls;

partial class usPaginatedListPage
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlHeader = new Panel();
        btnBack = new Button();
        lblTitle = new Label();
        pnlToolbar = new Panel();
        txtSearch = new TextBox();
        lblSearchHint = new Label();
        cboFilter = new ComboBox();
        btnAdd = new Button();
        dgv = new DataGridView();
        pnlFooter = new Panel();
        lblTotal = new Label();
        btnPrev = new Button();
        lblPageInfo = new Label();
        btnNext = new Button();
        pnlHeader.SuspendLayout();
        pnlToolbar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        pnlFooter.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.White;
        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(btnBack);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Padding = new Padding(20, 12, 20, 10);
        pnlHeader.Size = new Size(800, 56);
        pnlHeader.TabIndex = 0;
        // 
        // btnBack
        // 
        btnBack.BackColor = Color.White;
        btnBack.Cursor = Cursors.Hand;
        btnBack.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnBack.FlatStyle = FlatStyle.Flat;
        btnBack.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        btnBack.ForeColor = Color.FromArgb(51, 65, 85);
        btnBack.Location = new Point(20, 12);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(110, 32);
        btnBack.TabIndex = 0;
        btnBack.Text = "‹  Quay lại";
        btnBack.UseVisualStyleBackColor = false;
        btnBack.Click += btnBack_Click;
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(51, 65, 85);
        lblTitle.Location = new Point(150, 14);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(104, 32);
        lblTitle.TabIndex = 1;
        lblTitle.Text = "Danh sách";
        // 
        // pnlToolbar
        // 
        pnlToolbar.BackColor = Color.FromArgb(241, 245, 249);
        pnlToolbar.Controls.Add(btnAdd);
        pnlToolbar.Controls.Add(cboFilter);
        pnlToolbar.Controls.Add(lblSearchHint);
        pnlToolbar.Controls.Add(txtSearch);
        pnlToolbar.Dock = DockStyle.Top;
        pnlToolbar.Location = new Point(0, 56);
        pnlToolbar.Name = "pnlToolbar";
        pnlToolbar.Padding = new Padding(20, 12, 20, 12);
        pnlToolbar.Size = new Size(800, 64);
        pnlToolbar.TabIndex = 1;
        pnlToolbar.Resize += pnlToolbar_Resize;
        // 
        // txtSearch
        // 
        txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtSearch.BorderStyle = BorderStyle.FixedSingle;
        txtSearch.Font = new Font("Segoe UI", 10.5F);
        txtSearch.Location = new Point(20, 18);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(420, 31);
        txtSearch.TabIndex = 0;
        txtSearch.TextChanged += txtSearch_TextChanged;
        txtSearch.GotFocus += txtSearch_GotFocus;
        txtSearch.LostFocus += txtSearch_LostFocus;
        // 
        // lblSearchHint
        // 
        lblSearchHint.BackColor = Color.White;
        lblSearchHint.Cursor = Cursors.IBeam;
        lblSearchHint.Font = new Font("Segoe UI", 10F);
        lblSearchHint.ForeColor = Color.FromArgb(148, 163, 184);
        lblSearchHint.Location = new Point(28, 23);
        lblSearchHint.Name = "lblSearchHint";
        lblSearchHint.Size = new Size(120, 20);
        lblSearchHint.TabIndex = 1;
        lblSearchHint.Text = "Tìm kiếm…";
        lblSearchHint.Click += lblSearchHint_Click;
        // 
        // cboFilter
        // 
        cboFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        cboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cboFilter.Font = new Font("Segoe UI", 10F);
        cboFilter.FormattingEnabled = true;
        cboFilter.Location = new Point(580, 18);
        cboFilter.Name = "cboFilter";
        cboFilter.Size = new Size(200, 31);
        cboFilter.TabIndex = 2;
        cboFilter.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
        // 
        // btnAdd
        // 
        btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnAdd.BackColor = Color.FromArgb(21, 100, 55);
        btnAdd.Cursor = Cursors.Hand;
        btnAdd.FlatAppearance.BorderSize = 0;
        btnAdd.FlatStyle = FlatStyle.Flat;
        btnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        btnAdd.ForeColor = Color.White;
        btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
        btnAdd.Location = new Point(610, 16);
        btnAdd.Name = "btnAdd";
        btnAdd.Padding = new Padding(10, 0, 12, 0);
        btnAdd.Size = new Size(170, 32);
        btnAdd.TabIndex = 3;
        btnAdd.TextAlign = ContentAlignment.MiddleCenter;
        btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnAdd.UseVisualStyleBackColor = false;
        btnAdd.Click += btnAdd_Click;
        // 
        // dgv
        // 
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.AllowUserToOrderColumns = false;
        dgv.AllowUserToResizeColumns = false;
        dgv.AllowUserToResizeRows = false;
        dgv.BackgroundColor = Color.White;
        dgv.BorderStyle = BorderStyle.None;
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Color.White,
            Font = new Font("Segoe UI", 9.75F, FontStyle.Bold),
            ForeColor = Color.FromArgb(51, 65, 85),
            Padding = new Padding(12, 8, 12, 8),
            SelectionBackColor = Color.White,
            SelectionForeColor = Color.FromArgb(51, 65, 85)
        };
        dgv.ColumnHeadersHeight = 44;
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgv.DefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Color.White,
            Font = new Font("Segoe UI", 9.5F),
            ForeColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(10, 6, 10, 6),
            SelectionBackColor = Color.FromArgb(239, 246, 255),
            SelectionForeColor = Color.FromArgb(30, 41, 59)
        };
        dgv.Dock = DockStyle.Fill;
        dgv.EnableHeadersVisualStyles = false;
        dgv.GridColor = Color.FromArgb(241, 245, 249);
        dgv.Location = new Point(0, 120);
        dgv.MultiSelect = false;
        dgv.Name = "dgv";
        dgv.ReadOnly = true;
        dgv.RowHeadersVisible = false;
        dgv.RowTemplate.Height = 44;
        dgv.ScrollBars = ScrollBars.Vertical;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.Size = new Size(800, 366);
        dgv.TabIndex = 2;
        dgv.TabStop = false;
        dgv.CellFormatting += dgv_CellFormatting;
        dgv.CellPainting += dgv_CellPainting;
        // 
        // pnlFooter
        // 
        pnlFooter.BackColor = Color.White;
        pnlFooter.Controls.Add(btnNext);
        pnlFooter.Controls.Add(lblPageInfo);
        pnlFooter.Controls.Add(btnPrev);
        pnlFooter.Controls.Add(lblTotal);
        pnlFooter.Dock = DockStyle.Bottom;
        pnlFooter.Location = new Point(0, 486);
        pnlFooter.Name = "pnlFooter";
        pnlFooter.Padding = new Padding(20, 10, 20, 10);
        pnlFooter.Size = new Size(800, 54);
        pnlFooter.TabIndex = 3;
        pnlFooter.Resize += pnlFooter_Resize;
        // 
        // lblTotal
        // 
        lblTotal.AutoSize = true;
        lblTotal.Font = new Font("Segoe UI", 9.5F);
        lblTotal.ForeColor = Color.FromArgb(71, 85, 105);
        lblTotal.Location = new Point(20, 18);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(52, 21);
        lblTotal.TabIndex = 0;
        lblTotal.Text = "0 dòng";
        // 
        // btnPrev
        // 
        btnPrev.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrev.BackColor = Color.White;
        btnPrev.Cursor = Cursors.Hand;
        btnPrev.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnPrev.FlatStyle = FlatStyle.Flat;
        btnPrev.Location = new Point(528, 11);
        btnPrev.Name = "btnPrev";
        btnPrev.Size = new Size(120, 32);
        btnPrev.TabIndex = 1;
        btnPrev.Text = "‹ Trang trước";
        btnPrev.UseVisualStyleBackColor = false;
        btnPrev.Click += btnPrev_Click;
        // 
        // lblPageInfo
        // 
        lblPageInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblPageInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        lblPageInfo.ForeColor = Color.FromArgb(51, 65, 85);
        lblPageInfo.Location = new Point(652, 12);
        lblPageInfo.Name = "lblPageInfo";
        lblPageInfo.Size = new Size(120, 30);
        lblPageInfo.TabIndex = 2;
        lblPageInfo.Text = "1 / 1";
        lblPageInfo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btnNext
        // 
        btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnNext.BackColor = Color.White;
        btnNext.Cursor = Cursors.Hand;
        btnNext.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnNext.FlatStyle = FlatStyle.Flat;
        btnNext.Location = new Point(660, 11);
        btnNext.Name = "btnNext";
        btnNext.Size = new Size(120, 32);
        btnNext.TabIndex = 3;
        btnNext.Text = "Trang sau ›";
        btnNext.UseVisualStyleBackColor = false;
        btnNext.Click += btnNext_Click;
        // 
        // usPaginatedListPage
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(241, 245, 249);
        Controls.Add(dgv);
        Controls.Add(pnlFooter);
        Controls.Add(pnlToolbar);
        Controls.Add(pnlHeader);
        DoubleBuffered = true;
        Font = new Font("Segoe UI", 9.5F);
        Name = "usPaginatedListPage";
        Size = new Size(800, 540);
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        pnlToolbar.ResumeLayout(false);
        pnlToolbar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        pnlFooter.ResumeLayout(false);
        pnlFooter.PerformLayout();
        ResumeLayout(false);
    }

    private Panel pnlHeader;
    private Button btnBack;
    private Label lblTitle;
    private Panel pnlToolbar;
    private TextBox txtSearch;
    private Label lblSearchHint;
    private ComboBox cboFilter;
    private Button btnAdd;
    private DataGridView dgv;
    private Panel pnlFooter;
    private Label lblTotal;
    private Button btnPrev;
    private Label lblPageInfo;
    private Button btnNext;
}
