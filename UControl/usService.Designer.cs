namespace HotelManagement.CustomControls
{
    partial class usService
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlBody = new Panel();
            tabMain = new TabControl();

            // Tab Danh mục
            tabCatalog = new TabPage();
            tblCatalogRoot = new TableLayoutPanel();
            cardCategories = new RoundedCardPanel();
            pnlCategoryHeader = new Panel();
            lblCategoryTitle = new Label();
            pnlCategoryToolbar = new Panel();
            btnAddCategory = new Button();
            btnEditCategory = new Button();
            btnDeleteCategory = new Button();
            dgvCategories = new DataGridView();

            cardDetails = new RoundedCardPanel();
            tabCatalogRight = new TabControl();
            tabServices = new TabPage();
            pnlServiceToolbar = new Panel();
            btnAddService = new Button();
            btnEditService = new Button();
            btnToggleService = new Button();
            btnDeleteService = new Button();
            chkShowHidden = new CheckBox();
            dgvServices = new DataGridView();
            tabPackages = new TabPage();
            pnlPackageToolbar = new Panel();
            btnAddPackage = new Button();
            btnEditPackage = new Button();
            btnDeletePackage = new Button();
            dgvPackages = new DataGridView();
            tabPriceRules = new TabPage();
            pnlPriceRuleToolbar = new Panel();
            btnAddPriceRule = new Button();
            btnEditPriceRule = new Button();
            btnDeletePriceRule = new Button();
            dgvPriceRules = new DataGridView();

            // Tab Vận hành
            tabOps = new TabPage();
            tblOpsRoot = new TableLayoutPanel();
            cardOrderEntry = new RoundedCardPanel();
            pnlOrderEntryHeader = new Panel();
            lblOrderEntryTitle = new Label();
            lblStay = new Label();
            cmbStay = new ComboBox();
            lblCatalog = new Label();
            tabSvcCategories = new TabControl();
            lstCatalog = new ListBox();
            pnlOrderActions = new TableLayoutPanel();
            pnlChargeInner = new Panel();
            lblQty = new Label();
            numQty = new NumericUpDown();
            btnPlaceOrder = new Button();

            cardTracking = new RoundedCardPanel();
            pnlTrackingHeader = new Panel();
            lblTrackingTitle = new Label();
            pnlTrackingToolbar = new Panel();
            lblStatusFilter = new Label();
            cmbOrderStatus = new ComboBox();
            btnMarkPending = new Button();
            btnMarkInProgress = new Button();
            btnMarkCompleted = new Button();
            btnCancelOrder = new Button();
            btnReloadOps = new Button();
            dgvOrders = new DataGridView();

            pnlHeader.SuspendLayout();
            pnlBody.SuspendLayout();
            tabMain.SuspendLayout();
            tabCatalog.SuspendLayout();
            tblCatalogRoot.SuspendLayout();
            cardCategories.SuspendLayout();
            pnlCategoryHeader.SuspendLayout();
            pnlCategoryToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            cardDetails.SuspendLayout();
            tabCatalogRight.SuspendLayout();
            tabServices.SuspendLayout();
            pnlServiceToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            tabPackages.SuspendLayout();
            pnlPackageToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPackages).BeginInit();
            tabPriceRules.SuspendLayout();
            pnlPriceRuleToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPriceRules).BeginInit();
            tabOps.SuspendLayout();
            tblOpsRoot.SuspendLayout();
            cardOrderEntry.SuspendLayout();
            pnlOrderEntryHeader.SuspendLayout();
            pnlChargeInner.SuspendLayout();
            pnlOrderActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            cardTracking.SuspendLayout();
            pnlTrackingHeader.SuspendLayout();
            pnlTrackingToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.BackColor = System.Drawing.Color.White;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new System.Windows.Forms.Padding(24, 14, 24, 10);
            pnlHeader.Size = new System.Drawing.Size(1151, 56);
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblTitle.Location = new System.Drawing.Point(24, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Quản lý dịch vụ & tiện ích";
            //
            // pnlBody
            //
            pnlBody.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            pnlBody.Controls.Add(tabMain);
            pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlBody.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            pnlBody.Name = "pnlBody";
            //
            // tabMain
            //
            tabMain.Controls.Add(tabCatalog);
            tabMain.Controls.Add(tabOps);
            tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tabMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            tabMain.ItemSize = new System.Drawing.Size(132, 32);
            tabMain.Padding = new System.Drawing.Point(14, 6);
            tabMain.SelectedIndex = 0;
            tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            //
            // tabCatalog
            //
            tabCatalog.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            tabCatalog.Controls.Add(tblCatalogRoot);
            tabCatalog.Name = "tabCatalog";
            tabCatalog.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            tabCatalog.Text = "Danh mục";
            //
            // tblCatalogRoot
            //
            tblCatalogRoot.ColumnCount = 2;
            tblCatalogRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            tblCatalogRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            tblCatalogRoot.Controls.Add(cardCategories, 0, 0);
            tblCatalogRoot.Controls.Add(cardDetails, 1, 0);
            tblCatalogRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            tblCatalogRoot.Name = "tblCatalogRoot";
            tblCatalogRoot.RowCount = 1;
            tblCatalogRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //
            // cardCategories
            //
            cardCategories.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            cardCategories.CardBackColor = System.Drawing.Color.White;
            cardCategories.Controls.Add(dgvCategories);
            cardCategories.Controls.Add(pnlCategoryToolbar);
            cardCategories.Controls.Add(pnlCategoryHeader);
            cardCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            cardCategories.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            cardCategories.Name = "cardCategories";
            cardCategories.Padding = new System.Windows.Forms.Padding(16, 12, 16, 14);
            cardCategories.DrawShadow = false;
            cardCategories.Radius = 6;
            //
            // pnlCategoryHeader
            //
            pnlCategoryHeader.BackColor = System.Drawing.Color.White;
            pnlCategoryHeader.Controls.Add(lblCategoryTitle);
            pnlCategoryHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlCategoryHeader.Height = 36;
            pnlCategoryHeader.Name = "pnlCategoryHeader";
            //
            // lblCategoryTitle
            //
            lblCategoryTitle.AutoSize = true;
            lblCategoryTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblCategoryTitle.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblCategoryTitle.Location = new System.Drawing.Point(0, 6);
            lblCategoryTitle.Name = "lblCategoryTitle";
            lblCategoryTitle.Text = "Phân loại dịch vụ";
            //
            // pnlCategoryToolbar
            //
            pnlCategoryToolbar.BackColor = System.Drawing.Color.White;
            pnlCategoryToolbar.Controls.Add(btnAddCategory);
            pnlCategoryToolbar.Controls.Add(btnEditCategory);
            pnlCategoryToolbar.Controls.Add(btnDeleteCategory);
            pnlCategoryToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            pnlCategoryToolbar.Height = 44;
            pnlCategoryToolbar.Padding = new System.Windows.Forms.Padding(0, 4, 0, 8);
            pnlCategoryToolbar.Name = "pnlCategoryToolbar";
            //
            // btnAddCategory
            //
            btnAddCategory.Location = new System.Drawing.Point(0, 6);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new System.Drawing.Size(110, 30);
            btnAddCategory.Text = "+ Phân loại";
            btnAddCategory.Click += btnAddCategory_Click;
            //
            // btnEditCategory
            //
            btnEditCategory.Location = new System.Drawing.Point(118, 6);
            btnEditCategory.Name = "btnEditCategory";
            btnEditCategory.Size = new System.Drawing.Size(64, 30);
            btnEditCategory.Text = "Sửa";
            btnEditCategory.Click += btnEditCategory_Click;
            //
            // btnDeleteCategory
            //
            btnDeleteCategory.Location = new System.Drawing.Point(188, 6);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new System.Drawing.Size(64, 30);
            btnDeleteCategory.Text = "Xóa";
            btnDeleteCategory.Click += btnDeleteCategory_Click;
            //
            // dgvCategories
            //
            dgvCategories.BackgroundColor = System.Drawing.Color.White;
            dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvCategories.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvCategories.GridColor = System.Drawing.Color.FromArgb(241, 245, 249);
            dgvCategories.Name = "dgvCategories";
            dgvCategories.RowHeadersVisible = false;
            //
            // cardDetails
            //
            cardDetails.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            cardDetails.CardBackColor = System.Drawing.Color.White;
            cardDetails.Controls.Add(tabCatalogRight);
            cardDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            cardDetails.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            cardDetails.Name = "cardDetails";
            cardDetails.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            cardDetails.DrawShadow = false;
            cardDetails.Radius = 6;
            //
            // tabCatalogRight
            //
            tabCatalogRight.Controls.Add(tabServices);
            tabCatalogRight.Controls.Add(tabPackages);
            tabCatalogRight.Controls.Add(tabPriceRules);
            tabCatalogRight.Dock = System.Windows.Forms.DockStyle.Fill;
            tabCatalogRight.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            tabCatalogRight.ItemSize = new System.Drawing.Size(110, 28);
            tabCatalogRight.Name = "tabCatalogRight";
            tabCatalogRight.SelectedIndex = 0;
            tabCatalogRight.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            //
            // tabServices
            //
            tabServices.BackColor = System.Drawing.Color.White;
            tabServices.Controls.Add(dgvServices);
            tabServices.Controls.Add(pnlServiceToolbar);
            tabServices.Name = "tabServices";
            tabServices.Padding = new System.Windows.Forms.Padding(8);
            tabServices.Text = "Dịch vụ";
            //
            // pnlServiceToolbar
            //
            pnlServiceToolbar.BackColor = System.Drawing.Color.White;
            pnlServiceToolbar.Controls.Add(btnAddService);
            pnlServiceToolbar.Controls.Add(btnEditService);
            pnlServiceToolbar.Controls.Add(btnToggleService);
            pnlServiceToolbar.Controls.Add(btnDeleteService);
            pnlServiceToolbar.Controls.Add(chkShowHidden);
            pnlServiceToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            pnlServiceToolbar.Height = 44;
            pnlServiceToolbar.Padding = new System.Windows.Forms.Padding(0, 4, 0, 8);
            pnlServiceToolbar.Name = "pnlServiceToolbar";
            //
            // btnAddService
            //
            btnAddService.Location = new System.Drawing.Point(0, 6);
            btnAddService.Name = "btnAddService";
            btnAddService.Size = new System.Drawing.Size(110, 30);
            btnAddService.Text = "+ Dịch vụ";
            btnAddService.Click += btnAddService_Click;
            //
            // btnEditService
            //
            btnEditService.Location = new System.Drawing.Point(118, 6);
            btnEditService.Name = "btnEditService";
            btnEditService.Size = new System.Drawing.Size(64, 30);
            btnEditService.Text = "Sửa";
            btnEditService.Click += btnEditService_Click;
            //
            // btnToggleService
            //
            btnToggleService.Location = new System.Drawing.Point(188, 6);
            btnToggleService.Name = "btnToggleService";
            btnToggleService.Size = new System.Drawing.Size(96, 30);
            btnToggleService.Text = "Ẩn/Hiện";
            btnToggleService.Click += btnToggleService_Click;
            //
            // btnDeleteService
            //
            btnDeleteService.Location = new System.Drawing.Point(290, 6);
            btnDeleteService.Name = "btnDeleteService";
            btnDeleteService.Size = new System.Drawing.Size(64, 30);
            btnDeleteService.Text = "Xóa";
            btnDeleteService.Click += btnDeleteService_Click;
            //
            // chkShowHidden
            //
            chkShowHidden.AutoSize = true;
            chkShowHidden.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkShowHidden.Location = new System.Drawing.Point(370, 11);
            chkShowHidden.Name = "chkShowHidden";
            chkShowHidden.Text = "Hiện mục đã ẩn";
            chkShowHidden.CheckedChanged += chkShowHidden_CheckedChanged;
            //
            // dgvServices
            //
            dgvServices.BackgroundColor = System.Drawing.Color.White;
            dgvServices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvServices.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvServices.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvServices.GridColor = System.Drawing.Color.FromArgb(241, 245, 249);
            dgvServices.Name = "dgvServices";
            dgvServices.RowHeadersVisible = false;
            //
            // tabPackages
            //
            tabPackages.BackColor = System.Drawing.Color.White;
            tabPackages.Controls.Add(dgvPackages);
            tabPackages.Controls.Add(pnlPackageToolbar);
            tabPackages.Name = "tabPackages";
            tabPackages.Padding = new System.Windows.Forms.Padding(8);
            tabPackages.Text = "Gói combo";
            //
            // pnlPackageToolbar
            //
            pnlPackageToolbar.BackColor = System.Drawing.Color.White;
            pnlPackageToolbar.Controls.Add(btnAddPackage);
            pnlPackageToolbar.Controls.Add(btnEditPackage);
            pnlPackageToolbar.Controls.Add(btnDeletePackage);
            pnlPackageToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            pnlPackageToolbar.Height = 44;
            pnlPackageToolbar.Padding = new System.Windows.Forms.Padding(0, 4, 0, 8);
            pnlPackageToolbar.Name = "pnlPackageToolbar";
            //
            // btnAddPackage
            //
            btnAddPackage.Location = new System.Drawing.Point(0, 6);
            btnAddPackage.Name = "btnAddPackage";
            btnAddPackage.Size = new System.Drawing.Size(126, 30);
            btnAddPackage.Text = "+ Gói combo";
            btnAddPackage.Click += btnAddPackage_Click;
            //
            // btnEditPackage
            //
            btnEditPackage.Location = new System.Drawing.Point(134, 6);
            btnEditPackage.Name = "btnEditPackage";
            btnEditPackage.Size = new System.Drawing.Size(64, 30);
            btnEditPackage.Text = "Sửa";
            btnEditPackage.Click += btnEditPackage_Click;
            //
            // btnDeletePackage
            //
            btnDeletePackage.Location = new System.Drawing.Point(204, 6);
            btnDeletePackage.Name = "btnDeletePackage";
            btnDeletePackage.Size = new System.Drawing.Size(64, 30);
            btnDeletePackage.Text = "Xóa";
            btnDeletePackage.Click += btnDeletePackage_Click;
            //
            // dgvPackages
            //
            dgvPackages.BackgroundColor = System.Drawing.Color.White;
            dgvPackages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvPackages.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPackages.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvPackages.GridColor = System.Drawing.Color.FromArgb(241, 245, 249);
            dgvPackages.Name = "dgvPackages";
            dgvPackages.RowHeadersVisible = false;
            //
            // tabPriceRules
            //
            tabPriceRules.BackColor = System.Drawing.Color.White;
            tabPriceRules.Controls.Add(dgvPriceRules);
            tabPriceRules.Controls.Add(pnlPriceRuleToolbar);
            tabPriceRules.Name = "tabPriceRules";
            tabPriceRules.Padding = new System.Windows.Forms.Padding(8);
            tabPriceRules.Text = "Giá linh hoạt";
            //
            // pnlPriceRuleToolbar
            //
            pnlPriceRuleToolbar.BackColor = System.Drawing.Color.White;
            pnlPriceRuleToolbar.Controls.Add(btnAddPriceRule);
            pnlPriceRuleToolbar.Controls.Add(btnEditPriceRule);
            pnlPriceRuleToolbar.Controls.Add(btnDeletePriceRule);
            pnlPriceRuleToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            pnlPriceRuleToolbar.Height = 44;
            pnlPriceRuleToolbar.Padding = new System.Windows.Forms.Padding(0, 4, 0, 8);
            pnlPriceRuleToolbar.Name = "pnlPriceRuleToolbar";
            //
            // btnAddPriceRule
            //
            btnAddPriceRule.Location = new System.Drawing.Point(0, 6);
            btnAddPriceRule.Name = "btnAddPriceRule";
            btnAddPriceRule.Size = new System.Drawing.Size(132, 30);
            btnAddPriceRule.Text = "+ Quy tắc giá";
            btnAddPriceRule.Click += btnAddPriceRule_Click;
            //
            // btnEditPriceRule
            //
            btnEditPriceRule.Location = new System.Drawing.Point(140, 6);
            btnEditPriceRule.Name = "btnEditPriceRule";
            btnEditPriceRule.Size = new System.Drawing.Size(64, 30);
            btnEditPriceRule.Text = "Sửa";
            btnEditPriceRule.Click += btnEditPriceRule_Click;
            //
            // btnDeletePriceRule
            //
            btnDeletePriceRule.Location = new System.Drawing.Point(210, 6);
            btnDeletePriceRule.Name = "btnDeletePriceRule";
            btnDeletePriceRule.Size = new System.Drawing.Size(64, 30);
            btnDeletePriceRule.Text = "Xóa";
            btnDeletePriceRule.Click += btnDeletePriceRule_Click;
            //
            // dgvPriceRules
            //
            dgvPriceRules.BackgroundColor = System.Drawing.Color.White;
            dgvPriceRules.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvPriceRules.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPriceRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPriceRules.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvPriceRules.GridColor = System.Drawing.Color.FromArgb(241, 245, 249);
            dgvPriceRules.Name = "dgvPriceRules";
            dgvPriceRules.RowHeadersVisible = false;
            //
            // tabOps
            //
            tabOps.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            tabOps.Controls.Add(tblOpsRoot);
            tabOps.Name = "tabOps";
            tabOps.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            tabOps.Text = "Vận hành";
            //
            // tblOpsRoot
            //
            tblOpsRoot.ColumnCount = 1;
            tblOpsRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tblOpsRoot.Controls.Add(cardOrderEntry, 0, 0);
            tblOpsRoot.Controls.Add(cardTracking, 0, 1);
            tblOpsRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            tblOpsRoot.Name = "tblOpsRoot";
            tblOpsRoot.RowCount = 2;
            tblOpsRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 640F));
            tblOpsRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //
            // cardOrderEntry
            //
            cardOrderEntry.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            cardOrderEntry.CardBackColor = System.Drawing.Color.White;
            // Thứ tự thêm: control nào docked sau sẽ ăn cạnh trước.
            // Vì vậy thêm theo thứ tự ngược với top-down trên màn hình.
            cardOrderEntry.Controls.Add(lstCatalog);
            cardOrderEntry.Controls.Add(tabSvcCategories);
            cardOrderEntry.Controls.Add(lblCatalog);
            cardOrderEntry.Controls.Add(cmbStay);
            cardOrderEntry.Controls.Add(lblStay);
            cardOrderEntry.Controls.Add(pnlOrderActions);
            cardOrderEntry.Controls.Add(pnlOrderEntryHeader);
            cardOrderEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            cardOrderEntry.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            cardOrderEntry.Name = "cardOrderEntry";
            cardOrderEntry.Padding = new System.Windows.Forms.Padding(16, 12, 16, 14);
            cardOrderEntry.DrawShadow = false;
            cardOrderEntry.DrawCardBorder = false;
            cardOrderEntry.Radius = 6;
            cardOrderEntry.ClipChildrenToRoundedBounds = false;
            //
            // pnlOrderEntryHeader
            //
            pnlOrderEntryHeader.BackColor = System.Drawing.Color.White;
            pnlOrderEntryHeader.Controls.Add(lblOrderEntryTitle);
            pnlOrderEntryHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlOrderEntryHeader.Height = 32;
            pnlOrderEntryHeader.Name = "pnlOrderEntryHeader";
            //
            // lblOrderEntryTitle
            //
            lblOrderEntryTitle.AutoSize = true;
            lblOrderEntryTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblOrderEntryTitle.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblOrderEntryTitle.Location = new System.Drawing.Point(0, 4);
            lblOrderEntryTitle.Name = "lblOrderEntryTitle";
            lblOrderEntryTitle.Text = "Ghi nhận yêu cầu dịch vụ";
            //
            // lblStay
            //
            lblStay.AutoSize = false;
            lblStay.Dock = System.Windows.Forms.DockStyle.Top;
            lblStay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblStay.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblStay.Height = 34;
            lblStay.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            lblStay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblStay.Name = "lblStay";
            lblStay.Text = "Phòng đang lưu trú";
            //
            // cmbStay
            //
            cmbStay.Dock = System.Windows.Forms.DockStyle.Top;
            cmbStay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbStay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbStay.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbStay.Name = "cmbStay";
            //
            // lblCatalog
            //
            lblCatalog.AutoSize = false;
            lblCatalog.Dock = System.Windows.Forms.DockStyle.Top;
            lblCatalog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblCatalog.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblCatalog.Height = 36;
            lblCatalog.Name = "lblCatalog";
            lblCatalog.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            lblCatalog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblCatalog.Text = "Chọn dịch vụ (theo danh mục)";
            //
            // tabSvcCategories
            //
            tabSvcCategories.Dock = System.Windows.Forms.DockStyle.Top;
            tabSvcCategories.Font = new System.Drawing.Font("Segoe UI", 9F);
            tabSvcCategories.ItemSize = new System.Drawing.Size(88, 26);
            tabSvcCategories.Name = "tabSvcCategories";
            tabSvcCategories.SelectedIndex = 0;
            tabSvcCategories.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tabSvcCategories.Height = 34;
            tabSvcCategories.SelectedIndexChanged += tabSvcCategories_SelectedIndexChanged;
            //
            // lstCatalog
            //
            lstCatalog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lstCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            lstCatalog.Font = new System.Drawing.Font("Segoe UI", 10F);
            lstCatalog.ItemHeight = 28;
            lstCatalog.IntegralHeight = false;
            lstCatalog.MinimumSize = new System.Drawing.Size(0, 120);
            lstCatalog.Name = "lstCatalog";
            //
            // pnlChargeInner
            //
            pnlChargeInner.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            pnlChargeInner.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlChargeInner.Name = "pnlChargeInner";
            pnlChargeInner.Padding = new System.Windows.Forms.Padding(0, 6, 0, 8);
            //
            // pnlOrderActions
            //
            pnlOrderActions.ColumnCount = 5;
            pnlOrderActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            pnlOrderActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            pnlOrderActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            pnlOrderActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            pnlOrderActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            pnlOrderActions.Controls.Add(pnlChargeInner, 0, 0);
            pnlOrderActions.Controls.Add(lblQty, 0, 1);
            pnlOrderActions.Controls.Add(numQty, 1, 1);
            pnlOrderActions.Controls.Add(btnPlaceOrder, 4, 1);
            pnlOrderActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlOrderActions.Height = 304;
            pnlOrderActions.Name = "pnlOrderActions";
            pnlOrderActions.RowCount = 2;
            pnlOrderActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 248F));
            pnlOrderActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            pnlOrderActions.SetColumnSpan(pnlChargeInner, 5);
            //
            // lblQty
            //
            lblQty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblQty.AutoSize = true;
            lblQty.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblQty.Name = "lblQty";
            lblQty.Text = "Số lượng:";
            //
            // numQty
            //
            numQty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            numQty.Minimum = 1;
            numQty.Maximum = 99;
            numQty.Value = 1;
            numQty.Name = "numQty";
            numQty.Size = new System.Drawing.Size(78, 27);
            //
            // btnPlaceOrder
            //
            btnPlaceOrder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            btnPlaceOrder.Name = "btnPlaceOrder";
            btnPlaceOrder.Size = new System.Drawing.Size(160, 34);
            btnPlaceOrder.Text = "✓ Ghi nhận yêu cầu";
            btnPlaceOrder.Click += btnPlaceOrder_Click;
            //
            // cardTracking
            //
            cardTracking.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            cardTracking.CardBackColor = System.Drawing.Color.White;
            cardTracking.Controls.Add(dgvOrders);
            cardTracking.Controls.Add(pnlTrackingToolbar);
            cardTracking.Controls.Add(pnlTrackingHeader);
            cardTracking.Dock = System.Windows.Forms.DockStyle.Fill;
            cardTracking.Margin = new System.Windows.Forms.Padding(0);
            cardTracking.Name = "cardTracking";
            cardTracking.Padding = new System.Windows.Forms.Padding(16, 12, 16, 14);
            cardTracking.DrawShadow = false;
            cardTracking.Radius = 6;
            //
            // pnlTrackingHeader
            //
            pnlTrackingHeader.BackColor = System.Drawing.Color.White;
            pnlTrackingHeader.Controls.Add(lblTrackingTitle);
            pnlTrackingHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTrackingHeader.Height = 32;
            pnlTrackingHeader.Name = "pnlTrackingHeader";
            //
            // lblTrackingTitle
            //
            lblTrackingTitle.AutoSize = true;
            lblTrackingTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblTrackingTitle.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblTrackingTitle.Location = new System.Drawing.Point(0, 4);
            lblTrackingTitle.Name = "lblTrackingTitle";
            lblTrackingTitle.Text = "Theo dõi tiến độ phục vụ";
            //
            // pnlTrackingToolbar
            //
            pnlTrackingToolbar.BackColor = System.Drawing.Color.White;
            pnlTrackingToolbar.Controls.Add(lblStatusFilter);
            pnlTrackingToolbar.Controls.Add(cmbOrderStatus);
            pnlTrackingToolbar.Controls.Add(btnMarkPending);
            pnlTrackingToolbar.Controls.Add(btnMarkInProgress);
            pnlTrackingToolbar.Controls.Add(btnMarkCompleted);
            pnlTrackingToolbar.Controls.Add(btnCancelOrder);
            pnlTrackingToolbar.Controls.Add(btnReloadOps);
            pnlTrackingToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTrackingToolbar.Height = 52;
            pnlTrackingToolbar.Padding = new System.Windows.Forms.Padding(0, 8, 0, 10);
            pnlTrackingToolbar.Name = "pnlTrackingToolbar";
            //
            // lblStatusFilter
            //
            lblStatusFilter.AutoSize = true;
            lblStatusFilter.Location = new System.Drawing.Point(0, 16);
            lblStatusFilter.Name = "lblStatusFilter";
            lblStatusFilter.Text = "Lọc:";
            //
            // cmbOrderStatus
            //
            cmbOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbOrderStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbOrderStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbOrderStatus.Location = new System.Drawing.Point(40, 10);
            cmbOrderStatus.Name = "cmbOrderStatus";
            cmbOrderStatus.Size = new System.Drawing.Size(170, 30);
            cmbOrderStatus.SelectedIndexChanged += cmbOrderStatus_SelectedIndexChanged;
            //
            // btnMarkPending
            //
            btnMarkPending.Location = new System.Drawing.Point(222, 10);
            btnMarkPending.Name = "btnMarkPending";
            btnMarkPending.Size = new System.Drawing.Size(120, 30);
            btnMarkPending.Text = "→ Chờ xử lý";
            btnMarkPending.Click += btnMarkPending_Click;
            //
            // btnMarkInProgress
            //
            btnMarkInProgress.Location = new System.Drawing.Point(346, 10);
            btnMarkInProgress.Name = "btnMarkInProgress";
            btnMarkInProgress.Size = new System.Drawing.Size(120, 30);
            btnMarkInProgress.Text = "→ Đang làm";
            btnMarkInProgress.Click += btnMarkInProgress_Click;
            //
            // btnMarkCompleted
            //
            btnMarkCompleted.Location = new System.Drawing.Point(470, 10);
            btnMarkCompleted.Name = "btnMarkCompleted";
            btnMarkCompleted.Size = new System.Drawing.Size(130, 30);
            btnMarkCompleted.Text = "✓ Hoàn thành";
            btnMarkCompleted.Click += btnMarkCompleted_Click;
            //
            // btnCancelOrder
            //
            btnCancelOrder.Location = new System.Drawing.Point(604, 10);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new System.Drawing.Size(64, 30);
            btnCancelOrder.Text = "Hủy";
            btnCancelOrder.Click += btnCancelOrder_Click;
            //
            // btnReloadOps
            //
            btnReloadOps.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnReloadOps.Name = "btnReloadOps";
            btnReloadOps.Size = new System.Drawing.Size(90, 30);
            btnReloadOps.Text = "↻ Làm mới";
            btnReloadOps.Click += btnReloadOps_Click;
            //
            // dgvOrders
            //
            dgvOrders.BackgroundColor = System.Drawing.Color.White;
            dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvOrders.GridColor = System.Drawing.Color.FromArgb(241, 245, 249);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersVisible = false;
            //
            // usService
            //
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);
            Name = "usService";
            Size = new System.Drawing.Size(1151, 651);
            Load += usService_Load;

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlBody.ResumeLayout(false);
            tabMain.ResumeLayout(false);
            tabCatalog.ResumeLayout(false);
            tblCatalogRoot.ResumeLayout(false);
            cardCategories.ResumeLayout(false);
            pnlCategoryHeader.ResumeLayout(false);
            pnlCategoryHeader.PerformLayout();
            pnlCategoryToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            cardDetails.ResumeLayout(false);
            tabCatalogRight.ResumeLayout(false);
            tabServices.ResumeLayout(false);
            pnlServiceToolbar.ResumeLayout(false);
            pnlServiceToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            tabPackages.ResumeLayout(false);
            pnlPackageToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPackages).EndInit();
            tabPriceRules.ResumeLayout(false);
            pnlPriceRuleToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPriceRules).EndInit();
            tabOps.ResumeLayout(false);
            tblOpsRoot.ResumeLayout(false);
            cardOrderEntry.ResumeLayout(false);
            cardOrderEntry.PerformLayout();
            pnlOrderEntryHeader.ResumeLayout(false);
            pnlOrderEntryHeader.PerformLayout();
            pnlChargeInner.ResumeLayout(false);
            pnlOrderActions.ResumeLayout(false);
            pnlOrderActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            cardTracking.ResumeLayout(false);
            pnlTrackingHeader.ResumeLayout(false);
            pnlTrackingHeader.PerformLayout();
            pnlTrackingToolbar.ResumeLayout(false);
            pnlTrackingToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.TabControl tabMain;

        private System.Windows.Forms.TabPage tabCatalog;
        private System.Windows.Forms.TableLayoutPanel tblCatalogRoot;
        private RoundedCardPanel cardCategories;
        private System.Windows.Forms.Panel pnlCategoryHeader;
        private System.Windows.Forms.Label lblCategoryTitle;
        private System.Windows.Forms.Panel pnlCategoryToolbar;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnEditCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.DataGridView dgvCategories;

        private RoundedCardPanel cardDetails;
        private System.Windows.Forms.TabControl tabCatalogRight;
        private System.Windows.Forms.TabPage tabServices;
        private System.Windows.Forms.Panel pnlServiceToolbar;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnEditService;
        private System.Windows.Forms.Button btnToggleService;
        private System.Windows.Forms.Button btnDeleteService;
        private System.Windows.Forms.CheckBox chkShowHidden;
        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.TabPage tabPackages;
        private System.Windows.Forms.Panel pnlPackageToolbar;
        private System.Windows.Forms.Button btnAddPackage;
        private System.Windows.Forms.Button btnEditPackage;
        private System.Windows.Forms.Button btnDeletePackage;
        private System.Windows.Forms.DataGridView dgvPackages;
        private System.Windows.Forms.TabPage tabPriceRules;
        private System.Windows.Forms.Panel pnlPriceRuleToolbar;
        private System.Windows.Forms.Button btnAddPriceRule;
        private System.Windows.Forms.Button btnEditPriceRule;
        private System.Windows.Forms.Button btnDeletePriceRule;
        private System.Windows.Forms.DataGridView dgvPriceRules;

        private System.Windows.Forms.TabPage tabOps;
        private System.Windows.Forms.TableLayoutPanel tblOpsRoot;
        private RoundedCardPanel cardOrderEntry;
        private System.Windows.Forms.Panel pnlOrderEntryHeader;
        private System.Windows.Forms.Label lblOrderEntryTitle;
        private System.Windows.Forms.Label lblStay;
        private System.Windows.Forms.ComboBox cmbStay;
        private System.Windows.Forms.Label lblCatalog;
        private System.Windows.Forms.TabControl tabSvcCategories;
        private System.Windows.Forms.ListBox lstCatalog;
        private System.Windows.Forms.TableLayoutPanel pnlOrderActions;
        private System.Windows.Forms.Panel pnlChargeInner;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.Button btnPlaceOrder;

        private RoundedCardPanel cardTracking;
        private System.Windows.Forms.Panel pnlTrackingHeader;
        private System.Windows.Forms.Label lblTrackingTitle;
        private System.Windows.Forms.Panel pnlTrackingToolbar;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.ComboBox cmbOrderStatus;
        private System.Windows.Forms.Button btnMarkPending;
        private System.Windows.Forms.Button btnMarkInProgress;
        private System.Windows.Forms.Button btnMarkCompleted;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnReloadOps;
        private System.Windows.Forms.DataGridView dgvOrders;
    }
}
