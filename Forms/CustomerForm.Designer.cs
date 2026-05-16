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
            tableLayoutPanel2 = new TableLayoutPanel();
            panel1 = new Panel();
            lblPeople = new Label();
            label2 = new Label();
            panel2 = new Panel();
            lblVIP = new Label();
            label4 = new Label();
            panel3 = new Panel();
            label8 = new Label();
            lblInHouse = new Label();
            panel4 = new Panel();
            label9 = new Label();
            lblLeave = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            label10 = new Label();
            label3 = new Label();
            txtFind = new TextBox();
            numShow = new NumericUpDown();
            cboSapXep = new ComboBox();
            cboFilter = new ComboBox();
            dgvCustomer = new DataGridView();
            btnExport = new Button();
            btnAddCustomer = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numShow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(381, 9);
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(btnExport, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(btnAddCustomer, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(20);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1256, 53);
            tableLayoutPanel1.TabIndex = 1;
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
            tableLayoutPanel2.Location = new Point(0, 53);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1256, 91);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DodgerBlue;
            panel1.Controls.Add(lblPeople);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 10);
            panel1.Margin = new Padding(20, 10, 10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(284, 71);
            panel1.TabIndex = 0;
            // 
            // lblPeople
            // 
            lblPeople.Dock = DockStyle.Bottom;
            lblPeople.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPeople.ForeColor = Color.White;
            lblPeople.Location = new Point(0, 37);
            lblPeople.Margin = new Padding(3, 0, 10, 10);
            lblPeople.Name = "lblPeople";
            lblPeople.Size = new Size(284, 34);
            lblPeople.TabIndex = 1;
            lblPeople.Text = "12";
            lblPeople.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(284, 47);
            label2.TabIndex = 0;
            label2.Text = "People";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 128, 0);
            panel2.Controls.Add(lblVIP);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(324, 10);
            panel2.Margin = new Padding(10);
            panel2.Name = "panel2";
            panel2.Size = new Size(294, 71);
            panel2.TabIndex = 1;
            // 
            // lblVIP
            // 
            lblVIP.Dock = DockStyle.Bottom;
            lblVIP.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVIP.ForeColor = Color.White;
            lblVIP.Location = new Point(0, 37);
            lblVIP.Margin = new Padding(3, 0, 10, 10);
            lblVIP.Name = "lblVIP";
            lblVIP.Size = new Size(294, 34);
            lblVIP.TabIndex = 2;
            lblVIP.Text = "12";
            lblVIP.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(294, 47);
            label4.TabIndex = 1;
            label4.Text = "VIP";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 192, 192);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(lblInHouse);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(638, 10);
            panel3.Margin = new Padding(10);
            panel3.Name = "panel3";
            panel3.Size = new Size(294, 71);
            panel3.TabIndex = 2;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(294, 47);
            label8.TabIndex = 3;
            label8.Text = "In-house";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblInHouse
            // 
            lblInHouse.Dock = DockStyle.Bottom;
            lblInHouse.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInHouse.ForeColor = Color.White;
            lblInHouse.Location = new Point(0, 37);
            lblInHouse.Margin = new Padding(3, 0, 10, 10);
            lblInHouse.Name = "lblInHouse";
            lblInHouse.Size = new Size(294, 34);
            lblInHouse.TabIndex = 2;
            lblInHouse.Text = "12";
            lblInHouse.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Silver;
            panel4.Controls.Add(label9);
            panel4.Controls.Add(lblLeave);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(952, 10);
            panel4.Margin = new Padding(10, 10, 20, 10);
            panel4.Name = "panel4";
            panel4.Size = new Size(284, 71);
            panel4.TabIndex = 3;
            // 
            // label9
            // 
            label9.Dock = DockStyle.Top;
            label9.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(0, 0);
            label9.Name = "label9";
            label9.Size = new Size(284, 47);
            label9.TabIndex = 3;
            label9.Text = "Leave (today)";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLeave
            // 
            lblLeave.Dock = DockStyle.Bottom;
            lblLeave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLeave.ForeColor = Color.White;
            lblLeave.Location = new Point(0, 37);
            lblLeave.Margin = new Padding(3, 0, 10, 10);
            lblLeave.Name = "lblLeave";
            lblLeave.Size = new Size(284, 34);
            lblLeave.TabIndex = 2;
            lblLeave.Text = "12";
            lblLeave.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 6;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.Controls.Add(label10, 0, 0);
            tableLayoutPanel3.Controls.Add(label3, 2, 0);
            tableLayoutPanel3.Controls.Add(txtFind, 1, 0);
            tableLayoutPanel3.Controls.Add(numShow, 3, 0);
            tableLayoutPanel3.Controls.Add(cboSapXep, 4, 0);
            tableLayoutPanel3.Controls.Add(cboFilter, 5, 0);
            tableLayoutPanel3.Location = new Point(20, 147);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(1216, 38);
            tableLayoutPanel3.TabIndex = 3;
            tableLayoutPanel3.Paint += tableLayoutPanel3_Paint;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(3, 0);
            label10.Name = "label10";
            label10.Size = new Size(84, 38);
            label10.TabIndex = 0;
            label10.Text = "Tìm kiếm";
            label10.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(192, 255, 255);
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(670, 0);
            label3.Name = "label3";
            label3.Size = new Size(73, 38);
            label3.TabIndex = 1;
            label3.Text = "Hiển thị";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtFind
            // 
            txtFind.Location = new Point(93, 3);
            txtFind.Name = "txtFind";
            txtFind.Size = new Size(380, 27);
            txtFind.TabIndex = 2;
            // 
            // numShow
            // 
            numShow.Dock = DockStyle.Fill;
            numShow.Location = new Point(749, 3);
            numShow.Name = "numShow";
            numShow.Size = new Size(150, 27);
            numShow.TabIndex = 3;
            // 
            // cboSapXep
            // 
            cboSapXep.FormattingEnabled = true;
            cboSapXep.Location = new Point(905, 3);
            cboSapXep.Name = "cboSapXep";
            cboSapXep.Size = new Size(151, 28);
            cboSapXep.TabIndex = 4;
            // 
            // cboFilter
            // 
            cboFilter.FormattingEnabled = true;
            cboFilter.Location = new Point(1062, 3);
            cboFilter.Name = "cboFilter";
            cboFilter.Size = new Size(151, 28);
            cboFilter.TabIndex = 5;
            // 
            // dgvCustomer
            // 
            dgvCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomer.BackgroundColor = Color.White;
            dgvCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomer.Location = new Point(23, 219);
            dgvCustomer.Name = "dgvCustomer";
            dgvCustomer.RowHeadersWidth = 51;
            dgvCustomer.Size = new Size(1213, 394);
            dgvCustomer.TabIndex = 4;
            // 
            // btnExport
            // 
            btnExport.AutoSize = true;
            btnExport.BackColor = SystemColors.ActiveCaption;
            btnExport.Dock = DockStyle.Fill;
            btnExport.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExport.Location = new Point(937, 3);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(96, 47);
            btnExport.TabIndex = 3;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.AutoSize = true;
            btnAddCustomer.BackColor = Color.FromArgb(192, 192, 255);
            btnAddCustomer.Dock = DockStyle.Fill;
            btnAddCustomer.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddCustomer.Location = new Point(1039, 3);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(214, 47);
            btnAddCustomer.TabIndex = 4;
            btnAddCustomer.Text = "Thêm khách hàng";
            btnAddCustomer.UseVisualStyleBackColor = false;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            ClientSize = new Size(1256, 643);
            Controls.Add(dgvCustomer);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomerForm";
            Text = "CustomerForm";
            Load += CustomerForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numShow).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label label2;
        private Label lblPeople;
        private Label lblVIP;
        private Label label4;
        private Label label8;
        private Label lblInHouse;
        private Label label9;
        private Label lblLeave;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label10;
        private Label label3;
        private TextBox txtFind;
        private NumericUpDown numShow;
        private ComboBox cboSapXep;
        private ComboBox cboFilter;
        private DataGridView dgvCustomer;
        private Button btnExport;
        private Button btnAddCustomer;
    }
}