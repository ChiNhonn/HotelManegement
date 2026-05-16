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
            button3 = new Button();
            button2 = new Button();
            btnThem = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            label5 = new Label();
            txtNo = new TextBox();
            txtFullName = new TextBox();
            dtpBirthDay = new DateTimePicker();
            groupBox1 = new GroupBox();
            this.rbNu = new RadioButton();
            this.rbNam = new RadioButton();
            flowLayoutPanel2 = new FlowLayoutPanel();
            this.txtXa = new TextBox();
            txtHuyen = new TextBox();
            txtTinh = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            label6 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
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
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(601, 390);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button3);
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Controls.Add(btnThem);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(3, 288);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(595, 99);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // button3
            // 
            button3.AutoSize = true;
            button3.BackColor = Color.Lime;
            button3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(498, 3);
            button3.Name = "button3";
            button3.Size = new Size(94, 35);
            button3.TabIndex = 4;
            button3.Text = "Xóa";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.BackColor = Color.FromArgb(255, 255, 128);
            button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(398, 3);
            button2.Name = "button2";
            button2.Size = new Size(94, 35);
            button2.TabIndex = 5;
            button2.Text = "Sửa";
            button2.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            btnThem.AutoSize = true;
            btnThem.BackColor = Color.FromArgb(255, 128, 128);
            btnThem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(298, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 40);
            btnThem.TabIndex = 6;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label3, 0, 5);
            tableLayoutPanel2.Controls.Add(label2, 0, 4);
            tableLayoutPanel2.Controls.Add(label1, 0, 3);
            tableLayoutPanel2.Controls.Add(label6, 0, 2);
            tableLayoutPanel2.Controls.Add(label4, 0, 1);
            tableLayoutPanel2.Controls.Add(textBox1, 1, 5);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 1, 4);
            tableLayoutPanel2.Controls.Add(groupBox1, 1, 3);
            tableLayoutPanel2.Controls.Add(dtpBirthDay, 1, 2);
            tableLayoutPanel2.Controls.Add(txtFullName, 1, 1);
            tableLayoutPanel2.Controls.Add(txtNo, 1, 0);
            tableLayoutPanel2.Controls.Add(label5, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 6;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(595, 279);
            tableLayoutPanel2.TabIndex = 1;
            tableLayoutPanel2.Paint += tableLayoutPanel2_Paint;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(97, 37);
            label5.TabIndex = 3;
            label5.Text = "Số CCCD";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtNo
            // 
            txtNo.Dock = DockStyle.Left;
            txtNo.Font = new Font("Segoe UI Light", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNo.Location = new Point(106, 3);
            txtNo.Name = "txtNo";
            txtNo.Size = new Size(370, 31);
            txtNo.TabIndex = 9;
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI Light", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFullName.Location = new Point(106, 40);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(125, 31);
            txtFullName.TabIndex = 10;
            // 
            // dtpBirthDay
            // 
            dtpBirthDay.Format = DateTimePickerFormat.Custom;
            dtpBirthDay.Location = new Point(106, 77);
            dtpBirthDay.Name = "dtpBirthDay";
            dtpBirthDay.Size = new Size(142, 27);
            dtpBirthDay.TabIndex = 11;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.rbNu);
            groupBox1.Controls.Add(this.rbNam);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(106, 110);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(486, 67);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // rbNu
            // 
            this.rbNu.AutoSize = true;
            this.rbNu.Dock = DockStyle.Top;
            this.rbNu.Location = new Point(3, 47);
            this.rbNu.Name = "rbNu";
            this.rbNu.Size = new Size(480, 24);
            this.rbNu.TabIndex = 1;
            this.rbNu.TabStop = true;
            this.rbNu.Text = "Nữ";
            this.rbNu.UseVisualStyleBackColor = true;
            // 
            // rbNam
            // 
            this.rbNam.AutoSize = true;
            this.rbNam.Dock = DockStyle.Top;
            this.rbNam.Location = new Point(3, 23);
            this.rbNam.Name = "rbNam";
            this.rbNam.Size = new Size(480, 24);
            this.rbNam.TabIndex = 0;
            this.rbNam.TabStop = true;
            this.rbNam.Text = "Nam";
            this.rbNam.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(this.txtXa);
            flowLayoutPanel2.Controls.Add(txtHuyen);
            flowLayoutPanel2.Controls.Add(txtTinh);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(106, 183);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(486, 56);
            flowLayoutPanel2.TabIndex = 13;
            // 
            // txtXa
            // 
            this.txtXa.Location = new Point(3, 3);
            this.txtXa.Name = "txtXa";
            this.txtXa.Size = new Size(125, 27);
            this.txtXa.TabIndex = 0;
            // 
            // txtHuyen
            // 
            txtHuyen.Location = new Point(134, 3);
            txtHuyen.Name = "txtHuyen";
            txtHuyen.Size = new Size(125, 27);
            txtHuyen.TabIndex = 1;
            // 
            // txtTinh
            // 
            txtTinh.Location = new Point(265, 3);
            txtTinh.Name = "txtTinh";
            txtTinh.Size = new Size(125, 27);
            txtTinh.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(106, 245);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 37);
            label4.Name = "label4";
            label4.Size = new Size(97, 37);
            label4.TabIndex = 15;
            label4.Text = "Họ và tên";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(3, 74);
            label6.Name = "label6";
            label6.Size = new Size(97, 33);
            label6.TabIndex = 16;
            label6.Text = "Ngày sinh";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 107);
            label1.Name = "label1";
            label1.Size = new Size(97, 73);
            label1.TabIndex = 17;
            label1.Text = "Giới tính";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 180);
            label2.Name = "label2";
            label2.Size = new Size(97, 62);
            label2.TabIndex = 18;
            label2.Text = "Quê quán";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 242);
            label3.Name = "label3";
            label3.Size = new Size(97, 37);
            label3.TabIndex = 19;
            label3.Text = "Quốc tịch";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // InfoCustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 539);
            Controls.Add(tableLayoutPanel1);
            Name = "InfoCustomerForm";
            Text = "InfoCustomerForm";
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button3;
        private Button button2;
        private Button btnThem;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label5;
        private TextBox txtNo;
        private TextBox txtFullName;
        private DateTimePicker dtpBirthDay;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private FlowLayoutPanel flowLayoutPanel2;
        private TextBox textBox2;
        private TextBox txtHuyen;
        private TextBox txtTinh;
        private TextBox textBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label6;
    }
}