namespace QuanLyKhachSan.GUI
{
    partial class AddRoomTypeDiaLogForm
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
            lblLoaiPhong = new Label();
            lblSucChua = new Label();
            lblGia = new Label();
            lblMoTa = new Label();
            txtThemLoaiPhong = new TextBox();
            numSucChuaToiDa = new NumericUpDown();
            numGia = new NumericUpDown();
            txtMoTa = new TextBox();
            btnHuy = new Button();
            btnThem = new Button();
            ((System.ComponentModel.ISupportInitialize)numSucChuaToiDa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGia).BeginInit();
            SuspendLayout();
            // 
            // lblLoaiPhong
            // 
            lblLoaiPhong.AutoSize = true;
            lblLoaiPhong.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblLoaiPhong.Location = new Point(38, 44);
            lblLoaiPhong.Name = "lblLoaiPhong";
            lblLoaiPhong.Size = new Size(179, 31);
            lblLoaiPhong.TabIndex = 0;
            lblLoaiPhong.Text = "Ten loại phòng:";
            // 
            // lblSucChua
            // 
            lblSucChua.AutoSize = true;
            lblSucChua.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblSucChua.Location = new Point(38, 125);
            lblSucChua.Name = "lblSucChua";
            lblSucChua.Size = new Size(186, 31);
            lblSucChua.TabIndex = 1;
            lblSucChua.Text = "Sức chứa tối đa:";
            // 
            // lblGia
            // 
            lblGia.AutoSize = true;
            lblGia.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblGia.Location = new Point(38, 195);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(55, 31);
            lblGia.TabIndex = 2;
            lblGia.Text = "Giá:";
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblMoTa.Location = new Point(38, 284);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(83, 31);
            lblMoTa.TabIndex = 3;
            lblMoTa.Text = "Mô tả:";
            // 
            // txtThemLoaiPhong
            // 
            txtThemLoaiPhong.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 163);
            txtThemLoaiPhong.Location = new Point(246, 41);
            txtThemLoaiPhong.Name = "txtThemLoaiPhong";
            txtThemLoaiPhong.PlaceholderText = "Nhập tên loại phòng...";
            txtThemLoaiPhong.Size = new Size(245, 34);
            txtThemLoaiPhong.TabIndex = 4;
            // 
            // numSucChuaToiDa
            // 
            numSucChuaToiDa.Location = new Point(241, 132);
            numSucChuaToiDa.Name = "numSucChuaToiDa";
            numSucChuaToiDa.Size = new Size(152, 27);
            numSucChuaToiDa.TabIndex = 5;
            // 
            // numGia
            // 
            numGia.Location = new Point(241, 202);
            numGia.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numGia.Name = "numGia";
            numGia.Size = new Size(152, 27);
            numGia.TabIndex = 6;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(241, 291);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.ScrollBars = ScrollBars.Both;
            txtMoTa.Size = new Size(245, 81);
            txtMoTa.TabIndex = 7;
            // 
            // btnHuy
            // 
            btnHuy.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnHuy.Location = new Point(38, 425);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(148, 57);
            btnHuy.TabIndex = 8;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnThem.Location = new Point(319, 425);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(148, 57);
            btnThem.TabIndex = 9;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // ThemLPhongDiaLogForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 517);
            Controls.Add(btnThem);
            Controls.Add(btnHuy);
            Controls.Add(txtMoTa);
            Controls.Add(numGia);
            Controls.Add(numSucChuaToiDa);
            Controls.Add(txtThemLoaiPhong);
            Controls.Add(lblMoTa);
            Controls.Add(lblGia);
            Controls.Add(lblSucChua);
            Controls.Add(lblLoaiPhong);
            Name = "ThemLPhongDiaLogForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm loại phòng";
            ((System.ComponentModel.ISupportInitialize)numSucChuaToiDa).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLoaiPhong;
        private Label lblSucChua;
        private Label lblGia;
        private Label lblMoTa;
        private TextBox txtThemLoaiPhong;
        private NumericUpDown numSucChuaToiDa;
        private NumericUpDown numGia;
        private TextBox txtMoTa;
        private Button btnHuy;
        private Button btnThem;
    }
}