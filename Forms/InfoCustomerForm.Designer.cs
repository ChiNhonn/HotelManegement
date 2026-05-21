namespace HotelManagement.Forms
{
    partial class InfoCustomerForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnSua = new Button();
            btnThem = new Button();
            btnScanCCCD = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            label8 = new Label();
            label7 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label6 = new Label();
            label4 = new Label();
            txtCountry = new TextBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            txtXa = new TextBox();
            txtHuyen = new TextBox();
            txtTinh = new TextBox();
            groupBox1 = new GroupBox();
            rbNu = new RadioButton();
            rbNam = new RadioButton();
            dtpBirthDay = new DateTimePicker();
            txtFullName = new TextBox();
            txtNo = new TextBox();
            label5 = new Label();
            txtStatus = new TextBox();
            numVip = new NumericUpDown();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numVip).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Location = new Point(66, 51);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(605, 438);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnSua);
            flowLayoutPanel1.Controls.Add(btnThem);
            flowLayoutPanel1.Controls.Add(btnScanCCCD);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(3, 353);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(599, 82);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnSua
            // 
            btnSua.AutoSize = true;
            btnSua.BackColor = Color.FromArgb(255, 255, 128);
            btnSua.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnSua.Location = new Point(502, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 40);
            btnSua.TabIndex = 5;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.AutoSize = true;
            btnThem.BackColor = Color.FromArgb(255, 128, 128);
            btnThem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnThem.Location = new Point(402, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 40);
            btnThem.TabIndex = 6;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click_1;
            // 
            // btnScanCCCD
            // 
            btnScanCCCD.AutoSize = true;
            btnScanCCCD.BackColor = Color.FromArgb(192, 255, 255);
            btnScanCCCD.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnScanCCCD.Location = new Point(283, 3);
            btnScanCCCD.Name = "btnScanCCCD";
            btnScanCCCD.Size = new Size(113, 40);
            btnScanCCCD.TabIndex = 7;
            btnScanCCCD.Text = "Quét CCCD";
            btnScanCCCD.UseVisualStyleBackColor = false;
            btnScanCCCD.Click += btnScanCCCD_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label8, 0, 7);
            tableLayoutPanel2.Controls.Add(label7, 0, 6);
            tableLayoutPanel2.Controls.Add(label3, 0, 5);
            tableLayoutPanel2.Controls.Add(label2, 0, 4);
            tableLayoutPanel2.Controls.Add(label1, 0, 3);
            tableLayoutPanel2.Controls.Add(label6, 0, 2);
            tableLayoutPanel2.Controls.Add(label4, 0, 1);
            tableLayoutPanel2.Controls.Add(txtCountry, 1, 5);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 1, 4);
            tableLayoutPanel2.Controls.Add(groupBox1, 1, 3);
            tableLayoutPanel2.Controls.Add(dtpBirthDay, 1, 2);
            tableLayoutPanel2.Controls.Add(txtFullName, 1, 1);
            tableLayoutPanel2.Controls.Add(txtNo, 1, 0);
            tableLayoutPanel2.Controls.Add(label5, 0, 0);
            tableLayoutPanel2.Controls.Add(txtStatus, 1, 7);
            tableLayoutPanel2.Controls.Add(numVip, 1, 6);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 8;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(599, 344);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label8.Location = new Point(3, 311);
            label8.Name = "label8";
            label8.Size = new Size(99, 33);
            label8.TabIndex = 25;
            label8.Text = "Trạng thái";
            label8.TextAlign = ContentAlignment.TopCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label7.Location = new Point(3, 278);
            label7.Name = "label7";
            label7.Size = new Size(99, 33);
            label7.TabIndex = 24;
            label7.Text = "VIP";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label3.Location = new Point(3, 241);
            label3.Name = "label3";
            label3.Size = new Size(99, 37);
            label3.TabIndex = 19;
            label3.Text = "Quốc tịch";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label2.Location = new Point(3, 184);
            label2.Name = "label2";
            label2.Size = new Size(99, 57);
            label2.TabIndex = 18;
            label2.Text = "Quê quán";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label1.Location = new Point(3, 111);
            label1.Name = "label1";
            label1.Size = new Size(99, 73);
            label1.TabIndex = 17;
            label1.Text = "Giới tính";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label6.Location = new Point(3, 74);
            label6.Name = "label6";
            label6.Size = new Size(99, 37);
            label6.TabIndex = 16;
            label6.Text = "Ngày sinh";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label4.Location = new Point(3, 37);
            label4.Name = "label4";
            label4.Size = new Size(99, 37);
            label4.TabIndex = 15;
            label4.Text = "Họ và tên";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtCountry
            // 
            txtCountry.Font = new Font("Segoe UI Light", 10.8F);
            txtCountry.Location = new Point(108, 244);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(156, 31);
            txtCountry.TabIndex = 14;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(txtXa);
            flowLayoutPanel2.Controls.Add(txtHuyen);
            flowLayoutPanel2.Controls.Add(txtTinh);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(108, 187);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(488, 51);
            flowLayoutPanel2.TabIndex = 13;
            // 
            // txtXa
            // 
            txtXa.Font = new Font("Segoe UI Light", 10.8F);
            txtXa.Location = new Point(3, 3);
            txtXa.Name = "txtXa";
            txtXa.Size = new Size(153, 31);
            txtXa.TabIndex = 0;
            // 
            // txtHuyen
            // 
            txtHuyen.Font = new Font("Segoe UI Light", 10.8F);
            txtHuyen.Location = new Point(162, 3);
            txtHuyen.Name = "txtHuyen";
            txtHuyen.Size = new Size(153, 31);
            txtHuyen.TabIndex = 1;
            // 
            // txtTinh
            // 
            txtTinh.Font = new Font("Segoe UI Light", 10.8F);
            txtTinh.Location = new Point(321, 3);
            txtTinh.Name = "txtTinh";
            txtTinh.Size = new Size(153, 31);
            txtTinh.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbNu);
            groupBox1.Controls.Add(rbNam);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(108, 114);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(488, 67);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chọn giới tính";
            // 
            // rbNu
            // 
            rbNu.AutoSize = true;
            rbNu.Location = new Point(100, 26);
            rbNu.Name = "rbNu";
            rbNu.Size = new Size(50, 24);
            rbNu.TabIndex = 1;
            rbNu.TabStop = true;
            rbNu.Text = "Nữ";
            rbNu.UseVisualStyleBackColor = true;
            // 
            // rbNam
            // 
            rbNam.AutoSize = true;
            rbNam.Location = new Point(15, 26);
            rbNam.Name = "rbNam";
            rbNam.Size = new Size(62, 24);
            rbNam.TabIndex = 0;
            rbNam.TabStop = true;
            rbNam.Text = "Nam";
            rbNam.UseVisualStyleBackColor = true;
            // 
            // dtpBirthDay
            // 
            dtpBirthDay.Font = new Font("Segoe UI Light", 10.8F);
            dtpBirthDay.Format = DateTimePickerFormat.Short;
            dtpBirthDay.Location = new Point(108, 77);
            dtpBirthDay.Name = "dtpBirthDay";
            dtpBirthDay.Size = new Size(370, 31);
            dtpBirthDay.TabIndex = 11;
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI Light", 10.8F);
            txtFullName.Location = new Point(108, 40);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(370, 31);
            txtFullName.TabIndex = 10;
            // 
            // txtNo
            // 
            txtNo.Font = new Font("Segoe UI Light", 10.8F);
            txtNo.Location = new Point(108, 3);
            txtNo.Name = "txtNo";
            txtNo.Size = new Size(370, 31);
            txtNo.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(99, 37);
            label5.TabIndex = 3;
            label5.Text = "Số CCCD";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(108, 314);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(156, 27);
            txtStatus.TabIndex = 23;
            // 
            // numVip
            // 
            numVip.Location = new Point(108, 281);
            numVip.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numVip.Name = "numVip";
            numVip.Size = new Size(156, 27);
            numVip.TabIndex = 26;
            // 
            // InfoCustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 576);
            Controls.Add(tableLayoutPanel1);
            Name = "InfoCustomerForm";
            Text = "Thông Tin Khách Hàng";
            Load += InfoCustomerForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numVip).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnSua;
        private Button btnThem;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label5;
        private TextBox txtNo;
        private TextBox txtFullName;
        private DateTimePicker dtpBirthDay;
        private GroupBox groupBox1;
        private RadioButton rbNu;
        private RadioButton rbNam;
        private FlowLayoutPanel flowLayoutPanel2;
        private TextBox txtXa;
        private TextBox txtHuyen;
        private TextBox txtTinh;
        private TextBox txtCountry;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label6;
        private Button btnScanCCCD;
        private Label label8;
        private Label label7;
        private TextBox txtStatus;
        private NumericUpDown numVip;
    }
}