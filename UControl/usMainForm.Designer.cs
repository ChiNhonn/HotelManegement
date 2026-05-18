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
            lblQuickManualPaymentHeading = new Label();
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
            pnlHeader.Padding = new Padding(27, 19, 27, 13);
            pnlHeader.Size = new Size(1200, 75);
            pnlHeader.TabIndex = 0;
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblDashboard.ForeColor = Color.FromArgb(51, 65, 85);
            lblDashboard.Location = new Point(27, 19);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(157, 37);
            lblDashboard.TabIndex = 0;
            lblDashboard.Text = "Dashboard";
            // 
            // scrollDashboard
            // 
            scrollDashboard.BackColor = Color.FromArgb(241, 245, 249);
            scrollDashboard.Controls.Add(tblRoot);
            scrollDashboard.Dock = DockStyle.Fill;
            scrollDashboard.Location = new Point(0, 75);
            scrollDashboard.Margin = new Padding(0);
            scrollDashboard.Name = "scrollDashboard";
            scrollDashboard.Size = new Size(1200, 858);
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
            tblRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 219F));
            tblRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblRoot.Size = new Size(1200, 858);
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
            tblKpi.Padding = new Padding(21, 16, 21, 8);
            tblKpi.RowCount = 1;
            tblKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblKpi.Size = new Size(1200, 219);
            tblKpi.TabIndex = 0;
            // 
            // cardVacant
            // 
            cardVacant.BackColor = Color.FromArgb(241, 245, 249);
            cardVacant.Dock = DockStyle.Fill;
            cardVacant.KpiCaption = "Phòng trống";
            cardVacant.KpiIconGlyph = "";
            cardVacant.KpiValue = "—";
            cardVacant.Location = new Point(28, 24);
            cardVacant.Margin = new Padding(7, 8, 7, 8);
            cardVacant.MinimumSize = new Size(137, 171);
            cardVacant.Name = "cardVacant";
            cardVacant.Size = new Size(275, 179);
            cardVacant.TabIndex = 0;
            // 
            // cardArrivals
            // 
            cardArrivals.BackColor = Color.FromArgb(241, 245, 249);
            cardArrivals.Dock = DockStyle.Fill;
            cardArrivals.KpiCaption = "Khách đến trong ngày";
            cardArrivals.KpiIconGlyph = "";
            cardArrivals.KpiValue = "—";
            cardArrivals.Location = new Point(317, 24);
            cardArrivals.Margin = new Padding(7, 8, 7, 8);
            cardArrivals.MinimumSize = new Size(137, 171);
            cardArrivals.Name = "cardArrivals";
            cardArrivals.Size = new Size(275, 179);
            cardArrivals.TabIndex = 1;
            // 
            // cardDepartures
            // 
            cardDepartures.BackColor = Color.FromArgb(241, 245, 249);
            cardDepartures.Dock = DockStyle.Fill;
            cardDepartures.KpiCaption = "Khách đi trong ngày";
            cardDepartures.KpiIconGlyph = "";
            cardDepartures.KpiValue = "—";
            cardDepartures.Location = new Point(606, 24);
            cardDepartures.Margin = new Padding(7, 8, 7, 8);
            cardDepartures.MinimumSize = new Size(137, 171);
            cardDepartures.Name = "cardDepartures";
            cardDepartures.Size = new Size(275, 179);
            cardDepartures.TabIndex = 2;
            // 
            // cardRevenue
            // 
            cardRevenue.BackColor = Color.FromArgb(241, 245, 249);
            cardRevenue.Dock = DockStyle.Fill;
            cardRevenue.KpiCaption = "Doanh thu trong ngày";
            cardRevenue.KpiIconGlyph = "";
            cardRevenue.KpiValue = "—";
            cardRevenue.Location = new Point(895, 24);
            cardRevenue.Margin = new Padding(7, 8, 7, 8);
            cardRevenue.MinimumSize = new Size(137, 171);
            cardRevenue.Name = "cardRevenue";
            cardRevenue.Size = new Size(277, 179);
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
            tblMidRow.Location = new Point(0, 219);
            tblMidRow.Margin = new Padding(0);
            tblMidRow.Name = "tblMidRow";
            tblMidRow.Padding = new Padding(21, 8, 21, 8);
            tblMidRow.RowCount = 1;
            tblMidRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMidRow.Size = new Size(1200, 319);
            tblMidRow.TabIndex = 1;
            // 
            // cardRecentTx
            // 
            cardRecentTx.BackColor = Color.Transparent;
            cardRecentTx.BorderColor = Color.FromArgb(226, 232, 240);
            cardRecentTx.CardBackColor = Color.White;
            cardRecentTx.ClipChildrenToRoundedBounds = true;
            cardRecentTx.Controls.Add(dgvRecentTx);
            cardRecentTx.Controls.Add(tblRecentTxHead);
            cardRecentTx.Dock = DockStyle.Fill;
            cardRecentTx.DrawCardBorder = true;
            cardRecentTx.DrawShadow = true;
            cardRecentTx.Location = new Point(21, 8);
            cardRecentTx.Margin = new Padding(0, 0, 9, 0);
            cardRecentTx.Name = "cardRecentTx";
            cardRecentTx.Padding = new Padding(18, 16, 18, 19);
            cardRecentTx.Radius = 12;
            cardRecentTx.Size = new Size(755, 303);
            cardRecentTx.TabIndex = 0;
            // 
            // dgvRecentTx
            // 
            dgvRecentTx.BackgroundColor = Color.White;
            dgvRecentTx.BorderStyle = BorderStyle.None;
            dgvRecentTx.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRecentTx.ColumnHeadersHeight = 29;
            dgvRecentTx.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRecentTx.Dock = DockStyle.Fill;
            dgvRecentTx.GridColor = Color.FromArgb(241, 245, 249);
            dgvRecentTx.Location = new Point(18, 72);
            dgvRecentTx.Margin = new Padding(3, 5, 3, 5);
            dgvRecentTx.Name = "dgvRecentTx";
            dgvRecentTx.RowHeadersVisible = false;
            dgvRecentTx.RowHeadersWidth = 51;
            dgvRecentTx.RowTemplate.Height = 44;
            dgvRecentTx.Size = new Size(719, 212);
            dgvRecentTx.TabIndex = 1;
            // 
            // tblRecentTxHead
            // 
            tblRecentTxHead.BackColor = Color.White;
            tblRecentTxHead.ColumnCount = 3;
            tblRecentTxHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 43F));
            tblRecentTxHead.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblRecentTxHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 123F));
            tblRecentTxHead.Controls.Add(picRecentTxHdr, 0, 0);
            tblRecentTxHead.Controls.Add(lblRecentTxTitle, 1, 0);
            tblRecentTxHead.Controls.Add(btnRecentTxViewAll, 2, 0);
            tblRecentTxHead.Dock = DockStyle.Top;
            tblRecentTxHead.Location = new Point(18, 16);
            tblRecentTxHead.Margin = new Padding(0);
            tblRecentTxHead.Name = "tblRecentTxHead";
            tblRecentTxHead.RowCount = 1;
            tblRecentTxHead.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tblRecentTxHead.Size = new Size(719, 56);
            tblRecentTxHead.TabIndex = 0;
            // 
            // picRecentTxHdr
            // 
            picRecentTxHdr.BackColor = Color.White;
            picRecentTxHdr.Dock = DockStyle.Fill;
            picRecentTxHdr.Location = new Point(0, 5);
            picRecentTxHdr.Margin = new Padding(0, 5, 7, 5);
            picRecentTxHdr.Name = "picRecentTxHdr";
            picRecentTxHdr.Size = new Size(36, 46);
            picRecentTxHdr.SizeMode = PictureBoxSizeMode.Zoom;
            picRecentTxHdr.TabIndex = 0;
            picRecentTxHdr.TabStop = false;
            // 
            // lblRecentTxTitle
            // 
            lblRecentTxTitle.Dock = DockStyle.Fill;
            lblRecentTxTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblRecentTxTitle.ForeColor = Color.FromArgb(51, 65, 85);
            lblRecentTxTitle.Location = new Point(43, 0);
            lblRecentTxTitle.Margin = new Padding(0);
            lblRecentTxTitle.Name = "lblRecentTxTitle";
            lblRecentTxTitle.Size = new Size(553, 56);
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
            btnRecentTxViewAll.Location = new Point(596, 8);
            btnRecentTxViewAll.Margin = new Padding(0, 8, 0, 8);
            btnRecentTxViewAll.Name = "btnRecentTxViewAll";
            btnRecentTxViewAll.Size = new Size(123, 40);
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
            tblRightSidebar.Location = new Point(794, 8);
            tblRightSidebar.Margin = new Padding(9, 0, 0, 0);
            tblRightSidebar.Name = "tblRightSidebar";
            tblRightSidebar.RowCount = 2;
            tblRightSidebar.RowStyles.Add(new RowStyle(SizeType.Absolute, 336F));
            tblRightSidebar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblRightSidebar.Size = new Size(385, 303);
            tblRightSidebar.TabIndex = 1;
            // 
            // cardQuickActions
            // 
            cardQuickActions.BackColor = Color.Transparent;
            cardQuickActions.BorderColor = Color.FromArgb(226, 232, 240);
            cardQuickActions.CardBackColor = Color.White;
            cardQuickActions.ClipChildrenToRoundedBounds = true;
            cardQuickActions.Controls.Add(pnlQuickActionsBody);
            cardQuickActions.Controls.Add(tblQuickHead);
            cardQuickActions.Dock = DockStyle.Fill;
            cardQuickActions.DrawCardBorder = true;
            cardQuickActions.DrawShadow = true;
            cardQuickActions.Location = new Point(0, 0);
            cardQuickActions.Margin = new Padding(0, 0, 0, 11);
            cardQuickActions.Name = "cardQuickActions";
            cardQuickActions.Padding = new Padding(18, 16, 18, 19);
            cardQuickActions.Radius = 12;
            cardQuickActions.Size = new Size(385, 325);
            cardQuickActions.TabIndex = 0;
            // 
            // pnlQuickActionsBody
            // 
            pnlQuickActionsBody.BackColor = Color.White;
            pnlQuickActionsBody.Controls.Add(flowQuickActions);
            pnlQuickActionsBody.Dock = DockStyle.Fill;
            pnlQuickActionsBody.Location = new Point(18, 69);
            pnlQuickActionsBody.Margin = new Padding(3, 4, 3, 4);
            pnlQuickActionsBody.Name = "pnlQuickActionsBody";
            pnlQuickActionsBody.Padding = new Padding(0, 3, 0, 5);
            pnlQuickActionsBody.Size = new Size(349, 237);
            pnlQuickActionsBody.TabIndex = 1;
            // 
            // flowQuickActions
            // 
            flowQuickActions.AutoSize = true;
            flowQuickActions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowQuickActions.BackColor = Color.White;
            flowQuickActions.Controls.Add(lblQuickManualPaymentHeading);
            flowQuickActions.Controls.Add(btnAddRecentPayment);
            flowQuickActions.Controls.Add(btnAddPayout);
            flowQuickActions.Dock = DockStyle.Top;
            flowQuickActions.FlowDirection = FlowDirection.TopDown;
            flowQuickActions.Location = new Point(0, 3);
            flowQuickActions.Margin = new Padding(0);
            flowQuickActions.Name = "flowQuickActions";
            flowQuickActions.Padding = new Padding(0, 3, 0, 3);
            flowQuickActions.Size = new Size(349, 84);
            flowQuickActions.TabIndex = 0;
            flowQuickActions.WrapContents = false;
            // 
            // lblQuickManualPaymentHeading
            // 
            lblQuickManualPaymentHeading.AutoSize = false;
            lblQuickManualPaymentHeading.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblQuickManualPaymentHeading.ForeColor = Color.FromArgb(71, 85, 105);
            lblQuickManualPaymentHeading.Location = new Point(3, 3);
            lblQuickManualPaymentHeading.Margin = new Padding(3, 0, 3, 8);
            lblQuickManualPaymentHeading.Name = "lblQuickManualPaymentHeading";
            lblQuickManualPaymentHeading.Size = new Size(343, 24);
            lblQuickManualPaymentHeading.TabIndex = 2;
            lblQuickManualPaymentHeading.Text = "Tiêu đề giao dịch";
            lblQuickManualPaymentHeading.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnAddRecentPayment
            // 
            btnAddRecentPayment.FlatStyle = FlatStyle.Flat;
            btnAddRecentPayment.Location = new Point(3, 7);
            btnAddRecentPayment.Margin = new Padding(3, 4, 3, 4);
            btnAddRecentPayment.Name = "btnAddRecentPayment";
            btnAddRecentPayment.Size = new Size(86, 31);
            btnAddRecentPayment.TabIndex = 0;
            btnAddRecentPayment.Text = "Thêm giao dịch";
            btnAddRecentPayment.UseVisualStyleBackColor = false;
            // 
            // btnAddPayout
            // 
            btnAddPayout.Cursor = Cursors.Hand;
            btnAddPayout.FlatStyle = FlatStyle.Flat;
            btnAddPayout.Location = new Point(3, 46);
            btnAddPayout.Margin = new Padding(3, 4, 3, 4);
            btnAddPayout.Name = "btnAddPayout";
            btnAddPayout.Size = new Size(86, 31);
            btnAddPayout.TabIndex = 1;
            btnAddPayout.Text = "Thêm chi trả";
            btnAddPayout.UseVisualStyleBackColor = false;
            // 
            // tblQuickHead
            // 
            tblQuickHead.BackColor = Color.White;
            tblQuickHead.ColumnCount = 2;
            tblQuickHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 43F));
            tblQuickHead.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblQuickHead.Controls.Add(picQuickHdr, 0, 0);
            tblQuickHead.Controls.Add(lblQuickActionsTitle, 1, 0);
            tblQuickHead.Dock = DockStyle.Top;
            tblQuickHead.Location = new Point(18, 16);
            tblQuickHead.Margin = new Padding(0);
            tblQuickHead.Name = "tblQuickHead";
            tblQuickHead.RowCount = 1;
            tblQuickHead.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tblQuickHead.Size = new Size(349, 53);
            tblQuickHead.TabIndex = 0;
            // 
            // picQuickHdr
            // 
            picQuickHdr.BackColor = Color.White;
            picQuickHdr.Dock = DockStyle.Fill;
            picQuickHdr.Location = new Point(0, 3);
            picQuickHdr.Margin = new Padding(0, 3, 7, 3);
            picQuickHdr.Name = "picQuickHdr";
            picQuickHdr.Size = new Size(36, 47);
            picQuickHdr.SizeMode = PictureBoxSizeMode.Zoom;
            picQuickHdr.TabIndex = 0;
            picQuickHdr.TabStop = false;
            // 
            // lblQuickActionsTitle
            // 
            lblQuickActionsTitle.Dock = DockStyle.Fill;
            lblQuickActionsTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblQuickActionsTitle.ForeColor = Color.FromArgb(51, 65, 85);
            lblQuickActionsTitle.Location = new Point(43, 0);
            lblQuickActionsTitle.Margin = new Padding(0);
            lblQuickActionsTitle.Name = "lblQuickActionsTitle";
            lblQuickActionsTitle.Size = new Size(306, 53);
            lblQuickActionsTitle.TabIndex = 1;
            lblQuickActionsTitle.Text = "Thao tác nhanh";
            lblQuickActionsTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cardMyTasks
            // 
            cardMyTasks.BackColor = Color.Transparent;
            cardMyTasks.BorderColor = Color.FromArgb(226, 232, 240);
            cardMyTasks.CardBackColor = Color.White;
            cardMyTasks.ClipChildrenToRoundedBounds = true;
            cardMyTasks.Controls.Add(pnlMyTasksBody);
            cardMyTasks.Controls.Add(tblMyTasksHead);
            cardMyTasks.Dock = DockStyle.Fill;
            cardMyTasks.DrawCardBorder = true;
            cardMyTasks.DrawShadow = true;
            cardMyTasks.Location = new Point(0, 347);
            cardMyTasks.Margin = new Padding(0, 11, 0, 0);
            cardMyTasks.Name = "cardMyTasks";
            cardMyTasks.Padding = new Padding(18, 16, 18, 19);
            cardMyTasks.Radius = 12;
            cardMyTasks.Size = new Size(385, 1);
            cardMyTasks.TabIndex = 1;
            // 
            // pnlMyTasksBody
            // 
            pnlMyTasksBody.BackColor = Color.White;
            pnlMyTasksBody.Controls.Add(dgvStaffPayouts);
            pnlMyTasksBody.Dock = DockStyle.Fill;
            pnlMyTasksBody.Location = new Point(18, 72);
            pnlMyTasksBody.Margin = new Padding(3, 4, 3, 4);
            pnlMyTasksBody.Name = "pnlMyTasksBody";
            pnlMyTasksBody.Size = new Size(349, 0);
            pnlMyTasksBody.TabIndex = 1;
            // 
            // dgvStaffPayouts
            // 
            dgvStaffPayouts.BackgroundColor = Color.White;
            dgvStaffPayouts.BorderStyle = BorderStyle.None;
            dgvStaffPayouts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvStaffPayouts.ColumnHeadersHeight = 29;
            dgvStaffPayouts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvStaffPayouts.Dock = DockStyle.Fill;
            dgvStaffPayouts.GridColor = Color.FromArgb(241, 245, 249);
            dgvStaffPayouts.Location = new Point(0, 0);
            dgvStaffPayouts.Margin = new Padding(3, 5, 3, 5);
            dgvStaffPayouts.Name = "dgvStaffPayouts";
            dgvStaffPayouts.RowHeadersVisible = false;
            dgvStaffPayouts.RowHeadersWidth = 51;
            dgvStaffPayouts.RowTemplate.Height = 36;
            dgvStaffPayouts.Size = new Size(349, 0);
            dgvStaffPayouts.TabIndex = 0;
            // 
            // tblMyTasksHead
            // 
            tblMyTasksHead.BackColor = Color.White;
            tblMyTasksHead.ColumnCount = 3;
            tblMyTasksHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 43F));
            tblMyTasksHead.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMyTasksHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 123F));
            tblMyTasksHead.Controls.Add(picMyTasksHdr, 0, 0);
            tblMyTasksHead.Controls.Add(lblMyTasksTitle, 1, 0);
            tblMyTasksHead.Controls.Add(btnMyTasksViewAll, 2, 0);
            tblMyTasksHead.Dock = DockStyle.Top;
            tblMyTasksHead.Location = new Point(18, 16);
            tblMyTasksHead.Margin = new Padding(0);
            tblMyTasksHead.Name = "tblMyTasksHead";
            tblMyTasksHead.RowCount = 1;
            tblMyTasksHead.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tblMyTasksHead.Size = new Size(349, 56);
            tblMyTasksHead.TabIndex = 0;
            // 
            // picMyTasksHdr
            // 
            picMyTasksHdr.BackColor = Color.White;
            picMyTasksHdr.Dock = DockStyle.Fill;
            picMyTasksHdr.Location = new Point(0, 5);
            picMyTasksHdr.Margin = new Padding(0, 5, 7, 5);
            picMyTasksHdr.Name = "picMyTasksHdr";
            picMyTasksHdr.Size = new Size(36, 46);
            picMyTasksHdr.SizeMode = PictureBoxSizeMode.Zoom;
            picMyTasksHdr.TabIndex = 0;
            picMyTasksHdr.TabStop = false;
            // 
            // lblMyTasksTitle
            // 
            lblMyTasksTitle.Dock = DockStyle.Fill;
            lblMyTasksTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblMyTasksTitle.ForeColor = Color.FromArgb(51, 65, 85);
            lblMyTasksTitle.Location = new Point(43, 0);
            lblMyTasksTitle.Margin = new Padding(0);
            lblMyTasksTitle.Name = "lblMyTasksTitle";
            lblMyTasksTitle.Size = new Size(183, 56);
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
            btnMyTasksViewAll.Location = new Point(226, 8);
            btnMyTasksViewAll.Margin = new Padding(0, 8, 0, 8);
            btnMyTasksViewAll.Name = "btnMyTasksViewAll";
            btnMyTasksViewAll.Size = new Size(123, 40);
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
            tblBottomRow.Location = new Point(0, 538);
            tblBottomRow.Margin = new Padding(0);
            tblBottomRow.Name = "tblBottomRow";
            tblBottomRow.Padding = new Padding(21, 8, 21, 19);
            tblBottomRow.RowCount = 1;
            tblBottomRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblBottomRow.Size = new Size(1200, 320);
            tblBottomRow.TabIndex = 2;
            // 
            // cardPending
            // 
            cardPending.BackColor = Color.Transparent;
            cardPending.BorderColor = Color.FromArgb(226, 232, 240);
            cardPending.CardBackColor = Color.White;
            cardPending.ClipChildrenToRoundedBounds = true;
            cardPending.Controls.Add(dgvPending);
            cardPending.Controls.Add(tblPendingHead);
            cardPending.Dock = DockStyle.Fill;
            cardPending.DrawCardBorder = true;
            cardPending.DrawShadow = true;
            cardPending.Location = new Point(21, 8);
            cardPending.Margin = new Padding(0, 0, 9, 0);
            cardPending.Name = "cardPending";
            cardPending.Padding = new Padding(18, 16, 18, 19);
            cardPending.Radius = 12;
            cardPending.Size = new Size(570, 293);
            cardPending.TabIndex = 0;
            // 
            // dgvPending
            // 
            dgvPending.BackgroundColor = Color.White;
            dgvPending.BorderStyle = BorderStyle.None;
            dgvPending.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPending.ColumnHeadersHeight = 29;
            dgvPending.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPending.Dock = DockStyle.Fill;
            dgvPending.GridColor = Color.FromArgb(241, 245, 249);
            dgvPending.Location = new Point(18, 72);
            dgvPending.Margin = new Padding(3, 5, 3, 5);
            dgvPending.Name = "dgvPending";
            dgvPending.RowHeadersVisible = false;
            dgvPending.RowHeadersWidth = 51;
            dgvPending.RowTemplate.Height = 44;
            dgvPending.Size = new Size(534, 202);
            dgvPending.TabIndex = 1;
            // 
            // tblPendingHead
            // 
            tblPendingHead.BackColor = Color.White;
            tblPendingHead.ColumnCount = 3;
            tblPendingHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 43F));
            tblPendingHead.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPendingHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 123F));
            tblPendingHead.Controls.Add(picPendingHdr, 0, 0);
            tblPendingHead.Controls.Add(lblPendingTitle, 1, 0);
            tblPendingHead.Controls.Add(btnPendingViewAll, 2, 0);
            tblPendingHead.Dock = DockStyle.Top;
            tblPendingHead.Location = new Point(18, 16);
            tblPendingHead.Margin = new Padding(0);
            tblPendingHead.Name = "tblPendingHead";
            tblPendingHead.RowCount = 1;
            tblPendingHead.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tblPendingHead.Size = new Size(534, 56);
            tblPendingHead.TabIndex = 0;
            // 
            // picPendingHdr
            // 
            picPendingHdr.BackColor = Color.White;
            picPendingHdr.Dock = DockStyle.Fill;
            picPendingHdr.Location = new Point(0, 5);
            picPendingHdr.Margin = new Padding(0, 5, 7, 5);
            picPendingHdr.Name = "picPendingHdr";
            picPendingHdr.Size = new Size(36, 46);
            picPendingHdr.SizeMode = PictureBoxSizeMode.Zoom;
            picPendingHdr.TabIndex = 0;
            picPendingHdr.TabStop = false;
            // 
            // lblPendingTitle
            // 
            lblPendingTitle.Dock = DockStyle.Fill;
            lblPendingTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPendingTitle.ForeColor = Color.FromArgb(51, 65, 85);
            lblPendingTitle.Location = new Point(43, 0);
            lblPendingTitle.Margin = new Padding(0);
            lblPendingTitle.Name = "lblPendingTitle";
            lblPendingTitle.Size = new Size(368, 56);
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
            btnPendingViewAll.Location = new Point(411, 8);
            btnPendingViewAll.Margin = new Padding(0, 8, 0, 8);
            btnPendingViewAll.Name = "btnPendingViewAll";
            btnPendingViewAll.Size = new Size(123, 40);
            btnPendingViewAll.TabIndex = 2;
            btnPendingViewAll.Text = "Xem tất cả";
            btnPendingViewAll.UseVisualStyleBackColor = false;
            // 
            // cardReminders
            // 
            cardReminders.BackColor = Color.Transparent;
            cardReminders.BorderColor = Color.FromArgb(226, 232, 240);
            cardReminders.CardBackColor = Color.White;
            cardReminders.ClipChildrenToRoundedBounds = true;
            cardReminders.Controls.Add(dgvReminders);
            cardReminders.Controls.Add(tblRemindersHead);
            cardReminders.Dock = DockStyle.Fill;
            cardReminders.DrawCardBorder = true;
            cardReminders.DrawShadow = true;
            cardReminders.Location = new Point(609, 8);
            cardReminders.Margin = new Padding(9, 0, 0, 0);
            cardReminders.Name = "cardReminders";
            cardReminders.Padding = new Padding(18, 16, 18, 19);
            cardReminders.Radius = 12;
            cardReminders.Size = new Size(570, 293);
            cardReminders.TabIndex = 1;
            // 
            // dgvReminders
            // 
            dgvReminders.BackgroundColor = Color.White;
            dgvReminders.BorderStyle = BorderStyle.None;
            dgvReminders.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReminders.ColumnHeadersHeight = 29;
            dgvReminders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvReminders.Dock = DockStyle.Fill;
            dgvReminders.GridColor = Color.FromArgb(241, 245, 249);
            dgvReminders.Location = new Point(18, 72);
            dgvReminders.Margin = new Padding(3, 5, 3, 5);
            dgvReminders.Name = "dgvReminders";
            dgvReminders.RowHeadersVisible = false;
            dgvReminders.RowHeadersWidth = 51;
            dgvReminders.RowTemplate.Height = 44;
            dgvReminders.Size = new Size(534, 202);
            dgvReminders.TabIndex = 1;
            // 
            // tblRemindersHead
            // 
            tblRemindersHead.BackColor = Color.White;
            tblRemindersHead.ColumnCount = 3;
            tblRemindersHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 43F));
            tblRemindersHead.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblRemindersHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 123F));
            tblRemindersHead.Controls.Add(picRemindersHdr, 0, 0);
            tblRemindersHead.Controls.Add(lblRemindersTitle, 1, 0);
            tblRemindersHead.Controls.Add(btnRemindersViewAll, 2, 0);
            tblRemindersHead.Dock = DockStyle.Top;
            tblRemindersHead.Location = new Point(18, 16);
            tblRemindersHead.Margin = new Padding(0);
            tblRemindersHead.Name = "tblRemindersHead";
            tblRemindersHead.RowCount = 1;
            tblRemindersHead.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tblRemindersHead.Size = new Size(534, 56);
            tblRemindersHead.TabIndex = 0;
            // 
            // picRemindersHdr
            // 
            picRemindersHdr.BackColor = Color.White;
            picRemindersHdr.Dock = DockStyle.Fill;
            picRemindersHdr.Location = new Point(0, 5);
            picRemindersHdr.Margin = new Padding(0, 5, 7, 5);
            picRemindersHdr.Name = "picRemindersHdr";
            picRemindersHdr.Size = new Size(36, 46);
            picRemindersHdr.SizeMode = PictureBoxSizeMode.Zoom;
            picRemindersHdr.TabIndex = 0;
            picRemindersHdr.TabStop = false;
            // 
            // lblRemindersTitle
            // 
            lblRemindersTitle.Dock = DockStyle.Fill;
            lblRemindersTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblRemindersTitle.ForeColor = Color.FromArgb(51, 65, 85);
            lblRemindersTitle.Location = new Point(43, 0);
            lblRemindersTitle.Margin = new Padding(0);
            lblRemindersTitle.Name = "lblRemindersTitle";
            lblRemindersTitle.Size = new Size(368, 56);
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
            btnRemindersViewAll.Location = new Point(411, 8);
            btnRemindersViewAll.Margin = new Padding(0, 8, 0, 8);
            btnRemindersViewAll.Name = "btnRemindersViewAll";
            btnRemindersViewAll.Size = new Size(123, 40);
            btnRemindersViewAll.TabIndex = 2;
            btnRemindersViewAll.Text = "Xem tất cả";
            btnRemindersViewAll.UseVisualStyleBackColor = false;
            // 
            // usMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            Controls.Add(scrollDashboard);
            Controls.Add(pnlHeader);
            Margin = new Padding(0);
            Name = "usMainForm";
            Size = new Size(1200, 933);
            Load += usMainForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            scrollDashboard.ResumeLayout(false);
            tblRoot.ResumeLayout(false);
            tblKpi.ResumeLayout(false);
            tblMidRow.ResumeLayout(false);
            cardRecentTx.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecentTx).EndInit();
            tblRecentTxHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picRecentTxHdr).EndInit();
            tblRightSidebar.ResumeLayout(false);
            cardQuickActions.ResumeLayout(false);
            pnlQuickActionsBody.ResumeLayout(false);
            pnlQuickActionsBody.PerformLayout();
            flowQuickActions.ResumeLayout(false);
            tblQuickHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picQuickHdr).EndInit();
            cardMyTasks.ResumeLayout(false);
            pnlMyTasksBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStaffPayouts).EndInit();
            tblMyTasksHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picMyTasksHdr).EndInit();
            tblBottomRow.ResumeLayout(false);
            cardPending.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPending).EndInit();
            tblPendingHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPendingHdr).EndInit();
            cardReminders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReminders).EndInit();
            tblRemindersHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picRemindersHdr).EndInit();
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
        private Label lblQuickManualPaymentHeading;
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
