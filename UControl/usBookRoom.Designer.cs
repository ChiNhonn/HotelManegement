namespace HotelManagement.CustomControls
{
    partial class usBookRoom
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usBookRoom));
            pnlTop = new Panel();
            tblHeader = new TableLayoutPanel();
            lblTitle = new Label();
            flowToolbar = new FlowLayoutPanel();
            lblViewDate = new Label();
            dtpViewDate = new DateTimePicker();
            btnPrevWeek = new Button();
            btnToday = new Button();
            btnNextWeek = new Button();
            lblStatus = new Label();
            cmbStatusFilter = new ComboBox();
            lblRoomType = new Label();
            cmbRoomType = new ComboBox();
            lblSearch = new Label();
            txtSearch = new TextBox();
            cardRoomMap = new RoundedCardPanel();
            tblMapOuter = new TableLayoutPanel();
            lblMapTitle = new Label();
            scrollRoomTiles = new DoubleBufferedPanel();
            tblRoomTiles = new TableLayoutPanel();
            lblMapLegend = new Label();
            pnlTop.SuspendLayout();
            tblHeader.SuspendLayout();
            flowToolbar.SuspendLayout();
            cardRoomMap.SuspendLayout();
            tblMapOuter.SuspendLayout();
            scrollRoomTiles.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(tblHeader);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(3, 2, 3, 2);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1085, 88);
            pnlTop.TabIndex = 0;
            // 
            // tblHeader
            // 
            tblHeader.ColumnCount = 1;
            tblHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblHeader.Controls.Add(lblTitle, 0, 0);
            tblHeader.Controls.Add(flowToolbar, 0, 1);
            tblHeader.Dock = DockStyle.Fill;
            tblHeader.Location = new Point(0, 0);
            tblHeader.Margin = new Padding(0);
            tblHeader.Name = "tblHeader";
            tblHeader.RowCount = 2;
            tblHeader.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tblHeader.RowStyles.Add(new RowStyle());
            tblHeader.Size = new Size(1085, 88);
            tblHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(51, 65, 85);
            lblTitle.Location = new Point(18, 6);
            lblTitle.Margin = new Padding(18, 6, 3, 3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1064, 24);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý đặt phòng";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flowToolbar
            // 
            flowToolbar.AutoSize = true;
            flowToolbar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowToolbar.BackColor = Color.White;
            flowToolbar.Controls.Add(lblViewDate);
            flowToolbar.Controls.Add(dtpViewDate);
            flowToolbar.Controls.Add(btnPrevWeek);
            flowToolbar.Controls.Add(btnToday);
            flowToolbar.Controls.Add(btnNextWeek);
            flowToolbar.Controls.Add(lblStatus);
            flowToolbar.Controls.Add(cmbStatusFilter);
            flowToolbar.Controls.Add(lblRoomType);
            flowToolbar.Controls.Add(cmbRoomType);
            flowToolbar.Controls.Add(lblSearch);
            flowToolbar.Controls.Add(txtSearch);
            flowToolbar.Dock = DockStyle.Fill;
            flowToolbar.Location = new Point(16, 33);
            flowToolbar.Margin = new Padding(16, 0, 16, 8);
            flowToolbar.Name = "flowToolbar";
            flowToolbar.Padding = new Padding(0, 2, 0, 3);
            flowToolbar.Size = new Size(1053, 65);
            flowToolbar.TabIndex = 1;
            // 
            // lblViewDate
            // 
            lblViewDate.Anchor = AnchorStyles.Left;
            lblViewDate.AutoSize = true;
            lblViewDate.Font = new Font("Segoe UI", 9.5F);
            lblViewDate.ForeColor = Color.FromArgb(71, 85, 105);
            lblViewDate.Location = new Point(3, 11);
            lblViewDate.Margin = new Padding(3, 6, 5, 2);
            lblViewDate.Name = "lblViewDate";
            lblViewDate.Size = new Size(42, 17);
            lblViewDate.TabIndex = 0;
            lblViewDate.Text = "Ngày:";
            // 
            // dtpViewDate
            // 
            dtpViewDate.Anchor = AnchorStyles.Left;
            dtpViewDate.CalendarFont = new Font("Segoe UI", 9.5F);
            dtpViewDate.Font = new Font("Segoe UI", 9.5F);
            dtpViewDate.Format = DateTimePickerFormat.Short;
            dtpViewDate.Location = new Point(53, 6);
            dtpViewDate.Margin = new Padding(3, 2, 9, 2);
            dtpViewDate.Name = "dtpViewDate";
            dtpViewDate.Size = new Size(104, 24);
            dtpViewDate.TabIndex = 1;
            // 
            // btnPrevWeek
            // 
            btnPrevWeek.Anchor = AnchorStyles.Left;
            btnPrevWeek.Cursor = Cursors.Hand;
            btnPrevWeek.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnPrevWeek.FlatStyle = FlatStyle.Flat;
            btnPrevWeek.Font = new Font("Segoe UI", 9F);
            btnPrevWeek.Location = new Point(169, 4);
            btnPrevWeek.Margin = new Padding(3, 2, 4, 2);
            btnPrevWeek.Name = "btnPrevWeek";
            btnPrevWeek.Size = new Size(96, 28);
            btnPrevWeek.TabIndex = 2;
            btnPrevWeek.Text = "◀ Tuần trước";
            btnPrevWeek.UseVisualStyleBackColor = true;
            // 
            // btnToday
            // 
            btnToday.Anchor = AnchorStyles.Left;
            btnToday.Cursor = Cursors.Hand;
            btnToday.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
            btnToday.FlatStyle = FlatStyle.Flat;
            btnToday.Font = new Font("Segoe UI", 9F);
            btnToday.ForeColor = Color.FromArgb(59, 130, 246);
            btnToday.Location = new Point(272, 4);
            btnToday.Margin = new Padding(3, 2, 4, 2);
            btnToday.Name = "btnToday";
            btnToday.Size = new Size(78, 28);
            btnToday.TabIndex = 3;
            btnToday.Text = "Hôm nay";
            btnToday.UseVisualStyleBackColor = true;
            // 
            // btnNextWeek
            // 
            btnNextWeek.Anchor = AnchorStyles.Left;
            btnNextWeek.Cursor = Cursors.Hand;
            btnNextWeek.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnNextWeek.FlatStyle = FlatStyle.Flat;
            btnNextWeek.Font = new Font("Segoe UI", 9F);
            btnNextWeek.Location = new Point(357, 4);
            btnNextWeek.Margin = new Padding(3, 2, 14, 2);
            btnNextWeek.Name = "btnNextWeek";
            btnNextWeek.Size = new Size(92, 28);
            btnNextWeek.TabIndex = 4;
            btnNextWeek.Text = "Tuần sau ▶";
            btnNextWeek.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9.5F);
            lblStatus.ForeColor = Color.FromArgb(71, 85, 105);
            lblStatus.Location = new Point(466, 11);
            lblStatus.Margin = new Padding(3, 6, 5, 2);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(69, 17);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Trạng thái:";
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.Anchor = AnchorStyles.Left;
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.Font = new Font("Segoe UI", 9.5F);
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Location = new Point(543, 5);
            cmbStatusFilter.Margin = new Padding(3, 2, 12, 2);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(165, 25);
            cmbStatusFilter.TabIndex = 6;
            // 
            // lblRoomType
            // 
            lblRoomType.Anchor = AnchorStyles.Left;
            lblRoomType.AutoSize = true;
            lblRoomType.Font = new Font("Segoe UI", 9.5F);
            lblRoomType.ForeColor = Color.FromArgb(71, 85, 105);
            lblRoomType.Location = new Point(723, 11);
            lblRoomType.Margin = new Padding(3, 6, 5, 2);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(84, 17);
            lblRoomType.TabIndex = 7;
            lblRoomType.Text = "Hạng phòng:";
            // 
            // cmbRoomType
            // 
            cmbRoomType.Anchor = AnchorStyles.Left;
            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomType.Font = new Font("Segoe UI", 9.5F);
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(815, 5);
            cmbRoomType.Margin = new Padding(3, 2, 12, 2);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(158, 25);
            cmbRoomType.TabIndex = 8;
            // 
            // lblSearch
            // 
            lblSearch.Anchor = AnchorStyles.Left;
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9.5F);
            lblSearch.ForeColor = Color.FromArgb(71, 85, 105);
            lblSearch.Location = new Point(3, 41);
            lblSearch.Margin = new Padding(3, 6, 5, 2);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(71, 17);
            lblSearch.TabIndex = 9;
            lblSearch.Text = "Tìm nhanh:";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Left;
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.Location = new Point(82, 36);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(246, 24);
            txtSearch.TabIndex = 10;
            // 
            // cardRoomMap
            // 
            cardRoomMap.BackColor = Color.Transparent;
            cardRoomMap.BorderColor = Color.FromArgb(226, 232, 240);
            cardRoomMap.CardBackColor = Color.White;
            cardRoomMap.Controls.Add(tblMapOuter);
            cardRoomMap.Dock = DockStyle.Fill;
            cardRoomMap.Location = new Point(0, 88);
            cardRoomMap.Margin = new Padding(16, 4, 16, 9);
            cardRoomMap.Name = "cardRoomMap";
            cardRoomMap.Padding = new Padding(10, 6, 10, 8);
            cardRoomMap.Radius = 12;
            cardRoomMap.Size = new Size(1085, 347);
            cardRoomMap.TabIndex = 1;
            // 
            // tblMapOuter
            // 
            tblMapOuter.ColumnCount = 1;
            tblMapOuter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMapOuter.Controls.Add(lblMapTitle, 0, 0);
            tblMapOuter.Controls.Add(scrollRoomTiles, 0, 1);
            tblMapOuter.Controls.Add(lblMapLegend, 0, 2);
            tblMapOuter.Dock = DockStyle.Fill;
            tblMapOuter.Location = new Point(10, 6);
            tblMapOuter.Margin = new Padding(0);
            tblMapOuter.Name = "tblMapOuter";
            tblMapOuter.RowCount = 3;
            tblMapOuter.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tblMapOuter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMapOuter.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMapOuter.Size = new Size(1065, 333);
            tblMapOuter.TabIndex = 0;
            // 
            // lblMapTitle
            // 
            lblMapTitle.AutoSize = true;
            lblMapTitle.Dock = DockStyle.Fill;
            lblMapTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblMapTitle.ForeColor = Color.FromArgb(51, 65, 85);
            lblMapTitle.Location = new Point(3, 0);
            lblMapTitle.Margin = new Padding(3, 0, 3, 4);
            lblMapTitle.Name = "lblMapTitle";
            lblMapTitle.Size = new Size(1059, 20);
            lblMapTitle.TabIndex = 0;
            lblMapTitle.Text = "Sơ đồ Trạng thái Phòng";
            lblMapTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // scrollRoomTiles
            // 
            scrollRoomTiles.AutoScroll = true;
            scrollRoomTiles.AutoScrollMargin = new Size(12, 12);
            scrollRoomTiles.BackColor = Color.FromArgb(248, 250, 252);
            scrollRoomTiles.Controls.Add(tblRoomTiles);
            scrollRoomTiles.Dock = DockStyle.Fill;
            scrollRoomTiles.Location = new Point(0, 24);
            scrollRoomTiles.Margin = new Padding(0, 0, 0, 4);
            scrollRoomTiles.Name = "scrollRoomTiles";
            scrollRoomTiles.Padding = new Padding(20, 16, 20, 20);
            scrollRoomTiles.Size = new Size(1065, 285);
            scrollRoomTiles.TabIndex = 1;
            // 
            // tblRoomTiles
            // 
            tblRoomTiles.BackColor = Color.FromArgb(248, 250, 252);
            tblRoomTiles.ColumnCount = 1;
            tblRoomTiles.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 96F));
            tblRoomTiles.Location = new Point(20, 16);
            tblRoomTiles.Margin = new Padding(0);
            tblRoomTiles.Name = "tblRoomTiles";
            tblRoomTiles.Padding = new Padding(4, 4, 8, 8);
            tblRoomTiles.RowCount = 1;
            tblRoomTiles.RowStyles.Add(new RowStyle(SizeType.Absolute, 124F));
            tblRoomTiles.Size = new Size(147, 145);
            tblRoomTiles.TabIndex = 0;
            // 
            // lblMapLegend
            // 
            lblMapLegend.AutoSize = true;
            lblMapLegend.Dock = DockStyle.Fill;
            lblMapLegend.Font = new Font("Segoe UI", 9F);
            lblMapLegend.ForeColor = Color.FromArgb(100, 116, 139);
            lblMapLegend.Location = new Point(3, 313);
            lblMapLegend.Name = "lblMapLegend";
            lblMapLegend.Size = new Size(1059, 20);
            lblMapLegend.TabIndex = 2;
            lblMapLegend.Text = resources.GetString("lblMapLegend.Text");
            lblMapLegend.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // usBookRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            Controls.Add(cardRoomMap);
            Controls.Add(pnlTop);
            Margin = new Padding(3, 2, 3, 2);
            Name = "usBookRoom";
            Size = new Size(1085, 435);
            Load += usBookRoom_Load;
            pnlTop.ResumeLayout(false);
            tblHeader.ResumeLayout(false);
            tblHeader.PerformLayout();
            flowToolbar.ResumeLayout(false);
            flowToolbar.PerformLayout();
            cardRoomMap.ResumeLayout(false);
            tblMapOuter.ResumeLayout(false);
            tblMapOuter.PerformLayout();
            scrollRoomTiles.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel pnlTop;
        private TableLayoutPanel tblHeader;
        private FlowLayoutPanel flowToolbar;
        private Label lblViewDate;
        private DateTimePicker dtpViewDate;
        private Button btnPrevWeek;
        private Button btnToday;
        private Button btnNextWeek;
        private Label lblStatus;
        private ComboBox cmbStatusFilter;
        private Label lblRoomType;
        private ComboBox cmbRoomType;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblTitle;
        private RoundedCardPanel cardRoomMap;
        private TableLayoutPanel tblMapOuter;
        private Label lblMapTitle;
        private DoubleBufferedPanel scrollRoomTiles;
        private TableLayoutPanel tblRoomTiles;
        private Label lblMapLegend;
    }
}
