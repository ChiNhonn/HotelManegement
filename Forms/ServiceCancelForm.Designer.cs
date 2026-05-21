namespace HotelManagement.Forms;

partial class ServiceCancelForm
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
        lblTitle = new Label();
        lblReason = new Label();
        txtReason = new TextBox();
        lblFee = new Label();
        numFee = new NumericUpDown();
        btnOk = new Button();
        btnCancel = new Button();
        ((System.ComponentModel.ISupportInitialize)numFee).BeginInit();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblTitle.Location = new Point(16, 12);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(50, 21);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Hủy:";
        // 
        // lblReason
        // 
        lblReason.AutoSize = true;
        lblReason.Location = new Point(16, 44);
        lblReason.Name = "lblReason";
        lblReason.Size = new Size(44, 20);
        lblReason.TabIndex = 1;
        lblReason.Text = "Lý do";
        // 
        // txtReason
        // 
        txtReason.Location = new Point(16, 64);
        txtReason.Multiline = true;
        txtReason.Name = "txtReason";
        txtReason.Size = new Size(368, 70);
        txtReason.TabIndex = 2;
        // 
        // lblFee
        // 
        lblFee.AutoSize = true;
        lblFee.Location = new Point(16, 148);
        lblFee.Name = "lblFee";
        lblFee.Size = new Size(103, 20);
        lblFee.TabIndex = 3;
        lblFee.Text = "Phí hủy (VNĐ)";
        // 
        // numFee
        // 
        numFee.Location = new Point(140, 144);
        numFee.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
        numFee.Name = "numFee";
        numFee.Size = new Size(140, 27);
        numFee.TabIndex = 4;
        numFee.ThousandsSeparator = true;
        // 
        // btnOk
        // 
        btnOk.DialogResult = DialogResult.OK;
        btnOk.Location = new Point(200, 144);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(110, 29);
        btnOk.TabIndex = 5;
        btnOk.Text = "Xác nhận hủy";
        btnOk.UseVisualStyleBackColor = true;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(318, 144);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(70, 29);
        btnCancel.TabIndex = 6;
        btnCancel.Text = "Đóng";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // ServiceCancelForm
        // 
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(400, 200);
        Controls.Add(btnCancel);
        Controls.Add(btnOk);
        Controls.Add(numFee);
        Controls.Add(lblFee);
        Controls.Add(txtReason);
        Controls.Add(lblReason);
        Controls.Add(lblTitle);
        Font = new Font("Segoe UI", 9.5F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ServiceCancelForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Hủy dịch vụ";
        ((System.ComponentModel.ISupportInitialize)numFee).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle;
    private Label lblReason;
    private TextBox txtReason;
    private Label lblFee;
    private NumericUpDown numFee;
    private Button btnOk;
    private Button btnCancel;
}
