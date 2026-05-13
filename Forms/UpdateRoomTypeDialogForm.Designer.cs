namespace QuanLyKhachSan.GUI
{
    partial class UpdateRoomTypeDialogForm
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
            btnLuu = new Button();
            btnHuy = new Button();
            txtMoTa = new TextBox();
            numGia = new NumericUpDown();
            numSucChuaToiDa = new NumericUpDown();
            txtThemLoaiPhong = new TextBox();
            lblMoTa = new Label();
            lblGia = new Label();
            lblSucChua = new Label();
            lblLoaiPhong = new Label();
            ((System.ComponentModel.ISupportInitialize)numGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSucChuaToiDa).BeginInit();
            SuspendLayout();
            // 
            // btnLuu
            // 
            btnLuu.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnLuu.Location = new Point(316, 432);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(148, 57);
            btnLuu.TabIndex = 19;
            btnLuu.Text = " Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnHuy.Location = new Point(35, 432);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(148, 57);
            btnHuy.TabIndex = 18;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // txtMoTa
            // 
            txtMoTa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtMoTa.Location = new Point(238, 298);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.ScrollBars = ScrollBars.Both;
            txtMoTa.Size = new Size(245, 81);
            txtMoTa.TabIndex = 17;
            // 
            // numGia
            // 
            numGia.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            numGia.Location = new Point(238, 209);
            numGia.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numGia.Name = "numGia";
            numGia.Size = new Size(152, 34);
            numGia.TabIndex = 16;
            // 
            // numSucChuaToiDa
            // 
            numSucChuaToiDa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            numSucChuaToiDa.Location = new Point(238, 139);
            numSucChuaToiDa.Name = "numSucChuaToiDa";
            numSucChuaToiDa.Size = new Size(152, 34);
            numSucChuaToiDa.TabIndex = 15;
            // 
            // txtThemLoaiPhong
            // 
            txtThemLoaiPhong.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtThemLoaiPhong.Location = new Point(238, 48);
            txtThemLoaiPhong.Name = "txtThemLoaiPhong";
            txtThemLoaiPhong.PlaceholderText = "Nhập tên loại phòng...";
            txtThemLoaiPhong.Size = new Size(245, 34);
            txtThemLoaiPhong.TabIndex = 14;
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblMoTa.Location = new Point(35, 291);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(83, 31);
            lblMoTa.TabIndex = 13;
            lblMoTa.Text = "Mô tả:";
            // 
            // lblGia
            // 
            lblGia.AutoSize = true;
            lblGia.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblGia.Location = new Point(35, 202);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(55, 31);
            lblGia.TabIndex = 12;
            lblGia.Text = "Giá:";
            // 
            // lblSucChua
            // 
            lblSucChua.AutoSize = true;
            lblSucChua.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblSucChua.Location = new Point(35, 132);
            lblSucChua.Name = "lblSucChua";
            lblSucChua.Size = new Size(186, 31);
            lblSucChua.TabIndex = 11;
            lblSucChua.Text = "Sức chứa tối đa:";
            // 
            // lblLoaiPhong
            // 
            lblLoaiPhong.AutoSize = true;
            lblLoaiPhong.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblLoaiPhong.Location = new Point(35, 51);
            lblLoaiPhong.Name = "lblLoaiPhong";
            lblLoaiPhong.Size = new Size(179, 31);
            lblLoaiPhong.TabIndex = 10;
            lblLoaiPhong.Text = "Tên loại phòng:";
            // 
            // SuaLPhongDialogForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 508);
            Controls.Add(btnLuu);
            Controls.Add(btnHuy);
            Controls.Add(txtMoTa);
            Controls.Add(numGia);
            Controls.Add(numSucChuaToiDa);
            Controls.Add(txtThemLoaiPhong);
            Controls.Add(lblMoTa);
            Controls.Add(lblGia);
            Controls.Add(lblSucChua);
            Controls.Add(lblLoaiPhong);
            Name = "SuaLPhongDialogForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sửa thông tin loại phòng";
            Load += SuaLPhongDialogForm_Load;
            ((System.ComponentModel.ISupportInitialize)numGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSucChuaToiDa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLuu;
        private Button btnHuy;
        private TextBox txtMoTa;
        private NumericUpDown numGia;
        private NumericUpDown numSucChuaToiDa;
        private TextBox txtThemLoaiPhong;
        private Label lblMoTa;
        private Label lblGia;
        private Label lblSucChua;
        private Label lblLoaiPhong;
    }
}