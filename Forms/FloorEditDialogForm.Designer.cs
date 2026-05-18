namespace HotelManagement.Forms
{
    partial class FloorEditDialogForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblName;
        private TextBox txtName;
        private Label lblBranch;
        private ComboBox cmbBranch;
        private Button btnOk;
        private Button btnCancel;
        private TableLayoutPanel tlpTang;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tlpTang = new TableLayoutPanel();
            lblName = new Label();
            txtName = new TextBox();
            lblBranch = new Label();
            cmbBranch = new ComboBox();
            btnOk = new Button();
            btnCancel = new Button();
            tlpTang.SuspendLayout();
            SuspendLayout();
            // 
            // tlpTang
            // 
            tlpTang.ColumnCount = 2;
            tlpTang.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tlpTang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpTang.Controls.Add(lblName, 0, 0);
            tlpTang.Controls.Add(txtName, 1, 0);
            tlpTang.Controls.Add(lblBranch, 0, 1);
            tlpTang.Controls.Add(cmbBranch, 1, 1);
            tlpTang.Controls.Add(btnOk, 0, 2);
            tlpTang.Controls.Add(btnCancel, 1, 2);
            tlpTang.Dock = DockStyle.Fill;
            tlpTang.Location = new Point(0, 0);
            tlpTang.Margin = new Padding(3, 4, 3, 4);
            tlpTang.Name = "tlpTang";
            tlpTang.Padding = new Padding(0, 0, 0, 8);
            tlpTang.RowCount = 3;
            tlpTang.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tlpTang.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tlpTang.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tlpTang.Size = new Size(520, 180);
            tlpTang.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Left;
            lblName.AutoSize = true;
            lblName.Location = new Point(3, 12);
            lblName.Name = "lblName";
            lblName.Size = new Size(66, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Tên tầng";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(113, 8);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.MaxLength = 100;
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Ví dụ: Tầng 1, Khu Villa A…";
            txtName.Size = new Size(404, 27);
            txtName.TabIndex = 1;
            // 
            // lblBranch
            // 
            lblBranch.Anchor = AnchorStyles.Left;
            lblBranch.AutoSize = true;
            lblBranch.Location = new Point(3, 56);
            lblBranch.Name = "lblBranch";
            lblBranch.Size = new Size(74, 20);
            lblBranch.TabIndex = 2;
            lblBranch.Text = "Chi nhánh";
            // 
            // cmbBranch
            // 
            cmbBranch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbBranch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranch.FormattingEnabled = true;
            cmbBranch.Location = new Point(113, 52);
            cmbBranch.Margin = new Padding(3, 4, 3, 4);
            cmbBranch.Name = "cmbBranch";
            cmbBranch.Size = new Size(404, 28);
            cmbBranch.TabIndex = 3;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Left;
            btnOk.BackColor = Color.FromArgb(21, 128, 61);
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(3, 111);
            btnOk.Margin = new Padding(3, 4, 3, 4);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(104, 38);
            btnOk.TabIndex = 4;
            btnOk.Text = "Lưu";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += BtnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Right;
            btnCancel.Location = new Point(413, 111);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(104, 38);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // FloorEditDialogForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 180);
            Controls.Add(tlpTang);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(400, 180);
            Name = "FloorEditDialogForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tầng";
            Load += FloorEditDialogForm_Load;
            tlpTang.ResumeLayout(false);
            tlpTang.PerformLayout();
            ResumeLayout(false);
        }
    }
}
