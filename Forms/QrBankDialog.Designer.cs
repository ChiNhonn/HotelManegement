namespace HotelManagement.Forms;

partial class QrBankDialog
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
            _qrBmp?.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblAmt = new Label();
        lblSub = new Label();
        lblMemo = new Label();
        picQr = new PictureBox();
        btnClose = new Button();
        ((System.ComponentModel.ISupportInitialize)picQr).BeginInit();
        SuspendLayout();
        // 
        // lblAmt
        // 
        lblAmt.Dock = DockStyle.Top;
        lblAmt.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblAmt.ForeColor = Color.FromArgb(15, 23, 42);
        lblAmt.Location = new Point(0, 0);
        lblAmt.Name = "lblAmt";
        lblAmt.Padding = new Padding(12, 14, 12, 6);
        lblAmt.Size = new Size(420, 52);
        lblAmt.TabIndex = 0;
        lblAmt.Text = "0 đ";
        lblAmt.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSub
        // 
        lblSub.Dock = DockStyle.Top;
        lblSub.Font = new Font("Segoe UI", 9F);
        lblSub.ForeColor = Color.FromArgb(100, 116, 139);
        lblSub.Location = new Point(0, 52);
        lblSub.Name = "lblSub";
        lblSub.Padding = new Padding(12, 0, 12, 8);
        lblSub.Size = new Size(420, 36);
        lblSub.TabIndex = 1;
        lblSub.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblMemo
        // 
        lblMemo.Dock = DockStyle.Top;
        lblMemo.Font = new Font("Segoe UI", 8.25F);
        lblMemo.ForeColor = Color.FromArgb(71, 85, 105);
        lblMemo.Location = new Point(0, 88);
        lblMemo.Name = "lblMemo";
        lblMemo.Padding = new Padding(16, 0, 16, 8);
        lblMemo.Size = new Size(420, 44);
        lblMemo.TabIndex = 2;
        lblMemo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // picQr
        // 
        picQr.BackColor = Color.White;
        picQr.Dock = DockStyle.Fill;
        picQr.Location = new Point(0, 132);
        picQr.Name = "picQr";
        picQr.Padding = new Padding(24, 8, 24, 8);
        picQr.Size = new Size(420, 412);
        picQr.SizeMode = PictureBoxSizeMode.Zoom;
        picQr.TabIndex = 3;
        picQr.TabStop = false;
        // 
        // btnClose
        // 
        btnClose.Cursor = Cursors.Hand;
        btnClose.DialogResult = DialogResult.OK;
        btnClose.Dock = DockStyle.Bottom;
        btnClose.FlatStyle = FlatStyle.Flat;
        btnClose.Font = new Font("Segoe UI", 10F);
        btnClose.Location = new Point(0, 544);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(420, 44);
        btnClose.TabIndex = 4;
        btnClose.Text = "Đóng";
        btnClose.UseVisualStyleBackColor = true;
        // 
        // QrBankDialog
        // 
        AcceptButton = btnClose;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        CancelButton = btnClose;
        ClientSize = new Size(420, 588);
        Controls.Add(picQr);
        Controls.Add(lblMemo);
        Controls.Add(lblSub);
        Controls.Add(lblAmt);
        Controls.Add(btnClose);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "QrBankDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "QR chuyển khoản";
        ((System.ComponentModel.ISupportInitialize)picQr).EndInit();
        ResumeLayout(false);
    }

    private Label lblAmt;
    private Label lblSub;
    private Label lblMemo;
    private PictureBox picQr;
    private Button btnClose;
}
