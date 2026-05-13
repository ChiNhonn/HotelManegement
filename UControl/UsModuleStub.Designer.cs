namespace HotelManagement.CustomControls
{
    partial class UsModuleStub
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            lblMessage = new Label();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lblMessage.ForeColor = Color.FromArgb(51, 65, 85);
            lblMessage.Location = new Point(0, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(800, 480);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Module";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UsModuleStub
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            Controls.Add(lblMessage);
            Name = "UsModuleStub";
            Size = new Size(800, 480);
            ResumeLayout(false);
        }

        #endregion

        private Label lblMessage;
    }
}
