namespace HotelManagement.Forms
{
    partial class ForgetPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgetPasswordForm));
            btnGuiOTP = new Button();
            btnQuayVeLogin = new Button();
            lblNhapEmail = new Label();
            txtNhapEmail = new TextBox();
            SuspendLayout();
            // 
            // btnGuiOTP
            // 
            btnGuiOTP.BackColor = Color.Transparent;
            btnGuiOTP.FlatAppearance.BorderColor = Color.Black;
            btnGuiOTP.FlatAppearance.BorderSize = 3;
            btnGuiOTP.FlatStyle = FlatStyle.Flat;
            btnGuiOTP.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnGuiOTP.Location = new Point(74, 134);
            btnGuiOTP.Name = "btnGuiOTP";
            btnGuiOTP.Size = new Size(173, 59);
            btnGuiOTP.TabIndex = 0;
            btnGuiOTP.Text = "Gửi Mã OTP";
            btnGuiOTP.UseVisualStyleBackColor = false;
            // 
            // btnQuayVeLogin
            // 
            btnQuayVeLogin.BackColor = Color.Transparent;
            btnQuayVeLogin.FlatAppearance.BorderColor = Color.Black;
            btnQuayVeLogin.FlatAppearance.BorderSize = 3;
            btnQuayVeLogin.FlatStyle = FlatStyle.Flat;
            btnQuayVeLogin.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnQuayVeLogin.Location = new Point(346, 134);
            btnQuayVeLogin.Name = "btnQuayVeLogin";
            btnQuayVeLogin.Size = new Size(173, 59);
            btnQuayVeLogin.TabIndex = 1;
            btnQuayVeLogin.Text = "Quay Lại";
            btnQuayVeLogin.UseVisualStyleBackColor = false;
            btnQuayVeLogin.Click += btnQuayVeLogin_Click;
            // 
            // lblNhapEmail
            // 
            lblNhapEmail.AutoSize = true;
            lblNhapEmail.BackColor = Color.Transparent;
            lblNhapEmail.Font = new Font("Segoe UI Emoji", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNhapEmail.Location = new Point(30, 54);
            lblNhapEmail.Name = "lblNhapEmail";
            lblNhapEmail.Size = new Size(177, 37);
            lblNhapEmail.TabIndex = 2;
            lblNhapEmail.Text = "Nhập Email:";
            // 
            // txtNhapEmail
            // 
            txtNhapEmail.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Italic, GraphicsUnit.Point, 163);
            txtNhapEmail.Location = new Point(213, 54);
            txtNhapEmail.Name = "txtNhapEmail";
            txtNhapEmail.PlaceholderText = "Nhập email của bạn.....";
            txtNhapEmail.Size = new Size(306, 37);
            txtNhapEmail.TabIndex = 3;
            // 
            // QuenMKForm
            // 
            AcceptButton = btnQuayVeLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(569, 227);
            Controls.Add(txtNhapEmail);
            Controls.Add(lblNhapEmail);
            Controls.Add(btnQuayVeLogin);
            Controls.Add(btnGuiOTP);
            MaximizeBox = false;
            Name = "QuenMKForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QuenMKForm";
            Load += QuenMKForm_Load;
            Shown += QuenMKForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuiOTP;
        private Button btnQuayVeLogin;
        private Label lblNhapEmail;
        private TextBox txtNhapEmail;
    }
}