namespace HotelManagement.Forms
{
    partial class UpdateRoomDialogForm
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
            grpDetails = new GroupBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblRoomNumber = new Label();
            lblRoomType = new Label();
            cboStatus = new ComboBox();
            cboFloor = new ComboBox();
            lblFloor = new Label();
            lblStatus = new Label();
            cboRoomType = new ComboBox();
            txtRoomNumber = new TextBox();
            grpDetails.SuspendLayout();
            SuspendLayout();
            //
            // grpDetails
            //
            grpDetails.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpDetails.Controls.Add(btnSave);
            grpDetails.Controls.Add(btnCancel);
            grpDetails.Controls.Add(lblRoomNumber);
            grpDetails.Controls.Add(lblRoomType);
            grpDetails.Controls.Add(cboStatus);
            grpDetails.Controls.Add(cboFloor);
            grpDetails.Controls.Add(lblFloor);
            grpDetails.Controls.Add(lblStatus);
            grpDetails.Controls.Add(cboRoomType);
            grpDetails.Controls.Add(txtRoomNumber);
            grpDetails.Dock = DockStyle.Fill;
            grpDetails.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            grpDetails.Location = new Point(0, 0);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new Size(539, 460);
            grpDetails.TabIndex = 25;
            grpDetails.TabStop = false;
            grpDetails.Text = "Thông tin phòng";
            //
            // btnSave
            //
            btnSave.Location = new Point(341, 360);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(119, 60);
            btnSave.TabIndex = 15;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            //
            // btnCancel
            //
            btnCancel.Location = new Point(74, 360);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(119, 60);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            //
            // lblRoomNumber
            //
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblRoomNumber.Location = new Point(46, 75);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(123, 31);
            lblRoomNumber.TabIndex = 1;
            lblRoomNumber.Text = "Số phòng:";
            //
            // lblRoomType
            //
            lblRoomType.AutoSize = true;
            lblRoomType.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblRoomType.Location = new Point(46, 138);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(147, 31);
            lblRoomType.TabIndex = 8;
            lblRoomType.Text = "Loại phòng:";
            lblRoomType.TextAlign = ContentAlignment.MiddleCenter;
            //
            // cboStatus
            //
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(208, 284);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(316, 36);
            cboStatus.TabIndex = 7;
            //
            // cboFloor
            //
            cboFloor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFloor.Enabled = false;
            cboFloor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cboFloor.FormattingEnabled = true;
            cboFloor.Location = new Point(208, 210);
            cboFloor.Name = "cboFloor";
            cboFloor.Size = new Size(316, 36);
            cboFloor.TabIndex = 13;
            //
            // lblFloor
            //
            lblFloor.AutoSize = true;
            lblFloor.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblFloor.Location = new Point(46, 210);
            lblFloor.Name = "lblFloor";
            lblFloor.Size = new Size(138, 31);
            lblFloor.TabIndex = 12;
            lblFloor.Text = "Tầng (tự động):";
            //
            // lblStatus
            //
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblStatus.Location = new Point(46, 289);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(138, 31);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Trạng thái:";
            //
            // cboRoomType
            //
            cboRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoomType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cboRoomType.FormattingEnabled = true;
            cboRoomType.Location = new Point(208, 137);
            cboRoomType.Name = "cboRoomType";
            cboRoomType.Size = new Size(316, 36);
            cboRoomType.TabIndex = 9;
            //
            // txtRoomNumber
            //
            txtRoomNumber.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 163);
            txtRoomNumber.Location = new Point(208, 72);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.PlaceholderText = "VD: 101 → tầng 1 (tự động)";
            txtRoomNumber.Size = new Size(316, 34);
            txtRoomNumber.TabIndex = 4;
            //
            // UpdateRoomDialogForm
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 460);
            Controls.Add(grpDetails);
            Name = "UpdateRoomDialogForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sửa phòng";
            Load += UpdateRoomDialogForm_Load;
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDetails;
        private Button btnSave;
        private Button btnCancel;
        private Label lblRoomNumber;
        private Label lblRoomType;
        private ComboBox cboStatus;
        private ComboBox cboFloor;
        private Label lblFloor;
        private Label lblStatus;
        private ComboBox cboRoomType;
        private TextBox txtRoomNumber;
    }
}
