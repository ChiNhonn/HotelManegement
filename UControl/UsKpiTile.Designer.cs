namespace HotelManagement.CustomControls
{
    partial class UsKpiTile
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
            pnlCard = new Panel();
            tlpContent = new TableLayoutPanel();
            lblIcon = new Label();
            lblValue = new Label();
            lblCaption = new Label();
            pnlCard.SuspendLayout();
            tlpContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.FromArgb(30, 95, 200);
            pnlCard.Controls.Add(tlpContent);
            pnlCard.Dock = DockStyle.Fill;
            pnlCard.Location = new Point(0, 0);
            pnlCard.Margin = new Padding(9, 8, 9, 8);
            pnlCard.Name = "pnlCard";
            pnlCard.Padding = new Padding(12, 9, 12, 9);
            pnlCard.Size = new Size(245, 343);
            pnlCard.TabIndex = 0;
            // 
            // tlpContent
            // 
            tlpContent.ColumnCount = 1;
            tlpContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpContent.Controls.Add(lblIcon, 0, 0);
            tlpContent.Controls.Add(lblValue, 0, 1);
            tlpContent.Controls.Add(lblCaption, 0, 2);
            tlpContent.Dock = DockStyle.Fill;
            tlpContent.Location = new Point(12, 9);
            tlpContent.Margin = new Padding(3, 2, 3, 2);
            tlpContent.Name = "tlpContent";
            tlpContent.RowCount = 3;
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 32F));
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 38F));
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tlpContent.Size = new Size(221, 325);
            tlpContent.TabIndex = 0;
            // 
            // lblIcon
            // 
            lblIcon.Dock = DockStyle.Fill;
            lblIcon.Font = new Font("Segoe MDL2 Assets", 26F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblIcon.ForeColor = Color.White;
            lblIcon.Location = new Point(3, 0);
            lblIcon.Name = "lblIcon";
            lblIcon.Size = new Size(215, 104);
            lblIcon.TabIndex = 0;
            lblIcon.Text = "";
            lblIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblValue
            // 
            lblValue.Dock = DockStyle.Fill;
            lblValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblValue.ForeColor = Color.White;
            lblValue.Location = new Point(3, 104);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(215, 123);
            lblValue.TabIndex = 1;
            lblValue.Text = "0";
            lblValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCaption
            // 
            lblCaption.Dock = DockStyle.Fill;
            lblCaption.Font = new Font("Segoe UI", 10F);
            lblCaption.ForeColor = Color.FromArgb(235, 255, 255, 255);
            lblCaption.Location = new Point(3, 227);
            lblCaption.Name = "lblCaption";
            lblCaption.Size = new Size(215, 98);
            lblCaption.TabIndex = 2;
            lblCaption.Text = "Nhãn";
            lblCaption.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UsKpiTile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            Controls.Add(pnlCard);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UsKpiTile";
            Size = new Size(245, 343);
            pnlCard.ResumeLayout(false);
            tlpContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCard;
        private TableLayoutPanel tlpContent;
        private Label lblIcon;
        private Label lblValue;
        private Label lblCaption;
    }
}
