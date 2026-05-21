namespace HotelManagement.Forms;

partial class ManualPaymentDialog
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
        lblBill = new Label();
        cmbBill = new ComboBox();
        lblNote = new Label();
        txtNote = new TextBox();
        lblAmount = new Label();
        txtAmount = new TextBox();
        lblMethod = new Label();
        radCash = new RadioButton();
        radTransfer = new RadioButton();
        btnOk = new Button();
        btnCancel = new Button();
        SuspendLayout();
        // 
        // lblBill
        // 
        lblBill.AutoSize = true;
        lblBill.Location = new Point(16, 14);
        lblBill.Name = "lblBill";
        lblBill.Size = new Size(151, 20);
        lblBill.TabIndex = 0;
        lblBill.Text = "Chọn hóa đơn chờ thu";
        // 
        // cmbBill
        // 
        cmbBill.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        cmbBill.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbBill.FormattingEnabled = true;
        cmbBill.Location = new Point(16, 38);
        cmbBill.Name = "cmbBill";
        cmbBill.Size = new Size(488, 28);
        cmbBill.TabIndex = 1;
        cmbBill.SelectedIndexChanged += cmbBill_SelectedIndexChanged;
        // 
        // lblNote
        // 
        lblNote.AutoSize = true;
        lblNote.Location = new Point(16, 72);
        lblNote.Name = "lblNote";
        lblNote.Size = new Size(141, 20);
        lblNote.TabIndex = 2;
        lblNote.Text = "Nội dung thanh toán";
        // 
        // txtNote
        // 
        txtNote.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtNote.Location = new Point(16, 94);
        txtNote.Name = "txtNote";
        txtNote.Size = new Size(488, 27);
        txtNote.TabIndex = 3;
        // 
        // lblAmount
        // 
        lblAmount.AutoSize = true;
        lblAmount.Location = new Point(16, 133);
        lblAmount.Name = "lblAmount";
        lblAmount.Size = new Size(103, 20);
        lblAmount.TabIndex = 4;
        lblAmount.Text = "Số tiền (VNĐ)";
        lblAmount.Visible = false;
        // 
        // txtAmount
        // 
        txtAmount.Location = new Point(16, 155);
        txtAmount.Name = "txtAmount";
        txtAmount.Size = new Size(240, 27);
        txtAmount.TabIndex = 5;
        txtAmount.Visible = false;
        // 
        // lblMethod
        // 
        lblMethod.AutoSize = true;
        lblMethod.Location = new Point(16, 133);
        lblMethod.Name = "lblMethod";
        lblMethod.Size = new Size(168, 20);
        lblMethod.TabIndex = 6;
        lblMethod.Text = "Phương thức thanh toán";
        // 
        // radCash
        // 
        radCash.AutoSize = true;
        radCash.Checked = true;
        radCash.Location = new Point(16, 157);
        radCash.Name = "radCash";
        radCash.Size = new Size(89, 24);
        radCash.TabIndex = 7;
        radCash.TabStop = true;
        radCash.Text = "Tiền mặt";
        radCash.UseVisualStyleBackColor = true;
        // 
        // radTransfer
        // 
        radTransfer.AutoSize = true;
        radTransfer.Location = new Point(132, 157);
        radTransfer.Name = "radTransfer";
        radTransfer.Size = new Size(118, 24);
        radTransfer.TabIndex = 8;
        radTransfer.Text = "Chuyển khoản";
        radTransfer.UseVisualStyleBackColor = true;
        // 
        // btnOk
        // 
        btnOk.Location = new Point(296, 217);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(110, 32);
        btnOk.TabIndex = 9;
        btnOk.Text = "Ghi nhận";
        btnOk.UseVisualStyleBackColor = true;
        btnOk.Click += btnOk_Click;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(416, 217);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(88, 32);
        btnCancel.TabIndex = 10;
        btnCancel.Text = "Đóng";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // ManualPaymentDialog
        // 
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(520, 265);
        Controls.Add(btnCancel);
        Controls.Add(btnOk);
        Controls.Add(radTransfer);
        Controls.Add(radCash);
        Controls.Add(lblMethod);
        Controls.Add(txtAmount);
        Controls.Add(lblAmount);
        Controls.Add(txtNote);
        Controls.Add(lblNote);
        Controls.Add(cmbBill);
        Controls.Add(lblBill);
        Font = new Font("Segoe UI", 9.5F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ManualPaymentDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Thêm giao dịch — ghi nhận thanh toán";
        Shown += ManualPaymentDialog_Shown;
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblBill;
    private ComboBox cmbBill;
    private Label lblNote;
    private TextBox txtNote;
    private Label lblAmount;
    private TextBox txtAmount;
    private Label lblMethod;
    private RadioButton radCash;
    private RadioButton radTransfer;
    private Button btnOk;
    private Button btnCancel;
}
