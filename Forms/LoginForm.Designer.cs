namespace QuanLyKhachSan
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            lblTaiKhoan = new Label();
            lblMatKhau = new Label();
            btnDangNhap = new Button();
            btnDangKy = new Button();
            txtTaiKhoan = new TextBox();
            txtMatKhau = new TextBox();
            lblTitleDangNhap = new Label();
            linkQuenMK = new LinkLabel();
            SuspendLayout();
            // 
            // lblTaiKhoan
            // 
            lblTaiKhoan.AutoSize = true;
            lblTaiKhoan.BackColor = Color.Transparent;
            lblTaiKhoan.Font = new Font("Segoe UI Emoji", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTaiKhoan.ForeColor = SystemColors.InactiveCaptionText;
            lblTaiKhoan.Location = new Point(51, 95);
            lblTaiKhoan.Name = "lblTaiKhoan";
            lblTaiKhoan.Size = new Size(166, 37);
            lblTaiKhoan.TabIndex = 0;
            lblTaiKhoan.Text = "Tài Khoản: ";
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.BackColor = Color.Transparent;
            lblMatKhau.Font = new Font("Segoe UI Emoji", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMatKhau.Location = new Point(54, 161);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(163, 37);
            lblMatKhau.TabIndex = 1;
            lblMatKhau.Text = "Mật Khẩu: ";
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.Transparent;
            btnDangNhap.Cursor = Cursors.Hand;
            btnDangNhap.FlatAppearance.BorderColor = Color.DimGray;
            btnDangNhap.FlatAppearance.BorderSize = 2;
            btnDangNhap.FlatAppearance.MouseDownBackColor = Color.Snow;
            btnDangNhap.FlatAppearance.MouseOverBackColor = Color.Linen;
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnDangNhap.ForeColor = SystemColors.WindowText;
            btnDangNhap.Location = new Point(138, 226);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(158, 53);
            btnDangNhap.TabIndex = 2;
            btnDangNhap.Text = "Đăng Nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // btnDangKy
            // 
            btnDangKy.BackColor = Color.Transparent;
            btnDangKy.Cursor = Cursors.Hand;
            btnDangKy.FlatAppearance.BorderColor = Color.Gray;
            btnDangKy.FlatAppearance.BorderSize = 2;
            btnDangKy.FlatAppearance.MouseDownBackColor = Color.Snow;
            btnDangKy.FlatAppearance.MouseOverBackColor = Color.SeaShell;
            btnDangKy.FlatStyle = FlatStyle.Flat;
            btnDangKy.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnDangKy.ForeColor = SystemColors.WindowText;
            btnDangKy.Location = new Point(358, 226);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(158, 53);
            btnDangKy.TabIndex = 3;
            btnDangKy.Text = "Đăng Ký";
            btnDangKy.UseVisualStyleBackColor = false;
            // 
            // txtTaiKhoan
            // 
            txtTaiKhoan.BackColor = Color.FloralWhite;
            txtTaiKhoan.BorderStyle = BorderStyle.None;
            txtTaiKhoan.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Italic, GraphicsUnit.Point, 163);
            txtTaiKhoan.ForeColor = Color.Black;
            txtTaiKhoan.Location = new Point(223, 95);
            txtTaiKhoan.Multiline = true;
            txtTaiKhoan.Name = "txtTaiKhoan";
            txtTaiKhoan.PlaceholderText = "Nhập tài khoản của bạn.....";
            txtTaiKhoan.Size = new Size(323, 37);
            txtTaiKhoan.TabIndex = 4;
            // 
            // txtMatKhau
            // 
            txtMatKhau.BackColor = Color.FloralWhite;
            txtMatKhau.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Italic, GraphicsUnit.Point, 163);
            txtMatKhau.ForeColor = Color.Black;
            txtMatKhau.Location = new Point(223, 161);
            txtMatKhau.Multiline = true;
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.PlaceholderText = "Nhập mật khẩu của bạn.....";
            txtMatKhau.Size = new Size(323, 43);
            txtMatKhau.TabIndex = 5;
            // 
            // lblTitleDangNhap
            // 
            lblTitleDangNhap.AutoSize = true;
            lblTitleDangNhap.BackColor = Color.Transparent;
            lblTitleDangNhap.Font = new Font("Cascadia Code", 28.2F, FontStyle.Italic, GraphicsUnit.Point, 163);
            lblTitleDangNhap.Location = new Point(223, 9);
            lblTitleDangNhap.Name = "lblTitleDangNhap";
            lblTitleDangNhap.Size = new Size(279, 62);
            lblTitleDangNhap.TabIndex = 6;
            lblTitleDangNhap.Text = "ĐĂNG NHẬP";
            // 
            // linkQuenMK
            // 
            linkQuenMK.AutoSize = true;
            linkQuenMK.BackColor = Color.Transparent;
            linkQuenMK.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 163);
            linkQuenMK.LinkColor = Color.Black;
            linkQuenMK.Location = new Point(258, 305);
            linkQuenMK.Name = "linkQuenMK";
            linkQuenMK.Size = new Size(157, 28);
            linkQuenMK.TabIndex = 7;
            linkQuenMK.TabStop = true;
            linkQuenMK.Text = "Quên mật khẩu?";
            // 
            // LoginForm
            // 
            AcceptButton = btnDangNhap;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(696, 360);
            Controls.Add(linkQuenMK);
            Controls.Add(lblTitleDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTaiKhoan);
            Controls.Add(btnDangKy);
            Controls.Add(btnDangNhap);
            Controls.Add(lblMatKhau);
            Controls.Add(lblTaiKhoan);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Nhập";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTaiKhoan;
        private Label lblMatKhau;
        private Button btnDangNhap;
        private Button btnDangKy;
        private TextBox txtTaiKhoan;
        private TextBox txtMatKhau;
        private Label lblTitleDangNhap;
        private LinkLabel linkQuenMK;
    }
}
