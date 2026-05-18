namespace HotelManagement.Forms
{
    partial class RoomTypeEditDialogForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlRoot = new Panel();
            lblTypeCode = new Label();
            txtTypeCode = new TextBox();
            lblDisplayName = new Label();
            txtDisplayName = new TextBox();
            lblBasePrice = new Label();
            numBasePrice = new NumericUpDown();
            lblMaxAdults = new Label();
            numMaxAdults = new NumericUpDown();
            lblMaxChildren = new Label();
            numMaxChildren = new NumericUpDown();
            lblBedType = new Label();
            cmbBedType = new ComboBox();
            lblNotes = new Label();
            txtNotes = new TextBox();
            btnCancel = new Button();
            btnSave = new Button();
            pnlRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBasePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxAdults).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxChildren).BeginInit();
            SuspendLayout();
            // 
            // pnlRoot
            // 
            pnlRoot.AutoScroll = true;
            pnlRoot.Controls.Add(lblTypeCode);
            pnlRoot.Controls.Add(txtTypeCode);
            pnlRoot.Controls.Add(lblDisplayName);
            pnlRoot.Controls.Add(txtDisplayName);
            pnlRoot.Controls.Add(lblBasePrice);
            pnlRoot.Controls.Add(numBasePrice);
            pnlRoot.Controls.Add(lblMaxAdults);
            pnlRoot.Controls.Add(numMaxAdults);
            pnlRoot.Controls.Add(lblMaxChildren);
            pnlRoot.Controls.Add(numMaxChildren);
            pnlRoot.Controls.Add(lblBedType);
            pnlRoot.Controls.Add(cmbBedType);
            pnlRoot.Controls.Add(lblNotes);
            pnlRoot.Controls.Add(txtNotes);
            pnlRoot.Controls.Add(btnCancel);
            pnlRoot.Controls.Add(btnSave);
            pnlRoot.Dock = DockStyle.Fill;
            pnlRoot.Location = new Point(0, 0);
            pnlRoot.Name = "pnlRoot";
            pnlRoot.Padding = new Padding(12);
            pnlRoot.Size = new Size(598, 450);
            pnlRoot.TabIndex = 0;
            // 
            // lblTypeCode
            // 
            lblTypeCode.AutoSize = true;
            lblTypeCode.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTypeCode.Location = new Point(16, 18);
            lblTypeCode.Name = "lblTypeCode";
            lblTypeCode.Size = new Size(219, 25);
            lblTypeCode.TabIndex = 0;
            lblTypeCode.Text = "Mã loại (STD, DLX, SUI)";
            // 
            // txtTypeCode
            // 
            txtTypeCode.Font = new Font("Segoe UI", 11F);
            txtTypeCode.Location = new Point(260, 14);
            txtTypeCode.MaxLength = 20;
            txtTypeCode.Name = "txtTypeCode";
            txtTypeCode.PlaceholderText = "VD: STD";
            txtTypeCode.Size = new Size(300, 32);
            txtTypeCode.TabIndex = 1;
            // 
            // lblDisplayName
            // 
            lblDisplayName.AutoSize = true;
            lblDisplayName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDisplayName.Location = new Point(16, 62);
            lblDisplayName.Name = "lblDisplayName";
            lblDisplayName.Size = new Size(149, 25);
            lblDisplayName.TabIndex = 2;
            lblDisplayName.Text = "Tên loại phòng ";
            // 
            // txtDisplayName
            // 
            txtDisplayName.Font = new Font("Segoe UI", 11F);
            txtDisplayName.Location = new Point(260, 58);
            txtDisplayName.Name = "txtDisplayName";
            txtDisplayName.PlaceholderText = "Ví dụ: Phòng Deluxe hướng biển";
            txtDisplayName.Size = new Size(300, 32);
            txtDisplayName.TabIndex = 2;
            // 
            // lblBasePrice
            // 
            lblBasePrice.AutoSize = true;
            lblBasePrice.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBasePrice.Location = new Point(16, 106);
            lblBasePrice.Name = "lblBasePrice";
            lblBasePrice.Size = new Size(244, 25);
            lblBasePrice.TabIndex = 4;
            lblBasePrice.Text = "Giá mặc định (VNĐ/đêm)*";
            // 
            // numBasePrice
            // 
            numBasePrice.Font = new Font("Segoe UI", 11F);
            numBasePrice.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            numBasePrice.Location = new Point(260, 102);
            numBasePrice.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numBasePrice.Name = "numBasePrice";
            numBasePrice.Size = new Size(300, 32);
            numBasePrice.TabIndex = 3;
            numBasePrice.ThousandsSeparator = true;
            // 
            // lblMaxAdults
            // 
            lblMaxAdults.AutoSize = true;
            lblMaxAdults.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMaxAdults.Location = new Point(16, 150);
            lblMaxAdults.Name = "lblMaxAdults";
            lblMaxAdults.Size = new Size(184, 25);
            lblMaxAdults.TabIndex = 6;
            lblMaxAdults.Text = "Số người lớn tối đa";
            // 
            // numMaxAdults
            // 
            numMaxAdults.Font = new Font("Segoe UI", 11F);
            numMaxAdults.Location = new Point(260, 146);
            numMaxAdults.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numMaxAdults.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxAdults.Name = "numMaxAdults";
            numMaxAdults.Size = new Size(120, 32);
            numMaxAdults.TabIndex = 4;
            numMaxAdults.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lblMaxChildren
            // 
            lblMaxChildren.AutoSize = true;
            lblMaxChildren.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMaxChildren.Location = new Point(16, 190);
            lblMaxChildren.Name = "lblMaxChildren";
            lblMaxChildren.Size = new Size(153, 25);
            lblMaxChildren.TabIndex = 8;
            lblMaxChildren.Text = "Số trẻ em tối đa";
            // 
            // numMaxChildren
            // 
            numMaxChildren.Font = new Font("Segoe UI", 11F);
            numMaxChildren.Location = new Point(260, 186);
            numMaxChildren.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numMaxChildren.Name = "numMaxChildren";
            numMaxChildren.Size = new Size(120, 32);
            numMaxChildren.TabIndex = 5;
            // 
            // lblBedType
            // 
            lblBedType.AutoSize = true;
            lblBedType.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBedType.Location = new Point(16, 234);
            lblBedType.Name = "lblBedType";
            lblBedType.Size = new Size(187, 25);
            lblBedType.TabIndex = 10;
            lblBedType.Text = "Loại giường / bố trí";
            // 
            // cmbBedType
            // 
            cmbBedType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBedType.Font = new Font("Segoe UI", 11F);
            cmbBedType.FormattingEnabled = true;
            cmbBedType.Location = new Point(260, 230);
            cmbBedType.Name = "cmbBedType";
            cmbBedType.Size = new Size(300, 33);
            cmbBedType.TabIndex = 6;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNotes.Location = new Point(16, 282);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(147, 25);
            lblNotes.TabIndex = 12;
            lblNotes.Text = "Mô tả / ghi chú";
            // 
            // txtNotes
            // 
            txtNotes.Font = new Font("Segoe UI", 10.5F);
            txtNotes.Location = new Point(260, 278);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.PlaceholderText = "Tiện nghi, view, ghi chú hiển thị nội bộ…";
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(300, 84);
            txtNotes.TabIndex = 7;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.Location = new Point(16, 376);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(148, 44);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.Location = new Point(412, 376);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(148, 44);
            btnSave.TabIndex = 9;
            btnSave.Text = "Lưu thay đổi";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // RoomTypeEditDialogForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 450);
            Controls.Add(pnlRoot);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RoomTypeEditDialogForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Loại Phòng";
            pnlRoot.ResumeLayout(false);
            pnlRoot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBasePrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxAdults).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxChildren).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRoot;
        private Label lblTypeCode;
        private TextBox txtTypeCode;
        private Label lblDisplayName;
        private TextBox txtDisplayName;
        private Label lblBasePrice;
        private NumericUpDown numBasePrice;
        private Label lblMaxAdults;
        private NumericUpDown numMaxAdults;
        private Label lblMaxChildren;
        private NumericUpDown numMaxChildren;
        private Label lblBedType;
        private ComboBox cmbBedType;
        private Label lblNotes;
        private TextBox txtNotes;
        private Button btnCancel;
        private Button btnSave;
    }
}
