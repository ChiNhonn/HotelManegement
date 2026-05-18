namespace HotelManagement.Forms
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
            lblUsername = new Label();
            lblPassword = new Label();
            btnSignIn = new Button();
            btnOpenRegister = new Button();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            lblTitleLogin = new Label();
            linkForgotPassword = new LinkLabel();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Segoe UI Emoji", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = SystemColors.InactiveCaptionText;
            lblUsername.Location = new Point(51, 95);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(166, 37);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tài khoản:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI Emoji", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(54, 161);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(163, 37);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Mật khẩu:";
            // 
            // btnSignIn
            // 
            btnSignIn.BackColor = Color.Transparent;
            btnSignIn.Cursor = Cursors.Hand;
            btnSignIn.FlatAppearance.BorderColor = Color.DimGray;
            btnSignIn.FlatAppearance.BorderSize = 2;
            btnSignIn.FlatAppearance.MouseDownBackColor = Color.Snow;
            btnSignIn.FlatAppearance.MouseOverBackColor = Color.Linen;
            btnSignIn.FlatStyle = FlatStyle.Flat;
            btnSignIn.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnSignIn.ForeColor = SystemColors.WindowText;
            btnSignIn.Location = new Point(138, 226);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(158, 53);
            btnSignIn.TabIndex = 2;
            btnSignIn.Text = "Đăng nhập";
            btnSignIn.UseVisualStyleBackColor = false;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // btnOpenRegister
            // 
            btnOpenRegister.BackColor = Color.Transparent;
            btnOpenRegister.Cursor = Cursors.Hand;
            btnOpenRegister.FlatAppearance.BorderColor = Color.Gray;
            btnOpenRegister.FlatAppearance.BorderSize = 2;
            btnOpenRegister.FlatAppearance.MouseDownBackColor = Color.Snow;
            btnOpenRegister.FlatAppearance.MouseOverBackColor = Color.SeaShell;
            btnOpenRegister.FlatStyle = FlatStyle.Flat;
            btnOpenRegister.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnOpenRegister.ForeColor = SystemColors.WindowText;
            btnOpenRegister.Location = new Point(358, 226);
            btnOpenRegister.Name = "btnOpenRegister";
            btnOpenRegister.Size = new Size(158, 53);
            btnOpenRegister.TabIndex = 3;
            btnOpenRegister.Text = "Đăng ký";
            btnOpenRegister.UseVisualStyleBackColor = false;
            btnOpenRegister.Click += btnOpenRegister_Click;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FloralWhite;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Italic, GraphicsUnit.Point, 163);
            txtUsername.ForeColor = Color.Black;
            txtUsername.Location = new Point(223, 95);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Nhập tài khoản";
            txtUsername.Size = new Size(323, 37);
            txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FloralWhite;
            txtPassword.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Italic, GraphicsUnit.Point, 163);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(223, 161);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Nhập mật khẩu";
            txtPassword.Size = new Size(323, 43);
            txtPassword.TabIndex = 5;
            // 
            // lblTitleLogin
            // 
            lblTitleLogin.AutoSize = true;
            lblTitleLogin.BackColor = Color.Transparent;
            lblTitleLogin.Font = new Font("Cascadia Code", 28.2F, FontStyle.Italic, GraphicsUnit.Point, 163);
            lblTitleLogin.Location = new Point(223, 9);
            lblTitleLogin.Name = "lblTitleLogin";
            lblTitleLogin.Size = new Size(279, 62);
            lblTitleLogin.TabIndex = 6;
            lblTitleLogin.Text = "ĐĂNG NHẬP";
            // 
            // linkForgotPassword
            // 
            linkForgotPassword.AutoSize = true;
            linkForgotPassword.BackColor = Color.Transparent;
            linkForgotPassword.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 163);
            linkForgotPassword.LinkColor = Color.Black;
            linkForgotPassword.Location = new Point(258, 305);
            linkForgotPassword.Name = "linkForgotPassword";
            linkForgotPassword.Size = new Size(157, 28);
            linkForgotPassword.TabIndex = 7;
            linkForgotPassword.TabStop = true;
            linkForgotPassword.Text = "Quên mật khẩu?";
            linkForgotPassword.LinkClicked += linkForgotPassword_LinkClicked;
            // 
            // LoginForm
            // 
            AcceptButton = btnSignIn;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(696, 360);
            Controls.Add(linkForgotPassword);
            Controls.Add(lblTitleLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(btnOpenRegister);
            Controls.Add(btnSignIn);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private Label lblPassword;
        private Button btnSignIn;
        private Button btnOpenRegister;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label lblTitleLogin;
        private LinkLabel linkForgotPassword;
    }
}
