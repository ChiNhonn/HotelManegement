using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement.Forms;

partial class AddStaffPayoutDialog
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
        _lblUser = new Label();
        _txtUser = new TextBox();
        _lblAmt = new Label();
        _numAmount = new NumericUpDown();
        _btnOk = new Button();
        _btnCancel = new Button();
        ((System.ComponentModel.ISupportInitialize)_numAmount).BeginInit();
        SuspendLayout();
        //
        // _lblUser
        //
        _lblUser.AutoSize = false;
        _lblUser.Location = new Point(18, 20);
        _lblUser.Name = "_lblUser";
        _lblUser.Size = new Size(384, 22);
        _lblUser.TabIndex = 0;
        _lblUser.Text = "Username";
        //
        // _txtUser
        //
        _txtUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        _txtUser.Location = new Point(18, 44);
        _txtUser.Name = "_txtUser";
        _txtUser.Size = new Size(384, 28);
        _txtUser.TabIndex = 1;
        //
        // _lblAmt
        //
        _lblAmt.AutoSize = false;
        _lblAmt.Location = new Point(18, 82);
        _lblAmt.Name = "_lblAmt";
        _lblAmt.Size = new Size(384, 22);
        _lblAmt.TabIndex = 2;
        _lblAmt.Text = "Amount (VND)";
        //
        // _numAmount
        //
        _numAmount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        _numAmount.DecimalPlaces = 0;
        _numAmount.Increment = new decimal(new[] { 10000, 0, 0, 0 });
        _numAmount.Location = new Point(18, 106);
        _numAmount.Maximum = 9999999999M;
        _numAmount.Minimum = new decimal(new[] { 1, 0, 0, 0 });
        _numAmount.Name = "_numAmount";
        _numAmount.Size = new Size(384, 28);
        _numAmount.TabIndex = 3;
        _numAmount.ThousandsSeparator = true;
        _numAmount.Value = new decimal(new[] { 1, 0, 0, 0 });
        //
        // _btnOk
        //
        _btnOk.BackColor = Color.FromArgb(21, 100, 55);
        _btnOk.FlatAppearance.BorderSize = 0;
        _btnOk.FlatStyle = FlatStyle.Flat;
        _btnOk.ForeColor = Color.White;
        _btnOk.Location = new Point(174, 140);
        _btnOk.Name = "_btnOk";
        _btnOk.Size = new Size(120, 34);
        _btnOk.TabIndex = 4;
        _btnOk.Text = "Save";
        _btnOk.UseVisualStyleBackColor = false;
        _btnOk.DialogResult = DialogResult.OK;
        //
        // _btnCancel
        //
        _btnCancel.DialogResult = DialogResult.Cancel;
        _btnCancel.Location = new Point(306, 140);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new Size(96, 34);
        _btnCancel.TabIndex = 5;
        _btnCancel.Text = "Cancel";
        _btnCancel.UseVisualStyleBackColor = true;
        //
        // AddStaffPayoutDialog
        //
        AcceptButton = _btnOk;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = _btnCancel;
        ClientSize = new Size(420, 190);
        Controls.Add(_btnCancel);
        Controls.Add(_btnOk);
        Controls.Add(_numAmount);
        Controls.Add(_lblAmt);
        Controls.Add(_txtUser);
        Controls.Add(_lblUser);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Margin = new Padding(18);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AddStaffPayoutDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Add staff payout";
        Shown += AddStaffPayoutDialog_Shown;
        ((System.ComponentModel.ISupportInitialize)_numAmount).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Label _lblUser;
    private TextBox _txtUser;
    private Label _lblAmt;
    private NumericUpDown _numAmount;
    private Button _btnOk;
    private Button _btnCancel;
}
