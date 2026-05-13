namespace HotelManagement.Forms
{
    partial class UpdateRoomDialogForm
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
            grpThongTin = new GroupBox();
            btnSua = new Button();
            btnHuy = new Button();
            lblSoPhong = new Label();
            lblLoaiPhong = new Label();
            cboTrangThai = new ComboBox();
            cboFloor = new ComboBox();
            lblTang = new Label();
            lblTrangThai = new Label();
            cboLoaiPhong = new ComboBox();
            txtSoPhong = new TextBox();
            grpThongTin.SuspendLayout();
            SuspendLayout();
            //
            // grpThongTin
            //
            grpThongTin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnHuy);
            grpThongTin.Controls.Add(lblSoPhong);
            grpThongTin.Controls.Add(lblLoaiPhong);
            grpThongTin.Controls.Add(cboTrangThai);
            grpThongTin.Controls.Add(cboFloor);
            grpThongTin.Controls.Add(lblTang);
            grpThongTin.Controls.Add(lblTrangThai);
            grpThongTin.Controls.Add(cboLoaiPhong);
            grpThongTin.Controls.Add(txtSoPhong);
            grpThongTin.Dock = DockStyle.Fill;
            grpThongTin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            grpThongTin.Location = new Point(0, 0);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(539, 460);
            grpThongTin.TabIndex = 25;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin cần sửa";
            //
            // btnSua
            //
            btnSua.Location = new Point(341, 360);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(119, 60);
            btnSua.TabIndex = 15;
            btnSua.Text = "Sửa ";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            //
            // btnHuy
            //
            btnHuy.Location = new Point(74, 360);
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
            cboTrangThai.Size = new Size(316, 36);
            cboTrangThai.TabIndex = 7;
            //
            // cboFloor
            //
            cboFloor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFloor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cboFloor.FormattingEnabled = true;
            cboFloor.Location = new Point(208, 210);
            cboFloor.Name = "cboFloor";
            cboFloor.Size = new Size(316, 36);
            cboFloor.TabIndex = 13;
            //
            // lblTang
            //
            lblTang.AutoSize = true;
            lblTang.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblTang.Location = new Point(46, 210);
            lblTang.Name = "lblTang";
            lblTang.Size = new Size(138, 31);
            lblTang.TabIndex = 12;
            lblTang.Text = "Tầng (DB):";
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
            // cboLoaiPhong
            //
            cboLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiPhong.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cboLoaiPhong.FormattingEnabled = true;
            cboLoaiPhong.Location = new Point(208, 137);
            cboLoaiPhong.Name = "cboLoaiPhong";
            cboLoaiPhong.Size = new Size(316, 36);
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
            //
            // UpdateRoomDialogForm
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 460);
            Controls.Add(grpThongTin);
            Name = "UpdateRoomDialogForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chỉnh sửa thông tin Phòng";
            Load += SuaPhongDialogForm_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpThongTin;
        private Button btnSua;
        private Button btnHuy;
        private Label lblSoPhong;
        private Label lblLoaiPhong;
        private ComboBox cboTrangThai;
        private ComboBox cboFloor;
        private Label lblTang;
        private Label lblTrangThai;
        private ComboBox cboLoaiPhong;
        private TextBox txtSoPhong;
    }
}
