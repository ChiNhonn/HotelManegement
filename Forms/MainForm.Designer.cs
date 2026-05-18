namespace HotelManagement.Forms
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlContainerMainForm = new Panel();
            panelContainer = new Panel();
            pnlChoice = new SidebarGradientPanel();
            btnSignOut = new Button();
            btnRolesStaff = new Button();
            btnCustomers = new Button();
            btnBill = new Button();
            btnFinance = new Button();
            btnServices = new Button();
            btnBookings = new Button();
            btnRooms = new Button();
            btnDashboard = new Button();
            pnlSidebarHeader = new Panel();
            pnlSidebarLine = new Panel();
            lblSidebarSubtitle = new Label();
            lblSidebarTitle = new Label();
            lblSidebarIcon = new Label();
            pnlContainerMainForm.SuspendLayout();
            pnlChoice.SuspendLayout();
            pnlSidebarHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainerMainForm
            // 
            pnlContainerMainForm.Controls.Add(panelContainer);
            pnlContainerMainForm.Controls.Add(pnlChoice);
            pnlContainerMainForm.Dock = DockStyle.Fill;
            pnlContainerMainForm.Location = new Point(0, 0);
            pnlContainerMainForm.Name = "pnlContainerMainForm";
            pnlContainerMainForm.Size = new Size(1422, 851);
            pnlContainerMainForm.TabIndex = 2;
            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.WhiteSmoke;
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(309, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1113, 851);
            panelContainer.TabIndex = 1;
            // 
            // pnlChoice
            // 
            pnlChoice.BackColor = Color.FromArgb(0, 114, 255);
            pnlChoice.Controls.Add(btnSignOut);
            pnlChoice.Controls.Add(btnRolesStaff);
            pnlChoice.Controls.Add(btnCustomers);
            pnlChoice.Controls.Add(btnBill);
            pnlChoice.Controls.Add(btnFinance);
            pnlChoice.Controls.Add(btnServices);
            pnlChoice.Controls.Add(btnBookings);
            pnlChoice.Controls.Add(btnRooms);
            pnlChoice.Controls.Add(btnDashboard);
            pnlChoice.Controls.Add(pnlSidebarHeader);
            pnlChoice.Dock = DockStyle.Left;
            pnlChoice.Location = new Point(0, 0);
            pnlChoice.Name = "pnlChoice";
            pnlChoice.Size = new Size(309, 851);
            pnlChoice.TabIndex = 2;
            // 
            // btnSignOut
            // 
            btnSignOut.FlatStyle = FlatStyle.Flat;
            btnSignOut.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnSignOut.Location = new Point(10, 780);
            btnSignOut.Name = "btnSignOut";
            btnSignOut.Size = new Size(288, 56);
            btnSignOut.TabIndex = 7;
            btnSignOut.Text = "Đăng xuất";
            btnSignOut.UseVisualStyleBackColor = false;
            btnSignOut.Click += btnSignOut_Click;
            // 
            // btnRolesStaff
            // 
            btnRolesStaff.FlatStyle = FlatStyle.Flat;
            btnRolesStaff.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnRolesStaff.Location = new Point(10, 545);
            btnRolesStaff.Name = "btnRolesStaff";
            btnRolesStaff.Size = new Size(288, 59);
            btnRolesStaff.TabIndex = 6;
            btnRolesStaff.Text = "Quản lý phân quyền && nhân sự";
            btnRolesStaff.UseVisualStyleBackColor = false;
            btnRolesStaff.Click += btnRolesStaff_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.FlatStyle = FlatStyle.Flat;
            btnCustomers.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnCustomers.Location = new Point(10, 483);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(288, 56);
            btnCustomers.TabIndex = 5;
            btnCustomers.Text = "Quản lý khách hàng";
            btnCustomers.UseVisualStyleBackColor = false;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // btnBill
            // 
            btnBill.FlatStyle = FlatStyle.Flat;
            btnBill.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnBill.Location = new Point(10, 418);
            btnBill.Name = "btnBill";
            btnBill.Size = new Size(288, 59);
            btnBill.TabIndex = 9;
            btnBill.Text = "Quản lý hóa đơn";
            btnBill.UseVisualStyleBackColor = false;
            btnBill.Click += btnBill_Click;
            // 
            // btnFinance
            // 
            btnFinance.FlatStyle = FlatStyle.Flat;
            btnFinance.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnFinance.Location = new Point(10, 353);
            btnFinance.Name = "btnFinance";
            btnFinance.Size = new Size(288, 59);
            btnFinance.TabIndex = 4;
            btnFinance.Text = "Quản lý tài chính && thanh toán";
            btnFinance.UseVisualStyleBackColor = false;
            btnFinance.Click += btnFinance_Click;
            // 
            // btnServices
            // 
            btnServices.FlatStyle = FlatStyle.Flat;
            btnServices.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnServices.Location = new Point(10, 288);
            btnServices.Name = "btnServices";
            btnServices.Size = new Size(288, 59);
            btnServices.TabIndex = 3;
            btnServices.Text = "Quản lý dịch vụ && tiện ích";
            btnServices.UseVisualStyleBackColor = false;
            btnServices.Click += btnServices_Click;
            // 
            // btnBookings
            // 
            btnBookings.FlatStyle = FlatStyle.Flat;
            btnBookings.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnBookings.Location = new Point(10, 226);
            btnBookings.Name = "btnBookings";
            btnBookings.Size = new Size(288, 56);
            btnBookings.TabIndex = 2;
            btnBookings.Text = "Quản lý đặt phòng";
            btnBookings.UseVisualStyleBackColor = false;
            btnBookings.Click += btnBookings_Click;
            // 
            // btnRooms
            // 
            btnRooms.FlatStyle = FlatStyle.Flat;
            btnRooms.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnRooms.Location = new Point(10, 164);
            btnRooms.Name = "btnRooms";
            btnRooms.Size = new Size(288, 56);
            btnRooms.TabIndex = 1;
            btnRooms.Text = "Quản lý phòng";
            btnRooms.UseVisualStyleBackColor = false;
            btnRooms.Click += btnRooms_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnDashboard.Location = new Point(10, 102);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(288, 56);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Trang chủ";
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // pnlSidebarHeader
            // 
            pnlSidebarHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSidebarHeader.BackColor = Color.FromArgb(55, 125, 230);
            pnlSidebarHeader.Controls.Add(pnlSidebarLine);
            pnlSidebarHeader.Controls.Add(lblSidebarSubtitle);
            pnlSidebarHeader.Controls.Add(lblSidebarTitle);
            pnlSidebarHeader.Controls.Add(lblSidebarIcon);
            pnlSidebarHeader.Location = new Point(0, 0);
            pnlSidebarHeader.Name = "pnlSidebarHeader";
            pnlSidebarHeader.Size = new Size(309, 96);
            pnlSidebarHeader.TabIndex = 8;
            // 
            // pnlSidebarLine
            // 
            pnlSidebarLine.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlSidebarLine.BackColor = Color.FromArgb(60, 255, 255, 255);
            pnlSidebarLine.Location = new Point(14, 91);
            pnlSidebarLine.Name = "pnlSidebarLine";
            pnlSidebarLine.Size = new Size(280, 1);
            pnlSidebarLine.TabIndex = 3;
            // 
            // lblSidebarSubtitle
            // 
            lblSidebarSubtitle.AutoSize = true;
            lblSidebarSubtitle.Font = new Font("Segoe UI", 9.2F);
            lblSidebarSubtitle.ForeColor = Color.FromArgb(210, 255, 255, 255);
            lblSidebarSubtitle.Location = new Point(53, 45);
            lblSidebarSubtitle.Name = "lblSidebarSubtitle";
            lblSidebarSubtitle.Size = new Size(137, 21);
            lblSidebarSubtitle.TabIndex = 2;
            lblSidebarSubtitle.Text = "Quản lý khách sạn";
            // 
            // lblSidebarTitle
            // 
            lblSidebarTitle.AutoSize = true;
            lblSidebarTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblSidebarTitle.ForeColor = Color.White;
            lblSidebarTitle.Location = new Point(53, 16);
            lblSidebarTitle.Name = "lblSidebarTitle";
            lblSidebarTitle.Size = new Size(93, 30);
            lblSidebarTitle.TabIndex = 1;
            lblSidebarTitle.Text = "The Sea";
            // 
            // lblSidebarIcon
            // 
            lblSidebarIcon.AutoSize = true;
            lblSidebarIcon.Font = new Font("Segoe MDL2 Assets", 22F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSidebarIcon.ForeColor = Color.White;
            lblSidebarIcon.Location = new Point(16, 21);
            lblSidebarIcon.Name = "lblSidebarIcon";
            lblSidebarIcon.Size = new Size(33, 23);
            lblSidebarIcon.TabIndex = 0;
            lblSidebarIcon.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1422, 851);
            Controls.Add(pnlContainerMainForm);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "The Sea — Quản lý khách sạn";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            pnlContainerMainForm.ResumeLayout(false);
            pnlChoice.ResumeLayout(false);
            pnlSidebarHeader.ResumeLayout(false);
            pnlSidebarHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainerMainForm;
        private Panel panelContainer;
        private Panel pnlSidebarHeader;
        private Label lblSidebarIcon;
        private Label lblSidebarTitle;
        private Label lblSidebarSubtitle;
        private Panel pnlSidebarLine;
        private Button btnCustomers;
        private Button btnRooms;
        private Button btnDashboard;
        private Button btnSignOut;
        private Button btnRolesStaff;
        private Button btnFinance;
        private Button btnBill;
        private Button btnServices;
        private Button btnBookings;
        public SidebarGradientPanel pnlChoice;
    }
}
