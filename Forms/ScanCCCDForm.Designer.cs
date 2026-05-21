namespace HotelManagement.Forms
{
    partial class ScanCCCDForm
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
            picCamera = new PictureBox();
            btnConfirm = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)picCamera).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // picCamera
            // 
            picCamera.Location = new Point(3, 3);
            picCamera.Name = "picCamera";
            picCamera.Size = new Size(635, 400);
            picCamera.TabIndex = 0;
            picCamera.TabStop = false;
            // 
            // btnConfirm
            // 
            btnConfirm.AutoSize = true;
            btnConfirm.BackColor = Color.FromArgb(192, 255, 192);
            btnConfirm.Dock = DockStyle.Right;
            btnConfirm.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.Location = new Point(538, 431);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(112, 41);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnExtract_Click_1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(picCamera, 0, 0);
            tableLayoutPanel1.Controls.Add(btnConfirm, 0, 1);
            tableLayoutPanel1.Location = new Point(152, 46);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(653, 475);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // ScanCCCDForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 591);
            Controls.Add(tableLayoutPanel1);
            Name = "ScanCCCDForm";
            Text = "ScanCCCDForm";
            Load += ScanCCCDForm_Load;
            ((System.ComponentModel.ISupportInitialize)picCamera).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picCamera;
        private Button btnConfirm;
        private TableLayoutPanel tableLayoutPanel1;
    }
}