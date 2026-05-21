namespace HotelManagement.Forms;

partial class ServiceEditForm
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
        lblCat = new Label();
        cboCat = new ComboBox();
        lblUnit = new Label();
        txtUnit = new TextBox();
        lblPrice = new Label();
        numPrice = new NumericUpDown();
        lblDesc = new Label();
        txtDesc = new TextBox();
        lblImage = new Label();
        txtImage = new TextBox();
        chkHidden = new CheckBox();
        chkStock = new CheckBox();
        numStock = new NumericUpDown();
        btnOk = new Button();
        btnCancel = new Button();
        ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
        SuspendLayout();
        // 
        // lblName
        // 
        lblName.AutoSize = true;
        lblName.Location = new Point(16, 19);
        lblName.Name = "lblName";
        lblName.Size = new Size(44, 20);
        lblName.TabIndex = 0;
        lblName.Text = "Tên *";
        // 
        // txtName
        // 
        txtName.Location = new Point(130, 16);
        txtName.Name = "txtName";
        txtName.Size = new Size(300, 27);
        txtName.TabIndex = 1;
        // 
        // lblCat
        // 
        lblCat.AutoSize = true;
        lblCat.Location = new Point(16, 55);
        lblCat.Name = "lblCat";
        lblCat.Size = new Size(73, 20);
        lblCat.TabIndex = 2;
        lblCat.Text = "Phân loại";
        // 
        // cboCat
        // 
        cboCat.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCat.Location = new Point(130, 52);
        cboCat.Name = "cboCat";
        cboCat.Size = new Size(300, 28);
        cboCat.TabIndex = 3;
        // 
        // lblUnit
        // 
        lblUnit.AutoSize = true;
        lblUnit.Location = new Point(16, 91);
        lblUnit.Name = "lblUnit";
        lblUnit.Size = new Size(58, 20);
        lblUnit.TabIndex = 4;
        lblUnit.Text = "Đơn vị";
        // 
        // txtUnit
        // 
        txtUnit.Location = new Point(130, 88);
        txtUnit.Name = "txtUnit";
        txtUnit.Size = new Size(120, 27);
        txtUnit.TabIndex = 5;
        // 
        // lblPrice
        // 
        lblPrice.AutoSize = true;
        lblPrice.Location = new Point(16, 127);
        lblPrice.Name = "lblPrice";
        lblPrice.Size = new Size(58, 20);
        lblPrice.TabIndex = 6;
        lblPrice.Text = "Giá bán";
        // 
        // numPrice
        // 
        numPrice.Location = new Point(130, 124);
        numPrice.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
        numPrice.Name = "numPrice";
        numPrice.Size = new Size(140, 27);
        numPrice.TabIndex = 7;
        numPrice.ThousandsSeparator = true;
        // 
        // lblDesc
        // 
        lblDesc.AutoSize = true;
        lblDesc.Location = new Point(16, 163);
        lblDesc.Name = "lblDesc";
        lblDesc.Size = new Size(47, 20);
        lblDesc.TabIndex = 8;
        lblDesc.Text = "Mô tả";
        // 
        // txtDesc
        // 
        txtDesc.Location = new Point(130, 160);
        txtDesc.Multiline = true;
        txtDesc.Name = "txtDesc";
        txtDesc.Size = new Size(300, 50);
        txtDesc.TabIndex = 9;
        // 
        // lblImage
        // 
        lblImage.AutoSize = true;
        lblImage.Location = new Point(16, 225);
        lblImage.Name = "lblImage";
        lblImage.Size = new Size(70, 20);
        lblImage.TabIndex = 10;
        lblImage.Text = "Hình ảnh";
        // 
        // txtImage
        // 
        txtImage.Location = new Point(130, 222);
        txtImage.Name = "txtImage";
        txtImage.Size = new Size(300, 27);
        txtImage.TabIndex = 11;
        // 
        // chkHidden
        // 
        chkHidden.AutoSize = true;
        chkHidden.Location = new Point(130, 262);
        chkHidden.Name = "chkHidden";
        chkHidden.Size = new Size(151, 24);
        chkHidden.TabIndex = 12;
        chkHidden.Text = "Ẩn khỏi menu đặt";
        chkHidden.UseVisualStyleBackColor = true;
        // 
        // chkStock
        // 
        chkStock.AutoSize = true;
        chkStock.Location = new Point(130, 292);
        chkStock.Name = "chkStock";
        chkStock.Size = new Size(140, 24);
        chkStock.TabIndex = 13;
        chkStock.Text = "Theo dõi tồn kho";
        chkStock.UseVisualStyleBackColor = true;
        // 
        // numStock
        // 
        numStock.Location = new Point(280, 290);
        numStock.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
        numStock.Name = "numStock";
        numStock.Size = new Size(100, 27);
        numStock.TabIndex = 14;
        // 
        // btnOk
        // 
        btnOk.DialogResult = DialogResult.OK;
        btnOk.Location = new Point(240, 328);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(80, 29);
        btnOk.TabIndex = 15;
        btnOk.Text = "Lưu";
        btnOk.UseVisualStyleBackColor = true;
        btnOk.Click += btnOk_Click;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(330, 328);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(80, 29);
        btnCancel.TabIndex = 16;
        btnCancel.Text = "Hủy";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // ServiceEditForm
        // 
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(440, 380);
        Controls.Add(btnCancel);
        Controls.Add(btnOk);
        Controls.Add(numStock);
        Controls.Add(chkStock);
        Controls.Add(chkHidden);
        Controls.Add(txtImage);
        Controls.Add(lblImage);
        Controls.Add(txtDesc);
        Controls.Add(lblDesc);
        Controls.Add(numPrice);
        Controls.Add(lblPrice);
        Controls.Add(txtUnit);
        Controls.Add(lblUnit);
        Controls.Add(cboCat);
        Controls.Add(lblCat);
        Controls.Add(txtName);
        Controls.Add(lblName);
        Font = new Font("Segoe UI", 9.5F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ServiceEditForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Dịch vụ";
        ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
        ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblName;
    private TextBox txtName;
    private Label lblCat;
    private ComboBox cboCat;
    private Label lblUnit;
    private TextBox txtUnit;
    private Label lblPrice;
    private NumericUpDown numPrice;
    private Label lblDesc;
    private TextBox txtDesc;
    private Label lblImage;
    private TextBox txtImage;
    private CheckBox chkHidden;
    private CheckBox chkStock;
    private NumericUpDown numStock;
    private Button btnOk;
    private Button btnCancel;
}
