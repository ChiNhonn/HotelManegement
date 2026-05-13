namespace HotelManagement.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlTopMainForm = new Panel();
            panel1 = new Panel();
            lblTenKhachSan = new Label();
            pnlContainerMainForm = new Panel();
            panelContainer = new Panel();
            pnlChoice = new Panel();
            btnDangXuat = new Button();
            btnThongKe = new Button();
            btnDichVu = new Button();
            btnDatPhong = new Button();
            btnKhach = new Button();
            btnPhong = new Button();
            btnTrangChu = new Button();
            pnlTopMainForm.SuspendLayout();
            panel1.SuspendLayout();
            pnlContainerMainForm.SuspendLayout();
            pnlChoice.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTopMainForm
            // 
            pnlTopMainForm.Controls.Add(panel1);
            pnlTopMainForm.Dock = DockStyle.Top;
            pnlTopMainForm.Location = new Point(0, 0);
            pnlTopMainForm.Name = "pnlTopMainForm";
            pnlTopMainForm.Size = new Size(1422, 125);
            pnlTopMainForm.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTenKhachSan);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(270, 96);
            panel1.TabIndex = 1;
            // 
            // lblTenKhachSan
            // 
            lblTenKhachSan.AutoSize = true;
            lblTenKhachSan.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblTenKhachSan.Location = new Point(24, 22);
            lblTenKhachSan.Name = "lblTenKhachSan";
            lblTenKhachSan.Size = new Size(209, 46);
            lblTenKhachSan.TabIndex = 0;
            lblTenKhachSan.Text = "NHẤT THỜI";
            // 
            // pnlContainerMainForm
            // 
            pnlContainerMainForm.Controls.Add(panelContainer);
            pnlContainerMainForm.Controls.Add(pnlChoice);
            pnlContainerMainForm.Dock = DockStyle.Fill;
            pnlContainerMainForm.Location = new Point(0, 125);
            pnlContainerMainForm.Name = "pnlContainerMainForm";
            pnlContainerMainForm.Size = new Size(1422, 850);
            pnlContainerMainForm.TabIndex = 2;
            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.WhiteSmoke;
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(288, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1134, 850);
            panelContainer.TabIndex = 1;
            // 
            // pnlChoice
            // 
            pnlChoice.BackColor = Color.White;
            pnlChoice.Controls.Add(btnDangXuat);
            pnlChoice.Controls.Add(btnThongKe);
            pnlChoice.Controls.Add(btnDichVu);
            pnlChoice.Controls.Add(btnDatPhong);
            pnlChoice.Controls.Add(btnKhach);
            pnlChoice.Controls.Add(btnPhong);
            pnlChoice.Controls.Add(btnTrangChu);
            pnlChoice.Dock = DockStyle.Left;
            pnlChoice.Location = new Point(0, 0);
            pnlChoice.Name = "pnlChoice";
            pnlChoice.Size = new Size(288, 850);
            pnlChoice.TabIndex = 2;
            // 
            // btnDangXuat
            // 
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnDangXuat.Location = new Point(6, 414);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(276, 62);
            btnDangXuat.TabIndex = 5;
            btnDangXuat.Text = "Đăng Xuất ";
            btnDangXuat.UseVisualStyleBackColor = true;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // btnThongKe
            // 
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnThongKe.Location = new Point(6, 346);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(276, 62);
            btnThongKe.TabIndex = 4;
            btnThongKe.Text = "Thống Kê";
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // btnDichVu
            // 
            btnDichVu.FlatStyle = FlatStyle.Flat;
            btnDichVu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnDichVu.Location = new Point(6, 278);
            btnDichVu.Name = "btnDichVu";
            btnDichVu.Size = new Size(276, 62);
            btnDichVu.TabIndex = 3;
            btnDichVu.Text = "Dịch vụ";
            btnDichVu.UseVisualStyleBackColor = true;
            btnDichVu.Click += btnDichVu_Click;
            // 
            // btnDatPhong
            // 
            btnDatPhong.FlatStyle = FlatStyle.Flat;
            btnDatPhong.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnDatPhong.Location = new Point(6, 210);
            btnDatPhong.Name = "btnDatPhong";
            btnDatPhong.Size = new Size(276, 62);
            btnDatPhong.TabIndex = 2;
            btnDatPhong.Text = "Đặt Phòng";
            btnDatPhong.UseVisualStyleBackColor = true;
            btnDatPhong.Click += btnDatPhong_Click;
            // 
            // btnKhach
            // 
            btnKhach.FlatStyle = FlatStyle.Flat;
            btnKhach.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnKhach.Location = new Point(6, 142);
            btnKhach.Name = "btnKhach";
            btnKhach.Size = new Size(276, 62);
            btnKhach.TabIndex = 1;
            btnKhach.Text = "Khách";
            btnKhach.UseVisualStyleBackColor = true;
            btnKhach.Click += btnKhach_Click;
            // 
            // btnPhong
            // 
            btnPhong.FlatStyle = FlatStyle.Flat;
            btnPhong.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnPhong.Location = new Point(6, 74);
            btnPhong.Name = "btnPhong";
            btnPhong.Size = new Size(276, 62);
            btnPhong.TabIndex = 0;
            btnPhong.Text = "Phòng ";
            btnPhong.UseVisualStyleBackColor = true;
            btnPhong.Click += btnPhong_Click;
            // 
            // btnTrangChu
            // 
            btnTrangChu.FlatStyle = FlatStyle.Flat;
            btnTrangChu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnTrangChu.Location = new Point(6, 6);
            btnTrangChu.Name = "btnTrangChu";
            btnTrangChu.Size = new Size(276, 62);
            btnTrangChu.TabIndex = 6;
            btnTrangChu.Text = "Trang Chủ";
            btnTrangChu.UseVisualStyleBackColor = true;
            btnTrangChu.Click += btnTrangChu_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1422, 975);
            Controls.Add(pnlContainerMainForm);
            Controls.Add(pnlTopMainForm);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            pnlTopMainForm.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlContainerMainForm.ResumeLayout(false);
            pnlChoice.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTopMainForm;
        private Panel pnlContainerMainForm;
        private Panel panelContainer;
        public Panel pnlChoice;
        private Button btnKhach;
        private Button btnPhong;
        private Button btnTrangChu;
        private Button btnDangXuat;
        private Button btnThongKe;
        private Button btnDichVu;
        private Button btnDatPhong;
        private Panel panel1;
        private Label lblTenKhachSan;
    }
}