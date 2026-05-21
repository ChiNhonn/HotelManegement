namespace HotelManagement.Forms;

partial class ServiceCategoryEditForm
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
        tblMain = new TableLayoutPanel();
        lblName = new Label();
        txtName = new TextBox();
        lblDesc = new Label();
        txtDesc = new TextBox();
        lblSort = new Label();
        numSort = new NumericUpDown();
        pnlBtn = new FlowLayoutPanel();
        btnOk = new Button();
        btnCancel = new Button();
        tblMain.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numSort).BeginInit();
        pnlBtn.SuspendLayout();
        SuspendLayout();
        // 
        // tblMain
        // 
        tblMain.ColumnCount = 2;
        tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
        tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblMain.Controls.Add(lblName, 0, 0);
        tblMain.Controls.Add(txtName, 1, 0);
        tblMain.Controls.Add(lblDesc, 0, 1);
        tblMain.Controls.Add(txtDesc, 1, 1);
        tblMain.Controls.Add(lblSort, 0, 2);
        tblMain.Controls.Add(numSort, 1, 2);
        tblMain.Dock = DockStyle.Fill;
        tblMain.Location = new Point(0, 0);
        tblMain.Name = "tblMain";
        tblMain.Padding = new Padding(16);
        tblMain.RowCount = 3;
        tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        tblMain.Size = new Size(400, 176);
        tblMain.TabIndex = 0;
        // 
        // lblName
        // 
        lblName.Anchor = AnchorStyles.Left;
        lblName.AutoSize = true;
        lblName.Location = new Point(19, 25);
        lblName.Name = "lblName";
        lblName.Size = new Size(44, 20);
        lblName.TabIndex = 0;
        lblName.Text = "Tên *";
        // 
        // txtName
        // 
        txtName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtName.Location = new Point(129, 21);
        txtName.Name = "txtName";
        txtName.Size = new Size(252, 27);
        txtName.TabIndex = 1;
        // 
        // lblDesc
        // 
        lblDesc.Anchor = AnchorStyles.Left;
        lblDesc.AutoSize = true;
        lblDesc.Location = new Point(19, 75);
        lblDesc.Name = "lblDesc";
        lblDesc.Size = new Size(47, 20);
        lblDesc.TabIndex = 2;
        lblDesc.Text = "Mô tả";
        // 
        // txtDesc
        // 
        txtDesc.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtDesc.Location = new Point(129, 61);
        txtDesc.Multiline = true;
        txtDesc.Name = "txtDesc";
        txtDesc.Size = new Size(252, 48);
        txtDesc.TabIndex = 3;
        // 
        // lblSort
        // 
        lblSort.Anchor = AnchorStyles.Left;
        lblSort.AutoSize = true;
        lblSort.Location = new Point(19, 129);
        lblSort.Name = "lblSort";
        lblSort.Size = new Size(56, 20);
        lblSort.TabIndex = 4;
        lblSort.Text = "Thứ tự";
        // 
        // numSort
        // 
        numSort.Anchor = AnchorStyles.Left;
        numSort.Location = new Point(129, 125);
        numSort.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        numSort.Name = "numSort";
        numSort.Size = new Size(100, 27);
        numSort.TabIndex = 5;
        // 
        // pnlBtn
        // 
        pnlBtn.Controls.Add(btnOk);
        pnlBtn.Controls.Add(btnCancel);
        pnlBtn.Dock = DockStyle.Bottom;
        pnlBtn.FlowDirection = FlowDirection.RightToLeft;
        pnlBtn.Location = new Point(0, 176);
        pnlBtn.Name = "pnlBtn";
        pnlBtn.Padding = new Padding(8);
        pnlBtn.Size = new Size(400, 44);
        pnlBtn.TabIndex = 1;
        // 
        // btnOk
        // 
        btnOk.DialogResult = DialogResult.OK;
        btnOk.Location = new Point(299, 11);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(90, 29);
        btnOk.TabIndex = 0;
        btnOk.Text = "Lưu";
        btnOk.UseVisualStyleBackColor = true;
        btnOk.Click += btnOk_Click;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(203, 11);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(90, 29);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "Hủy";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // ServiceCategoryEditForm
        // 
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(400, 220);
        Controls.Add(tblMain);
        Controls.Add(pnlBtn);
        Font = new Font("Segoe UI", 9.5F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ServiceCategoryEditForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Phân loại dịch vụ";
        tblMain.ResumeLayout(false);
        tblMain.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numSort).EndInit();
        pnlBtn.ResumeLayout(false);
        ResumeLayout(false);
    }

    private TableLayoutPanel tblMain;
    private Label lblName;
    private TextBox txtName;
    private Label lblDesc;
    private TextBox txtDesc;
    private Label lblSort;
    private NumericUpDown numSort;
    private FlowLayoutPanel pnlBtn;
    private Button btnOk;
    private Button btnCancel;
}
