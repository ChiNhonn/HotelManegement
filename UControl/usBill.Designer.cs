namespace HotelManagement.CustomControls
{
    partial class usBill
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
            pnlRoot = new Panel();
            dgvBill = new DataGridView();
            pnlToolbar = new Panel();
            btnSelectAll = new Button();
            flpActions = new FlowLayoutPanel();
            btnMergeBills = new Button();
            btnExportExcel = new Button();
            btnExportPDF = new Button();
            btnPrint = new Button();
            btnRefresh = new Button();
            lblToDate = new Label();
            dtpToDate = new DateTimePicker();
            lblFromDate = new Label();
            dtpFromDate = new DateTimePicker();
            cmbFilterStatus = new ComboBox();
            lblStatus = new Label();
            txtSearch = new TextBox();
            lblTitle = new Label();
            pnlRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBill).BeginInit();
            pnlToolbar.SuspendLayout();
            flpActions.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRoot
            // 
            pnlRoot.BackColor = Color.FromArgb(241, 245, 249);
            pnlRoot.Controls.Add(dgvBill);
            pnlRoot.Controls.Add(pnlToolbar);
            pnlRoot.Dock = DockStyle.Fill;
            pnlRoot.Location = new Point(0, 0);
            pnlRoot.Name = "pnlRoot";
            pnlRoot.Padding = new Padding(10);
            pnlRoot.Size = new Size(1515, 552);
            pnlRoot.TabIndex = 0;
            // 
            // dgvBill
            // 
            dgvBill.AllowUserToAddRows = false;
            dgvBill.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBill.BackgroundColor = Color.White;
            dgvBill.BorderStyle = BorderStyle.None;
            dgvBill.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBill.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvBill.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.LightCyan;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvBill.DefaultCellStyle = dataGridViewCellStyle3;
            dgvBill.Dock = DockStyle.Fill;
            dgvBill.EnableHeadersVisualStyles = false;
            dgvBill.GridColor = Color.Gainsboro;
            dgvBill.Location = new Point(10, 169);
            dgvBill.Name = "dgvBill";
            dgvBill.ReadOnly = true;
            dgvBill.RowHeadersVisible = false;
            dgvBill.RowHeadersWidth = 51;
            dgvBill.RowTemplate.Height = 40;
            dgvBill.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBill.Size = new Size(1495, 373);
            dgvBill.TabIndex = 1;
            dgvBill.CellDoubleClick += dgvBill_CellDoubleClick;
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.White;
            pnlToolbar.Controls.Add(btnSelectAll);
            pnlToolbar.Controls.Add(flpActions);
            pnlToolbar.Controls.Add(btnRefresh);
            pnlToolbar.Controls.Add(lblToDate);
            pnlToolbar.Controls.Add(dtpToDate);
            pnlToolbar.Controls.Add(lblFromDate);
            pnlToolbar.Controls.Add(dtpFromDate);
            pnlToolbar.Controls.Add(cmbFilterStatus);
            pnlToolbar.Controls.Add(lblStatus);
            pnlToolbar.Controls.Add(txtSearch);
            pnlToolbar.Controls.Add(lblTitle);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(10, 10);
            pnlToolbar.Margin = new Padding(3, 3, 3, 10);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(1495, 159);
            pnlToolbar.TabIndex = 0;
            // 
            // btnSelectAll
            // 
            btnSelectAll.BackColor = Color.FromArgb(0, 192, 192);
            btnSelectAll.FlatStyle = FlatStyle.Flat;
            btnSelectAll.ForeColor = Color.White;
            btnSelectAll.Location = new Point(20, 113);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(94, 40);
            btnSelectAll.TabIndex = 10;
            btnSelectAll.Text = "Chọn tất cả";
            btnSelectAll.UseVisualStyleBackColor = false;
            btnSelectAll.Click += btnSelectAll_Click;
            // 
            // flpActions
            // 
            flpActions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flpActions.Controls.Add(btnMergeBills);
            flpActions.Controls.Add(btnExportExcel);
            flpActions.Controls.Add(btnExportPDF);
            flpActions.Controls.Add(btnPrint);
            flpActions.FlowDirection = FlowDirection.RightToLeft;
            flpActions.Location = new Point(1059, 50);
            flpActions.Name = "flpActions";
            flpActions.Size = new Size(433, 40);
            flpActions.TabIndex = 9;
            // 
            // btnMergeBills
            // 
            btnMergeBills.BackColor = Color.DarkOrange;
            btnMergeBills.FlatStyle = FlatStyle.Flat;
            btnMergeBills.ForeColor = Color.White;
            btnMergeBills.Location = new Point(330, 3);
            btnMergeBills.Name = "btnMergeBills";
            btnMergeBills.Size = new Size(100, 32);
            btnMergeBills.TabIndex = 0;
            btnMergeBills.Text = "Ghép Bill";
            btnMergeBills.UseVisualStyleBackColor = false;
            btnMergeBills.Click += btnMergeBills_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.BackColor = Color.FromArgb(21, 128, 61);
            btnExportExcel.FlatStyle = FlatStyle.Flat;
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(224, 3);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(100, 32);
            btnExportExcel.TabIndex = 1;
            btnExportExcel.Text = "Xuất Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // btnExportPDF
            // 
            btnExportPDF.BackColor = Color.Crimson;
            btnExportPDF.FlatStyle = FlatStyle.Flat;
            btnExportPDF.ForeColor = Color.White;
            btnExportPDF.Location = new Point(118, 3);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(100, 32);
            btnExportPDF.TabIndex = 2;
            btnExportPDF.Text = "Xuất PDF";
            btnExportPDF.UseVisualStyleBackColor = false;
            btnExportPDF.Click += btnExportPDF_Click;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.RoyalBlue;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(12, 3);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(100, 32);
            btnPrint.TabIndex = 3;
            btnPrint.Text = "In Hóa Đơn";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.LightGray;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(950, 58);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 32);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblToDate
            // 
            lblToDate.AutoSize = true;
            lblToDate.Location = new Point(735, 63);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(75, 20);
            lblToDate.TabIndex = 6;
            lblToDate.Text = "Đến ngày:";
            // 
            // dtpToDate
            // 
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(815, 60);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(120, 27);
            dtpToDate.TabIndex = 7;
            // 
            // lblFromDate
            // 
            lblFromDate.AutoSize = true;
            lblFromDate.Location = new Point(530, 63);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(65, 20);
            lblFromDate.TabIndex = 4;
            lblFromDate.Text = "Từ ngày:";
            // 
            // dtpFromDate
            // 
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(600, 60);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(120, 27);
            dtpFromDate.TabIndex = 5;
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.FormattingEnabled = true;
            cmbFilterStatus.Items.AddRange(new object[] { "Tất cả", "Chưa thanh toán", "Đã thanh toán", "Đã hủy" });
            cmbFilterStatus.Location = new Point(365, 60);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(150, 28);
            cmbFilterStatus.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(285, 63);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(78, 20);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Trạng thái:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(20, 60);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm mã HĐ, tên KH, phòng...";
            txtSearch.Size = new Size(250, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(15, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(175, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý Hóa Đơn";
            // 
            // usBill
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlRoot);
            Font = new Font("Segoe UI", 9F);
            Name = "usBill";
            Size = new Size(1515, 552);
            pnlRoot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBill).EndInit();
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            flpActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRoot;
        private Panel pnlToolbar;
        private DataGridView dgvBill;
        private Label lblTitle;
        private TextBox txtSearch;
        private Label lblStatus;
        private ComboBox cmbFilterStatus;
        private Label lblFromDate;
        private DateTimePicker dtpFromDate;
        private Label lblToDate;
        private DateTimePicker dtpToDate;
        private Button btnRefresh;
        private FlowLayoutPanel flpActions;
        private Button btnMergeBills;
        private Button btnExportExcel;
        private Button btnExportPDF;
        private Button btnPrint;
        private Button btnSelectAll;
    }
}