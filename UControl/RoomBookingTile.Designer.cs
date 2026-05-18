namespace HotelManagement.CustomControls
{
    partial class RoomBookingTile
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
            tblRoot = new TableLayoutPanel();
            lblNum = new Label();
            pnlAction = new Panel();
            btnPrimary = new Button();
            tblGuest = new TableLayoutPanel();
            btnCheckout = new Button();
            btnView = new Button();
            btnEdit = new Button();
            pnlCleaning = new Panel();
            tblCleaning = new TableLayoutPanel();
            lblCleaningHead = new Label();
            btnCleaningDone = new Button();
            tblRoot.SuspendLayout();
            pnlAction.SuspendLayout();
            tblGuest.SuspendLayout();
            pnlCleaning.SuspendLayout();
            tblCleaning.SuspendLayout();
            SuspendLayout();
            // 
            // tblRoot
            // 
            tblRoot.ColumnCount = 1;
            tblRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblRoot.Controls.Add(lblNum, 0, 0);
            tblRoot.Controls.Add(pnlAction, 0, 1);
            tblRoot.Dock = DockStyle.Fill;
            tblRoot.Location = new Point(8, 8);
            tblRoot.Margin = new Padding(0);
            tblRoot.Name = "tblRoot";
            tblRoot.RowCount = 2;
            tblRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tblRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblRoot.Size = new Size(76, 102);
            tblRoot.TabIndex = 0;
            // 
            // lblNum
            // 
            lblNum.BackColor = Color.Transparent;
            lblNum.Dock = DockStyle.Fill;
            lblNum.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNum.Location = new Point(0, 0);
            lblNum.Margin = new Padding(0, 0, 0, 4);
            lblNum.Name = "lblNum";
            lblNum.Size = new Size(76, 22);
            lblNum.TabIndex = 0;
            lblNum.Text = "101";
            lblNum.TextAlign = ContentAlignment.TopCenter;
            // 
            // pnlAction
            // 
            pnlAction.Controls.Add(btnPrimary);
            pnlAction.Controls.Add(tblGuest);
            pnlAction.Controls.Add(pnlCleaning);
            pnlAction.Dock = DockStyle.Fill;
            pnlAction.Location = new Point(0, 26);
            pnlAction.Margin = new Padding(0, 2, 0, 0);
            pnlAction.Name = "pnlAction";
            pnlAction.Size = new Size(76, 76);
            pnlAction.TabIndex = 1;
            // 
            // btnPrimary
            // 
            btnPrimary.Cursor = Cursors.Hand;
            btnPrimary.Dock = DockStyle.Fill;
            btnPrimary.FlatAppearance.BorderColor = Color.FromArgb(220, 230, 220);
            btnPrimary.FlatAppearance.BorderSize = 1;
            btnPrimary.FlatStyle = FlatStyle.Flat;
            btnPrimary.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnPrimary.Location = new Point(0, 0);
            btnPrimary.Margin = new Padding(0);
            btnPrimary.Name = "btnPrimary";
            btnPrimary.Size = new Size(76, 76);
            btnPrimary.TabIndex = 0;
            btnPrimary.Text = "Đặt phòng";
            btnPrimary.UseVisualStyleBackColor = false;
            btnPrimary.BackColor = Color.White;
            btnPrimary.ForeColor = Color.FromArgb(15, 23, 42);
            // 
            // tblGuest
            // 
            tblGuest.ColumnCount = 1;
            tblGuest.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblGuest.Controls.Add(btnCheckout, 0, 0);
            tblGuest.Controls.Add(btnView, 0, 1);
            tblGuest.Controls.Add(btnEdit, 0, 2);
            tblGuest.Dock = DockStyle.Fill;
            tblGuest.Location = new Point(0, 0);
            tblGuest.Margin = new Padding(0);
            tblGuest.Name = "tblGuest";
            tblGuest.RowCount = 3;
            tblGuest.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tblGuest.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tblGuest.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tblGuest.Size = new Size(76, 76);
            tblGuest.TabIndex = 1;
            tblGuest.Visible = false;
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.FromArgb(254, 242, 242);
            btnCheckout.Cursor = Cursors.Hand;
            btnCheckout.Dock = DockStyle.Fill;
            btnCheckout.FlatAppearance.BorderColor = Color.FromArgb(252, 200, 200);
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.FromArgb(127, 29, 29);
            btnCheckout.Location = new Point(0, 0);
            btnCheckout.Margin = new Padding(0, 0, 0, 4);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(76, 21);
            btnCheckout.TabIndex = 0;
            btnCheckout.Text = "Trả";
            btnCheckout.UseVisualStyleBackColor = false;
            // 
            // btnView
            // 
            btnView.BackColor = Color.FromArgb(254, 242, 242);
            btnView.Cursor = Cursors.Hand;
            btnView.Dock = DockStyle.Fill;
            btnView.FlatAppearance.BorderColor = Color.FromArgb(252, 200, 200);
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnView.ForeColor = Color.FromArgb(127, 29, 29);
            btnView.Location = new Point(0, 21);
            btnView.Margin = new Padding(0, 0, 0, 4);
            btnView.Name = "btnView";
            btnView.Size = new Size(76, 21);
            btnView.TabIndex = 1;
            btnView.Text = "Xem";
            btnView.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(254, 242, 242);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Dock = DockStyle.Fill;
            btnEdit.FlatAppearance.BorderColor = Color.FromArgb(252, 200, 200);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEdit.ForeColor = Color.FromArgb(127, 29, 29);
            btnEdit.Location = new Point(0, 42);
            btnEdit.Margin = new Padding(0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(76, 34);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // pnlCleaning
            // 
            pnlCleaning.Controls.Add(tblCleaning);
            pnlCleaning.Dock = DockStyle.Fill;
            pnlCleaning.Location = new Point(0, 0);
            pnlCleaning.Margin = new Padding(0);
            pnlCleaning.Name = "pnlCleaning";
            pnlCleaning.Size = new Size(76, 76);
            pnlCleaning.TabIndex = 2;
            pnlCleaning.Visible = false;
            // 
            // tblCleaning
            // 
            tblCleaning.ColumnCount = 1;
            tblCleaning.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblCleaning.Controls.Add(lblCleaningHead, 0, 0);
            tblCleaning.Controls.Add(btnCleaningDone, 0, 1);
            tblCleaning.Dock = DockStyle.Fill;
            tblCleaning.Location = new Point(0, 0);
            tblCleaning.Margin = new Padding(0);
            tblCleaning.Name = "tblCleaning";
            tblCleaning.RowCount = 2;
            tblCleaning.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tblCleaning.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCleaning.Size = new Size(76, 76);
            tblCleaning.TabIndex = 0;
            // 
            // lblCleaningHead
            // 
            lblCleaningHead.Dock = DockStyle.Fill;
            lblCleaningHead.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCleaningHead.ForeColor = Color.FromArgb(120, 90, 0);
            lblCleaningHead.Location = new Point(0, 0);
            lblCleaningHead.Margin = new Padding(0);
            lblCleaningHead.Name = "lblCleaningHead";
            lblCleaningHead.Size = new Size(76, 24);
            lblCleaningHead.TabIndex = 0;
            lblCleaningHead.Text = "Đang dọn";
            lblCleaningHead.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCleaningDone
            // 
            btnCleaningDone.BackColor = Color.FromArgb(255, 237, 150);
            btnCleaningDone.Cursor = Cursors.Hand;
            btnCleaningDone.Dock = DockStyle.Fill;
            btnCleaningDone.FlatAppearance.BorderColor = Color.FromArgb(180, 150, 30);
            btnCleaningDone.FlatStyle = FlatStyle.Flat;
            btnCleaningDone.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCleaningDone.ForeColor = Color.FromArgb(30, 41, 59);
            btnCleaningDone.Location = new Point(0, 24);
            btnCleaningDone.Margin = new Padding(0, 4, 0, 0);
            btnCleaningDone.Name = "btnCleaningDone";
            btnCleaningDone.Size = new Size(76, 52);
            btnCleaningDone.TabIndex = 1;
            btnCleaningDone.Text = "Đã dọn xong";
            btnCleaningDone.UseVisualStyleBackColor = false;
            // 
            // RoomBookingTile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 163, 74);
            Dock = DockStyle.Fill;
            Margin = new Padding(5, 5, 5, 10);
            MinimumSize = new Size(100, 132);
            Name = "RoomBookingTile";
            Padding = new Padding(10, 10, 10, 8);
            Size = new Size(110, 148);
            Controls.Add(tblRoot);
            tblRoot.ResumeLayout(false);
            pnlAction.ResumeLayout(false);
            tblGuest.ResumeLayout(false);
            pnlCleaning.ResumeLayout(false);
            tblCleaning.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblRoot;
        private Label lblNum;
        private Panel pnlAction;
        private Button btnPrimary;
        private TableLayoutPanel tblGuest;
        private Button btnCheckout;
        private Button btnView;
        private Button btnEdit;
        private Panel pnlCleaning;
        private TableLayoutPanel tblCleaning;
        private Label lblCleaningHead;
        private Button btnCleaningDone;
    }
}
