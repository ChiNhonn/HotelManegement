namespace HotelManagement.Forms
{
    partial class CustomerForm
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
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnAddCustomer = new Button();
            btnExport = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(234, 5);
            label1.Name = "label1";
            label1.Size = new Size(171, 35);
            label1.TabIndex = 0;
            label1.Text = "DASHBOARD";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(btnAddCustomer, 1, 0);
            tableLayoutPanel1.Controls.Add(btnExport, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(20);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(920, 46);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.AutoSize = true;
            btnAddCustomer.BackColor = SystemColors.GradientInactiveCaption;
            btnAddCustomer.Dock = DockStyle.Fill;
            btnAddCustomer.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddCustomer.Location = new Point(643, 3);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(174, 40);
            btnAddCustomer.TabIndex = 1;
            btnAddCustomer.Text = "Thêm khách hàng";
            btnAddCustomer.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            btnExport.AutoSize = true;
            btnExport.BackColor = SystemColors.ActiveCaption;
            btnExport.Dock = DockStyle.Fill;
            btnExport.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExport.Location = new Point(823, 3);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(94, 40);
            btnExport.TabIndex = 2;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Controls.Add(panel2, 1, 0);
            tableLayoutPanel2.Controls.Add(panel3, 2, 0);
            tableLayoutPanel2.Controls.Add(panel4, 3, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(0, 46);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(920, 125);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(113, 61);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Location = new Point(233, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(169, 77);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Location = new Point(463, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(155, 77);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Location = new Point(693, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(107, 77);
            panel4.TabIndex = 3;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 624);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomerForm";
            Text = "CustomerForm";
            Load += CustomerForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnAddCustomer;
        private Button btnExport;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
    }
}