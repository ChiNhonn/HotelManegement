namespace HotelManagement.Forms
{
    partial class PaymentByBankForm
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
            picQRCode = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picQRCode).BeginInit();
            SuspendLayout();
            // 
            // picQRCode
            // 
            picQRCode.Anchor = AnchorStyles.None;
            picQRCode.Location = new Point(137, 73);
            picQRCode.Name = "picQRCode";
            picQRCode.Size = new Size(499, 505);
            picQRCode.SizeMode = PictureBoxSizeMode.Zoom;
            picQRCode.TabIndex = 0;
            picQRCode.TabStop = false;
            // 
            // PaymentByBankForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 661);
            Controls.Add(picQRCode);
            Name = "PaymentByBankForm";
            Text = "PaymentByBankForm";
            Load += PaymentByBankForm_Load;
            ((System.ComponentModel.ISupportInitialize)picQRCode).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picQRCode;
    }
}