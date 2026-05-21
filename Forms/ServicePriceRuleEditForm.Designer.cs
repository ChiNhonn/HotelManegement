namespace HotelManagement.Forms;

partial class ServicePriceRuleEditForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblService = new Label();
        cboSvc = new ComboBox();
        lblRuleName = new Label();
        txtName = new TextBox();
        lblType = new Label();
        cboType = new ComboBox();
        lblPrice = new Label();
        numPrice = new NumericUpDown();
        lblDateRange = new Label();
        dtpFrom = new DateTimePicker();
        dtpTo = new DateTimePicker();
        lblTime = new Label();
        txtTimeStart = new TextBox();
        txtTimeEnd = new TextBox();
        lblPriority = new Label();
        numPri = new NumericUpDown();
        btnOk = new Button();
        btnCancel = new Button();
        ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numPri).BeginInit();
        SuspendLayout();
        // 
        // lblService
        // 
        lblService.AutoSize = true;
        lblService.Location = new Point(12, 16);
        lblService.Name = "lblService";
        lblService.Size = new Size(57, 20);
        lblService.TabIndex = 0;
        lblService.Text = "Dịch vụ";
        // 
        // cboSvc
        // 
        cboSvc.DropDownStyle = ComboBoxStyle.DropDownList;
        cboSvc.FormattingEnabled = true;
        cboSvc.Location = new Point(120, 12);
        cboSvc.Name = "cboSvc";
        cboSvc.Size = new Size(280, 28);
        cboSvc.TabIndex = 1;
        // 
        // lblRuleName
        // 
        lblRuleName.AutoSize = true;
        lblRuleName.Location = new Point(12, 48);
        lblRuleName.Name = "lblRuleName";
        lblRuleName.Size = new Size(89, 20);
        lblRuleName.TabIndex = 2;
        lblRuleName.Text = "Tên quy tắc";
        // 
        // txtName
        // 
        txtName.Location = new Point(120, 44);
        txtName.Name = "txtName";
        txtName.Size = new Size(280, 27);
        txtName.TabIndex = 3;
        // 
        // lblType
        // 
        lblType.AutoSize = true;
        lblType.Location = new Point(12, 80);
        lblType.Name = "lblType";
        lblType.Size = new Size(37, 20);
        lblType.TabIndex = 4;
        lblType.Text = "Loại";
        // 
        // cboType
        // 
        cboType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboType.FormattingEnabled = true;
        cboType.Location = new Point(120, 76);
        cboType.Name = "cboType";
        cboType.Size = new Size(280, 28);
        cboType.TabIndex = 5;
        // 
        // lblPrice
        // 
        lblPrice.AutoSize = true;
        lblPrice.Location = new Point(12, 112);
        lblPrice.Name = "lblPrice";
        lblPrice.Size = new Size(89, 20);
        lblPrice.TabIndex = 6;
        lblPrice.Text = "Giá áp dụng";
        // 
        // numPrice
        // 
        numPrice.Location = new Point(120, 108);
        numPrice.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
        numPrice.Name = "numPrice";
        numPrice.Size = new Size(140, 27);
        numPrice.TabIndex = 7;
        numPrice.ThousandsSeparator = true;
        // 
        // lblDateRange
        // 
        lblDateRange.AutoSize = true;
        lblDateRange.Location = new Point(12, 144);
        lblDateRange.Name = "lblDateRange";
        lblDateRange.Size = new Size(103, 20);
        lblDateRange.TabIndex = 8;
        lblDateRange.Text = "Từ ngày → đến";
        // 
        // dtpFrom
        // 
        dtpFrom.Format = DateTimePickerFormat.Short;
        dtpFrom.Location = new Point(120, 140);
        dtpFrom.Name = "dtpFrom";
        dtpFrom.ShowCheckBox = true;
        dtpFrom.Size = new Size(130, 27);
        dtpFrom.TabIndex = 9;
        // 
        // dtpTo
        // 
        dtpTo.Format = DateTimePickerFormat.Short;
        dtpTo.Location = new Point(270, 140);
        dtpTo.Name = "dtpTo";
        dtpTo.ShowCheckBox = true;
        dtpTo.Size = new Size(130, 27);
        dtpTo.TabIndex = 10;
        // 
        // lblTime
        // 
        lblTime.AutoSize = true;
        lblTime.Location = new Point(12, 176);
        lblTime.Name = "lblTime";
        lblTime.Size = new Size(99, 20);
        lblTime.TabIndex = 11;
        lblTime.Text = "Giờ (HH:mm)";
        // 
        // txtTimeStart
        // 
        txtTimeStart.Location = new Point(120, 172);
        txtTimeStart.Name = "txtTimeStart";
        txtTimeStart.Size = new Size(80, 27);
        txtTimeStart.TabIndex = 12;
        // 
        // txtTimeEnd
        // 
        txtTimeEnd.Location = new Point(220, 172);
        txtTimeEnd.Name = "txtTimeEnd";
        txtTimeEnd.Size = new Size(80, 27);
        txtTimeEnd.TabIndex = 13;
        // 
        // lblPriority
        // 
        lblPriority.AutoSize = true;
        lblPriority.Location = new Point(12, 208);
        lblPriority.Name = "lblPriority";
        lblPriority.Size = new Size(58, 20);
        lblPriority.TabIndex = 14;
        lblPriority.Text = "Ưu tiên";
        // 
        // numPri
        // 
        numPri.Location = new Point(120, 204);
        numPri.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
        numPri.Name = "numPri";
        numPri.Size = new Size(80, 27);
        numPri.TabIndex = 15;
        // 
        // btnOk
        // 
        btnOk.DialogResult = DialogResult.OK;
        btnOk.Location = new Point(220, 250);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(80, 29);
        btnOk.TabIndex = 16;
        btnOk.Text = "Lưu";
        btnOk.UseVisualStyleBackColor = true;
        btnOk.Click += btnOk_Click;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(310, 250);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(80, 29);
        btnCancel.TabIndex = 17;
        btnCancel.Text = "Hủy";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // ServicePriceRuleEditForm
        // 
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(420, 340);
        Controls.Add(btnCancel);
        Controls.Add(btnOk);
        Controls.Add(numPri);
        Controls.Add(lblPriority);
        Controls.Add(txtTimeEnd);
        Controls.Add(txtTimeStart);
        Controls.Add(lblTime);
        Controls.Add(dtpTo);
        Controls.Add(dtpFrom);
        Controls.Add(lblDateRange);
        Controls.Add(numPrice);
        Controls.Add(lblPrice);
        Controls.Add(cboType);
        Controls.Add(lblType);
        Controls.Add(txtName);
        Controls.Add(lblRuleName);
        Controls.Add(cboSvc);
        Controls.Add(lblService);
        Font = new Font("Segoe UI", 9.5F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ServicePriceRuleEditForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Quy tắc giá";
        ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
        ((System.ComponentModel.ISupportInitialize)numPri).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblService;
    private ComboBox cboSvc;
    private Label lblRuleName;
    private TextBox txtName;
    private Label lblType;
    private ComboBox cboType;
    private Label lblPrice;
    private NumericUpDown numPrice;
    private Label lblDateRange;
    private DateTimePicker dtpFrom;
    private DateTimePicker dtpTo;
    private Label lblTime;
    private TextBox txtTimeStart;
    private TextBox txtTimeEnd;
    private Label lblPriority;
    private NumericUpDown numPri;
    private Button btnOk;
    private Button btnCancel;
}
