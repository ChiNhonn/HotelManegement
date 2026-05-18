namespace HotelManagement.CustomControls
{
    partial class usRoom
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            tabMain = new TabControl();
            tabRooms = new TabPage();
            pnlRoomsRoot = new Panel();
            dgvRooms = new DataGridView();
            tlpRoomToolbar = new TableLayoutPanel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblFloor = new Label();
            cmbFilterFloor = new ComboBox();
            lblRoomType = new Label();
            cmbFilterRoomType = new ComboBox();
            lblOperational = new Label();
            btnRefreshList = new Button();
            btnBulkCreate = new Button();
            cmbOperationalApply = new ComboBox();
            flpButton = new FlowLayoutPanel();
            btnAddRoom = new Button();
            btnEditRoom = new Button();
            btnDeleteRoom = new Button();
            tabRoomTypes = new TabPage();
            pnlRoomTypesRoot = new Panel();
            dgvRoomTypes = new DataGridView();
            pnlTypesToolbar = new Panel();
            lblRoomTypesTitle = new Label();
            txtRoomTypeSearch = new TextBox();
            btnRoomTypeRefresh = new Button();
            btnRoomTypeAdd = new Button();
            btnRoomTypeEdit = new Button();
            btnRoomTypeDelete = new Button();
            tabFloors = new TabPage();
            pnlFloorsRoot = new Panel();
            pnlFloorsScroll = new Panel();
            flowFloorMgmtLayout = new FlowLayoutPanel();
            pnlFloorsToolbar = new Panel();
            lblFloorsTitle = new Label();
            txtFloorSearch = new TextBox();
            btnFloorRefresh = new Button();
            btnFloorAdd = new Button();
            btnFloorEdit = new Button();
            btnFloorDelete = new Button();
            tabBranches = new TabPage();
            pnlBranchesRoot = new Panel();
            dgvBranches = new DataGridView();
            pnlBranchesToolbar = new Panel();
            lblBranchesTitle = new Label();
            txtBranchSearch = new TextBox();
            btnBranchRefresh = new Button();
            btnBranchAdd = new Button();
            btnBranchEdit = new Button();
            btnBranchDelete = new Button();
            tabMain.SuspendLayout();
            tabRooms.SuspendLayout();
            pnlRoomsRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            tlpRoomToolbar.SuspendLayout();
            flpButton.SuspendLayout();
            tabRoomTypes.SuspendLayout();
            pnlRoomTypesRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoomTypes).BeginInit();
            pnlTypesToolbar.SuspendLayout();
            tabFloors.SuspendLayout();
            pnlFloorsRoot.SuspendLayout();
            pnlFloorsScroll.SuspendLayout();
            pnlFloorsToolbar.SuspendLayout();
            tabBranches.SuspendLayout();
            pnlBranchesRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBranches).BeginInit();
            pnlBranchesToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabRooms);
            tabMain.Controls.Add(tabRoomTypes);
            tabMain.Controls.Add(tabFloors);
            tabMain.Controls.Add(tabBranches);
            tabMain.Dock = DockStyle.Fill;
            tabMain.Font = new Font("Segoe UI", 10F);
            tabMain.Location = new Point(0, 0);
            tabMain.Margin = new Padding(2);
            tabMain.Name = "tabMain";
            tabMain.Padding = new Point(10, 8);
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(1100, 552);
            tabMain.TabIndex = 0;
            // 
            // tabRooms
            // 
            tabRooms.Controls.Add(pnlRoomsRoot);
            tabRooms.Location = new Point(4, 42);
            tabRooms.Margin = new Padding(3, 4, 3, 4);
            tabRooms.Name = "tabRooms";
            tabRooms.Padding = new Padding(10, 12, 10, 10);
            tabRooms.Size = new Size(1092, 506);
            tabRooms.TabIndex = 0;
            tabRooms.Text = "Quản lý phòng";
            tabRooms.UseVisualStyleBackColor = true;
            // 
            // pnlRoomsRoot
            // 
            pnlRoomsRoot.BackColor = Color.FromArgb(241, 245, 249);
            pnlRoomsRoot.Controls.Add(dgvRooms);
            pnlRoomsRoot.Controls.Add(tlpRoomToolbar);
            pnlRoomsRoot.Dock = DockStyle.Fill;
            pnlRoomsRoot.Location = new Point(10, 12);
            pnlRoomsRoot.Name = "pnlRoomsRoot";
            pnlRoomsRoot.Padding = new Padding(0, 0, 0, 6);
            pnlRoomsRoot.Size = new Size(1072, 484);
            pnlRoomsRoot.TabIndex = 0;
            // 
            // dgvRooms
            // 
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.AllowUserToDeleteRows = false;
            dgvRooms.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvRooms.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRooms.BackgroundColor = Color.White;
            dgvRooms.BorderStyle = BorderStyle.None;
            dgvRooms.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRooms.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvRooms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.LightCyan;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvRooms.DefaultCellStyle = dataGridViewCellStyle3;
            dgvRooms.Dock = DockStyle.Fill;
            dgvRooms.EnableHeadersVisualStyles = false;
            dgvRooms.GridColor = Color.Gainsboro;
            dgvRooms.Location = new Point(0, 132);
            dgvRooms.Name = "dgvRooms";
            dgvRooms.ReadOnly = true;
            dgvRooms.RowHeadersVisible = false;
            dgvRooms.RowHeadersWidth = 51;
            dgvRooms.RowTemplate.Height = 40;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.Size = new Size(1072, 346);
            dgvRooms.TabIndex = 1;
            dgvRooms.SelectionChanged += DgvRooms_SelectionChanged;
            // 
            // tlpRoomToolbar
            // 
            tlpRoomToolbar.AutoSize = true;
            tlpRoomToolbar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpRoomToolbar.BackColor = Color.White;
            tlpRoomToolbar.ColumnCount = 9;
            tlpRoomToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 89F));
            tlpRoomToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.9444447F));
            tlpRoomToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68.05556F));
            tlpRoomToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 116F));
            tlpRoomToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 57F));
            tlpRoomToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 133F));
            tlpRoomToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 103F));
            tlpRoomToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 119F));
            tlpRoomToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 149F));
            tlpRoomToolbar.Controls.Add(lblSearch, 0, 0);
            tlpRoomToolbar.Controls.Add(txtSearch, 1, 0);
            tlpRoomToolbar.Controls.Add(lblFloor, 4, 0);
            tlpRoomToolbar.Controls.Add(cmbFilterFloor, 5, 0);
            tlpRoomToolbar.Controls.Add(lblRoomType, 6, 0);
            tlpRoomToolbar.Controls.Add(cmbFilterRoomType, 7, 0);
            tlpRoomToolbar.Controls.Add(lblOperational, 3, 1);
            tlpRoomToolbar.Controls.Add(btnRefreshList, 3, 0);
            tlpRoomToolbar.Controls.Add(btnBulkCreate, 8, 0);
            tlpRoomToolbar.Controls.Add(cmbOperationalApply, 5, 1);
            tlpRoomToolbar.Controls.Add(flpButton, 0, 1);
            tlpRoomToolbar.Dock = DockStyle.Top;
            tlpRoomToolbar.Location = new Point(0, 0);
            tlpRoomToolbar.Margin = new Padding(0, 0, 0, 10);
            tlpRoomToolbar.Name = "tlpRoomToolbar";
            tlpRoomToolbar.Padding = new Padding(12);
            tlpRoomToolbar.RowCount = 3;
            tlpRoomToolbar.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tlpRoomToolbar.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tlpRoomToolbar.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpRoomToolbar.Size = new Size(1072, 132);
            tlpRoomToolbar.TabIndex = 0;
            // 
            // lblSearch
            // 
            lblSearch.Anchor = AnchorStyles.Left;
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(15, 22);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(79, 23);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tlpRoomToolbar.SetColumnSpan(txtSearch, 2);
            txtSearch.Location = new Point(104, 19);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm theo số phòng…";
            txtSearch.Size = new Size(275, 30);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblFloor
            // 
            lblFloor.Anchor = AnchorStyles.Left;
            lblFloor.AutoSize = true;
            lblFloor.Location = new Point(501, 22);
            lblFloor.Name = "lblFloor";
            lblFloor.Size = new Size(48, 23);
            lblFloor.TabIndex = 4;
            lblFloor.Text = "Tầng";
            // 
            // cmbFilterFloor
            // 
            cmbFilterFloor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbFilterFloor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterFloor.FormattingEnabled = true;
            cmbFilterFloor.Location = new Point(558, 20);
            cmbFilterFloor.Margin = new Padding(3, 4, 3, 4);
            cmbFilterFloor.Name = "cmbFilterFloor";
            cmbFilterFloor.Size = new Size(127, 31);
            cmbFilterFloor.TabIndex = 5;
            cmbFilterFloor.SelectedIndexChanged += CmbFilterFloor_SelectedIndexChanged;
            // 
            // lblRoomType
            // 
            lblRoomType.Anchor = AnchorStyles.Left;
            lblRoomType.AutoSize = true;
            lblRoomType.Location = new Point(691, 22);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(96, 23);
            lblRoomType.TabIndex = 6;
            lblRoomType.Text = "Loại phòng";
            // 
            // cmbFilterRoomType
            // 
            cmbFilterRoomType.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbFilterRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterRoomType.FormattingEnabled = true;
            cmbFilterRoomType.Location = new Point(794, 20);
            cmbFilterRoomType.Margin = new Padding(3, 4, 3, 4);
            cmbFilterRoomType.Name = "cmbFilterRoomType";
            cmbFilterRoomType.Size = new Size(113, 31);
            cmbFilterRoomType.TabIndex = 7;
            cmbFilterRoomType.SelectedIndexChanged += CmbFilterRoomType_SelectedIndexChanged;
            // 
            // lblOperational
            // 
            lblOperational.Anchor = AnchorStyles.Left;
            lblOperational.AutoSize = true;
            tlpRoomToolbar.SetColumnSpan(lblOperational, 2);
            lblOperational.Location = new Point(385, 66);
            lblOperational.Name = "lblOperational";
            lblOperational.Size = new Size(138, 23);
            lblOperational.TabIndex = 11;
            lblOperational.Text = "Vận hành / khóa";
            // 
            // btnRefreshList
            // 
            btnRefreshList.Anchor = AnchorStyles.Right;
            btnRefreshList.Location = new Point(400, 16);
            btnRefreshList.Margin = new Padding(3, 4, 3, 4);
            btnRefreshList.Name = "btnRefreshList";
            btnRefreshList.Size = new Size(95, 36);
            btnRefreshList.TabIndex = 3;
            btnRefreshList.Text = "Làm mới";
            btnRefreshList.UseVisualStyleBackColor = true;
            btnRefreshList.Click += BtnRefreshList_Click;
            // 
            // btnBulkCreate
            // 
            btnBulkCreate.Anchor = AnchorStyles.Right;
            btnBulkCreate.BackColor = Color.Silver;
            btnBulkCreate.FlatStyle = FlatStyle.Flat;
            btnBulkCreate.ForeColor = Color.White;
            btnBulkCreate.Location = new Point(926, 17);
            btnBulkCreate.Margin = new Padding(3, 4, 3, 4);
            btnBulkCreate.Name = "btnBulkCreate";
            btnBulkCreate.Size = new Size(131, 34);
            btnBulkCreate.TabIndex = 14;
            btnBulkCreate.Text = "Tạo hàng loạt";
            btnBulkCreate.UseVisualStyleBackColor = false;
            btnBulkCreate.Click += BtnBulkCreate_Click;
            // 
            // cmbOperationalApply
            // 
            cmbOperationalApply.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tlpRoomToolbar.SetColumnSpan(cmbOperationalApply, 4);
            cmbOperationalApply.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOperationalApply.FormattingEnabled = true;
            cmbOperationalApply.Location = new Point(558, 64);
            cmbOperationalApply.Margin = new Padding(3, 4, 3, 4);
            cmbOperationalApply.Name = "cmbOperationalApply";
            cmbOperationalApply.Size = new Size(499, 31);
            cmbOperationalApply.TabIndex = 12;
            cmbOperationalApply.SelectedIndexChanged += CmbOperationalApply_SelectedIndexChanged;
            // 
            // flpButton
            // 
            tlpRoomToolbar.SetColumnSpan(flpButton, 3);
            flpButton.Controls.Add(btnAddRoom);
            flpButton.Controls.Add(btnEditRoom);
            flpButton.Controls.Add(btnDeleteRoom);
            flpButton.Location = new Point(15, 59);
            flpButton.Name = "flpButton";
            flpButton.Size = new Size(283, 38);
            flpButton.TabIndex = 15;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Anchor = AnchorStyles.Right;
            btnAddRoom.BackColor = Color.FromArgb(21, 128, 61);
            btnAddRoom.FlatStyle = FlatStyle.Flat;
            btnAddRoom.ForeColor = Color.White;
            btnAddRoom.Location = new Point(3, 4);
            btnAddRoom.Margin = new Padding(3, 4, 3, 4);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(83, 36);
            btnAddRoom.TabIndex = 8;
            btnAddRoom.Text = "Thêm";
            btnAddRoom.UseVisualStyleBackColor = false;
            btnAddRoom.Click += BtnAddRoom_Click;
            // 
            // btnEditRoom
            // 
            btnEditRoom.Anchor = AnchorStyles.Left;
            btnEditRoom.BackColor = Color.DeepSkyBlue;
            btnEditRoom.FlatStyle = FlatStyle.Flat;
            btnEditRoom.ForeColor = Color.White;
            btnEditRoom.Location = new Point(92, 5);
            btnEditRoom.Margin = new Padding(3, 4, 3, 4);
            btnEditRoom.Name = "btnEditRoom";
            btnEditRoom.Size = new Size(76, 34);
            btnEditRoom.TabIndex = 9;
            btnEditRoom.Text = "Sửa";
            btnEditRoom.UseVisualStyleBackColor = false;
            btnEditRoom.Click += BtnEditRoom_Click;
            // 
            // btnDeleteRoom
            // 
            btnDeleteRoom.Anchor = AnchorStyles.Left;
            btnDeleteRoom.BackColor = Color.Red;
            btnDeleteRoom.FlatStyle = FlatStyle.Flat;
            btnDeleteRoom.ForeColor = Color.White;
            btnDeleteRoom.Location = new Point(174, 5);
            btnDeleteRoom.Margin = new Padding(3, 4, 3, 4);
            btnDeleteRoom.Name = "btnDeleteRoom";
            btnDeleteRoom.Size = new Size(84, 34);
            btnDeleteRoom.TabIndex = 10;
            btnDeleteRoom.Text = "Xóa";
            btnDeleteRoom.UseVisualStyleBackColor = false;
            btnDeleteRoom.Click += BtnDeleteRoom_Click;
            // 
            // tabRoomTypes
            // 
            tabRoomTypes.Controls.Add(pnlRoomTypesRoot);
            tabRoomTypes.Location = new Point(4, 42);
            tabRoomTypes.Margin = new Padding(3, 4, 3, 4);
            tabRoomTypes.Name = "tabRoomTypes";
            tabRoomTypes.Padding = new Padding(10);
            tabRoomTypes.Size = new Size(1092, 506);
            tabRoomTypes.TabIndex = 1;
            tabRoomTypes.Text = "Quản lý loại phòng";
            tabRoomTypes.UseVisualStyleBackColor = true;
            // 
            // pnlRoomTypesRoot
            // 
            pnlRoomTypesRoot.BackColor = Color.FromArgb(241, 245, 249);
            pnlRoomTypesRoot.Controls.Add(dgvRoomTypes);
            pnlRoomTypesRoot.Controls.Add(pnlTypesToolbar);
            pnlRoomTypesRoot.Dock = DockStyle.Fill;
            pnlRoomTypesRoot.Location = new Point(10, 10);
            pnlRoomTypesRoot.Name = "pnlRoomTypesRoot";
            pnlRoomTypesRoot.Padding = new Padding(0, 0, 0, 6);
            pnlRoomTypesRoot.Size = new Size(1072, 486);
            pnlRoomTypesRoot.TabIndex = 0;
            // 
            // dgvRoomTypes
            // 
            dgvRoomTypes.AllowUserToAddRows = false;
            dgvRoomTypes.AllowUserToDeleteRows = false;
            dgvRoomTypes.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.WhiteSmoke;
            dgvRoomTypes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvRoomTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoomTypes.BackgroundColor = Color.White;
            dgvRoomTypes.BorderStyle = BorderStyle.None;
            dgvRoomTypes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRoomTypes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvRoomTypes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvRoomTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.LightCyan;
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvRoomTypes.DefaultCellStyle = dataGridViewCellStyle6;
            dgvRoomTypes.Dock = DockStyle.Fill;
            dgvRoomTypes.EnableHeadersVisualStyles = false;
            dgvRoomTypes.GridColor = Color.Gainsboro;
            dgvRoomTypes.Location = new Point(0, 108);
            dgvRoomTypes.Name = "dgvRoomTypes";
            dgvRoomTypes.ReadOnly = true;
            dgvRoomTypes.RowHeadersVisible = false;
            dgvRoomTypes.RowHeadersWidth = 51;
            dgvRoomTypes.RowTemplate.Height = 40;
            dgvRoomTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoomTypes.Size = new Size(1072, 372);
            dgvRoomTypes.TabIndex = 1;
            // 
            // pnlTypesToolbar
            // 
            pnlTypesToolbar.BackColor = Color.White;
            pnlTypesToolbar.Controls.Add(lblRoomTypesTitle);
            pnlTypesToolbar.Controls.Add(txtRoomTypeSearch);
            pnlTypesToolbar.Controls.Add(btnRoomTypeRefresh);
            pnlTypesToolbar.Controls.Add(btnRoomTypeAdd);
            pnlTypesToolbar.Controls.Add(btnRoomTypeEdit);
            pnlTypesToolbar.Controls.Add(btnRoomTypeDelete);
            pnlTypesToolbar.Dock = DockStyle.Top;
            pnlTypesToolbar.Location = new Point(0, 0);
            pnlTypesToolbar.Name = "pnlTypesToolbar";
            pnlTypesToolbar.Padding = new Padding(12, 10, 12, 10);
            pnlTypesToolbar.Size = new Size(1072, 108);
            pnlTypesToolbar.TabIndex = 0;
            // 
            // lblRoomTypesTitle
            // 
            lblRoomTypesTitle.AutoSize = true;
            lblRoomTypesTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRoomTypesTitle.Location = new Point(16, 14);
            lblRoomTypesTitle.Name = "lblRoomTypesTitle";
            lblRoomTypesTitle.Size = new Size(432, 23);
            lblRoomTypesTitle.TabIndex = 0;
            lblRoomTypesTitle.Text = "Danh sách loại phòng — mã, giá, sức chứa, số phòng";
            // 
            // txtRoomTypeSearch
            // 
            txtRoomTypeSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRoomTypeSearch.Location = new Point(16, 44);
            txtRoomTypeSearch.Margin = new Padding(3, 4, 3, 4);
            txtRoomTypeSearch.Name = "txtRoomTypeSearch";
            txtRoomTypeSearch.PlaceholderText = "Tìm theo mã, tên, mô tả, loại giường…";
            txtRoomTypeSearch.Size = new Size(548, 30);
            txtRoomTypeSearch.TabIndex = 1;
            txtRoomTypeSearch.TextChanged += TxtRoomTypeSearch_TextChanged;
            // 
            // btnRoomTypeRefresh
            // 
            btnRoomTypeRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRoomTypeRefresh.BackColor = Color.LightGray;
            btnRoomTypeRefresh.FlatStyle = FlatStyle.Flat;
            btnRoomTypeRefresh.ForeColor = Color.White;
            btnRoomTypeRefresh.Location = new Point(582, 40);
            btnRoomTypeRefresh.Name = "btnRoomTypeRefresh";
            btnRoomTypeRefresh.Size = new Size(110, 36);
            btnRoomTypeRefresh.TabIndex = 2;
            btnRoomTypeRefresh.Text = "Làm mới";
            btnRoomTypeRefresh.UseVisualStyleBackColor = false;
            btnRoomTypeRefresh.Click += BtnRoomTypeRefresh_Click;
            // 
            // btnRoomTypeAdd
            // 
            btnRoomTypeAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRoomTypeAdd.BackColor = Color.FromArgb(21, 128, 61);
            btnRoomTypeAdd.FlatStyle = FlatStyle.Flat;
            btnRoomTypeAdd.ForeColor = Color.White;
            btnRoomTypeAdd.Location = new Point(702, 40);
            btnRoomTypeAdd.Name = "btnRoomTypeAdd";
            btnRoomTypeAdd.Size = new Size(110, 36);
            btnRoomTypeAdd.TabIndex = 3;
            btnRoomTypeAdd.Text = "Thêm";
            btnRoomTypeAdd.UseVisualStyleBackColor = false;
            btnRoomTypeAdd.Click += BtnRoomTypeAdd_Click;
            // 
            // btnRoomTypeEdit
            // 
            btnRoomTypeEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRoomTypeEdit.BackColor = Color.DeepSkyBlue;
            btnRoomTypeEdit.FlatStyle = FlatStyle.Flat;
            btnRoomTypeEdit.ForeColor = Color.White;
            btnRoomTypeEdit.Location = new Point(822, 40);
            btnRoomTypeEdit.Name = "btnRoomTypeEdit";
            btnRoomTypeEdit.Size = new Size(110, 36);
            btnRoomTypeEdit.TabIndex = 4;
            btnRoomTypeEdit.Text = "Sửa";
            btnRoomTypeEdit.UseVisualStyleBackColor = false;
            btnRoomTypeEdit.Click += BtnRoomTypeEdit_Click;
            // 
            // btnRoomTypeDelete
            // 
            btnRoomTypeDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRoomTypeDelete.BackColor = Color.Red;
            btnRoomTypeDelete.FlatStyle = FlatStyle.Flat;
            btnRoomTypeDelete.ForeColor = Color.White;
            btnRoomTypeDelete.Location = new Point(942, 40);
            btnRoomTypeDelete.Name = "btnRoomTypeDelete";
            btnRoomTypeDelete.Size = new Size(110, 36);
            btnRoomTypeDelete.TabIndex = 5;
            btnRoomTypeDelete.Text = "Xóa";
            btnRoomTypeDelete.UseVisualStyleBackColor = false;
            btnRoomTypeDelete.Click += BtnRoomTypeDelete_Click;
            // 
            // tabFloors
            // 
            tabFloors.Controls.Add(pnlFloorsRoot);
            tabFloors.Location = new Point(4, 42);
            tabFloors.Margin = new Padding(3, 4, 3, 4);
            tabFloors.Name = "tabFloors";
            tabFloors.Padding = new Padding(10, 12, 10, 10);
            tabFloors.Size = new Size(1092, 506);
            tabFloors.TabIndex = 2;
            tabFloors.Text = "Quản lý trạng thái tầng";
            tabFloors.UseVisualStyleBackColor = true;
            // 
            // pnlFloorsRoot
            // 
            pnlFloorsRoot.BackColor = Color.FromArgb(241, 245, 249);
            pnlFloorsRoot.Controls.Add(pnlFloorsScroll);
            pnlFloorsRoot.Controls.Add(pnlFloorsToolbar);
            pnlFloorsRoot.Dock = DockStyle.Fill;
            pnlFloorsRoot.Location = new Point(10, 12);
            pnlFloorsRoot.Name = "pnlFloorsRoot";
            pnlFloorsRoot.Padding = new Padding(0, 0, 0, 6);
            pnlFloorsRoot.Size = new Size(1072, 484);
            pnlFloorsRoot.TabIndex = 0;
            // 
            // pnlFloorsScroll
            // 
            pnlFloorsScroll.AutoScroll = true;
            pnlFloorsScroll.BackColor = Color.FromArgb(241, 245, 249);
            pnlFloorsScroll.Controls.Add(flowFloorMgmtLayout);
            pnlFloorsScroll.Dock = DockStyle.Fill;
            pnlFloorsScroll.Location = new Point(0, 108);
            pnlFloorsScroll.Name = "pnlFloorsScroll";
            pnlFloorsScroll.Padding = new Padding(8, 4, 8, 8);
            pnlFloorsScroll.Size = new Size(1072, 370);
            pnlFloorsScroll.TabIndex = 1;
            // 
            // flowFloorMgmtLayout
            // 
            flowFloorMgmtLayout.AutoSize = true;
            flowFloorMgmtLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowFloorMgmtLayout.Dock = DockStyle.Top;
            flowFloorMgmtLayout.Location = new Point(8, 4);
            flowFloorMgmtLayout.Name = "flowFloorMgmtLayout";
            flowFloorMgmtLayout.Padding = new Padding(4);
            flowFloorMgmtLayout.Size = new Size(1056, 8);
            flowFloorMgmtLayout.TabIndex = 0;
            // 
            // pnlFloorsToolbar
            // 
            pnlFloorsToolbar.BackColor = Color.White;
            pnlFloorsToolbar.Controls.Add(lblFloorsTitle);
            pnlFloorsToolbar.Controls.Add(txtFloorSearch);
            pnlFloorsToolbar.Controls.Add(btnFloorRefresh);
            pnlFloorsToolbar.Controls.Add(btnFloorAdd);
            pnlFloorsToolbar.Controls.Add(btnFloorEdit);
            pnlFloorsToolbar.Controls.Add(btnFloorDelete);
            pnlFloorsToolbar.Dock = DockStyle.Top;
            pnlFloorsToolbar.Location = new Point(0, 0);
            pnlFloorsToolbar.Name = "pnlFloorsToolbar";
            pnlFloorsToolbar.Padding = new Padding(12, 10, 12, 10);
            pnlFloorsToolbar.Size = new Size(1072, 108);
            pnlFloorsToolbar.TabIndex = 0;
            // 
            // lblFloorsTitle
            // 
            lblFloorsTitle.AutoSize = true;
            lblFloorsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFloorsTitle.Location = new Point(16, 14);
            lblFloorsTitle.Name = "lblFloorsTitle";
            lblFloorsTitle.Size = new Size(460, 23);
            lblFloorsTitle.TabIndex = 0;
            lblFloorsTitle.Text = "Lưới tầng — đóng/mở bảo trì (khóa đặt phòng cả tầng)";
            // 
            // txtFloorSearch
            // 
            txtFloorSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFloorSearch.Location = new Point(16, 44);
            txtFloorSearch.Margin = new Padding(3, 4, 3, 4);
            txtFloorSearch.Name = "txtFloorSearch";
            txtFloorSearch.PlaceholderText = "Tìm theo ID, tên tầng, chi nhánh…";
            txtFloorSearch.Size = new Size(548, 30);
            txtFloorSearch.TabIndex = 1;
            txtFloorSearch.TextChanged += TxtFloorSearch_TextChanged;
            // 
            // btnFloorRefresh
            // 
            btnFloorRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFloorRefresh.BackColor = Color.LightGray;
            btnFloorRefresh.FlatStyle = FlatStyle.Flat;
            btnFloorRefresh.ForeColor = Color.White;
            btnFloorRefresh.Location = new Point(582, 40);
            btnFloorRefresh.Name = "btnFloorRefresh";
            btnFloorRefresh.Size = new Size(110, 36);
            btnFloorRefresh.TabIndex = 2;
            btnFloorRefresh.Text = "Làm mới";
            btnFloorRefresh.UseVisualStyleBackColor = false;
            btnFloorRefresh.Click += BtnFloorRefresh_Click;
            // 
            // btnFloorAdd
            // 
            btnFloorAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFloorAdd.BackColor = Color.FromArgb(21, 128, 61);
            btnFloorAdd.FlatStyle = FlatStyle.Flat;
            btnFloorAdd.ForeColor = Color.White;
            btnFloorAdd.Location = new Point(702, 40);
            btnFloorAdd.Name = "btnFloorAdd";
            btnFloorAdd.Size = new Size(110, 36);
            btnFloorAdd.TabIndex = 3;
            btnFloorAdd.Text = "Thêm";
            btnFloorAdd.UseVisualStyleBackColor = false;
            btnFloorAdd.Click += BtnFloorAdd_Click;
            // 
            // btnFloorEdit
            // 
            btnFloorEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFloorEdit.BackColor = Color.DeepSkyBlue;
            btnFloorEdit.FlatStyle = FlatStyle.Flat;
            btnFloorEdit.ForeColor = Color.White;
            btnFloorEdit.Location = new Point(822, 40);
            btnFloorEdit.Name = "btnFloorEdit";
            btnFloorEdit.Size = new Size(110, 36);
            btnFloorEdit.TabIndex = 4;
            btnFloorEdit.Text = "Sửa";
            btnFloorEdit.UseVisualStyleBackColor = false;
            btnFloorEdit.Click += BtnFloorEdit_Click;
            // 
            // btnFloorDelete
            // 
            btnFloorDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFloorDelete.BackColor = Color.Red;
            btnFloorDelete.FlatStyle = FlatStyle.Flat;
            btnFloorDelete.ForeColor = Color.White;
            btnFloorDelete.Location = new Point(942, 40);
            btnFloorDelete.Name = "btnFloorDelete";
            btnFloorDelete.Size = new Size(110, 36);
            btnFloorDelete.TabIndex = 5;
            btnFloorDelete.Text = "Xóa";
            btnFloorDelete.UseVisualStyleBackColor = false;
            btnFloorDelete.Click += BtnFloorDelete_Click;
            // 
            // tabBranches
            // 
            tabBranches.Controls.Add(pnlBranchesRoot);
            tabBranches.Location = new Point(4, 42);
            tabBranches.Margin = new Padding(3, 4, 3, 4);
            tabBranches.Name = "tabBranches";
            tabBranches.Padding = new Padding(10);
            tabBranches.Size = new Size(1092, 506);
            tabBranches.TabIndex = 3;
            tabBranches.Text = "Quản lý chi nhánh";
            tabBranches.UseVisualStyleBackColor = true;
            // 
            // pnlBranchesRoot
            // 
            pnlBranchesRoot.BackColor = Color.FromArgb(241, 245, 249);
            pnlBranchesRoot.Controls.Add(dgvBranches);
            pnlBranchesRoot.Controls.Add(pnlBranchesToolbar);
            pnlBranchesRoot.Dock = DockStyle.Fill;
            pnlBranchesRoot.Location = new Point(10, 10);
            pnlBranchesRoot.Name = "pnlBranchesRoot";
            pnlBranchesRoot.Padding = new Padding(0, 0, 0, 6);
            pnlBranchesRoot.Size = new Size(1072, 486);
            pnlBranchesRoot.TabIndex = 0;
            // 
            // dgvBranches
            // 
            dgvBranches.AllowUserToAddRows = false;
            dgvBranches.AllowUserToDeleteRows = false;
            dgvBranches.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = Color.WhiteSmoke;
            dgvBranches.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dgvBranches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBranches.BackgroundColor = Color.White;
            dgvBranches.BorderStyle = BorderStyle.None;
            dgvBranches.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBranches.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvBranches.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvBranches.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Window;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle9.ForeColor = Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = Color.LightCyan;
            dataGridViewCellStyle9.SelectionForeColor = Color.Black;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dgvBranches.DefaultCellStyle = dataGridViewCellStyle9;
            dgvBranches.Dock = DockStyle.Fill;
            dgvBranches.EnableHeadersVisualStyles = false;
            dgvBranches.GridColor = Color.Gainsboro;
            dgvBranches.Location = new Point(0, 108);
            dgvBranches.Name = "dgvBranches";
            dgvBranches.ReadOnly = true;
            dgvBranches.RowHeadersVisible = false;
            dgvBranches.RowHeadersWidth = 51;
            dgvBranches.RowTemplate.Height = 40;
            dgvBranches.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBranches.Size = new Size(1072, 372);
            dgvBranches.TabIndex = 1;
            // 
            // pnlBranchesToolbar
            // 
            pnlBranchesToolbar.BackColor = Color.White;
            pnlBranchesToolbar.Controls.Add(lblBranchesTitle);
            pnlBranchesToolbar.Controls.Add(txtBranchSearch);
            pnlBranchesToolbar.Controls.Add(btnBranchRefresh);
            pnlBranchesToolbar.Controls.Add(btnBranchAdd);
            pnlBranchesToolbar.Controls.Add(btnBranchEdit);
            pnlBranchesToolbar.Controls.Add(btnBranchDelete);
            pnlBranchesToolbar.Dock = DockStyle.Top;
            pnlBranchesToolbar.Location = new Point(0, 0);
            pnlBranchesToolbar.Name = "pnlBranchesToolbar";
            pnlBranchesToolbar.Padding = new Padding(12, 10, 12, 10);
            pnlBranchesToolbar.Size = new Size(1072, 108);
            pnlBranchesToolbar.TabIndex = 0;
            // 
            // lblBranchesTitle
            // 
            lblBranchesTitle.AutoSize = true;
            lblBranchesTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBranchesTitle.Location = new Point(16, 14);
            lblBranchesTitle.Name = "lblBranchesTitle";
            lblBranchesTitle.Size = new Size(256, 23);
            lblBranchesTitle.TabIndex = 0;
            lblBranchesTitle.Text = "Danh sách chi nhánh khách sạn";
            // 
            // txtBranchSearch
            // 
            txtBranchSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBranchSearch.Location = new Point(16, 44);
            txtBranchSearch.Margin = new Padding(3, 4, 3, 4);
            txtBranchSearch.Name = "txtBranchSearch";
            txtBranchSearch.PlaceholderText = "Tìm theo ID, tên đường, thành phố...";
            txtBranchSearch.Size = new Size(548, 30);
            txtBranchSearch.TabIndex = 1;
            txtBranchSearch.TextChanged += TxtBranchSearch_TextChanged;
            // 
            // btnBranchRefresh
            // 
            btnBranchRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBranchRefresh.BackColor = Color.LightGray;
            btnBranchRefresh.FlatStyle = FlatStyle.Flat;
            btnBranchRefresh.ForeColor = Color.White;
            btnBranchRefresh.Location = new Point(582, 40);
            btnBranchRefresh.Name = "btnBranchRefresh";
            btnBranchRefresh.Size = new Size(110, 36);
            btnBranchRefresh.TabIndex = 2;
            btnBranchRefresh.Text = "Làm mới";
            btnBranchRefresh.UseVisualStyleBackColor = false;
            btnBranchRefresh.Click += BtnBranchRefresh_Click;
            // 
            // btnBranchAdd
            // 
            btnBranchAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBranchAdd.BackColor = Color.FromArgb(21, 128, 61);
            btnBranchAdd.FlatStyle = FlatStyle.Flat;
            btnBranchAdd.ForeColor = Color.White;
            btnBranchAdd.Location = new Point(702, 40);
            btnBranchAdd.Name = "btnBranchAdd";
            btnBranchAdd.Size = new Size(110, 36);
            btnBranchAdd.TabIndex = 3;
            btnBranchAdd.Text = "Thêm";
            btnBranchAdd.UseVisualStyleBackColor = false;
            btnBranchAdd.Click += BtnBranchAdd_Click;
            // 
            // btnBranchEdit
            // 
            btnBranchEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBranchEdit.BackColor = Color.DeepSkyBlue;
            btnBranchEdit.FlatStyle = FlatStyle.Flat;
            btnBranchEdit.ForeColor = Color.White;
            btnBranchEdit.Location = new Point(822, 40);
            btnBranchEdit.Name = "btnBranchEdit";
            btnBranchEdit.Size = new Size(110, 36);
            btnBranchEdit.TabIndex = 4;
            btnBranchEdit.Text = "Sửa";
            btnBranchEdit.UseVisualStyleBackColor = false;
            btnBranchEdit.Click += BtnBranchEdit_Click;
            // 
            // btnBranchDelete
            // 
            btnBranchDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBranchDelete.BackColor = Color.Red;
            btnBranchDelete.FlatStyle = FlatStyle.Flat;
            btnBranchDelete.ForeColor = Color.White;
            btnBranchDelete.Location = new Point(942, 40);
            btnBranchDelete.Name = "btnBranchDelete";
            btnBranchDelete.Size = new Size(110, 36);
            btnBranchDelete.TabIndex = 5;
            btnBranchDelete.Text = "Xóa";
            btnBranchDelete.UseVisualStyleBackColor = false;
            btnBranchDelete.Click += BtnBranchDelete_Click;
            // 
            // usRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            Controls.Add(tabMain);
            Name = "usRoom";
            Size = new Size(1100, 552);
            Load += usRoom_Load;
            tabMain.ResumeLayout(false);
            tabRooms.ResumeLayout(false);
            pnlRoomsRoot.ResumeLayout(false);
            pnlRoomsRoot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
            tlpRoomToolbar.ResumeLayout(false);
            tlpRoomToolbar.PerformLayout();
            flpButton.ResumeLayout(false);
            tabRoomTypes.ResumeLayout(false);
            pnlRoomTypesRoot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRoomTypes).EndInit();
            pnlTypesToolbar.ResumeLayout(false);
            pnlTypesToolbar.PerformLayout();
            tabFloors.ResumeLayout(false);
            pnlFloorsRoot.ResumeLayout(false);
            pnlFloorsScroll.ResumeLayout(false);
            pnlFloorsScroll.PerformLayout();
            pnlFloorsToolbar.ResumeLayout(false);
            pnlFloorsToolbar.PerformLayout();
            tabBranches.ResumeLayout(false);
            pnlBranchesRoot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBranches).EndInit();
            pnlBranchesToolbar.ResumeLayout(false);
            pnlBranchesToolbar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabMain;

        // ... (Khai báo biến Tab Phòng giữ nguyên)
        private TabPage tabRooms;
        private Panel pnlRoomsRoot;
        private TableLayoutPanel tlpRoomToolbar;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnRefreshList;
        private Label lblFloor;
        private ComboBox cmbFilterFloor;
        private Label lblRoomType;
        private ComboBox cmbFilterRoomType;
        private Button btnAddRoom;
        private Button btnEditRoom;
        private Button btnDeleteRoom;
        private Label lblOperational;
        private ComboBox cmbOperationalApply;
        private Button btnBulkCreate;
        private DataGridView dgvRooms;

        // ... (Khai báo biến Tab Loại Phòng giữ nguyên)
        private TabPage tabRoomTypes;
        private Panel pnlRoomTypesRoot;
        private Panel pnlTypesToolbar;
        private Label lblRoomTypesTitle;
        private TextBox txtRoomTypeSearch;
        private Button btnRoomTypeRefresh;
        private Button btnRoomTypeAdd;
        private Button btnRoomTypeEdit;
        private Button btnRoomTypeDelete;
        private DataGridView dgvRoomTypes;
        private DataGridViewTextBoxColumn colRtCode;
        private DataGridViewTextBoxColumn colRtTypeName;
        private DataGridViewTextBoxColumn colRtUnitPrice;
        private DataGridViewTextBoxColumn colRtCapacity;
        private DataGridViewTextBoxColumn colRtRoomCount;

        // ... (Khai báo biến Tab Tầng giữ nguyên)
        private TabPage tabFloors;
        private Panel pnlFloorsRoot;
        private Panel pnlFloorsToolbar;
        private Label lblFloorsTitle;
        private TextBox txtFloorSearch;
        private Button btnFloorRefresh;
        private Button btnFloorAdd;
        private Button btnFloorEdit;
        private Button btnFloorDelete;
        private Panel pnlFloorsScroll;
        private FlowLayoutPanel flowFloorMgmtLayout;
        private FlowLayoutPanel flpButton;

        // =======================================================
        // THÊM MỚI: Khai báo biến các Component của Tab Chi nhánh
        // =======================================================
        private TabPage tabBranches;
        private Panel pnlBranchesRoot;
        private Panel pnlBranchesToolbar;
        private Label lblBranchesTitle;
        private TextBox txtBranchSearch;
        private Button btnBranchRefresh;
        private Button btnBranchAdd;
        private Button btnBranchEdit;
        private Button btnBranchDelete;
        private DataGridView dgvBranches;
    }
}
