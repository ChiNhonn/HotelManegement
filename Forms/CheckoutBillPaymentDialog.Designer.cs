namespace HotelManagement.Forms;

partial class CheckoutBillPaymentDialog
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
        lblGuest = new Label();
        lblStay = new Label();
        grid = new DataGridView();
        lblDiscount = new Label();
        lblTax = new Label();
        lblDeposit = new Label();
        lblTotal = new Label();
        lblNote = new Label();
        txtNote = new TextBox();
        lblMethod = new Label();
        radCash = new RadioButton();
        radTransfer = new RadioButton();
        btnPrint = new Button();
        btnPay = new Button();
        btnClose = new Button();
        ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblTitle.Location = new Point(16, 16);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(600, 28);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "HÓA ĐƠN";
        // 
        // lblGuest
        // 
        lblGuest.AutoSize = true;
        lblGuest.Location = new Point(16, 48);
        lblGuest.Name = "lblGuest";
        lblGuest.Size = new Size(50, 20);
        lblGuest.TabIndex = 1;
        lblGuest.Text = "Khách:";
        // 
        // lblStay
        // 
        lblStay.AutoSize = true;
        lblStay.Location = new Point(16, 70);
        lblStay.Name = "lblStay";
        lblStay.Size = new Size(38, 20);
        lblStay.TabIndex = 2;
        lblStay.Text = "Stay";
        // 
        // grid
        // 
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        grid.BackgroundColor = Color.White;
        grid.BorderStyle = BorderStyle.FixedSingle;
        grid.ColumnHeadersHeight = 32;
        grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        grid.EnableHeadersVisualStyles = false;
        grid.Location = new Point(16, 100);
        grid.Name = "grid";
        grid.ReadOnly = true;
        grid.RowHeadersVisible = false;
        grid.RowTemplate.Height = 28;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.Size = new Size(608, 180);
        grid.TabIndex = 3;
        // 
        // lblDiscount
        // 
        lblDiscount.AutoSize = true;
        lblDiscount.Location = new Point(16, 288);
        lblDiscount.Name = "lblDiscount";
        lblDiscount.Size = new Size(70, 20);
        lblDiscount.TabIndex = 4;
        lblDiscount.Text = "Giảm giá:";
        // 
        // lblTax
        // 
        lblTax.AutoSize = true;
        lblTax.Location = new Point(16, 308);
        lblTax.Name = "lblTax";
        lblTax.Size = new Size(42, 20);
        lblTax.TabIndex = 5;
        lblTax.Text = "Thuế:";
        // 
        // lblDeposit
        // 
        lblDeposit.AutoSize = true;
        lblDeposit.Location = new Point(16, 328);
        lblDeposit.Name = "lblDeposit";
        lblDeposit.Size = new Size(50, 20);
        lblDeposit.TabIndex = 6;
        lblDeposit.Text = "Đã cọc:";
        // 
        // lblTotal
        // 
        lblTotal.AutoSize = true;
        lblTotal.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblTotal.Location = new Point(16, 352);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(50, 24);
        lblTotal.TabIndex = 7;
        lblTotal.Text = "TỔNG";
        // 
        // lblNote
        // 
        lblNote.AutoSize = true;
        lblNote.Location = new Point(16, 384);
        lblNote.Name = "lblNote";
        lblNote.Size = new Size(141, 20);
        lblNote.TabIndex = 8;
        lblNote.Text = "Nội dung thanh toán";
        // 
        // txtNote
        // 
        txtNote.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtNote.Location = new Point(16, 406);
        txtNote.Name = "txtNote";
        txtNote.Size = new Size(608, 27);
        txtNote.TabIndex = 9;
        // 
        // lblMethod
        // 
        lblMethod.AutoSize = true;
        lblMethod.Location = new Point(16, 440);
        lblMethod.Name = "lblMethod";
        lblMethod.Size = new Size(78, 20);
        lblMethod.TabIndex = 10;
        lblMethod.Text = "Phương thức";
        // 
        // radCash
        // 
        radCash.AutoSize = true;
        radCash.Checked = true;
        radCash.Location = new Point(106, 438);
        radCash.Name = "radCash";
        radCash.Size = new Size(89, 24);
        radCash.TabIndex = 11;
        radCash.TabStop = true;
        radCash.Text = "Tiền mặt";
        radCash.UseVisualStyleBackColor = true;
        // 
        // radTransfer
        // 
        radTransfer.AutoSize = true;
        radTransfer.Location = new Point(216, 438);
        radTransfer.Name = "radTransfer";
        radTransfer.Size = new Size(118, 24);
        radTransfer.TabIndex = 12;
        radTransfer.Text = "Chuyển khoản";
        radTransfer.UseVisualStyleBackColor = true;
        // 
        // btnPrint
        // 
        btnPrint.BackColor = Color.FromArgb(100, 116, 139);
        btnPrint.FlatAppearance.BorderSize = 0;
        btnPrint.FlatStyle = FlatStyle.Flat;
        btnPrint.ForeColor = Color.White;
        btnPrint.Location = new Point(302, 472);
        btnPrint.Name = "btnPrint";
        btnPrint.Size = new Size(110, 34);
        btnPrint.TabIndex = 13;
        btnPrint.Text = "In hóa đơn";
        btnPrint.UseVisualStyleBackColor = false;
        btnPrint.Click += btnPrint_Click;
        // 
        // btnPay
        // 
        btnPay.BackColor = Color.FromArgb(59, 130, 246);
        btnPay.FlatAppearance.BorderSize = 0;
        btnPay.FlatStyle = FlatStyle.Flat;
        btnPay.ForeColor = Color.White;
        btnPay.Location = new Point(424, 472);
        btnPay.Name = "btnPay";
        btnPay.Size = new Size(120, 34);
        btnPay.TabIndex = 14;
        btnPay.Text = "Thanh toán";
        btnPay.UseVisualStyleBackColor = false;
        btnPay.Click += btnPay_Click;
        // 
        // btnClose
        // 
        btnClose.DialogResult = DialogResult.Cancel;
        btnClose.Location = new Point(536, 472);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(88, 34);
        btnClose.TabIndex = 15;
        btnClose.Text = "Đóng";
        btnClose.UseVisualStyleBackColor = true;
        // 
        // CheckoutBillPaymentDialog
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnClose;
        ClientSize = new Size(640, 520);
        Controls.Add(btnClose);
        Controls.Add(btnPay);
        Controls.Add(btnPrint);
        Controls.Add(radTransfer);
        Controls.Add(radCash);
        Controls.Add(lblMethod);
        Controls.Add(txtNote);
        Controls.Add(lblNote);
        Controls.Add(lblTotal);
        Controls.Add(lblDeposit);
        Controls.Add(lblTax);
        Controls.Add(lblDiscount);
        Controls.Add(grid);
        Controls.Add(lblStay);
        Controls.Add(lblGuest);
        Controls.Add(lblTitle);
        Font = new Font("Segoe UI", 9.5F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "CheckoutBillPaymentDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Hóa đơn — thanh toán";
        Load += CheckoutBillPaymentDialog_Load;
        Shown += CheckoutBillPaymentDialog_Shown;
        Resize += CheckoutBillPaymentDialog_Resize;
        ((System.ComponentModel.ISupportInitialize)grid).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle;
    private Label lblGuest;
    private Label lblStay;
    private DataGridView grid;
    private Label lblDiscount;
    private Label lblTax;
    private Label lblDeposit;
    private Label lblTotal;
    private Label lblNote;
    private TextBox txtNote;
    private Label lblMethod;
    private RadioButton radCash;
    private RadioButton radTransfer;
    private Button btnPrint;
    private Button btnPay;
    private Button btnClose;
}
