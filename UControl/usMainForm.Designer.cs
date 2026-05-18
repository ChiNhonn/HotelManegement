namespace HotelManagement.CustomControls
{
    partial class usMainForm
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
            pnlHeader = new Panel();
            lblDashboard = new Label();

            scrollDashboard = new Panel();
            tblRoot = new TableLayoutPanel();

            tblKpi = new TableLayoutPanel();
            cardVacant = new UsKpiTile();
            cardArrivals = new UsKpiTile();
            cardDepartures = new UsKpiTile();
            cardRevenue = new UsKpiTile();

            tblMidRow = new TableLayoutPanel();
            cardRecentTx = new RoundedCardPanel();
            dgvRecentTx = new DataGridView();
            tblRecentTxHead = new TableLayoutPanel();
            picRecentTxHdr = new PictureBox();
            lblRecentTxTitle = new Label();
            btnRecentTxViewAll = new Button();

            tblRightSidebar = new TableLayoutPanel();
            cardQuickActions = new RoundedCardPanel();
            pnlQuickActionsBody = new Panel();
            flowQuickActions = new FlowLayoutPanel();
            btnAddRecentPayment = new QuickActionButton();
            btnAddPayout = new QuickActionButton();
            tblQuickHead = new TableLayoutPanel();
            picQuickHdr = new PictureBox();
            lblQuickActionsTitle = new Label();

            cardMyTasks = new RoundedCardPanel();
            pnlMyTasksBody = new Panel();
            dgvStaffPayouts = new DataGridView();
            tblMyTasksHead = new TableLayoutPanel();
            picMyTasksHdr = new PictureBox();
            lblMyTasksTitle = new Label();
            btnMyTasksViewAll = new Button();

            tblBottomRow = new TableLayoutPanel();
            cardPending = new RoundedCardPanel();
            dgvPending = new DataGridView();
            tblPendingHead = new TableLayoutPanel();
            picPendingHdr = new PictureBox();
            lblPendingTitle = new Label();
            btnPendingViewAll = new Button();

            cardReminders = new RoundedCardPanel();
            dgvReminders = new DataGridView();
            tblRemindersHead = new TableLayoutPanel();
            picRemindersHdr = new PictureBox();
            lblRemindersTitle = new Label();
            btnRemindersViewAll = new Button();

            pnlHeader.SuspendLayout();
            scrollDashboard.SuspendLayout();
            tblRoot.SuspendLayout();
            tblKpi.SuspendLayout();
            tblMidRow.SuspendLayout();
            cardRecentTx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentTx).BeginInit();
            tblRecentTxHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picRecentTxHdr).BeginInit();
            tblRightSidebar.SuspendLayout();
            cardQuickActions.SuspendLayout();
            pnlQuickActionsBody.SuspendLayout();
            flowQuickActions.SuspendLayout();
            tblQuickHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picQuickHdr).BeginInit();
            cardMyTasks.SuspendLayout();
            pnlMyTasksBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStaffPayouts).BeginInit();
            tblMyTasksHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMyTasksHdr).BeginInit();
            tblBottomRow.SuspendLayout();
            cardPending.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPending).BeginInit();
            tblPendingHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPendingHdr).BeginInit();
            cardReminders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReminders).BeginInit();
            tblRemindersHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picRemindersHdr).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblDashboard);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(24, 14, 24, 10);
            pnlHeader.Size = new Size(1050, 56);
            pnlHeader.TabIndex = 0;
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblDashboard.ForeColor = Color.FromArgb(51, 65, 85);
            lblDashboard.Location = new Point(24, 14);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(126, 30);
            lblDashboard.TabIndex = 0;
            lblDashboard.Text = "Dashboard";
            // 
            // scrollDashboard
            // 
            scrollDashboard.AutoScroll = false;
            scrollDashboard.BackColor = Color.FromArgb(241, 245, 249);
            scrollDashboard.Controls.Add(tblRoot);
            scrollDashboard.Dock = DockStyle.Fill;
            scrollDashboard.Location = new Point(0, 56);
            scrollDashboard.Margin = new Padding(0);
            scrollDashboard.Name = "scrollDashboard";
            scrollDashboard.Padding = new Padding(0);
            scrollDashboard.Size = new Size(1050, 644);
            scrollDashboard.TabIndex = 1;
            // 
            // tblRoot
            // 
            tblRoot.BackColor = Color.FromArgb(241, 245, 249);
            tblRoot.ColumnCount = 1;
            tblRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblRoot.Controls.Add(tblKpi, 0, 0);
            tblRoot.Controls.Add(tblMidRow, 0, 1);
            tblRoot.Controls.Add(tblBottomRow, 0, 2);
            tblRoot.Dock = DockStyle.Fill;
            tblRoot.Location = new Point(0, 0);
            tblRoot.Margin = new Padding(0);
            tblRoot.Name = "tblRoot";
            tblRoot.RowCount = 3;
            tblRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 164F));
            tblRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblRoot.Size = new Size(1050, 644);
            tblRoot.TabIndex = 0;
            // 
            // tblKpi
            // 
            tblKpi.BackColor = Color.FromArgb(241, 245, 249);
            tblKpi.ColumnCount = 4;
            tblKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblKpi.Controls.Add(cardVacant, 0, 0);
            tblKpi.Controls.Add(cardArrivals, 1, 0);
            tblKpi.Controls.Add(cardDepartures, 2, 0);
            tblKpi.Controls.Add(cardRevenue, 3, 0);
            tblKpi.Dock = DockStyle.Fill;
            tblKpi.Location = new Point(0, 0);
            tblKpi.Margin = new Padding(0);
            tblKpi.Name = "tblKpi";
            tblKpi.Padding = new Padding(18, 12, 18, 6);
            tblKpi.RowCount = 1;
            tblKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblKpi.Size = new Size(1050, 164);
            tblKpi.TabIndex = 0;
            // 
            // cardVacant
            // 
            cardVacant.BackColor = Color.FromArgb(241, 245, 249);
            cardVacant.Dock = DockStyle.Fill;
            cardVacant.KpiCaption = "Phòng trống";
            cardVacant.KpiIconGlyph = "";
            cardVacant.KpiValue = "—";
            cardVacant.Margin = new Padding(6, 6, 6, 6);
            cardVacant.MinimumSize = new Size(120, 128);
            cardVacant.Name = "cardVacant";
            cardVacant.TabIndex = 0;
            // 
            // cardArrivals
            // 
            cardArrivals.BackColor = Color.FromArgb(241, 245, 249);
            cardArrivals.Dock = DockStyle.Fill;
            cardArrivals.KpiCaption = "Khách đến trong ngày";
            cardArrivals.KpiIconGlyph = "";
            cardArrivals.KpiValue = "—";
            cardArrivals.Margin = new Padding(6, 6, 6, 6);
            cardArrivals.MinimumSize = new Size(120, 128);
            cardArrivals.Name = "cardArrivals";
            cardArrivals.TabIndex = 1;
            // 
            // cardDepartures
            // 
            cardDepartures.BackColor = Color.FromArgb(241, 245, 249);
            cardDepartures.Dock = DockStyle.Fill;
            cardDepartures.KpiCaption = "Khách đi trong ngày";
            cardDepartures.KpiIconGlyph = "";
            cardDepartures.KpiValue = "—";
            cardDepartures.Margin = new Padding(6, 6, 6, 6);
            cardDepartures.MinimumSize = new Size(120, 128);
            cardDepartures.Name = "cardDepartures";
            cardDepartures.TabIndex = 2;
            // 
            // cardRevenue
            // 
            cardRevenue.BackColor = Color.FromArgb(241, 245, 249);
            cardRevenue.Dock = DockStyle.Fill;
            cardRevenue.KpiCaption = "Doanh thu trong ngày";
            cardRevenue.KpiIconGlyph = "";
            cardRevenue.KpiValue = "—";
            cardRevenue.Margin = new Padding(6, 6, 6, 6);
            cardRevenue.MinimumSize = new Size(120, 128);
            cardRevenue.Name = "cardRevenue";
            cardRevenue.TabIndex = 3;
            // 
            // tblMidRow
            // 
            tblMidRow.BackColor = Color.FromArgb(241, 245, 249);
            tblMidRow.ColumnCount = 2;
            tblMidRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66F));
            tblMidRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tblMidRow.Controls.Add(cardRecentTx, 0, 0);
            tblMidRow.Controls.Add(tblRightSidebar, 1, 0);
            tblMidRow.Dock = DockStyle.Fill;
            tblMidRow.Location = new Point(0, 164);
            tblMidRow.Margin = new Padding(0);
            tblMidRow.Name = "tblMidRow";
            tblMidRow.Padding = new Padding(18, 6, 18, 6);
            tblMidRow.RowCount = 1;
            tblMidRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMidRow.Size = new Size(1050, 300);
            tblMidRow.TabIndex = 1;
            // 
            // cardRecentTx
            // 
            cardRecentTx.BackColor = Color.Transparent;
            cardRecentTx.BorderColor = Color.FromArgb(226, 232, 240);
            cardRecentTx.CardBackColor = Color.White;
            cardRecentTx.Controls.Add(dgvRecentTx);
            cardRecentTx.Controls.Add(tblRecentTxHead);
            cardRecentTx.Dock = DockStyle.Fill;
            cardRecentTx.Margin = new Padding(0, 0, 8, 0);
            cardRecentTx.Name = "cardRecentTx";
            cardRecentTx.Padding = new Padding(16, 12, 16, 14);
            cardRecentTx.Radius = 12;
            cardRecentTx.TabIndex = 0;
            // 
            // dgvRecentTx
            // 
            dgvRecentTx.BackgroundColor = Color.White;
            dgvRecentTx.BorderStyle = BorderStyle.None;
            dgvRecentTx.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRecentTx.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRecentTx.Dock = DockStyle.Fill;
            dgvRecentTx.GridColor = Color.FromArgb(241, 245, 249);
            dgvRecentTx.Margin = new Padding(3, 4, 3, 4);
            dgvRecentTx.Name = "dgvRecentTx";
            dgvRecentTx.RowHeadersVisible = false;
            dgvRecentTx.RowTemplate.Height = 44;
            dgvRecentTx.TabIndex = 1;
            // 
            // tblRecentTxHead
            // 
            tblRecentTxHead.BackColor = Color.White;
            tblRecentTxHead.ColumnCount = 3;
            tblRecentTxHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 38F));
            tblRecentTxHead.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblRecentTxHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 108F));
            tblRecentTxHead.Controls.Add(picRecentTxHdr, 0, 0);
            tblRecentTxHead.Controls.Add(lblRecentTxTitle, 1, 0);
            tblRecentTxHead.Controls.Add(btnRecentTxViewAll, 2, 0);
            tblRecentTxHead.Dock = DockStyle.Top;
            tblRecentTxHead.Margin = new Padding(0);
            tblRecentTxHead.Name = "tblRecentTxHead";
            tblRecentTxHead.RowCount = 1;
            tblRecentTxHead.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tblRecentTxHead.Size = new Size(645, 42);
            tblRecentTxHead.TabIndex = 0;
            // 
            // picRecentTxHdr
            // 
            picRecentTxHdr.BackColor = Color.White;
            picRecentTxHdr.Dock = DockStyle.Fill;
            picRecentTxHdr.Margin = new Padding(0, 4, 6, 4);
            picRecentTxHdr.Name = "picRecentTxHdr";
            picRecentTxHdr.SizeMode = PictureBoxSizeMode.Zoom;
            picRecentTxHdr.TabIndex = 0;
            picRecentTxHdr.TabStop = false;
            // 
            // lblRecentTxTitle
            // 
            lblRecentTxTitle.Dock = DockStyle.Fill;
            lblRecentTxTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblRecentTxTitle.ForeColor = Color.FromArgb(51, 65, 85);
            lblRecentTxTitle.Margin = new Padding(0);
            lblRecentTxTitle.Name = "lblRecentTxTitle";
            lblRecentTxTitle.TabIndex = 1;
            lblRecentTxTitle.Text = "Giao dịch gần đây";
            lblRecentTxTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnRecentTxViewAll
            // 
            btnRecentTxViewAll.BackColor = Color.White;
            btnRecentTxViewAll.Cursor = Cursors.Hand;
            btnRecentTxViewAll.Dock = DockStyle.Fill;
            btnRecentTxViewAll.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
            btnRecentTxViewAll.FlatStyle = FlatStyle.Flat;
            btnRecentTxViewAll.Font = new Font("Segoe UI", 9F);
            btnRecentTxViewAll.ForeColor = Color.FromArgb(59, 130, 246);
            btnRecentTxViewAll.Margin = new Padding(0, 6, 0, 6);
            btnRecentTxViewAll.Name = "btnRecentTxViewAll";
            btnRecentTxViewAll.TabIndex = 2;
            btnRecentTxViewAll.Text = "Xem tất cả";
            btnRecentTxViewAll.UseVisualStyleBackColor = false;
            // 
            // tblRightSidebar
            // 
            tblRightSidebar.BackColor = Color.FromArgb(241, 245, 249);
            tblRightSidebar.ColumnCount = 1;
            tblRightSidebar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblRightSidebar.Controls.Add(cardQuickActions, 0, 0);
            tblRightSidebar.Controls.Add(cardMyTasks, 0, 1);
            tblRightSidebar.Dock = DockStyle.Fill;
            tblRightSidebar.Margin = new Padding(8, 0, 0, 0);
            tblRightSidebar.Name = "tblRightSidebar";
            tblRightSidebar.RowCount = 2;
            tblRightSidebar.RowStyles.Add(new RowStyle(SizeType.Absolute, 252F));
            tblRightSidebar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblRightSidebar.TabIndex = 1;
            // 
            // cardQuickActions
            // 
            cardQuickActions.BackColor = Color.Transparent;
            cardQuickActions.BorderColor = Color.FromArgb(226, 232, 240);
            cardQuickActions.CardBackColor = Color.White;
            cardQuickActions.Controls.Add(pnlQuickActionsBody);
            cardQuickActions.Controls.Add(tblQuickHead);
            cardQuickActions.Dock = DockStyle.Fill;
            cardQuickActions.Margin = new Padding(0, 0, 0, 8);
            cardQuickActions.Name = "cardQuickActions";
            cardQuickActions.Padding = new Padding(16, 12, 16, 14);
            cardQuickActions.Radius = 12;
            cardQuickActions.TabIndex = 0;
            // 
            // pnlQuickActionsBody
            // 
            pnlQuickActionsBody.BackColor = Color.White;
            pnlQuickActionsBody.Controls.Add(flowQuickActions);
            pnlQuickActionsBody.Dock = DockStyle.Fill;
            pnlQuickActionsBody.Name = "pnlQuickActionsBody";
            pnlQuickActionsBody.Padding = new Padding(0, 2, 0, 4);
            pnlQuickActionsBody.TabIndex = 1;
            // 
            // flowQuickActions
            // 
            flowQuickActions.AutoSize = true;
            flowQuickActions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowQuickActions.BackColor = Color.White;
            flowQuickActions.Dock = DockStyle.Top;
            flowQuickActions.FlowDirection = FlowDirection.TopDown;
            flowQuickActions.Margin = new Padding(0);
            flowQuickActions.Name = "flowQuickActions";
            flowQuickActions.Padding = new Padding(0, 2, 0, 2);
            flowQuickActions.WrapContents = false;
            // 
            // btnAddRecentPayment
            // 
            btnAddRecentPayment.Location = new Point(0, 2);
            btnAddRecentPayment.Name = "btnAddRecentPayment";
            btnAddRecentPayment.TabIndex = 0;
            btnAddRecentPayment.Text = "+ Thêm giao dịch";
            btnAddRecentPayment.UseVisualStyleBackColor = false;
            // 
            // btnAddPayout
            // 
            btnAddPayout.Cursor = Cursors.Hand;
            btnAddPayout.Location = new Point(0, 56);
            btnAddPayout.Name = "btnAddPayout";
            btnAddPayout.TabIndex = 1;
            btnAddPayout.Text = "Thêm chi trả";
            btnAddPayout.UseVisualStyleBackColor = false;
            // 
            flowQuickActions.Controls.Add(btnAddRecentPayment);
            flowQuickActions.Controls.Add(btnAddPayout);
            // 
            // tblQuickHead
            // 
            tblQuickHead.BackColor = Color.White;
            tblQuickHead.ColumnCount = 2;
            tblQuickHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 38F));
            tblQuickHead.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblQuickHead.Controls.Add(picQuickHdr, 0, 0);
            tblQuickHead.Controls.Add(lblQuickActionsTitle, 1, 0);
            tblQuickHead.Dock = DockStyle.Top;
            tblQuickHead.Margin = new Padding(0);
            tblQuickHead.Name = "tblQuickHead";
            tblQuickHead.RowCount = 1;
            tblQuickHead.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblQuickHead.Size = new Size(297, 40);
            tblQuickHead.TabIndex = 0;
            // 
            // picQuickHdr
            // 
            picQuickHdr.BackColor = Color.White;
            picQuickHdr.Dock = DockStyle.Fill;
            picQuickHdr.Margin = new Padding(0, 2, 6, 2);
            picQuickHdr.Name = "picQuickHdr";
            picQuickHdr.SizeMode = PictureBoxSizeMode.Zoom;
            picQuickHdr.TabIndex = 0;
            picQuickHdr.TabStop = false;
            // 
            // lblQuickActionsTitle
            // 
            lblQuickActionsTitle.Dock = DockStyle.Fill;
            lblQuickActionsTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblQuickActionsTitle.ForeColor = Color.FromArgb(51, 65, 85);
            lblQuickActionsTitle.Margin = new Padding(0);
            lblQuickActionsTitle.Name = "lblQuickActionsTitle";
            lblQuickActionsTitle.TabIndex = 1;
            lblQuickActionsTitle.Text = "Thao tác nhanh";
            lblQuickActionsTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cardMyTasks
            // 
            cardMyTasks.BackColor = Color.Transparent;
            cardMyTasks.BorderColor = Color.FromArgb(226, 232, 240);
            cardMyTasks.CardBackColor = Color.White;
            cardMyTasks.Controls.Add(pnlMyTasksBody);
            cardMyTasks.Controls.Add(tblMyTasksHead);
            cardMyTasks.Dock = DockStyle.Fill;
            cardMyTasks.Margin = new Padding(0, 8, 0, 0);
            cardMyTasks.Name = "cardMyTasks";
            cardMyTasks.Padding = new Padding(16, 12, 16, 14);
            cardMyTasks.Radius = 12;
            cardMyTasks.TabIndex = 1;
            // 
            // pnlMyTasksBody
            // 
            pnlMyTasksBody.BackColor = Color.White;
            pnlMyTasksBody.Controls.Add(dgvStaffPayouts);
            pnlMyTasksBody.Dock = DockStyle.Fill;
            pnlMyTasksBody.Name = "pnlMyTasksBody";
            pnlMyTasksBody.TabIndex = 1;
            // 
            // dgvStaffPayouts
            // 
            dgvStaffPayouts.BackgroundColor = Color.White;
            dgvStaffPayouts.BorderStyle = BorderStyle.None;
            dgvStaffPayouts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvStaffPayouts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvStaffPayouts.Dock = DockStyle.Fill;
            dgvStaffPayouts.GridColor = Color.FromArgb(241, 245, 249);
            dgvStaffPayouts.Margin = new Padding(3, 4, 3, 4);
            dgvStaffPayouts.Name = "dgvStaffPayouts";
            dgvStaffPayouts.RowHeadersVisible = false;
            dgvStaffPayouts.RowTemplate.Height = 36;
            dgvStaffPayouts.TabIndex = 0;
            // 
            // tblMyTasksHead
            // 
            tblMyTasksHead.BackColor = Color.White;
            tblMyTasksHead.ColumnCount = 3;
            tblMyTasksHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 38F));
            tblMyTasksHead.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMyTasksHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 108F));
            tblMyTasksHead.Controls.Add(picMyTasksHdr, 0, 0);
            tblMyTasksHead.Controls.Add(lblMyTasksTitle, 1, 0);
            tblMyTasksHead.Controls.Add(btnMyTasksViewAll, 2, 0);
            tblMyTasksHead.Dock = DockStyle.Top;
            tblMyTasksHead.Margin = new Padding(0);
            tblMyTasksHead.Name = "tblMyTasksHead";
            tblMyTasksHead.RowCount = 1;
            tblMyTasksHead.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tblMyTasksHead.Size = new Size(297, 42);
            tblMyTasksHead.TabIndex = 0;
            // 
            // picMyTasksHdr
            // 
            picMyTasksHdr.BackColor = Color.White;
            picMyTasksHdr.Dock = DockStyle.Fill;
            picMyTasksHdr.Margin = new Padding(0, 4, 6, 4);
            picMyTasksHdr.Name = "picMyTasksHdr";
            picMyTasksHdr.SizeMode = PictureBoxSizeMode.Zoom;
            picMyTasksHdr.TabIndex = 0;
            picMyTasksHdr.TabStop = false;
            // 
            // lblMyTasksTitle
            // 
            lblMyTasksTitle.Dock = DockStyle.Fill;
            lblMyTasksTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblMyTasksTitle.ForeColor = Color.FromArgb(51, 65, 85);
            lblMyTasksTitle.Margin = new Padding(0);
            lblMyTasksTitle.Name = "lblMyTasksTitle";
            lblMyTasksTitle.TabIndex = 1;
            lblMyTasksTitle.Text = "Chi trả đã ghi nhận";
            lblMyTasksTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnMyTasksViewAll
            // 
            btnMyTasksViewAll.BackColor = Color.White;
            btnMyTasksViewAll.Cursor = Cursors.Hand;
            btnMyTasksViewAll.Dock = DockStyle.Fill;
            btnMyTasksViewAll.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
            btnMyTasksViewAll.FlatStyle = FlatStyle.Flat;
            btnMyTasksViewAll.Font = new Font("Segoe UI", 9F);
            btnMyTasksViewAll.ForeColor = Color.FromArgb(59, 130, 246);
            btnMyTasksViewAll.Margin = new Padding(0, 6, 0, 6);
            btnMyTasksViewAll.Name = "btnMyTasksViewAll";
            btnMyTasksViewAll.TabIndex = 2;
            btnMyTasksViewAll.Text = "Xem tất cả";
            btnMyTasksViewAll.UseVisualStyleBackColor = false;
            // 
            // tblBottomRow
            // 
            tblBottomRow.BackColor = Color.FromArgb(241, 245, 249);
            tblBottomRow.ColumnCount = 2;
            tblBottomRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblBottomRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblBottomRow.Controls.Add(cardPending, 0, 0);
            tblBottomRow.Controls.Add(cardReminders, 1, 0);
            tblBottomRow.Dock = DockStyle.Fill;
            tblBottomRow.Location = new Point(0, 464);
            tblBottomRow.Margin = new Padding(0);
            tblBottomRow.Name = "tblBottomRow";
            tblBottomRow.Padding = new Padding(18, 6, 18, 14);
            tblBottomRow.RowCount = 1;
            tblBottomRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblBottomRow.Size = new Size(1050, 304);
            tblBottomRow.TabIndex = 2;
            // 
            // cardPending
            // 
            cardPending.BackColor = Color.Transparent;
            cardPending.BorderColor = Color.FromArgb(226, 232, 240);
            cardPending.CardBackColor = Color.White;
            cardPending.Controls.Add(dgvPending);
            cardPending.Controls.Add(tblPendingHead);
            cardPending.Dock = DockStyle.Fill;
            cardPending.Margin = new Padding(0, 0, 8, 0);
            cardPending.Name = "cardPending";
            cardPending.Padding = new Padding(16, 12, 16, 14);
            cardPending.Radius = 12;
            cardPending.TabIndex = 0;
            // 
            // dgvPending
            // 
            dgvPending.BackgroundColor = Color.White;
            dgvPending.BorderStyle = BorderStyle.None;
            dgvPending.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPending.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPending.Dock = DockStyle.Fill;
            dgvPending.GridColor = Color.FromArgb(241, 245, 249);
            dgvPending.Margin = new Padding(3, 4, 3, 4);
            dgvPending.Name = "dgvPending";
            dgvPending.RowHeadersVisible = false;
            dgvPending.RowTemplate.Height = 44;
            dgvPending.TabIndex = 1;
            // 
            // tblPendingHead
            // 
            tblPendingHead.BackColor = Color.White;
            tblPendingHead.ColumnCount = 3;
            tblPendingHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 38F));
            tblPendingHead.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPendingHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 108F));
            tblPendingHead.Controls.Add(picPendingHdr, 0, 0);
            tblPendingHead.Controls.Add(lblPendingTitle, 1, 0);
            tblPendingHead.Controls.Add(btnPendingViewAll, 2, 0);
            tblPendingHead.Dock = DockStyle.Top;
            tblPendingHead.Margin = new Padding(0);
            tblPendingHead.Name = "tblPendingHead";
            tblPendingHead.RowCount = 1;
            tblPendingHead.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tblPendingHead.Size = new Size(464, 42);
            tblPendingHead.TabIndex = 0;
            // 
            // picPendingHdr
            // 
            picPendingHdr.BackColor = Color.White;
            picPendingHdr.Dock = DockStyle.Fill;
            picPendingHdr.Margin = new Padding(0, 4, 6, 4);
            picPendingHdr.Name = "picPendingHdr";
            picPendingHdr.SizeMode = PictureBoxSizeMode.Zoom;
            picPendingHdr.TabIndex = 0;
            picPendingHdr.TabStop = false;
            // 
            // lblPendingTitle
            // 
            lblPendingTitle.Dock = DockStyle.Fill;
            lblPendingTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPendingTitle.ForeColor = Color.FromArgb(51, 65, 85);
            lblPendingTitle.Margin = new Padding(0);
            lblPendingTitle.Name = "lblPendingTitle";
            lblPendingTitle.TabIndex = 1;
            lblPendingTitle.Text = "Booking mới chờ xác nhận";
            lblPendingTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnPendingViewAll
            // 
            btnPendingViewAll.BackColor = Color.White;
            btnPendingViewAll.Cursor = Cursors.Hand;
            btnPendingViewAll.Dock = DockStyle.Fill;
            btnPendingViewAll.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
            btnPendingViewAll.FlatStyle = FlatStyle.Flat;
            btnPendingViewAll.Font = new Font("Segoe UI", 9F);
            btnPendingViewAll.ForeColor = Color.FromArgb(59, 130, 246);
            btnPendingViewAll.Margin = new Padding(0, 6, 0, 6);
            btnPendingViewAll.Name = "btnPendingViewAll";
            btnPendingViewAll.TabIndex = 2;
            btnPendingViewAll.Text = "Xem tất cả";
            btnPendingViewAll.UseVisualStyleBackColor = false;
            // 
            // cardReminders
            // 
            cardReminders.BackColor = Color.Transparent;
            cardReminders.BorderColor = Color.FromArgb(226, 232, 240);
            cardReminders.CardBackColor = Color.White;
            cardReminders.Controls.Add(dgvReminders);
            cardReminders.Controls.Add(tblRemindersHead);
            cardReminders.Dock = DockStyle.Fill;
            cardReminders.Margin = new Padding(8, 0, 0, 0);
            cardReminders.Name = "cardReminders";
            cardReminders.Padding = new Padding(16, 12, 16, 14);
            cardReminders.Radius = 12;
            cardReminders.TabIndex = 1;
            // 
            // dgvReminders
            // 
            dgvReminders.BackgroundColor = Color.White;
            dgvReminders.BorderStyle = BorderStyle.None;
            dgvReminders.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReminders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvReminders.Dock = DockStyle.Fill;
            dgvReminders.GridColor = Color.FromArgb(241, 245, 249);
            dgvReminders.Margin = new Padding(3, 4, 3, 4);
            dgvReminders.Name = "dgvReminders";
            dgvReminders.RowHeadersVisible = false;
            dgvReminders.RowTemplate.Height = 44;
            dgvReminders.TabIndex = 1;
            // 
            // tblRemindersHead
            // 
            tblRemindersHead.BackColor = Color.White;
            tblRemindersHead.ColumnCount = 3;
            tblRemindersHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 38F));
            tblRemindersHead.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblRemindersHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 108F));
            tblRemindersHead.Controls.Add(picRemindersHdr, 0, 0);
            tblRemindersHead.Controls.Add(lblRemindersTitle, 1, 0);
            tblRemindersHead.Controls.Add(btnRemindersViewAll, 2, 0);
            tblRemindersHead.Dock = DockStyle.Top;
            tblRemindersHead.Margin = new Padding(0);
            tblRemindersHead.Name = "tblRemindersHead";
            tblRemindersHead.RowCount = 1;
            tblRemindersHead.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tblRemindersHead.Size = new Size(476, 42);
            tblRemindersHead.TabIndex = 0;
            // 
            // picRemindersHdr
            // 
            picRemindersHdr.BackColor = Color.White;
            picRemindersHdr.Dock = DockStyle.Fill;
            picRemindersHdr.Margin = new Padding(0, 4, 6, 4);
            picRemindersHdr.Name = "picRemindersHdr";
            picRemindersHdr.SizeMode = PictureBoxSizeMode.Zoom;
            picRemindersHdr.TabIndex = 0;
            picRemindersHdr.TabStop = false;
            // 
            // lblRemindersTitle
            // 
            lblRemindersTitle.Dock = DockStyle.Fill;
            lblRemindersTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblRemindersTitle.ForeColor = Color.FromArgb(51, 65, 85);
            lblRemindersTitle.Margin = new Padding(0);
            lblRemindersTitle.Name = "lblRemindersTitle";
            lblRemindersTitle.TabIndex = 1;
            lblRemindersTitle.Text = "Nhắc nhở";
            lblRemindersTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnRemindersViewAll
            // 
            btnRemindersViewAll.BackColor = Color.White;
            btnRemindersViewAll.Cursor = Cursors.Hand;
            btnRemindersViewAll.Dock = DockStyle.Fill;
            btnRemindersViewAll.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
            btnRemindersViewAll.FlatStyle = FlatStyle.Flat;
            btnRemindersViewAll.Font = new Font("Segoe UI", 9F);
            btnRemindersViewAll.ForeColor = Color.FromArgb(59, 130, 246);
            btnRemindersViewAll.Margin = new Padding(0, 6, 0, 6);
            btnRemindersViewAll.Name = "btnRemindersViewAll";
            btnRemindersViewAll.TabIndex = 2;
            btnRemindersViewAll.Text = "Xem tất cả";
            btnRemindersViewAll.UseVisualStyleBackColor = false;
            // 
            // usMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            Controls.Add(scrollDashboard);
            Controls.Add(pnlHeader);
            Margin = new Padding(0);
            Name = "usMainForm";
            Size = new Size(1050, 700);
            Load += usMainForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tblKpi.ResumeLayout(false);
            tblRecentTxHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picRecentTxHdr).EndInit();
            cardRecentTx.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecentTx).EndInit();
            tblQuickHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picQuickHdr).EndInit();
            flowQuickActions.ResumeLayout(false);
            pnlQuickActionsBody.ResumeLayout(false);
            cardQuickActions.ResumeLayout(false);
            tblMyTasksHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picMyTasksHdr).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStaffPayouts).EndInit();
            pnlMyTasksBody.ResumeLayout(false);
            cardMyTasks.ResumeLayout(false);
            tblRightSidebar.ResumeLayout(false);
            tblMidRow.ResumeLayout(false);
            tblPendingHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPendingHdr).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPending).EndInit();
            cardPending.ResumeLayout(false);
            tblRemindersHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picRemindersHdr).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReminders).EndInit();
            cardReminders.ResumeLayout(false);
            tblBottomRow.ResumeLayout(false);
            tblRoot.ResumeLayout(false);
            scrollDashboard.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblDashboard;

        private Panel scrollDashboard;
        private TableLayoutPanel tblRoot;

        private TableLayoutPanel tblKpi;
        private UsKpiTile cardVacant;
        private UsKpiTile cardArrivals;
        private UsKpiTile cardDepartures;
        private UsKpiTile cardRevenue;

        private TableLayoutPanel tblMidRow;
        private RoundedCardPanel cardRecentTx;
        private DataGridView dgvRecentTx;
        private TableLayoutPanel tblRecentTxHead;
        private PictureBox picRecentTxHdr;
        private Label lblRecentTxTitle;
        private Button btnRecentTxViewAll;

        private TableLayoutPanel tblRightSidebar;
        private RoundedCardPanel cardQuickActions;
        private Panel pnlQuickActionsBody;
        private FlowLayoutPanel flowQuickActions;
        private QuickActionButton btnAddRecentPayment;
        private QuickActionButton btnAddPayout;
        private TableLayoutPanel tblQuickHead;
        private PictureBox picQuickHdr;
        private Label lblQuickActionsTitle;

        private RoundedCardPanel cardMyTasks;
        private Panel pnlMyTasksBody;
        private DataGridView dgvStaffPayouts;
        private TableLayoutPanel tblMyTasksHead;
        private PictureBox picMyTasksHdr;
        private Label lblMyTasksTitle;
        private Button btnMyTasksViewAll;

        private TableLayoutPanel tblBottomRow;
        private RoundedCardPanel cardPending;
        private DataGridView dgvPending;
        private TableLayoutPanel tblPendingHead;
        private PictureBox picPendingHdr;
        private Label lblPendingTitle;
        private Button btnPendingViewAll;

        private RoundedCardPanel cardReminders;
        private DataGridView dgvReminders;
        private TableLayoutPanel tblRemindersHead;
        private PictureBox picRemindersHdr;
        private Label lblRemindersTitle;
        private Button btnRemindersViewAll;
    }
}
