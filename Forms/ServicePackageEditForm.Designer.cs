namespace HotelManagement.Forms;

partial class ServicePackageEditForm
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
        lblName = new Label();
        txtName = new TextBox();
        lblPrice = new Label();
        numPrice = new NumericUpDown();
        lblDesc = new Label();
        txtDesc = new TextBox();
        chkHidden = new CheckBox();
        lblItems = new Label();
        lstItems = new ListBox();
        cboService = new ComboBox();
        numQty = new NumericUpDown();
        btnAddItem = new Button();
        btnRemoveItem = new Button();
        btnOk = new Button();
        btnCancel = new Button();
        ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
        SuspendLayout();
        // 
        // lblName
        // 
        lblName.AutoSize = true;
        lblName.Location = new Point(12, 15);
        lblName.Name = "lblName";
        lblName.Size = new Size(72, 20);
        lblName.TabIndex = 0;
        lblName.Text = "Tên gói *";
        // 
        // txtName
        // 
        txtName.Location = new Point(120, 12);
        txtName.Name = "txtName";
        txtName.Size = new Size(300, 27);
        txtName.TabIndex = 1;
        // 
        // lblPrice
        // 
        lblPrice.AutoSize = true;
        lblPrice.Location = new Point(12, 51);
        lblPrice.Name = "lblPrice";
        lblPrice.Size = new Size(55, 20);
        lblPrice.TabIndex = 2;
        lblPrice.Text = "Giá gói";
        // 
        // numPrice
        // 
        numPrice.Location = new Point(120, 48);
        numPrice.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
        numPrice.Name = "numPrice";
        numPrice.Size = new Size(140, 27);
        numPrice.TabIndex = 3;
        numPrice.ThousandsSeparator = true;
        // 
        // lblDesc
        // 
        lblDesc.AutoSize = true;
        lblDesc.Location = new Point(12, 87);
        lblDesc.Name = "lblDesc";
        lblDesc.Size = new Size(47, 20);
        lblDesc.TabIndex = 4;
        lblDesc.Text = "Mô tả";
        // 
        // txtDesc
        // 
        txtDesc.Location = new Point(120, 84);
        txtDesc.Multiline = true;
        txtDesc.Name = "txtDesc";
        txtDesc.Size = new Size(300, 50);
        txtDesc.TabIndex = 5;
        // 
        // chkHidden
        // 
        chkHidden.AutoSize = true;
        chkHidden.Location = new Point(120, 144);
        chkHidden.Name = "chkHidden";
        chkHidden.Size = new Size(78, 24);
        chkHidden.TabIndex = 6;
        chkHidden.Text = "Ẩn gói";
        chkHidden.UseVisualStyleBackColor = true;
        // 
        // lblItems
        // 
        lblItems.AutoSize = true;
        lblItems.Location = new Point(12, 176);
        lblItems.Name = "lblItems";
        lblItems.Size = new Size(89, 20);
        lblItems.TabIndex = 7;
        lblItems.Text = "Thành phần";
        // 
        // lstItems
        // 
        lstItems.FormattingEnabled = true;
        lstItems.ItemHeight = 20;
        lstItems.Location = new Point(120, 176);
        lstItems.Name = "lstItems";
        lstItems.Size = new Size(300, 104);
        lstItems.TabIndex = 8;
        // 
        // cboService
        // 
        cboService.DropDownStyle = ComboBoxStyle.DropDownList;
        cboService.FormattingEnabled = true;
        cboService.Location = new Point(120, 288);
        cboService.Name = "cboService";
        cboService.Size = new Size(200, 28);
        cboService.TabIndex = 9;
        // 
        // numQty
        // 
        numQty.Location = new Point(330, 288);
        numQty.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
        numQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numQty.Name = "numQty";
        numQty.Size = new Size(60, 27);
        numQty.TabIndex = 10;
        numQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // btnAddItem
        // 
        btnAddItem.Location = new Point(396, 286);
        btnAddItem.Name = "btnAddItem";
        btnAddItem.Size = new Size(24, 29);
        btnAddItem.TabIndex = 11;
        btnAddItem.Text = "+";
        btnAddItem.UseVisualStyleBackColor = true;
        btnAddItem.Click += btnAddItem_Click;
        // 
        // btnRemoveItem
        // 
        btnRemoveItem.Location = new Point(120, 324);
        btnRemoveItem.Name = "btnRemoveItem";
        btnRemoveItem.Size = new Size(120, 29);
        btnRemoveItem.TabIndex = 12;
        btnRemoveItem.Text = "Xóa dòng chọn";
        btnRemoveItem.UseVisualStyleBackColor = true;
        btnRemoveItem.Click += btnRemoveItem_Click;
        // 
        // btnOk
        // 
        btnOk.DialogResult = DialogResult.OK;
        btnOk.Location = new Point(240, 360);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(80, 29);
        btnOk.TabIndex = 13;
        btnOk.Text = "Lưu";
        btnOk.UseVisualStyleBackColor = true;
        btnOk.Click += btnOk_Click;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(330, 360);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(80, 29);
        btnCancel.TabIndex = 14;
        btnCancel.Text = "Hủy";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // ServicePackageEditForm
        // 
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(440, 420);
        Controls.Add(btnCancel);
        Controls.Add(btnOk);
        Controls.Add(btnRemoveItem);
        Controls.Add(btnAddItem);
        Controls.Add(numQty);
        Controls.Add(cboService);
        Controls.Add(lstItems);
        Controls.Add(lblItems);
        Controls.Add(chkHidden);
        Controls.Add(txtDesc);
        Controls.Add(lblDesc);
        Controls.Add(numPrice);
        Controls.Add(lblPrice);
        Controls.Add(txtName);
        Controls.Add(lblName);
        Font = new Font("Segoe UI", 9.5F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ServicePackageEditForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Gói combo";
        ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
        ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblName;
    private TextBox txtName;
    private Label lblPrice;
    private NumericUpDown numPrice;
    private Label lblDesc;
    private TextBox txtDesc;
    private CheckBox chkHidden;
    private Label lblItems;
    private ListBox lstItems;
    private ComboBox cboService;
    private NumericUpDown numQty;
    private Button btnAddItem;
    private Button btnRemoveItem;
    private Button btnOk;
    private Button btnCancel;
}
