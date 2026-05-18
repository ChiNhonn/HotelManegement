using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement.Forms;

partial class BookRoomDialog
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        root = new TableLayoutPanel();
        lblCapRoom = new Label();
        lblRoom = new Label();
        lblCapType = new Label();
        lblType = new Label();
        lblCapRate = new Label();
        lblRate = new Label();
        lblCapCheckIn = new Label();
        dtpIn = new DateTimePicker();
        lblCapCheckOut = new Label();
        dtpOut = new DateTimePicker();
        lblCapName = new Label();
        txtName = new TextBox();
        lblCapCccd = new Label();
        txtCccd = new TextBox();
        lblCapPhone = new Label();
        txtPhone = new TextBox();
        lblCapAdults = new Label();
        numAdults = new NumericUpDown();
        lblCapChildren = new Label();
        numChildren = new NumericUpDown();
        lblCapNights = new Label();
        lblNights = new Label();
        lblCapTotal = new Label();
        lblTotal = new Label();
        lblCapNote = new Label();
        txtNote = new TextBox();
        flowButtons = new FlowLayoutPanel();
        btnOk = new Button();
        btnCancel = new Button();
        root.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numAdults).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numChildren).BeginInit();
        flowButtons.SuspendLayout();
        SuspendLayout();
        // 
        // root
        // 
        root.ColumnCount = 2;
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 148F));
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        root.Controls.Add(lblCapRoom, 0, 0);
        root.Controls.Add(lblRoom, 1, 0);
        root.Controls.Add(lblCapType, 0, 1);
        root.Controls.Add(lblType, 1, 1);
        root.Controls.Add(lblCapRate, 0, 2);
        root.Controls.Add(lblRate, 1, 2);
        root.Controls.Add(lblCapCheckIn, 0, 3);
        root.Controls.Add(dtpIn, 1, 3);
        root.Controls.Add(lblCapCheckOut, 0, 4);
        root.Controls.Add(dtpOut, 1, 4);
        root.Controls.Add(lblCapName, 0, 5);
        root.Controls.Add(txtName, 1, 5);
        root.Controls.Add(lblCapCccd, 0, 6);
        root.Controls.Add(txtCccd, 1, 6);
        root.Controls.Add(lblCapPhone, 0, 7);
        root.Controls.Add(txtPhone, 1, 7);
        root.Controls.Add(lblCapAdults, 0, 8);
        root.Controls.Add(numAdults, 1, 8);
        root.Controls.Add(lblCapChildren, 0, 9);
        root.Controls.Add(numChildren, 1, 9);
        root.Controls.Add(lblCapNights, 0, 10);
        root.Controls.Add(lblNights, 1, 10);
        root.Controls.Add(lblCapTotal, 0, 11);
        root.Controls.Add(lblTotal, 1, 11);
        root.Controls.Add(lblCapNote, 0, 12);
        root.Controls.Add(txtNote, 1, 12);
        root.Controls.Add(flowButtons, 0, 13);
        root.Dock = DockStyle.Fill;
        root.Location = new Point(0, 0);
        root.Name = "root";
        root.Padding = new Padding(18, 14, 18, 12);
        root.RowCount = 14;
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        root.Size = new Size(460, 560);
        root.TabIndex = 0;
        // 
        // lblCapRoom
        // 
        lblCapRoom.Location = new Point(21, 14);
        lblCapRoom.Name = "lblCapRoom";
        lblCapRoom.Size = new Size(100, 23);
        lblCapRoom.TabIndex = 0;
        // 
        // lblRoom
        // 
        lblRoom.Location = new Point(169, 14);
        lblRoom.Name = "lblRoom";
        lblRoom.Size = new Size(100, 23);
        lblRoom.TabIndex = 1;
        lblRoom.Text = "101";
        // 
        // lblCapType
        // 
        lblCapType.Location = new Point(21, 48);
        lblCapType.Name = "lblCapType";
        lblCapType.Size = new Size(100, 23);
        lblCapType.TabIndex = 2;
        // 
        // lblType
        // 
        lblType.Location = new Point(169, 48);
        lblType.Name = "lblType";
        lblType.Size = new Size(100, 23);
        lblType.TabIndex = 3;
        lblType.Text = "Standard";
        // 
        // lblCapRate
        // 
        lblCapRate.Location = new Point(21, 82);
        lblCapRate.Name = "lblCapRate";
        lblCapRate.Size = new Size(100, 23);
        lblCapRate.TabIndex = 4;
        // 
        // lblRate
        // 
        lblRate.Location = new Point(169, 82);
        lblRate.Name = "lblRate";
        lblRate.Size = new Size(100, 23);
        lblRate.TabIndex = 5;
        lblRate.Text = "0 VND / đêm";
        // 
        // lblCapCheckIn
        // 
        lblCapCheckIn.Location = new Point(21, 116);
        lblCapCheckIn.Name = "lblCapCheckIn";
        lblCapCheckIn.Size = new Size(100, 23);
        lblCapCheckIn.TabIndex = 6;
        // 
        // dtpIn
        // 
        dtpIn.Dock = DockStyle.Fill;
        dtpIn.Format = DateTimePickerFormat.Short;
        dtpIn.Location = new Point(169, 119);
        dtpIn.Name = "dtpIn";
        dtpIn.Size = new Size(270, 25);
        dtpIn.TabIndex = 7;
        // 
        // lblCapCheckOut
        // 
        lblCapCheckOut.Location = new Point(21, 150);
        lblCapCheckOut.Name = "lblCapCheckOut";
        lblCapCheckOut.Size = new Size(100, 23);
        lblCapCheckOut.TabIndex = 8;
        // 
        // dtpOut
        // 
        dtpOut.Dock = DockStyle.Fill;
        dtpOut.Format = DateTimePickerFormat.Short;
        dtpOut.Location = new Point(169, 153);
        dtpOut.Name = "dtpOut";
        dtpOut.Size = new Size(270, 25);
        dtpOut.TabIndex = 9;
        // 
        // lblCapName
        // 
        lblCapName.Location = new Point(21, 184);
        lblCapName.Name = "lblCapName";
        lblCapName.Size = new Size(100, 23);
        lblCapName.TabIndex = 10;
        // 
        // txtName
        // 
        txtName.Dock = DockStyle.Fill;
        txtName.Location = new Point(169, 187);
        txtName.Name = "txtName";
        txtName.Size = new Size(270, 25);
        txtName.TabIndex = 11;
        // 
        // lblCapCccd
        // 
        lblCapCccd.Location = new Point(21, 218);
        lblCapCccd.Name = "lblCapCccd";
        lblCapCccd.Size = new Size(100, 23);
        lblCapCccd.TabIndex = 12;
        // 
        // txtCccd
        // 
        txtCccd.Dock = DockStyle.Fill;
        txtCccd.Location = new Point(169, 221);
        txtCccd.Name = "txtCccd";
        txtCccd.Size = new Size(270, 25);
        txtCccd.TabIndex = 13;
        // 
        // lblCapPhone
        // 
        lblCapPhone.Location = new Point(21, 252);
        lblCapPhone.Name = "lblCapPhone";
        lblCapPhone.Size = new Size(100, 23);
        lblCapPhone.TabIndex = 14;
        // 
        // txtPhone
        // 
        txtPhone.Dock = DockStyle.Fill;
        txtPhone.Location = new Point(169, 255);
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new Size(270, 25);
        txtPhone.TabIndex = 15;
        // 
        // lblCapAdults
        // 
        lblCapAdults.Location = new Point(21, 286);
        lblCapAdults.Name = "lblCapAdults";
        lblCapAdults.Size = new Size(100, 23);
        lblCapAdults.TabIndex = 16;
        // 
        // numAdults
        // 
        numAdults.Dock = DockStyle.Fill;
        numAdults.Location = new Point(169, 289);
        numAdults.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
        numAdults.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numAdults.Name = "numAdults";
        numAdults.Size = new Size(270, 25);
        numAdults.TabIndex = 17;
        numAdults.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // lblCapChildren
        // 
        lblCapChildren.Location = new Point(21, 320);
        lblCapChildren.Name = "lblCapChildren";
        lblCapChildren.Size = new Size(100, 23);
        lblCapChildren.TabIndex = 18;
        // 
        // numChildren
        // 
        numChildren.Dock = DockStyle.Fill;
        numChildren.Location = new Point(169, 323);
        numChildren.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
        numChildren.Name = "numChildren";
        numChildren.Size = new Size(270, 25);
        numChildren.TabIndex = 19;
        // 
        // lblCapNights
        // 
        lblCapNights.Location = new Point(21, 354);
        lblCapNights.Name = "lblCapNights";
        lblCapNights.Size = new Size(100, 23);
        lblCapNights.TabIndex = 20;
        // 
        // lblNights
        // 
        lblNights.Location = new Point(169, 354);
        lblNights.Name = "lblNights";
        lblNights.Size = new Size(100, 23);
        lblNights.TabIndex = 21;
        lblNights.Text = "1";
        // 
        // lblCapTotal
        // 
        lblCapTotal.Location = new Point(21, 388);
        lblCapTotal.Name = "lblCapTotal";
        lblCapTotal.Size = new Size(100, 23);
        lblCapTotal.TabIndex = 22;
        // 
        // lblTotal
        // 
        lblTotal.Location = new Point(169, 388);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(100, 23);
        lblTotal.TabIndex = 23;
        lblTotal.Text = "0 VND";
        // 
        // lblCapNote
        // 
        lblCapNote.Location = new Point(21, 422);
        lblCapNote.Name = "lblCapNote";
        lblCapNote.Size = new Size(100, 23);
        lblCapNote.TabIndex = 24;
        // 
        // txtNote
        // 
        txtNote.Dock = DockStyle.Fill;
        txtNote.Location = new Point(169, 425);
        txtNote.MinimumSize = new Size(0, 72);
        txtNote.Multiline = true;
        txtNote.Name = "txtNote";
        txtNote.ScrollBars = ScrollBars.Vertical;
        txtNote.Size = new Size(270, 78);
        txtNote.TabIndex = 25;
        // 
        // flowButtons
        // 
        root.SetColumnSpan(flowButtons, 2);
        flowButtons.Controls.Add(btnOk);
        flowButtons.Controls.Add(btnCancel);
        flowButtons.Dock = DockStyle.Fill;
        flowButtons.FlowDirection = FlowDirection.RightToLeft;
        flowButtons.Location = new Point(21, 509);
        flowButtons.Name = "flowButtons";
        flowButtons.Padding = new Padding(0, 8, 0, 0);
        flowButtons.Size = new Size(418, 42);
        flowButtons.TabIndex = 26;
        flowButtons.WrapContents = false;
        // 
        // btnOk
        // 
        btnOk.AutoSize = true;
        btnOk.Location = new Point(247, 8);
        btnOk.Margin = new Padding(8, 0, 0, 0);
        btnOk.Name = "btnOk";
        btnOk.Padding = new Padding(14, 6, 14, 6);
        btnOk.Size = new Size(171, 41);
        btnOk.TabIndex = 0;
        btnOk.Text = "Xác nhận đặt phòng";
        btnOk.UseVisualStyleBackColor = true;
        // 
        // btnCancel
        // 
        btnCancel.AutoSize = true;
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(161, 11);
        btnCancel.Name = "btnCancel";
        btnCancel.Padding = new Padding(12, 6, 12, 6);
        btnCancel.Size = new Size(75, 41);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "Hủy";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // BookRoomDialog
        // 
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(460, 560);
        Controls.Add(root);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "BookRoomDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Đặt phòng";
        root.ResumeLayout(false);
        root.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numAdults).EndInit();
        ((System.ComponentModel.ISupportInitialize)numChildren).EndInit();
        flowButtons.ResumeLayout(false);
        flowButtons.PerformLayout();
        ResumeLayout(false);
    }

    private static void StyleCaption(Label lbl, string text)
    {
        lbl.Dock = DockStyle.Fill;
        lbl.ForeColor = Color.FromArgb(71, 85, 105);
        lbl.Text = text;
        lbl.TextAlign = ContentAlignment.MiddleLeft;
    }

    private static void StyleValue(Label lbl, bool bold = false)
    {
        lbl.Dock = DockStyle.Fill;
        lbl.ForeColor = Color.FromArgb(30, 41, 59);
        lbl.TextAlign = ContentAlignment.MiddleLeft;
        if (bold)
            lbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
    }

    #endregion

    private TableLayoutPanel root;
    private Label lblCapRoom;
    private Label lblRoom;
    private Label lblCapType;
    private Label lblType;
    private Label lblCapRate;
    private Label lblRate;
    private Label lblCapCheckIn;
    private DateTimePicker dtpIn;
    private Label lblCapCheckOut;
    private DateTimePicker dtpOut;
    private Label lblCapName;
    private TextBox txtName;
    private Label lblCapCccd;
    private TextBox txtCccd;
    private Label lblCapPhone;
    private TextBox txtPhone;
    private Label lblCapAdults;
    private NumericUpDown numAdults;
    private Label lblCapChildren;
    private NumericUpDown numChildren;
    private Label lblCapNights;
    private Label lblNights;
    private Label lblCapTotal;
    private Label lblTotal;
    private Label lblCapNote;
    private TextBox txtNote;
    private FlowLayoutPanel flowButtons;
    private Button btnOk;
    private Button btnCancel;
}
