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
            tabMain = new TabControl();
            tabRooms = new TabPage();
            pnlRoomsRoot = new Panel();
            dgvRooms = new DataGridView();
            colRoomNumber = new DataGridViewTextBoxColumn();
            colRoomTypeName = new DataGridViewTextBoxColumn();
            colFloorName = new DataGridViewTextBoxColumn();
            colStatusDisplay = new DataGridViewTextBoxColumn();
            colOperational = new DataGridViewTextBoxColumn();
            pnlRoomToolbar = new TableLayoutPanel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnRefreshList = new Button();
            lblFloor = new Label();
            cmbFilterFloor = new ComboBox();
            lblRoomType = new Label();
            cmbFilterRoomType = new ComboBox();
            btnAddRoom = new Button();
            btnEditRoom = new Button();
            btnDeleteRoom = new Button();
            lblOperational = new Label();
            cmbOperationalApply = new ComboBox();
            btnBulkCreate = new Button();
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
            tabMain.SuspendLayout();
            tabRooms.SuspendLayout();
            pnlRoomsRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            pnlRoomToolbar.SuspendLayout();
            tabRoomTypes.SuspendLayout();
            pnlRoomTypesRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoomTypes).BeginInit();
            pnlTypesToolbar.SuspendLayout();
            tabFloors.SuspendLayout();
            pnlFloorsRoot.SuspendLayout();
            pnlFloorsScroll.SuspendLayout();
            pnlFloorsToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabRooms);
            tabMain.Controls.Add(tabRoomTypes);
            tabMain.Controls.Add(tabFloors);
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
            pnlRoomsRoot.Controls.Add(pnlRoomToolbar);
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
            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRooms.BackgroundColor = Color.White;
            dgvRooms.BorderStyle = BorderStyle.None;
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRooms.Columns.AddRange(new DataGridViewColumn[] { colRoomNumber, colRoomTypeName, colFloorName, colStatusDisplay, colOperational });
            dgvRooms.Dock = DockStyle.Fill;
            dgvRooms.Location = new Point(0, 112);
            dgvRooms.Name = "dgvRooms";
            dgvRooms.ReadOnly = true;
            dgvRooms.RowHeadersVisible = false;
            dgvRooms.RowHeadersWidth = 51;
            dgvRooms.RowTemplate.Height = 40;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.Size = new Size(1072, 366);
            dgvRooms.TabIndex = 1;
            dgvRooms.SelectionChanged += DgvRooms_SelectionChanged;
            // 
            // colRoomNumber
            // 
            colRoomNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoomNumber.FillWeight = 90F;
            colRoomNumber.HeaderText = "Số phòng";
            colRoomNumber.MinimumWidth = 70;
            colRoomNumber.Name = "colRoomNumber";
            colRoomNumber.ReadOnly = true;
            // 
            // colRoomTypeName
            // 
            colRoomTypeName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoomTypeName.FillWeight = 120F;
            colRoomTypeName.HeaderText = "Loại phòng";
            colRoomTypeName.MinimumWidth = 6;
            colRoomTypeName.Name = "colRoomTypeName";
            colRoomTypeName.ReadOnly = true;
            // 
            // colFloorName
            // 
            colFloorName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFloorName.FillWeight = 80F;
            colFloorName.HeaderText = "Tầng";
            colFloorName.MinimumWidth = 6;
            colFloorName.Name = "colFloorName";
            colFloorName.ReadOnly = true;
            // 
            // colStatusDisplay
            // 
            colStatusDisplay.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colStatusDisplay.HeaderText = "Trạng thái phòng / lưu trú";
            colStatusDisplay.MinimumWidth = 6;
            colStatusDisplay.Name = "colStatusDisplay";
            colStatusDisplay.ReadOnly = true;
            // 
            // colOperational
            // 
            colOperational.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colOperational.FillWeight = 110F;
            colOperational.HeaderText = "Vận hành / khóa";
            colOperational.MinimumWidth = 6;
            colOperational.Name = "colOperational";
            colOperational.ReadOnly = true;
            // 
            // pnlRoomToolbar
            // 
            pnlRoomToolbar.AutoSize = true;
            pnlRoomToolbar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlRoomToolbar.BackColor = Color.White;
            pnlRoomToolbar.ColumnCount = 9;
            pnlRoomToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 82F));
            pnlRoomToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            pnlRoomToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            pnlRoomToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 86F));
            pnlRoomToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            pnlRoomToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 128F));
            pnlRoomToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            pnlRoomToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 128F));
            pnlRoomToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 118F));
            pnlRoomToolbar.Controls.Add(lblSearch, 0, 0);
            pnlRoomToolbar.Controls.Add(txtSearch, 1, 0);
            pnlRoomToolbar.Controls.Add(btnRefreshList, 3, 0);
            pnlRoomToolbar.Controls.Add(lblFloor, 4, 0);
            pnlRoomToolbar.Controls.Add(cmbFilterFloor, 5, 0);
            pnlRoomToolbar.Controls.Add(lblRoomType, 6, 0);
            pnlRoomToolbar.Controls.Add(cmbFilterRoomType, 7, 0);
            pnlRoomToolbar.Controls.Add(btnAddRoom, 8, 0);
            pnlRoomToolbar.Controls.Add(btnEditRoom, 0, 1);
            pnlRoomToolbar.Controls.Add(btnDeleteRoom, 1, 1);
            pnlRoomToolbar.Controls.Add(lblOperational, 2, 1);
            pnlRoomToolbar.Controls.Add(cmbOperationalApply, 4, 1);
            pnlRoomToolbar.Controls.Add(btnBulkCreate, 8, 1);
            pnlRoomToolbar.Dock = DockStyle.Top;
            pnlRoomToolbar.Location = new Point(0, 0);
            pnlRoomToolbar.Margin = new Padding(0, 0, 0, 10);
            pnlRoomToolbar.Name = "pnlRoomToolbar";
            pnlRoomToolbar.Padding = new Padding(12);
            pnlRoomToolbar.RowCount = 2;
            pnlRoomToolbar.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            pnlRoomToolbar.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            pnlRoomToolbar.Size = new Size(1072, 112);
            pnlRoomToolbar.TabIndex = 0;
            // 
            // lblSearch
            // 
            lblSearch.Anchor = AnchorStyles.Left;
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(15, 12);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(46, 44);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pnlRoomToolbar.SetColumnSpan(txtSearch, 2);
            txtSearch.Location = new Point(97, 19);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm theo số phòng…";
            txtSearch.Size = new Size(354, 30);
            txtSearch.TabIndex = 1;
            // 
            // btnRefreshList
            // 
            btnRefreshList.Anchor = AnchorStyles.Right;
            btnRefreshList.Location = new Point(461, 16);
            btnRefreshList.Margin = new Padding(3, 4, 3, 4);
            btnRefreshList.Name = "btnRefreshList";
            btnRefreshList.Size = new Size(76, 36);
            btnRefreshList.TabIndex = 3;
            btnRefreshList.Text = "Làm mới";
            btnRefreshList.UseVisualStyleBackColor = true;
            btnRefreshList.Click += BtnRefreshList_Click;
            // 
            // lblFloor
            // 
            lblFloor.Anchor = AnchorStyles.Left;
            lblFloor.AutoSize = true;
            lblFloor.Location = new Point(543, 12);
            lblFloor.Name = "lblFloor";
            lblFloor.Size = new Size(38, 44);
            lblFloor.TabIndex = 4;
            lblFloor.Text = "Tầng";
            // 
            // cmbFilterFloor
            // 
            cmbFilterFloor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbFilterFloor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterFloor.FormattingEnabled = true;
            cmbFilterFloor.Location = new Point(593, 20);
            cmbFilterFloor.Margin = new Padding(3, 4, 3, 4);
            cmbFilterFloor.Name = "cmbFilterFloor";
            cmbFilterFloor.Size = new Size(122, 31);
            cmbFilterFloor.TabIndex = 5;
            cmbFilterFloor.SelectedIndexChanged += CmbFilterFloor_SelectedIndexChanged;
            // 
            // lblRoomType
            // 
            lblRoomType.Anchor = AnchorStyles.Left;
            lblRoomType.AutoSize = true;
            lblRoomType.Location = new Point(721, 12);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(60, 44);
            lblRoomType.TabIndex = 6;
            lblRoomType.Text = "Loại phòng";
            // 
            // cmbFilterRoomType
            // 
            cmbFilterRoomType.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbFilterRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterRoomType.FormattingEnabled = true;
            cmbFilterRoomType.Location = new Point(816, 20);
            cmbFilterRoomType.Margin = new Padding(3, 4, 3, 4);
            cmbFilterRoomType.Name = "cmbFilterRoomType";
            cmbFilterRoomType.Size = new Size(122, 31);
            cmbFilterRoomType.TabIndex = 7;
            cmbFilterRoomType.SelectedIndexChanged += CmbFilterRoomType_SelectedIndexChanged;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Anchor = AnchorStyles.Right;
            btnAddRoom.BackColor = Color.FromArgb(21, 128, 61);
            btnAddRoom.FlatStyle = FlatStyle.Flat;
            btnAddRoom.ForeColor = Color.White;
            btnAddRoom.Location = new Point(944, 16);
            btnAddRoom.Margin = new Padding(3, 4, 3, 4);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(113, 36);
            btnAddRoom.TabIndex = 8;
            btnAddRoom.Text = "Thêm phòng";
            btnAddRoom.UseVisualStyleBackColor = false;
            btnAddRoom.Click += BtnAddRoom_Click;
            // 
            // btnEditRoom
            // 
            btnEditRoom.Anchor = AnchorStyles.Left;
            btnEditRoom.Location = new Point(15, 61);
            btnEditRoom.Margin = new Padding(3, 4, 3, 4);
            btnEditRoom.Name = "btnEditRoom";
            btnEditRoom.Size = new Size(76, 34);
            btnEditRoom.TabIndex = 9;
            btnEditRoom.Text = "Sửa";
            btnEditRoom.UseVisualStyleBackColor = true;
            btnEditRoom.Click += BtnEditRoom_Click;
            // 
            // btnDeleteRoom
            // 
            btnDeleteRoom.Anchor = AnchorStyles.Left;
            btnDeleteRoom.ForeColor = Color.FromArgb(185, 28, 28);
            btnDeleteRoom.Location = new Point(97, 61);
            btnDeleteRoom.Margin = new Padding(3, 4, 3, 4);
            btnDeleteRoom.Name = "btnDeleteRoom";
            btnDeleteRoom.Size = new Size(100, 34);
            btnDeleteRoom.TabIndex = 10;
            btnDeleteRoom.Text = "Xóa";
            btnDeleteRoom.UseVisualStyleBackColor = true;
            btnDeleteRoom.Click += BtnDeleteRoom_Click;
            // 
            // lblOperational
            // 
            lblOperational.Anchor = AnchorStyles.Left;
            lblOperational.AutoSize = true;
            pnlRoomToolbar.SetColumnSpan(lblOperational, 2);
            lblOperational.Location = new Point(295, 66);
            lblOperational.Name = "lblOperational";
            lblOperational.Size = new Size(138, 23);
            lblOperational.TabIndex = 11;
            lblOperational.Text = "Vận hành / khóa";
            // 
            // cmbOperationalApply
            // 
            cmbOperationalApply.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pnlRoomToolbar.SetColumnSpan(cmbOperationalApply, 4);
            cmbOperationalApply.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOperationalApply.FormattingEnabled = true;
            cmbOperationalApply.Location = new Point(543, 64);
            cmbOperationalApply.Margin = new Padding(3, 4, 3, 4);
            cmbOperationalApply.Name = "cmbOperationalApply";
            cmbOperationalApply.Size = new Size(395, 31);
            cmbOperationalApply.TabIndex = 12;
            cmbOperationalApply.SelectedIndexChanged += CmbOperationalApply_SelectedIndexChanged;
            // 
            // btnBulkCreate
            // 
            btnBulkCreate.Anchor = AnchorStyles.Right;
            btnBulkCreate.Location = new Point(944, 61);
            btnBulkCreate.Margin = new Padding(3, 4, 3, 4);
            btnBulkCreate.Name = "btnBulkCreate";
            btnBulkCreate.Size = new Size(113, 34);
            btnBulkCreate.TabIndex = 14;
            btnBulkCreate.Text = "Tạo hàng loạt";
            btnBulkCreate.UseVisualStyleBackColor = true;
            btnBulkCreate.Click += BtnBulkCreate_Click;
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
            dgvRoomTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoomTypes.BackgroundColor = Color.White;
            dgvRoomTypes.BorderStyle = BorderStyle.None;
            dgvRoomTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoomTypes.Dock = DockStyle.Fill;
            dgvRoomTypes.Location = new Point(0, 108);
            dgvRoomTypes.Margin = new Padding(3, 4, 3, 4);
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
            btnRoomTypeRefresh.Location = new Point(582, 40);
            btnRoomTypeRefresh.Name = "btnRoomTypeRefresh";
            btnRoomTypeRefresh.Size = new Size(110, 36);
            btnRoomTypeRefresh.TabIndex = 2;
            btnRoomTypeRefresh.Text = "Làm mới";
            btnRoomTypeRefresh.UseVisualStyleBackColor = true;
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
            btnRoomTypeEdit.Location = new Point(822, 40);
            btnRoomTypeEdit.Name = "btnRoomTypeEdit";
            btnRoomTypeEdit.Size = new Size(110, 36);
            btnRoomTypeEdit.TabIndex = 4;
            btnRoomTypeEdit.Text = "Sửa";
            btnRoomTypeEdit.UseVisualStyleBackColor = true;
            btnRoomTypeEdit.Click += BtnRoomTypeEdit_Click;
            // 
            // btnRoomTypeDelete
            // 
            btnRoomTypeDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRoomTypeDelete.ForeColor = Color.FromArgb(185, 28, 28);
            btnRoomTypeDelete.Location = new Point(942, 40);
            btnRoomTypeDelete.Name = "btnRoomTypeDelete";
            btnRoomTypeDelete.Size = new Size(110, 36);
            btnRoomTypeDelete.TabIndex = 5;
            btnRoomTypeDelete.Text = "Xóa";
            btnRoomTypeDelete.UseVisualStyleBackColor = true;
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
            btnFloorRefresh.Location = new Point(582, 40);
            btnFloorRefresh.Name = "btnFloorRefresh";
            btnFloorRefresh.Size = new Size(110, 36);
            btnFloorRefresh.TabIndex = 2;
            btnFloorRefresh.Text = "Làm mới";
            btnFloorRefresh.UseVisualStyleBackColor = true;
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
            btnFloorEdit.Location = new Point(822, 40);
            btnFloorEdit.Name = "btnFloorEdit";
            btnFloorEdit.Size = new Size(110, 36);
            btnFloorEdit.TabIndex = 4;
            btnFloorEdit.Text = "Sửa";
            btnFloorEdit.UseVisualStyleBackColor = true;
            btnFloorEdit.Click += BtnFloorEdit_Click;
            // 
            // btnFloorDelete
            // 
            btnFloorDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFloorDelete.ForeColor = Color.FromArgb(185, 28, 28);
            btnFloorDelete.Location = new Point(942, 40);
            btnFloorDelete.Name = "btnFloorDelete";
            btnFloorDelete.Size = new Size(110, 36);
            btnFloorDelete.TabIndex = 5;
            btnFloorDelete.Text = "Xóa";
            btnFloorDelete.UseVisualStyleBackColor = true;
            btnFloorDelete.Click += BtnFloorDelete_Click;
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
            pnlRoomToolbar.ResumeLayout(false);
            pnlRoomToolbar.PerformLayout();
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
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabMain;
        private TabPage tabRooms;
        private Panel pnlRoomsRoot;
        private TableLayoutPanel pnlRoomToolbar;
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
        private DataGridViewTextBoxColumn colRoomNumber;
        private DataGridViewTextBoxColumn colRoomTypeName;
        private DataGridViewTextBoxColumn colFloorName;
        private DataGridViewTextBoxColumn colStatusDisplay;
        private DataGridViewTextBoxColumn colOperational;
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
    }
}
