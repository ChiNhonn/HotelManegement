namespace HotelManagement.Forms;

partial class BulkCreateRoomsDialog
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
        tlpMain = new TableLayoutPanel();
        lblRange = new Label();
        flpRange = new FlowLayoutPanel();
        lblRangeTo = new Label();
        numTo = new NumericUpDown();
        numFrom = new NumericUpDown();
        txtPrefix = new TextBox();
        lblPrefix = new Label();
        lblFloor = new Label();
        cboRoomType = new ComboBox();
        lblRoomType = new Label();
        cboFloor = new ComboBox();
        pnlButton = new Panel();
        btnCreate = new Button();
        btnCancel = new Button();
        tlpMain.SuspendLayout();
        flpRange.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numTo).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numFrom).BeginInit();
        pnlButton.SuspendLayout();
        SuspendLayout();
        // 
        // tlpMain
        // 
        tlpMain.ColumnCount = 2;
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 147F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpMain.Controls.Add(lblRoomType, 0, 0);
        tlpMain.Controls.Add(cboRoomType, 1, 0);
        tlpMain.Controls.Add(lblFloor, 0, 1);
        tlpMain.Controls.Add(cboFloor, 1, 1);
        tlpMain.Controls.Add(lblPrefix, 0, 2);
        tlpMain.Controls.Add(txtPrefix, 1, 2);
        tlpMain.Controls.Add(lblRange, 0, 3);
        tlpMain.Controls.Add(flpRange, 1, 3);
        tlpMain.Controls.Add(pnlButton, 1, 4);
        tlpMain.Dock = DockStyle.Fill;
        tlpMain.Location = new Point(0, 0);
        tlpMain.Margin = new Padding(3, 2, 3, 2);
        tlpMain.Name = "tlpMain";
        tlpMain.Padding = new Padding(12, 9, 12, 9);
        tlpMain.RowCount = 5;
        tlpMain.RowStyles.Add(new RowStyle());
        tlpMain.RowStyles.Add(new RowStyle());
        tlpMain.RowStyles.Add(new RowStyle());
        tlpMain.RowStyles.Add(new RowStyle());
        tlpMain.RowStyles.Add(new RowStyle());
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpMain.Size = new Size(455, 224);
        tlpMain.TabIndex = 0;
        // 
        // lblRange
        // 
        lblRange.Anchor = AnchorStyles.Right;
        lblRange.AutoSize = true;
        lblRange.Location = new Point(52, 114);
        lblRange.Margin = new Padding(3, 4, 7, 2);
        lblRange.Name = "lblRange";
        lblRange.Size = new Size(100, 15);
        lblRange.TabIndex = 6;
        lblRange.Text = "Số thứ tự từ / đến";
        // 
        // flpRange
        // 
        flpRange.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        flpRange.AutoSize = true;
        flpRange.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        flpRange.Controls.Add(numFrom);
        flpRange.Controls.Add(lblRangeTo);
        flpRange.Controls.Add(numTo);
        flpRange.Location = new Point(162, 103);
        flpRange.Margin = new Padding(3, 0, 3, 6);
        flpRange.Name = "flpRange";
        flpRange.Padding = new Padding(0, 3, 0, 0);
        flpRange.Size = new Size(278, 30);
        flpRange.TabIndex = 7;
        flpRange.WrapContents = false;
        // 
        // lblRangeTo
        // 
        lblRangeTo.Anchor = AnchorStyles.Left;
        lblRangeTo.AutoSize = true;
        lblRangeTo.Location = new Point(93, 11);
        lblRangeTo.Margin = new Padding(3, 6, 10, 2);
        lblRangeTo.Name = "lblRangeTo";
        lblRangeTo.Size = new Size(27, 15);
        lblRangeTo.TabIndex = 1;
        lblRangeTo.Text = "đến";
        // 
        // numTo
        // 
        numTo.Location = new Point(133, 5);
        numTo.Margin = new Padding(3, 2, 3, 2);
        numTo.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        numTo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numTo.Name = "numTo";
        numTo.Size = new Size(77, 23);
        numTo.TabIndex = 2;
        numTo.Value = new decimal(new int[] { 10, 0, 0, 0 });
        // 
        // numFrom
        // 
        numFrom.Location = new Point(3, 5);
        numFrom.Margin = new Padding(3, 2, 10, 2);
        numFrom.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        numFrom.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numFrom.Name = "numFrom";
        numFrom.Size = new Size(77, 23);
        numFrom.TabIndex = 0;
        numFrom.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // txtPrefix
        // 
        txtPrefix.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtPrefix.Location = new Point(162, 71);
        txtPrefix.Margin = new Padding(3, 0, 3, 6);
        txtPrefix.Name = "txtPrefix";
        txtPrefix.PlaceholderText = "Để trống: chỉ số thuần";
        txtPrefix.Size = new Size(278, 23);
        txtPrefix.TabIndex = 5;
        // 
        // lblPrefix
        // 
        lblPrefix.Anchor = AnchorStyles.Right;
        lblPrefix.AutoSize = true;
        lblPrefix.Location = new Point(31, 71);
        lblPrefix.Margin = new Padding(3, 0, 7, 2);
        lblPrefix.Name = "lblPrefix";
        lblPrefix.Size = new Size(121, 30);
        lblPrefix.TabIndex = 4;
        lblPrefix.Text = "Tiền tố (VD: 3 → 301…310)";
        // 
        // lblFloor
        // 
        lblFloor.Anchor = AnchorStyles.Right;
        lblFloor.AutoSize = true;
        lblFloor.Location = new Point(60, 48);
        lblFloor.Margin = new Padding(3, 0, 7, 2);
        lblFloor.Name = "lblFloor";
        lblFloor.Size = new Size(92, 15);
        lblFloor.TabIndex = 2;
        lblFloor.Text = "Tầng (tùy chọn)";
        // 
        // cboRoomType
        // 
        cboRoomType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        cboRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboRoomType.FormattingEnabled = true;
        cboRoomType.Location = new Point(162, 13);
        cboRoomType.Margin = new Padding(3, 4, 3, 6);
        cboRoomType.Name = "cboRoomType";
        cboRoomType.Size = new Size(278, 23);
        cboRoomType.TabIndex = 1;
        // 
        // lblRoomType
        // 
        lblRoomType.Anchor = AnchorStyles.Right;
        lblRoomType.AutoSize = true;
        lblRoomType.Location = new Point(77, 21);
        lblRoomType.Margin = new Padding(3, 8, 7, 2);
        lblRoomType.Name = "lblRoomType";
        lblRoomType.Size = new Size(75, 15);
        lblRoomType.TabIndex = 0;
        lblRoomType.Text = "Loại phòng *";
        // 
        // cboFloor
        // 
        cboFloor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        cboFloor.DropDownStyle = ComboBoxStyle.DropDownList;
        cboFloor.FormattingEnabled = true;
        cboFloor.Location = new Point(162, 42);
        cboFloor.Margin = new Padding(3, 0, 3, 6);
        cboFloor.Name = "cboFloor";
        cboFloor.Size = new Size(278, 23);
        cboFloor.TabIndex = 3;
        // 
        // pnlButton
        // 
        pnlButton.Controls.Add(btnCreate);
        pnlButton.Controls.Add(btnCancel);
        pnlButton.Location = new Point(162, 142);
        pnlButton.Name = "pnlButton";
        pnlButton.Size = new Size(267, 69);
        pnlButton.TabIndex = 8;
        // 
        // btnCreate
        // 
        btnCreate.Location = new Point(30, 19);
        btnCreate.Margin = new Padding(3, 2, 10, 2);
        btnCreate.Name = "btnCreate";
        btnCreate.Size = new Size(105, 25);
        btnCreate.TabIndex = 2;
        btnCreate.Text = "Tạo phòng";
        btnCreate.UseVisualStyleBackColor = true;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(148, 19);
        btnCancel.Margin = new Padding(3, 2, 3, 2);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(88, 25);
        btnCancel.TabIndex = 3;
        btnCancel.Text = "Đóng";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // BulkCreateRoomsDialog
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(455, 224);
        Controls.Add(tlpMain);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Margin = new Padding(3, 2, 3, 2);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "BulkCreateRoomsDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Tạo hàng loạt phòng";
        Load += BulkCreateRoomsDialog_Load;
        tlpMain.ResumeLayout(false);
        tlpMain.PerformLayout();
        flpRange.ResumeLayout(false);
        flpRange.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numTo).EndInit();
        ((System.ComponentModel.ISupportInitialize)numFrom).EndInit();
        pnlButton.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tlpMain;
    private Label lblRoomType;
    private ComboBox cboRoomType;
    private Label lblFloor;
    private ComboBox cboFloor;
    private Label lblPrefix;
    private TextBox txtPrefix;
    private Label lblRange;
    private FlowLayoutPanel flpRange;
    private NumericUpDown numFrom;
    private Label lblRangeTo;
    private NumericUpDown numTo;
    private Panel pnlButton;
    private Button btnCreate;
    private Button btnCancel;
}
