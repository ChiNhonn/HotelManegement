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
            txtFullName.Location = new Point(343, 91);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Nguyễn Văn A";
            txtFullName.Size = new Size(185, 27);
            txtFullName.TabIndex = 0;
            txtFullName.UseWaitCursor = true;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(343, 123);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Tên đăng nhập";
            txtUsername.Size = new Size(185, 27);
            txtUsername.TabIndex = 1;
            txtUsername.UseWaitCursor = true;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(343, 156);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Mật khẩu (tối thiểu 6 ký tự)";
            txtPassword.Size = new Size(185, 27);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.UseWaitCursor = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(343, 189);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PlaceholderText = "Nhập lại mật khẩu";
            txtConfirmPassword.Size = new Size(185, 27);
            txtConfirmPassword.TabIndex = 3;
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseWaitCursor = true;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(343, 221);
            txtSDT.Name = "txtSDT";
            txtSDT.PlaceholderText = "0912345678";
            txtSDT.Size = new Size(185, 27);
            txtSDT.TabIndex = 4;
            txtSDT.UseWaitCursor = true;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(343, 255);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "email@example.com";
            txtEmail.Size = new Size(185, 27);
            txtEmail.TabIndex = 5;
            txtEmail.UseWaitCursor = true;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Transparent;
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRegister.ForeColor = Color.Black;
            btnRegister.Location = new Point(361, 295);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(141, 43);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Đăng ký";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.UseWaitCursor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // linkLogin
            // 
            linkLogin.AutoSize = true;
            linkLogin.BackColor = Color.Transparent;
            linkLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            linkLogin.LinkColor = Color.Red;
            linkLogin.Location = new Point(343, 340);
            linkLogin.Name = "linkLogin";
            linkLogin.Size = new Size(204, 20);
            linkLogin.TabIndex = 7;
            linkLogin.TabStop = true;
            linkLogin.Text = "Đã có tài khoản? Đăng nhập";
            linkLogin.UseWaitCursor = true;
            linkLogin.LinkClicked += linkLogin_LinkClicked;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.BackColor = Color.Transparent;
            lblFullName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFullName.Location = new Point(169, 97);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(80, 20);
            lblFullName.TabIndex = 8;
            lblFullName.Text = "Họ và tên:";
            lblFullName.UseWaitCursor = true;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblName.Location = new Point(169, 131);
            lblName.Name = "lblName";
            lblName.Size = new Size(116, 20);
            lblName.TabIndex = 9;
            lblName.Text = "Tên đăng nhập:";
            lblName.UseWaitCursor = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.Location = new Point(169, 163);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(79, 20);
            lblPassword.TabIndex = 10;
            lblPassword.Text = "Mật khẩu:";
            lblPassword.UseWaitCursor = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.BackColor = Color.Transparent;
            lblConfirmPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblConfirmPassword.Location = new Point(169, 196);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(147, 20);
            lblConfirmPassword.TabIndex = 11;
            lblConfirmPassword.Text = "Xác nhận mật khẩu:";
            lblConfirmPassword.UseWaitCursor = true;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.BackColor = Color.Transparent;
            lblSDT.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSDT.Location = new Point(169, 229);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(104, 20);
            lblSDT.TabIndex = 12;
            lblSDT.Text = "Số điện thoại:";
            lblSDT.UseWaitCursor = true;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.Location = new Point(169, 261);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 20);
            lblEmail.TabIndex = 13;
            lblEmail.Text = "Email:";
            lblEmail.UseWaitCursor = true;
            // 
            // RegisterForm
            // 
            AcceptButton = btnRegister;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 451);
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
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký tài khoản";
            UseWaitCursor = true;
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