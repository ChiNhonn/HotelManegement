using System.Windows.Forms;

namespace HotelManagement.Forms
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtSDT = new TextBox();
            txtEmail = new TextBox();
            btnRegister = new Button();
            linkLogin = new LinkLabel();
            lblName = new Label();
            lblSDT = new Label();
            lblPassword = new Label();
            lblEmail = new Label();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(343, 107);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Name";
            txtUsername.Size = new Size(184, 27);
            txtUsername.TabIndex = 0;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(343, 140);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(184, 27);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(343, 173);
            txtSDT.Name = "txtSDT";
            txtSDT.PlaceholderText = "***********";
            txtSDT.Size = new Size(184, 27);
            txtSDT.TabIndex = 2;
            txtSDT.UseSystemPasswordChar = true;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(343, 206);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(184, 27);
            txtEmail.TabIndex = 3;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Transparent;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.Black;
            btnRegister.Location = new Point(361, 239);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(141, 43);
            btnRegister.TabIndex = 4;
            btnRegister.Text = "Register";
            btnRegister.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // linkLogin
            // 
            linkLogin.AutoSize = true;
            linkLogin.BackColor = Color.Transparent;
            linkLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkLogin.LinkColor = Color.Red;
            linkLogin.Location = new Point(312, 285);
            linkLogin.Name = "linkLogin";
            linkLogin.Size = new Size(242, 20);
            linkLogin.TabIndex = 5;
            linkLogin.TabStop = true;
            linkLogin.Text = "Already have an account? Sign in";
            linkLogin.LinkClicked += linkLogin_LinkClicked;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(169, 114);
            lblName.Name = "lblName";
            lblName.Size = new Size(116, 20);
            lblName.TabIndex = 6;
            lblName.Text = "Username:";
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.BackColor = Color.Transparent;
            lblSDT.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSDT.Location = new Point(169, 180);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(100, 20);
            lblSDT.TabIndex = 7;
            lblSDT.Text = "Phone";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(169, 147);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(79, 20);
            lblPassword.TabIndex = 8;
            lblPassword.Text = "Password:\r\n";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(169, 213);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 20);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "Email:";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(lblEmail);
            Controls.Add(lblPassword);
            Controls.Add(lblSDT);
            Controls.Add(lblName);
            Controls.Add(linkLogin);
            Controls.Add(btnRegister);
            Controls.Add(txtEmail);
            Controls.Add(txtSDT);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Name = "RegisterForm";
            Text = "Register";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtSDT;
        private TextBox txtEmail;
        private Button btnRegister;
        private LinkLabel linkLogin;
        private Label lblName;
        private Label lblSDT;
        private Label lblPassword;
        private Label lblEmail;
    }
}