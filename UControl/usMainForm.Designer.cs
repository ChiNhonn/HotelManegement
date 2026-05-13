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
            splitKpiAndLists = new SplitContainer();
            scrollDashKpi = new Panel();
            scrollDashLists = new Panel();
            pnlDashListsInner = new Panel();
            tblKpiOuter = new TableLayoutPanel();
            tblKpi = new TableLayoutPanel();
            cardVacant = new UsKpiTile();
            cardArrivals = new UsKpiTile();
            cardDepartures = new UsKpiTile();
            cardRevenue = new UsKpiTile();
            tblBelowKpi = new TableLayoutPanel();
            cardRecentTx = new RoundedCardPanel();
            dgvRecentTx = new DataGridView();
            tblRecentTxHead = new TableLayoutPanel();
            picRecentTxHdr = new PictureBox();
            lblRecentTxTitle = new Label();
            btnRecentTxViewAll = new Button();
            tblRightSidebar = new TableLayoutPanel();
            cardQuickActions = new RoundedCardPanel();
            pnlQuickActionsBody = new Panel();
            btnAddPayout = new Button();
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
            splitPendingAndReminders = new SplitContainer();
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
            ((System.ComponentModel.ISupportInitialize)splitKpiAndLists).BeginInit();
            splitKpiAndLists.Panel1.SuspendLayout();
            splitKpiAndLists.Panel2.SuspendLayout();
            splitKpiAndLists.SuspendLayout();
            scrollDashKpi.SuspendLayout();
            scrollDashLists.SuspendLayout();
            pnlDashListsInner.SuspendLayout();
            tblKpiOuter.SuspendLayout();
            tblKpi.SuspendLayout();
            tblBelowKpi.SuspendLayout();
            cardRecentTx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentTx).BeginInit();
            tblRecentTxHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picRecentTxHdr).BeginInit();
            tblRightSidebar.SuspendLayout();
            cardQuickActions.SuspendLayout();
            pnlQuickActionsBody.SuspendLayout();
            tblQuickHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picQuickHdr).BeginInit();
            cardMyTasks.SuspendLayout();
            pnlMyTasksBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStaffPayouts).BeginInit();
            tblMyTasksHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMyTasksHdr).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitPendingAndReminders).BeginInit();
            splitPendingAndReminders.Panel1.SuspendLayout();
            splitPendingAndReminders.Panel2.SuspendLayout();
            splitPendingAndReminders.SuspendLayout();
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
            pnlHeader.Margin = new Padding(3, 2, 3, 2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(21, 14, 21, 10);
            pnlHeader.Size = new Size(1050, 48);
            pnlHeader.TabIndex = 0;
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblDashboard.ForeColor = Color.FromArgb(51, 65, 85);
            lblDashboard.Location = new Point(21, 14);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(126, 30);
            lblDashboard.TabIndex = 0;
            lblDashboard.Text = "Dashboard";
            // 
            // splitKpiAndLists
            // 
            splitKpiAndLists.BackColor = Color.FromArgb(241, 245, 249);
            splitKpiAndLists.Dock = DockStyle.Fill;
            splitKpiAndLists.Location = new Point(0, 48);
            splitKpiAndLists.Margin = new Padding(3, 2, 3, 2);
            splitKpiAndLists.Name = "splitKpiAndLists";
            splitKpiAndLists.Orientation = Orientation.Horizontal;
            // 
            // splitKpiAndLists.Panel1
            // 
            splitKpiAndLists.Panel1.Controls.Add(scrollDashKpi);
            splitKpiAndLists.Panel1MinSize = 200;
            // 
            // splitKpiAndLists.Panel2
            // 
            splitKpiAndLists.Panel2.BackColor = Color.FromArgb(241, 245, 249);
            splitKpiAndLists.Panel2.Controls.Add(scrollDashLists);
            splitKpiAndLists.Panel2MinSize = 110;
            splitKpiAndLists.Size = new Size(1050, 414);
            splitKpiAndLists.SplitterDistance = 288;
            splitKpiAndLists.SplitterWidth = 3;
            splitKpiAndLists.TabIndex = 2;
            // 
            // scrollDashKpi
            // 
            scrollDashKpi.AutoScroll = true;
            scrollDashKpi.BackColor = Color.FromArgb(241, 245, 249);
            scrollDashKpi.Controls.Add(tblKpiOuter);
            scrollDashKpi.Dock = DockStyle.Fill;
            scrollDashKpi.Location = new Point(0, 0);
            scrollDashKpi.Margin = new Padding(3, 2, 3, 2);
            scrollDashKpi.Name = "scrollDashKpi";
            scrollDashKpi.Size = new Size(1050, 288);
            scrollDashKpi.TabIndex = 0;
            // 
            // scrollDashLists
            // 
            scrollDashLists.AutoScroll = true;
            scrollDashLists.BackColor = Color.FromArgb(241, 245, 249);
            scrollDashLists.Controls.Add(pnlDashListsInner);
            scrollDashLists.Dock = DockStyle.Fill;
            scrollDashLists.Location = new Point(0, 0);
            scrollDashLists.Margin = new Padding(3, 2, 3, 2);
            scrollDashLists.Name = "scrollDashLists";
            scrollDashLists.Size = new Size(1050, 123);
            scrollDashLists.TabIndex = 0;
            // 
            // pnlDashListsInner
            // 
            pnlDashListsInner.BackColor = Color.FromArgb(241, 245, 249);
            pnlDashListsInner.Dock = DockStyle.Top;
            pnlDashListsInner.Location = new Point(0, 0);
            pnlDashListsInner.Margin = new Padding(0);
            pnlDashListsInner.MinimumSize = new Size(800, 360);
            pnlDashListsInner.Name = "pnlDashListsInner";
            pnlDashListsInner.Size = new Size(1050, 360);
            pnlDashListsInner.TabIndex = 0;
            // 
            // tblKpiOuter
            // 
            tblKpiOuter.BackColor = Color.FromArgb(241, 245, 249);
            tblKpiOuter.ColumnCount = 1;
            tblKpiOuter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblKpiOuter.Controls.Add(tblKpi, 0, 0);
            tblKpiOuter.Controls.Add(tblBelowKpi, 0, 1);
            tblKpiOuter.Dock = DockStyle.Top;
            tblKpiOuter.Location = new Point(0, 0);
            tblKpiOuter.Margin = new Padding(0);
            tblKpiOuter.MinimumSize = new Size(800, 388);
            tblKpiOuter.Name = "tblKpiOuter";
            tblKpiOuter.RowCount = 2;
            tblKpiOuter.RowStyles.Add(new RowStyle(SizeType.Absolute, 168F));
            tblKpiOuter.RowStyles.Add(new RowStyle(SizeType.Absolute, 220F));
            tblKpiOuter.Size = new Size(1050, 288);
            tblKpiOuter.TabIndex = 2;
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
            tblKpi.Location = new Point(3, 2);
            tblKpi.Margin = new Padding(3, 2, 3, 2);
            tblKpi.Name = "tblKpi";
            tblKpi.Padding = new Padding(18, 9, 18, 9);
            tblKpi.RowCount = 1;
            tblKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblKpi.Size = new Size(1044, 164);
            tblKpi.TabIndex = 1;
            // 
            // cardVacant
            // 
            cardVacant.BackColor = Color.FromArgb(241, 245, 249);
            cardVacant.Dock = DockStyle.Fill;
            cardVacant.KpiCaption = "Phòng trống";
            cardVacant.KpiIconGlyph = "";
            cardVacant.KpiValue = "—";
            cardVacant.Location = new Point(27, 17);
            cardVacant.Margin = new Padding(9, 8, 9, 8);
            cardVacant.MinimumSize = new Size(120, 128);
            cardVacant.Name = "cardVacant";
            cardVacant.Size = new Size(234, 130);
            cardVacant.TabIndex = 0;
            // 
            // cardArrivals
            // 
            cardArrivals.BackColor = Color.FromArgb(241, 245, 249);
            cardArrivals.Dock = DockStyle.Fill;
            cardArrivals.KpiCaption = "Khách đến trong ngày";
            cardArrivals.KpiIconGlyph = "";
            cardArrivals.KpiValue = "—";
            cardArrivals.Location = new Point(279, 17);
            cardArrivals.Margin = new Padding(9, 8, 9, 8);
            cardArrivals.MinimumSize = new Size(120, 128);
            cardArrivals.Name = "cardArrivals";
            cardArrivals.Size = new Size(234, 130);
            cardArrivals.TabIndex = 1;
            // 
            // cardDepartures
            // 
            cardDepartures.BackColor = Color.FromArgb(241, 245, 249);
            cardDepartures.Dock = DockStyle.Fill;
            cardDepartures.KpiCaption = "Khách đi trong ngày";
            cardDepartures.KpiIconGlyph = "";
            cardDepartures.KpiValue = "—";
            cardDepartures.Location = new Point(531, 17);
            cardDepartures.Margin = new Padding(9, 8, 9, 8);
            cardDepartures.MinimumSize = new Size(120, 128);
            cardDepartures.Name = "cardDepartures";
            cardDepartures.Size = new Size(234, 130);
            cardDepartures.TabIndex = 2;
            // 
            // cardRevenue
            // 
            cardRevenue.BackColor = Color.FromArgb(241, 245, 249);
            cardRevenue.Dock = DockStyle.Fill;
            cardRevenue.KpiCaption = "Doanh thu trong ngày";
            cardRevenue.KpiIconGlyph = "";
            cardRevenue.KpiValue = "—";
            cardRevenue.Location = new Point(783, 17);
            cardRevenue.Margin = new Padding(9, 8, 9, 8);
            cardRevenue.MinimumSize = new Size(120, 128);
            cardRevenue.Name = "cardRevenue";
            cardRevenue.Size = new Size(234, 130);
            cardRevenue.TabIndex = 3;
            // 
            // tblBelowKpi
            // 
            tblBelowKpi.BackColor = Color.FromArgb(241, 245, 249);
            tblBelowKpi.ColumnCount = 2;
            tblBelowKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67F));
            tblBelowKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tblBelowKpi.Controls.Add(cardRecentTx, 0, 0);
            tblBelowKpi.Controls.Add(tblRightSidebar, 1, 0);
            tblBelowKpi.Dock = DockStyle.Fill;
            tblBelowKpi.Location = new Point(0, 168);
            tblBelowKpi.Margin = new Padding(0);
            tblBelowKpi.Name = "tblBelowKpi";
            tblBelowKpi.RowCount = 1;
            tblBelowKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblBelowKpi.Size = new Size(1050, 120);
            tblBelowKpi.TabIndex = 3;
            // 
            // cardRecentTx
            // 
            cardRecentTx.BackColor = Color.Transparent;
            cardRecentTx.BorderColor = Color.FromArgb(226, 232, 240);
            cardRecentTx.CardBackColor = Color.White;
            cardRecentTx.Controls.Add(dgvRecentTx);
            cardRecentTx.Controls.Add(tblRecentTxHead);
            cardRecentTx.Dock = DockStyle.Fill;
            cardRecentTx.Location = new Point(18, 6);
            cardRecentTx.Margin = new Padding(18, 6, 8, 8);
            cardRecentTx.Name = "cardRecentTx";
            cardRecentTx.Padding = new Padding(16, 12, 16, 14);
            cardRecentTx.Radius = 12;
            cardRecentTx.Size = new Size(677, 106);
            cardRecentTx.TabIndex = 1;
            // 
            // dgvRecentTx
            // 
            dgvRecentTx.BackgroundColor = Color.White;
            dgvRecentTx.BorderStyle = BorderStyle.None;
            dgvRecentTx.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRecentTx.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRecentTx.Dock = DockStyle.Fill;
            dgvRecentTx.GridColor = Color.FromArgb(241, 245, 249);
            dgvRecentTx.Location = new Point(16, 54);
            dgvRecentTx.Margin = new Padding(3, 4, 3, 4);
            dgvRecentTx.Name = "dgvRecentTx";
            dgvRecentTx.RowHeadersVisible = false;
            dgvRecentTx.RowTemplate.Height = 44;
            dgvRecentTx.Size = new Size(645, 38);
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
            tblRecentTxHead.Location = new Point(16, 12);
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
            picRecentTxHdr.Location = new Point(0, 4);
            picRecentTxHdr.Margin = new Padding(0, 4, 6, 4);
            picRecentTxHdr.Name = "picRecentTxHdr";
            picRecentTxHdr.Size = new Size(32, 34);
            picRecentTxHdr.SizeMode = PictureBoxSizeMode.Zoom;
            picRecentTxHdr.TabIndex = 0;
            picRecentTxHdr.TabStop = false;
            // 
            // lblRecentTxTitle
            // 
            lblRecentTxTitle.Dock = DockStyle.Fill;
            lblRecentTxTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblRecentTxTitle.ForeColor = Color.FromArgb(51, 65, 85);
            lblRecentTxTitle.Location = new Point(38, 0);
            lblRecentTxTitle.Margin = new Padding(0);
            lblRecentTxTitle.Name = "lblRecentTxTitle";
            lblRecentTxTitle.Size = new Size(499, 42);
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
            btnRecentTxViewAll.Location = new Point(537, 6);
            btnRecentTxViewAll.Margin = new Padding(0, 6, 0, 6);
            btnRecentTxViewAll.Name = "btnRecentTxViewAll";
            btnRecentTxViewAll.Size = new Size(108, 30);
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
            tblRightSidebar.Location = new Point(703, 6);
            tblRightSidebar.Margin = new Padding(0, 6, 18, 8);
            tblRightSidebar.Name = "tblRightSidebar";
            tblRightSidebar.RowCount = 2;
            tblRightSidebar.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblRightSidebar.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblRightSidebar.Size = new Size(329, 106);
            tblRightSidebar.TabIndex = 0;
            // 
            // cardQuickActions
            // 
            cardQuickActions.BackColor = Color.Transparent;
            cardQuickActions.BorderColor = Color.FromArgb(226, 232, 240);
            cardQuickActions.CardBackColor = Color.White;
            cardQuickActions.Controls.Add(pnlQuickActionsBody);
            cardQuickActions.Controls.Add(tblQuickHead);
            cardQuickActions.Dock = DockStyle.Fill;
            cardQuickActions.Location = new Point(0, 0);
            cardQuickActions.Margin = new Padding(0, 0, 0, 4);
            cardQuickActions.Name = "cardQuickActions";
            cardQuickActions.Padding = new Padding(16, 12, 16, 14);
            cardQuickActions.Radius = 12;
            cardQuickActions.Size = new Size(329, 49);
            cardQuickActions.TabIndex = 0;
            // 
            // pnlQuickActionsBody
            // 
            pnlQuickActionsBody.BackColor = Color.White;
            pnlQuickActionsBody.Controls.Add(btnAddPayout);
            pnlQuickActionsBody.Dock = DockStyle.Fill;
            pnlQuickActionsBody.Location = new Point(16, 52);
            pnlQuickActionsBody.Name = "pnlQuickActionsBody";
            pnlQuickActionsBody.Padding = new Padding(0, 8, 0, 4);
            pnlQuickActionsBody.Size = new Size(297, 0);
            pnlQuickActionsBody.TabIndex = 1;
            // 
            // btnAddPayout
            // 
            btnAddPayout.Cursor = Cursors.Hand;
            btnAddPayout.Dock = DockStyle.Top;
            btnAddPayout.FlatAppearance.BorderSize = 0;
            btnAddPayout.FlatStyle = FlatStyle.Flat;
            btnAddPayout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddPayout.Location = new Point(0, 8);
            btnAddPayout.Name = "btnAddPayout";
            btnAddPayout.Padding = new Padding(14, 10, 18, 10);
            btnAddPayout.Size = new Size(297, 44);
            btnAddPayout.TabIndex = 0;
            btnAddPayout.Text = "Thêm chi trả";
            btnAddPayout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddPayout.UseVisualStyleBackColor = false;
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
            tblQuickHead.Location = new Point(16, 12);
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
            picQuickHdr.Location = new Point(0, 2);
            picQuickHdr.Margin = new Padding(0, 2, 6, 2);
            picQuickHdr.Name = "picQuickHdr";
            picQuickHdr.Size = new Size(32, 36);
            picQuickHdr.SizeMode = PictureBoxSizeMode.Zoom;
            picQuickHdr.TabIndex = 0;
            picQuickHdr.TabStop = false;
            // 
            // lblQuickActionsTitle
            // 
            lblQuickActionsTitle.Dock = DockStyle.Fill;
            lblQuickActionsTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblQuickActionsTitle.ForeColor = Color.FromArgb(51, 65, 85);
            lblQuickActionsTitle.Location = new Point(38, 0);
            lblQuickActionsTitle.Margin = new Padding(0);
            lblQuickActionsTitle.Name = "lblQuickActionsTitle";
            lblQuickActionsTitle.Size = new Size(259, 40);
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
            cardMyTasks.Location = new Point(0, 57);
            cardMyTasks.Margin = new Padding(0, 4, 0, 0);
            cardMyTasks.Name = "cardMyTasks";
            cardMyTasks.Padding = new Padding(16, 12, 16, 14);
            cardMyTasks.Radius = 12;
            cardMyTasks.Size = new Size(329, 49);
            cardMyTasks.TabIndex = 1;
            // 
            // pnlMyTasksBody
            // 
            pnlMyTasksBody.BackColor = Color.White;
            pnlMyTasksBody.Controls.Add(dgvStaffPayouts);
            pnlMyTasksBody.Dock = DockStyle.Fill;
            pnlMyTasksBody.Location = new Point(16, 54);
            pnlMyTasksBody.Name = "pnlMyTasksBody";
            pnlMyTasksBody.Size = new Size(297, 0);
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
            dgvStaffPayouts.Location = new Point(0, 0);
            dgvStaffPayouts.Margin = new Padding(3, 4, 3, 4);
            dgvStaffPayouts.Name = "dgvStaffPayouts";
            dgvStaffPayouts.RowHeadersVisible = false;
            dgvStaffPayouts.RowTemplate.Height = 44;
            dgvStaffPayouts.Size = new Size(297, 0);
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
            tblMyTasksHead.Location = new Point(16, 12);
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
            picMyTasksHdr.Location = new Point(0, 4);
            picMyTasksHdr.Margin = new Padding(0, 4, 6, 4);
            picMyTasksHdr.Name = "picMyTasksHdr";
            picMyTasksHdr.Size = new Size(32, 34);
            picMyTasksHdr.SizeMode = PictureBoxSizeMode.Zoom;
            picMyTasksHdr.TabIndex = 0;
            picMyTasksHdr.TabStop = false;
            // 
            // lblMyTasksTitle
            // 
            lblMyTasksTitle.Dock = DockStyle.Fill;
            lblMyTasksTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblMyTasksTitle.ForeColor = Color.FromArgb(51, 65, 85);
            lblMyTasksTitle.Location = new Point(38, 0);
            lblMyTasksTitle.Margin = new Padding(0);
            lblMyTasksTitle.Name = "lblMyTasksTitle";
            lblMyTasksTitle.Size = new Size(151, 42);
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
            btnMyTasksViewAll.Location = new Point(189, 6);
            btnMyTasksViewAll.Margin = new Padding(0, 6, 0, 6);
            btnMyTasksViewAll.Name = "btnMyTasksViewAll";
            btnMyTasksViewAll.Size = new Size(108, 30);
            btnMyTasksViewAll.TabIndex = 2;
            btnMyTasksViewAll.Text = "Xem tất cả";
            btnMyTasksViewAll.UseVisualStyleBackColor = false;
            // 
            // splitPendingAndReminders
            // 
            splitPendingAndReminders.BackColor = Color.FromArgb(241, 245, 249);
            splitPendingAndReminders.Dock = DockStyle.Fill;
            splitPendingAndReminders.Location = new Point(0, 0);
            splitPendingAndReminders.Margin = new Padding(3, 2, 3, 2);
            splitPendingAndReminders.Name = "splitPendingAndReminders";
            // 
            // splitPendingAndReminders.Panel1
            // 
            splitPendingAndReminders.Panel1.Controls.Add(cardPending);
            splitPendingAndReminders.Panel1.Padding = new Padding(14, 6, 7, 12);
            splitPendingAndReminders.Panel1MinSize = 240;
            // 
            // splitPendingAndReminders.Panel2
            // 
            splitPendingAndReminders.Panel2.Controls.Add(cardReminders);
            splitPendingAndReminders.Panel2.Padding = new Padding(7, 6, 14, 12);
            splitPendingAndReminders.Panel2MinSize = 240;
            splitPendingAndReminders.Size = new Size(1050, 360);
            splitPendingAndReminders.SplitterDistance = 517;
            splitPendingAndReminders.TabIndex = 0;
            pnlDashListsInner.Controls.Add(splitPendingAndReminders);
            // 
            // cardPending
            // 
            cardPending.BackColor = Color.Transparent;
            cardPending.BorderColor = Color.FromArgb(226, 232, 240);
            cardPending.CardBackColor = Color.White;
            cardPending.Controls.Add(dgvPending);
            cardPending.Controls.Add(tblPendingHead);
            cardPending.Dock = DockStyle.Fill;
            cardPending.Location = new Point(14, 6);
            cardPending.Margin = new Padding(0);
            cardPending.Name = "cardPending";
            cardPending.Padding = new Padding(16, 12, 16, 14);
            cardPending.Radius = 12;
            cardPending.Size = new Size(496, 105);
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
            dgvPending.Location = new Point(16, 54);
            dgvPending.Margin = new Padding(3, 4, 3, 4);
            dgvPending.Name = "dgvPending";
            dgvPending.RowHeadersVisible = false;
            dgvPending.RowTemplate.Height = 44;
            dgvPending.Size = new Size(464, 37);
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
            tblPendingHead.Location = new Point(16, 12);
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
            picPendingHdr.Location = new Point(0, 4);
            picPendingHdr.Margin = new Padding(0, 4, 6, 4);
            picPendingHdr.Name = "picPendingHdr";
            picPendingHdr.Size = new Size(32, 34);
            picPendingHdr.SizeMode = PictureBoxSizeMode.Zoom;
            picPendingHdr.TabIndex = 0;
            picPendingHdr.TabStop = false;
            // 
            // lblPendingTitle
            // 
            lblPendingTitle.Dock = DockStyle.Fill;
            lblPendingTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPendingTitle.ForeColor = Color.FromArgb(51, 65, 85);
            lblPendingTitle.Location = new Point(38, 0);
            lblPendingTitle.Margin = new Padding(0);
            lblPendingTitle.Name = "lblPendingTitle";
            lblPendingTitle.Size = new Size(318, 42);
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
            btnPendingViewAll.Location = new Point(356, 6);
            btnPendingViewAll.Margin = new Padding(0, 6, 0, 6);
            btnPendingViewAll.Name = "btnPendingViewAll";
            btnPendingViewAll.Size = new Size(108, 30);
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
            cardReminders.Location = new Point(7, 6);
            cardReminders.Margin = new Padding(0);
            cardReminders.Name = "cardReminders";
            cardReminders.Padding = new Padding(16, 12, 16, 14);
            cardReminders.Radius = 12;
            cardReminders.Size = new Size(508, 105);
            cardReminders.TabIndex = 0;
            // 
            // dgvReminders
            // 
            dgvReminders.BackgroundColor = Color.White;
            dgvReminders.BorderStyle = BorderStyle.None;
            dgvReminders.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReminders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvReminders.Dock = DockStyle.Fill;
            dgvReminders.GridColor = Color.FromArgb(241, 245, 249);
            dgvReminders.Location = new Point(16, 54);
            dgvReminders.Margin = new Padding(3, 4, 3, 4);
            dgvReminders.Name = "dgvReminders";
            dgvReminders.RowHeadersVisible = false;
            dgvReminders.RowTemplate.Height = 44;
            dgvReminders.Size = new Size(476, 37);
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
            tblRemindersHead.Location = new Point(16, 12);
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
            picRemindersHdr.Location = new Point(0, 4);
            picRemindersHdr.Margin = new Padding(0, 4, 6, 4);
            picRemindersHdr.Name = "picRemindersHdr";
            picRemindersHdr.Size = new Size(32, 34);
            picRemindersHdr.SizeMode = PictureBoxSizeMode.Zoom;
            picRemindersHdr.TabIndex = 0;
            picRemindersHdr.TabStop = false;
            // 
            // lblRemindersTitle
            // 
            lblRemindersTitle.Dock = DockStyle.Fill;
            lblRemindersTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblRemindersTitle.ForeColor = Color.FromArgb(51, 65, 85);
            lblRemindersTitle.Location = new Point(38, 0);
            lblRemindersTitle.Margin = new Padding(0);
            lblRemindersTitle.Name = "lblRemindersTitle";
            lblRemindersTitle.Size = new Size(330, 42);
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
            btnRemindersViewAll.Location = new Point(368, 6);
            btnRemindersViewAll.Margin = new Padding(0, 6, 0, 6);
            btnRemindersViewAll.Name = "btnRemindersViewAll";
            btnRemindersViewAll.Size = new Size(108, 30);
            btnRemindersViewAll.TabIndex = 2;
            btnRemindersViewAll.Text = "Xem tất cả";
            btnRemindersViewAll.UseVisualStyleBackColor = false;
            // 
            // usMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            Controls.Add(splitKpiAndLists);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 2, 3, 2);
            Name = "usMainForm";
            Size = new Size(1050, 462);
            Load += usMainForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            splitKpiAndLists.Panel1.ResumeLayout(false);
            splitKpiAndLists.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitKpiAndLists).EndInit();
            splitKpiAndLists.ResumeLayout(false);
            scrollDashKpi.ResumeLayout(false);
            tblKpiOuter.ResumeLayout(false);
            tblKpi.ResumeLayout(false);
            tblBelowKpi.ResumeLayout(false);
            cardRecentTx.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecentTx).EndInit();
            tblRecentTxHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picRecentTxHdr).EndInit();
            tblRightSidebar.ResumeLayout(false);
            cardQuickActions.ResumeLayout(false);
            pnlQuickActionsBody.ResumeLayout(false);
            tblQuickHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picQuickHdr).EndInit();
            cardMyTasks.ResumeLayout(false);
            pnlMyTasksBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStaffPayouts).EndInit();
            tblMyTasksHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picMyTasksHdr).EndInit();
            splitPendingAndReminders.Panel1.ResumeLayout(false);
            splitPendingAndReminders.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitPendingAndReminders).EndInit();
            splitPendingAndReminders.ResumeLayout(false);
            pnlDashListsInner.ResumeLayout(false);
            scrollDashLists.ResumeLayout(false);
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
        private SplitContainer splitKpiAndLists;
        private Panel scrollDashKpi;
        private Panel scrollDashLists;
        private Panel pnlDashListsInner;
        private TableLayoutPanel tblKpi;
        private TableLayoutPanel tblKpiOuter;
        private TableLayoutPanel tblBelowKpi;
        private TableLayoutPanel tblRightSidebar;
        private RoundedCardPanel cardRecentTx;
        private DataGridView dgvRecentTx;
        private TableLayoutPanel tblRecentTxHead;
        private PictureBox picRecentTxHdr;
        private Label lblRecentTxTitle;
        private Button btnRecentTxViewAll;
        private RoundedCardPanel cardQuickActions;
        private TableLayoutPanel tblQuickHead;
        private PictureBox picQuickHdr;
        private Label lblQuickActionsTitle;
        private Panel pnlQuickActionsBody;
        private Button btnAddPayout;
        private RoundedCardPanel cardMyTasks;
        private TableLayoutPanel tblMyTasksHead;
        private PictureBox picMyTasksHdr;
        private Label lblMyTasksTitle;
        private Button btnMyTasksViewAll;
        private Panel pnlMyTasksBody;
        private DataGridView dgvStaffPayouts;
        private UsKpiTile cardVacant;
        private UsKpiTile cardArrivals;
        private UsKpiTile cardDepartures;
        private UsKpiTile cardRevenue;
        private SplitContainer splitPendingAndReminders;
        private RoundedCardPanel cardPending;
        private TableLayoutPanel tblPendingHead;
        private Label lblPendingTitle;
        private Button btnPendingViewAll;
        private DataGridView dgvPending;
        private RoundedCardPanel cardReminders;
        private TableLayoutPanel tblRemindersHead;
        private PictureBox picRemindersHdr;
        private Label lblRemindersTitle;
        private Button btnRemindersViewAll;
        private DataGridView dgvReminders;
        private PictureBox picPendingHdr;
    }
}
