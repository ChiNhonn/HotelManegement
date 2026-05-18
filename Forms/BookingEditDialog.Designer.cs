using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement.Forms;

partial class BookingEditDialog
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
        flowButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numAdults).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numChildren).BeginInit();
        SuspendLayout();
        root.ColumnCount = 2;
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 158F));
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
        root.Name = "root";
        root.Padding = new Padding(18, 14, 18, 12);
        root.RowCount = 14;
        for (var i = 0; i < 12; i++)
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        root.SetColumnSpan(flowButtons, 2);
        StyleCaption(lblCapRoom, "Phòng (cố định)");
        StyleCaption(lblCapType, "Hạng phòng (cố định)");
        StyleCaption(lblCapRate, "Giá / đêm");
        StyleCaption(lblCapCheckIn, "Nhận phòng");
        StyleCaption(lblCapCheckOut, "Trả phòng");
        StyleCaption(lblCapName, "Họ tên");
        StyleCaption(lblCapCccd, "CCCD");
        StyleCaption(lblCapPhone, "SĐT");
        StyleCaption(lblCapAdults, "Người lớn");
        StyleCaption(lblCapChildren, "Trẻ em");
        StyleCaption(lblCapNights, "Số đêm");
        StyleCaption(lblCapTotal, "Tổng dự kiến");
        StyleCaption(lblCapNote, "Ghi chú");
        StyleValue(lblRoom, true);
        StyleValue(lblType);
        StyleValue(lblRate);
        StyleValue(lblNights);
        StyleValue(lblTotal, true);
        dtpIn.Dock = DockStyle.Fill;
        dtpIn.Format = DateTimePickerFormat.Short;
        dtpOut.Dock = DockStyle.Fill;
        dtpOut.Format = DateTimePickerFormat.Short;
        txtName.Dock = DockStyle.Fill;
        txtCccd.Dock = DockStyle.Fill;
        txtPhone.Dock = DockStyle.Fill;
        numAdults.Dock = DockStyle.Fill;
        numAdults.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
        numAdults.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numAdults.Value = new decimal(new int[] { 1, 0, 0, 0 });
        numChildren.Dock = DockStyle.Fill;
        numChildren.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
        txtNote.Dock = DockStyle.Fill;
        txtNote.MinimumSize = new Size(0, 72);
        txtNote.Multiline = true;
        txtNote.ScrollBars = ScrollBars.Vertical;
        flowButtons.Controls.Add(btnOk);
        flowButtons.Controls.Add(btnCancel);
        flowButtons.Dock = DockStyle.Fill;
        flowButtons.FlowDirection = FlowDirection.RightToLeft;
        flowButtons.Padding = new Padding(0, 8, 0, 0);
        flowButtons.WrapContents = false;
        btnOk.AutoSize = true;
        btnOk.Margin = new Padding(8, 0, 0, 0);
        btnOk.Padding = new Padding(14, 6, 14, 6);
        btnOk.Text = "Lưu";
        btnOk.UseVisualStyleBackColor = true;
        btnCancel.AutoSize = true;
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Padding = new Padding(12, 6, 12, 6);
        btnCancel.Text = "Hủy";
        btnCancel.UseVisualStyleBackColor = true;
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(460, 560);
        Controls.Add(root);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "BookingEditDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Sửa đặt phòng";
        root.ResumeLayout(false);
        flowButtons.ResumeLayout(false);
        flowButtons.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numAdults).EndInit();
        ((System.ComponentModel.ISupportInitialize)numChildren).EndInit();
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
