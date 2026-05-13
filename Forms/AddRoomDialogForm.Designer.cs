namespace HotelManagement.Forms
{
    partial class AddRoomDialogForm
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
            pnlContent = new Panel();
            grpDetails = new GroupBox();
            btnAdd = new Button();
            btnCancel = new Button();
            lblRoomNumber = new Label();
            lblRoomType = new Label();
            cboStatus = new ComboBox();
            cboFloor = new ComboBox();
            lblFloor = new Label();
            lblStatus = new Label();
            cboRoomType = new ComboBox();
            txtRoomNumber = new TextBox();
            pnlContent.SuspendLayout();
            grpDetails.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(grpDetails);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 0);
            pnlContent.Margin = new Padding(3, 2, 3, 2);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(452, 360);
            pnlContent.TabIndex = 32;
            // 
            // grpDetails
            // 
            grpDetails.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpDetails.Controls.Add(btnAdd);
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
            grpDetails.Margin = new Padding(3, 2, 3, 2);
            grpDetails.Name = "grpDetails";
            grpDetails.Padding = new Padding(3, 2, 3, 2);
            grpDetails.Size = new Size(452, 360);
            grpDetails.TabIndex = 24;
            grpDetails.TabStop = false;
            grpDetails.Text = "Thông tin phòng";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(298, 285);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(104, 45);
            btnAdd.TabIndex = 15;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(44, 285);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(104, 45);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblRoomNumber.Location = new Point(40, 56);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(104, 25);
            lblRoomNumber.TabIndex = 1;
            lblRoomNumber.Text = "Số phòng:";
            // 
            // lblRoomType
            // 
            lblRoomType.AutoSize = true;
            lblRoomType.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblRoomType.Location = new Point(40, 104);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(118, 25);
            lblRoomType.TabIndex = 8;
            lblRoomType.Text = "Loại phòng:";
            lblRoomType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(182, 213);
            cboStatus.Margin = new Padding(3, 2, 3, 2);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(228, 29);
            cboStatus.TabIndex = 7;
            // 
            // cboFloor
            // 
            cboFloor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFloor.Enabled = false;
            cboFloor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cboFloor.FormattingEnabled = true;
            cboFloor.Location = new Point(182, 158);
            cboFloor.Margin = new Padding(3, 2, 3, 2);
            cboFloor.Name = "cboFloor";
            cboFloor.Size = new Size(228, 29);
            cboFloor.TabIndex = 13;
            // 
            // lblFloor
            // 
            lblFloor.AutoSize = true;
            lblFloor.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblFloor.Location = new Point(40, 158);
            lblFloor.Name = "lblFloor";
            lblFloor.Size = new Size(154, 25);
            lblFloor.TabIndex = 12;
            lblFloor.Text = "Tầng (tự động):";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblStatus.Location = new Point(40, 217);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(107, 25);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Trạng thái:";
            // 
            // cboRoomType
            // 
            cboRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoomType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cboRoomType.FormattingEnabled = true;
            cboRoomType.Location = new Point(182, 103);
            cboRoomType.Margin = new Padding(3, 2, 3, 2);
            cboRoomType.Name = "cboRoomType";
            cboRoomType.Size = new Size(228, 29);
            cboRoomType.TabIndex = 9;
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 163);
            txtRoomNumber.Location = new Point(182, 54);
            txtRoomNumber.Margin = new Padding(3, 2, 3, 2);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.PlaceholderText = "VD: 101 → tầng 1 (tự động)";
            txtRoomNumber.Size = new Size(228, 29);
            txtRoomNumber.TabIndex = 4;
            // 
            // AddRoomDialogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 360);
            Controls.Add(pnlContent);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddRoomDialogForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm phòng";
            Load += AddRoomDialogForm_Load;
            pnlContent.ResumeLayout(false);
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContent;
        private GroupBox grpDetails;
        private Label lblRoomNumber;
        private Label lblRoomType;
        private ComboBox cboStatus;
        private ComboBox cboFloor;
        private Label lblFloor;
        private Label lblStatus;
        private ComboBox cboRoomType;
        private TextBox txtRoomNumber;
        private Button btnAdd;
        private Button btnCancel;
    }
}
