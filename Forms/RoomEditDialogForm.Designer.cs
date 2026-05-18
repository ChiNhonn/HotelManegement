namespace HotelManagement.Forms
{
    partial class RoomEditDialogForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtRoomNumber = new TextBox();
            cboRoomType = new ComboBox();
            lblStatus = new Label();
            lblFloor = new Label();
            cboFloor = new ComboBox();
            cboStatus = new ComboBox();
            lblRoomType = new Label();
            lblRoomNumber = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Font = new Font("Segoe UI", 10.8F);
            txtRoomNumber.Location = new Point(167, 3);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.PlaceholderText = "VD: 101 → tầng 1 (tự động)";
            txtRoomNumber.Size = new Size(268, 31);
            txtRoomNumber.TabIndex = 18;
            // 
            // cboRoomType
            // 
            cboRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoomType.Font = new Font("Segoe UI", 10.8F);
            cboRoomType.FormattingEnabled = true;
            cboRoomType.Location = new Point(167, 49);
            cboRoomType.Name = "cboRoomType";
            cboRoomType.Size = new Size(268, 33);
            cboRoomType.TabIndex = 21;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            lblStatus.Location = new Point(3, 151);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(104, 25);
            lblStatus.TabIndex = 17;
            lblStatus.Text = "Trạng thái:";
            // 
            // lblFloor
            // 
            lblFloor.AutoSize = true;
            lblFloor.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            lblFloor.Location = new Point(3, 99);
            lblFloor.Name = "lblFloor";
            lblFloor.Size = new Size(147, 25);
            lblFloor.TabIndex = 22;
            lblFloor.Text = "Tầng (tự động):";
            // 
            // cboFloor
            // 
            cboFloor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFloor.Enabled = false;
            cboFloor.Font = new Font("Segoe UI", 10.8F);
            cboFloor.FormattingEnabled = true;
            cboFloor.Location = new Point(167, 102);
            cboFloor.Name = "cboFloor";
            cboFloor.Size = new Size(268, 33);
            cboFloor.TabIndex = 23;
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Font = new Font("Segoe UI", 10.8F);
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(167, 154);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(268, 33);
            cboStatus.TabIndex = 19;
            // 
            // lblRoomType
            // 
            lblRoomType.AutoSize = true;
            lblRoomType.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            lblRoomType.Location = new Point(3, 46);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(112, 25);
            lblRoomType.TabIndex = 20;
            lblRoomType.Text = "Loại phòng:";
            lblRoomType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            lblRoomNumber.Location = new Point(3, 0);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(98, 25);
            lblRoomNumber.TabIndex = 16;
            lblRoomNumber.Text = "Số phòng:";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(3, 213);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(119, 60);
            btnCancel.TabIndex = 24;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.Location = new Point(345, 213);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(119, 60);
            btnSave.TabIndex = 25;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.11777F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.882225F));
            tableLayoutPanel1.Controls.Add(lblRoomNumber, 0, 0);
            tableLayoutPanel1.Controls.Add(btnSave, 1, 4);
            tableLayoutPanel1.Controls.Add(txtRoomNumber, 1, 0);
            tableLayoutPanel1.Controls.Add(btnCancel, 0, 4);
            tableLayoutPanel1.Controls.Add(cboStatus, 1, 3);
            tableLayoutPanel1.Controls.Add(cboRoomType, 1, 1);
            tableLayoutPanel1.Controls.Add(cboFloor, 1, 2);
            tableLayoutPanel1.Controls.Add(lblRoomType, 0, 1);
            tableLayoutPanel1.Controls.Add(lblFloor, 0, 2);
            tableLayoutPanel1.Controls.Add(lblStatus, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 46.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 53.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 59F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 122F));
            tableLayoutPanel1.Size = new Size(467, 333);
            tableLayoutPanel1.TabIndex = 26;
            // 
            // RoomEditDialogForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 333);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "RoomEditDialogForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Phòng";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtRoomNumber;
        private ComboBox cboRoomType;
        private Label lblStatus;
        private Label lblFloor;
        private ComboBox cboFloor;
        private ComboBox cboStatus;
        private Label lblRoomType;
        private Label lblRoomNumber;
        private Button btnCancel;
        private Button btnSave;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
