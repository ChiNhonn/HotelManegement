namespace HotelManagement.Forms
{
    partial class UpdateRoomDialogForm
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
            grpThongTin = new GroupBox();
            btnSua = new Button();
            btnHuy = new Button();
            lblSoPhong = new Label();
            txtMoTa = new TextBox();
            lblLoaiPhong = new Label();
            cboTrangThai = new ComboBox();
            numTang = new NumericUpDown();
            lblTang = new Label();
            lblTrangThai = new Label();
            lblMoTa = new Label();
            cboLoaiPhong = new ComboBox();
            txtSoPhong = new TextBox();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTang).BeginInit();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnHuy);
            grpThongTin.Controls.Add(lblSoPhong);
            grpThongTin.Controls.Add(txtMoTa);
            grpThongTin.Controls.Add(lblLoaiPhong);
            grpThongTin.Controls.Add(cboTrangThai);
            grpThongTin.Controls.Add(numTang);
            grpThongTin.Controls.Add(lblTang);
            grpThongTin.Controls.Add(lblTrangThai);
            grpThongTin.Controls.Add(lblMoTa);
            grpThongTin.Controls.Add(cboLoaiPhong);
            grpThongTin.Controls.Add(txtSoPhong);
            grpThongTin.Dock = DockStyle.Fill;
            grpThongTin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            grpThongTin.Location = new Point(0, 0);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(539, 557);
            grpThongTin.TabIndex = 25;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin cần sửa";
            // 
            // btnSua
            // 
            btnSua.Location = new Point(341, 473);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(119, 60);
            btnSua.TabIndex = 15;
            btnSua.Text = "Sửa ";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(74, 473);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(119, 60);
            btnHuy.TabIndex = 14;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // lblSoPhong
            // 
            lblSoPhong.AutoSize = true;
            lblSoPhong.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblSoPhong.Location = new Point(46, 75);
            lblSoPhong.Name = "lblSoPhong";
            lblSoPhong.Size = new Size(123, 31);
            lblSoPhong.TabIndex = 1;
            lblSoPhong.Text = "Số Phòng:";
            // 
            // txtMoTa
            // 
            txtMoTa.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            txtMoTa.Location = new Point(208, 367);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.ScrollBars = ScrollBars.Both;
            txtMoTa.Size = new Size(316, 85);
            txtMoTa.TabIndex = 11;
            // 
            // lblLoaiPhong
            // 
            lblLoaiPhong.AutoSize = true;
            lblLoaiPhong.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblLoaiPhong.Location = new Point(46, 138);
            lblLoaiPhong.Name = "lblLoaiPhong";
            lblLoaiPhong.Size = new Size(147, 31);
            lblLoaiPhong.TabIndex = 8;
            lblLoaiPhong.Text = "Loại Phòng: ";
            lblLoaiPhong.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(208, 284);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(166, 36);
            cboTrangThai.TabIndex = 7;
            // 
            // numTang
            // 
            numTang.Enabled = false;
            numTang.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            numTang.Location = new Point(208, 210);
            numTang.Name = "numTang";
            numTang.ReadOnly = true;
            numTang.Size = new Size(166, 34);
            numTang.TabIndex = 13;
            // 
            // lblTang
            // 
            lblTang.AutoSize = true;
            lblTang.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblTang.Location = new Point(46, 210);
            lblTang.Name = "lblTang";
            lblTang.Size = new Size(73, 31);
            lblTang.TabIndex = 12;
            lblTang.Text = "Tầng:";
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblTrangThai.Location = new Point(46, 289);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(138, 31);
            lblTrangThai.TabIndex = 3;
            lblTrangThai.Text = "Trạng Thái: ";
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblMoTa.Location = new Point(46, 367);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(83, 31);
            lblMoTa.TabIndex = 10;
            lblMoTa.Text = "Mô tả:";
            // 
            // cboLoaiPhong
            // 
            cboLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiPhong.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cboLoaiPhong.FormattingEnabled = true;
            cboLoaiPhong.Items.AddRange(new object[] { "Tiêu chuẩn", "Cao Cấp", "VIP" });
            cboLoaiPhong.Location = new Point(208, 137);
            cboLoaiPhong.Name = "cboLoaiPhong";
            cboLoaiPhong.Size = new Size(166, 36);
            cboLoaiPhong.TabIndex = 9;
            // 
            // txtSoPhong
            // 
            txtSoPhong.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 163);
            txtSoPhong.Location = new Point(208, 72);
            txtSoPhong.Name = "txtSoPhong";
            txtSoPhong.PlaceholderText = "Nhập số phòng....";
            txtSoPhong.Size = new Size(316, 34);
            txtSoPhong.TabIndex = 4;
            txtSoPhong.TextChanged += txtSoPhong_TextChanged;
            // 
            // SuaPhongDialogForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 557);
            Controls.Add(grpThongTin);
            Name = "SuaPhongDialogForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chỉnh sửa thông tin Phòng";
            Load += SuaPhongDialogForm_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpThongTin;
        private Button btnSua;
        private Button btnHuy;
        private Label lblSoPhong;
        private TextBox txtMoTa;
        private Label lblLoaiPhong;
        private ComboBox cboTrangThai;
        private NumericUpDown numTang;
        private Label lblTang;
        private Label lblTrangThai;
        private Label lblMoTa;
        private ComboBox cboLoaiPhong;
        private TextBox txtSoPhong;
    }
}