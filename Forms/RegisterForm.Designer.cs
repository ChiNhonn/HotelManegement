using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement.Forms
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            txtFullName = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            txtSDT = new TextBox();
            txtEmail = new TextBox();
            btnRegister = new Button();
            linkLogin = new LinkLabel();
            lblFullName = new Label();
            lblName = new Label();
            lblPassword = new Label();
            lblConfirmPassword = new Label();
            lblSDT = new Label();
            lblEmail = new Label();
            SuspendLayout();
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(300, 68);
            txtFullName.Margin = new Padding(3, 2, 3, 2);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Nguyễn Văn A";
            txtFullName.Size = new Size(162, 23);
            txtFullName.TabIndex = 0;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(300, 92);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Tên đăng nhập";
            txtUsername.Size = new Size(162, 23);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(300, 117);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Mật khẩu (tối thiểu 6 ký tự)";
            txtPassword.Size = new Size(162, 23);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(300, 142);
            txtConfirmPassword.Margin = new Padding(3, 2, 3, 2);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PlaceholderText = "Nhập lại mật khẩu";
            txtConfirmPassword.Size = new Size(162, 23);
            txtConfirmPassword.TabIndex = 3;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(300, 166);
            txtSDT.Margin = new Padding(3, 2, 3, 2);
            txtSDT.Name = "txtSDT";
            txtSDT.PlaceholderText = "0912345678";
            txtSDT.Size = new Size(162, 23);
            txtSDT.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(300, 191);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "email@example.com";
            txtEmail.Size = new Size(162, 23);
            txtEmail.TabIndex = 5;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Transparent;
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRegister.ForeColor = Color.Black;
            btnRegister.Location = new Point(316, 221);
            btnRegister.Margin = new Padding(3, 2, 3, 2);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(123, 32);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Đăng ký";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // linkLogin
            // 
            linkLogin.AutoSize = true;
            linkLogin.BackColor = Color.Transparent;
            linkLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            linkLogin.LinkColor = Color.Red;
            linkLogin.Location = new Point(300, 255);
            linkLogin.Name = "linkLogin";
            linkLogin.Size = new Size(159, 15);
            linkLogin.TabIndex = 7;
            linkLogin.TabStop = true;
            linkLogin.Text = "Đã có tài khoản? Đăng nhập";
            linkLogin.LinkClicked += linkLogin_LinkClicked;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.BackColor = Color.Transparent;
            lblFullName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFullName.Location = new Point(148, 73);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(64, 15);
            lblFullName.TabIndex = 8;
            lblFullName.Text = "Họ và tên:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblName.Location = new Point(148, 98);
            lblName.Name = "lblName";
            lblName.Size = new Size(91, 15);
            lblName.TabIndex = 9;
            lblName.Text = "Tên đăng nhập:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.Location = new Point(148, 122);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(62, 15);
            lblPassword.TabIndex = 10;
            lblPassword.Text = "Mật khẩu:";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.BackColor = Color.Transparent;
            lblConfirmPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblConfirmPassword.Location = new Point(148, 147);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(115, 15);
            lblConfirmPassword.TabIndex = 11;
            lblConfirmPassword.Text = "Xác nhận mật khẩu:";
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.BackColor = Color.Transparent;
            lblSDT.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSDT.Location = new Point(148, 172);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(83, 15);
            lblSDT.TabIndex = 12;
            lblSDT.Text = "Số điện thoại:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.Location = new Point(148, 196);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 13;
            lblEmail.Text = "Email:";
            // 
            // RegisterForm
            // 
            AcceptButton = btnRegister;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(700, 338);
            Controls.Add(lblEmail);
            Controls.Add(lblSDT);
            Controls.Add(lblConfirmPassword);
            Controls.Add(lblPassword);
            Controls.Add(lblName);
            Controls.Add(lblFullName);
            Controls.Add(linkLogin);
            Controls.Add(btnRegister);
            Controls.Add(txtEmail);
            Controls.Add(txtSDT);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtFullName);
            Margin = new Padding(3, 2, 3, 2);
            Name = "RegisterForm";
            Text = "Đăng ký tài khoản";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.LinkLabel linkLogin;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblEmail;
    }
}