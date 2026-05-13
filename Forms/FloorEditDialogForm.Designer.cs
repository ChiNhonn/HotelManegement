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
        private TableLayoutPanel layout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            layout = new TableLayoutPanel();
            lblName = new Label();
            txtName = new TextBox();
            lblBranch = new Label();
            cmbBranch = new ComboBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            layout.SuspendLayout();
            //
            // layout
            //
            layout.ColumnCount = 2;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.Controls.Add(lblName, 0, 0);
            layout.Controls.Add(txtName, 1, 0);
            layout.Controls.Add(lblBranch, 0, 1);
            layout.Controls.Add(cmbBranch, 1, 1);
            layout.Controls.Add(btnOk, 0, 2);
            layout.Controls.Add(btnCancel, 1, 2);
            layout.Dock = DockStyle.Fill;
            layout.Location = new Point(12, 12);
            layout.Margin = new Padding(3, 4, 3, 4);
            layout.Name = "layout";
            layout.Padding = new Padding(0, 0, 0, 8);
            layout.RowCount = 3;
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            layout.Size = new Size(496, 156);
            layout.TabIndex = 0;
            //
            // lblName
            //
            lblName.Anchor = AnchorStyles.Left;
            lblName.AutoSize = true;
            lblName.Location = new Point(3, 10);
            lblName.Margin = new Padding(3, 0, 3, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(85, 23);
            lblName.TabIndex = 0;
            lblName.Text = "Tên tầng";
            //
            // txtName
            //
            txtName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(113, 6);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.MaxLength = 100;
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Ví dụ: Tầng 1, Khu Villa A…";
            txtName.Size = new Size(380, 30);
            txtName.TabIndex = 1;
            //
            // lblBranch
            //
            lblBranch.Anchor = AnchorStyles.Left;
            lblBranch.AutoSize = true;
            lblBranch.Location = new Point(3, 54);
            lblBranch.Margin = new Padding(3, 0, 3, 0);
            lblBranch.Name = "lblBranch";
            lblBranch.Size = new Size(83, 23);
            lblBranch.TabIndex = 2;
            lblBranch.Text = "Chi nhánh";
            //
            // cmbBranch
            //
            cmbBranch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbBranch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranch.FormattingEnabled = true;
            cmbBranch.Location = new Point(113, 50);
            cmbBranch.Margin = new Padding(3, 4, 3, 4);
            cmbBranch.Name = "cmbBranch";
            cmbBranch.Size = new Size(380, 31);
            cmbBranch.TabIndex = 3;
            //
            // btnOk
            //
            btnOk.Anchor = AnchorStyles.Left;
            btnOk.BackColor = Color.FromArgb(21, 128, 61);
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(3, 92);
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
            btnCancel.Location = new Point(389, 92);
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
            Controls.Add(layout);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(400, 180);
            Name = "FloorEditDialogForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tầng";
            Load += FloorEditDialogForm_Load;
            layout.ResumeLayout(false);
            layout.PerformLayout();
            ResumeLayout(false);
        }
    }
}
