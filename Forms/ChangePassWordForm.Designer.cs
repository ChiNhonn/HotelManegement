namespace HotelManagement.Forms
{
    partial class DoiMKForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoiMKForm));
            lblMaOTP = new Label();
            lblMKlan1 = new Label();
            lblMKlan2 = new Label();
            txtNhapMaOTP = new TextBox();
            txtNhapMK = new TextBox();
            txtNhaplaiMK = new TextBox();
            btnXacNhan = new Button();
            SuspendLayout();
            // 
            // lblMaOTP
            // 
            lblMaOTP.AutoSize = true;
            lblMaOTP.BackColor = Color.Transparent;
            lblMaOTP.Font = new Font("Segoe UI Emoji", 13.2000008F, FontStyle.Bold);
            lblMaOTP.Location = new Point(12, 55);
            lblMaOTP.Name = "lblMaOTP";
            lblMaOTP.Size = new Size(115, 31);
            lblMaOTP.TabIndex = 0;
            lblMaOTP.Text = "Mã OTP:";
            // 
            // lblMKlan1
            // 
            lblMKlan1.AutoSize = true;
            lblMKlan1.BackColor = Color.Transparent;
            lblMKlan1.Font = new Font("Segoe UI Emoji", 13.2000008F, FontStyle.Bold);
            lblMKlan1.Location = new Point(12, 148);
            lblMKlan1.Name = "lblMKlan1";
            lblMKlan1.Size = new Size(181, 31);
            lblMKlan1.TabIndex = 1;
            lblMKlan1.Text = "Mật khẩu mới:";
            // 
            // lblMKlan2
            // 
            lblMKlan2.AutoSize = true;
            lblMKlan2.BackColor = Color.Transparent;
            lblMKlan2.Font = new Font("Segoe UI Emoji", 13.2000008F, FontStyle.Bold);
            lblMKlan2.Location = new Point(12, 239);
            lblMKlan2.Name = "lblMKlan2";
            lblMKlan2.Size = new Size(231, 31);
            lblMKlan2.TabIndex = 2;
            lblMKlan2.Text = "Nhập lại mật khẩu:";
            // 
            // txtNhapMaOTP
            // 
            txtNhapMaOTP.BorderStyle = BorderStyle.FixedSingle;
            txtNhapMaOTP.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Italic);
            txtNhapMaOTP.ForeColor = SystemColors.WindowText;
            txtNhapMaOTP.ImeMode = ImeMode.NoControl;
            txtNhapMaOTP.Location = new Point(248, 55);
            txtNhapMaOTP.Name = "txtNhapMaOTP";
            txtNhapMaOTP.PlaceholderText = "Nhập mã OTP 6 số...";
            txtNhapMaOTP.Size = new Size(304, 37);
            txtNhapMaOTP.TabIndex = 3;
            txtNhapMaOTP.TextChanged += txtNhapMaOTP_TextChanged;
            // 
            // txtNhapMK
            // 
            txtNhapMK.BorderStyle = BorderStyle.FixedSingle;
            txtNhapMK.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Italic);
            txtNhapMK.ForeColor = SystemColors.WindowText;
            txtNhapMK.ImeMode = ImeMode.NoControl;
            txtNhapMK.Location = new Point(248, 142);
            txtNhapMK.Name = "txtNhapMK";
            txtNhapMK.PasswordChar = '*';
            txtNhapMK.PlaceholderText = "Nhập mật khẩu mới...";
            txtNhapMK.Size = new Size(304, 37);
            txtNhapMK.TabIndex = 4;
            txtNhapMK.TextChanged += txtNhapMK_TextChanged;
            // 
            // txtNhaplaiMK
            // 
            txtNhaplaiMK.BorderStyle = BorderStyle.FixedSingle;
            txtNhaplaiMK.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Italic);
            txtNhaplaiMK.ForeColor = SystemColors.WindowText;
            txtNhaplaiMK.ImeMode = ImeMode.NoControl;
            txtNhaplaiMK.Location = new Point(249, 233);
            txtNhaplaiMK.Name = "txtNhaplaiMK";
            txtNhaplaiMK.PasswordChar = '*';
            txtNhaplaiMK.PlaceholderText = "Xác nhận mật khẩu mới...";
            txtNhaplaiMK.Size = new Size(303, 37);
            txtNhaplaiMK.TabIndex = 5;
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = Color.Transparent;
            btnXacNhan.Cursor = Cursors.Hand;
            btnXacNhan.FlatAppearance.BorderColor = Color.Black;
            btnXacNhan.FlatAppearance.BorderSize = 2;
            btnXacNhan.FlatStyle = FlatStyle.Flat;
            btnXacNhan.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnXacNhan.Location = new Point(229, 310);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(153, 56);
            btnXacNhan.TabIndex = 6;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.UseVisualStyleBackColor = false;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // DoiMKForm
            // 
            AcceptButton = btnXacNhan;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(591, 397);
            Controls.Add(btnXacNhan);
            Controls.Add(txtNhaplaiMK);
            Controls.Add(txtNhapMK);
            Controls.Add(txtNhapMaOTP);
            Controls.Add(lblMKlan2);
            Controls.Add(lblMKlan1);
            Controls.Add(lblMaOTP);
            MaximizeBox = false;
            Name = "DoiMKForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đặt lại mật khẩu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaOTP;
        private Label lblMKlan1;
        private Label lblMKlan2;
        private TextBox txtNhapMaOTP;
        private TextBox txtNhapMK;
        private TextBox txtNhaplaiMK;
        private Button btnXacNhan;
    }
}