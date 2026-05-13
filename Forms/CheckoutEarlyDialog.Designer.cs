using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement.Forms;

partial class CheckoutEarlyDialog
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
        root = new TableLayoutPanel();
        lblHead = new Label();
        lblRange = new Label();
        rowPick = new TableLayoutPanel();
        lblPickDate = new Label();
        _dtp = new DateTimePicker();
        flow = new FlowLayoutPanel();
        ok = new Button();
        cancel = new Button();
        root.SuspendLayout();
        rowPick.SuspendLayout();
        flow.SuspendLayout();
        SuspendLayout();
        //
        // root
        //
        root.ColumnCount = 1;
        root.Dock = DockStyle.Fill;
        root.Location = new Point(0, 0);
        root.Padding = new Padding(18, 14, 18, 12);
        root.RowCount = 4;
        root.Size = new Size(440, 200);
        root.TabIndex = 0;
        root.Controls.Add(lblHead, 0, 0);
        root.Controls.Add(lblRange, 0, 1);
        root.Controls.Add(rowPick, 0, 2);
        root.Controls.Add(flow, 0, 3);
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        //
        // lblHead
        //
        lblHead.Dock = DockStyle.Fill;
        lblHead.ForeColor = Color.FromArgb(30, 41, 59);
        lblHead.Location = new Point(18, 14);
        lblHead.Name = "lblHead";
        lblHead.Size = new Size(404, 28);
        lblHead.TabIndex = 0;
        lblHead.TextAlign = ContentAlignment.MiddleLeft;
        //
        // lblRange
        //
        lblRange.Dock = DockStyle.Fill;
        lblRange.ForeColor = Color.FromArgb(71, 85, 105);
        lblRange.Location = new Point(18, 42);
        lblRange.Name = "lblRange";
        lblRange.Size = new Size(404, 34);
        lblRange.TabIndex = 1;
        lblRange.TextAlign = ContentAlignment.MiddleLeft;
        //
        // rowPick
        //
        rowPick.ColumnCount = 2;
        rowPick.Dock = DockStyle.Fill;
        rowPick.Location = new Point(18, 76);
        rowPick.Name = "rowPick";
        rowPick.RowCount = 1;
        rowPick.Size = new Size(404, 34);
        rowPick.TabIndex = 2;
        rowPick.Controls.Add(lblPickDate, 0, 0);
        rowPick.Controls.Add(_dtp, 1, 0);
        rowPick.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 118F));
        rowPick.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        //
        // lblPickDate
        //
        lblPickDate.Dock = DockStyle.Fill;
        lblPickDate.Location = new Point(3, 0);
        lblPickDate.Name = "lblPickDate";
        lblPickDate.Size = new Size(112, 34);
        lblPickDate.TabIndex = 0;
        lblPickDate.Text = "Actual checkout";
        lblPickDate.TextAlign = ContentAlignment.MiddleLeft;
        //
        // _dtp
        //
        _dtp.Dock = DockStyle.Fill;
        _dtp.Format = DateTimePickerFormat.Short;
        _dtp.Location = new Point(121, 3);
        _dtp.Name = "_dtp";
        _dtp.Size = new Size(280, 27);
        _dtp.TabIndex = 1;
        //
        // flow
        //
        flow.Dock = DockStyle.Fill;
        flow.FlowDirection = FlowDirection.RightToLeft;
        flow.Location = new Point(18, 110);
        flow.Margin = new Padding(0, 8, 0, 0);
        flow.Name = "flow";
        flow.Size = new Size(404, 40);
        flow.TabIndex = 3;
        flow.WrapContents = false;
        flow.Controls.Add(ok);
        flow.Controls.Add(cancel);
        //
        // ok
        //
        ok.AutoSize = true;
        ok.DialogResult = DialogResult.OK;
        ok.Margin = new Padding(8, 0, 0, 0);
        ok.Name = "ok";
        ok.Padding = new Padding(14, 6, 14, 6);
        ok.Size = new Size(94, 37);
        ok.TabIndex = 0;
        ok.Text = "Confirm";
        ok.UseVisualStyleBackColor = true;
        //
        // cancel
        //
        cancel.AutoSize = true;
        cancel.DialogResult = DialogResult.Cancel;
        cancel.Name = "cancel";
        cancel.Padding = new Padding(12, 6, 12, 6);
        cancel.Size = new Size(81, 37);
        cancel.TabIndex = 1;
        cancel.Text = "Cancel";
        cancel.UseVisualStyleBackColor = true;
        //
        // CheckoutEarlyDialog
        //
        AcceptButton = ok;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = cancel;
        ClientSize = new Size(440, 200);
        Controls.Add(root);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "CheckoutEarlyDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Check out";
        root.ResumeLayout(false);
        rowPick.ResumeLayout(false);
        flow.ResumeLayout(false);
        flow.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel root;
    private Label lblHead;
    private Label lblRange;
    private TableLayoutPanel rowPick;
    private Label lblPickDate;
    private DateTimePicker _dtp;
    private FlowLayoutPanel flow;
    private Button ok;
    private Button cancel;
}
