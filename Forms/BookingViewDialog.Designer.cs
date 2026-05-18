using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement.Forms;

partial class BookingViewDialog
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
        txtDetails = new TextBox();
        flowButtons = new FlowLayoutPanel();
        btnClose = new Button();
        btnRoom = new Button();
        btnGuest = new Button();
        root.SuspendLayout();
        flowButtons.SuspendLayout();
        SuspendLayout();
        // 
        // root
        // 
        root.ColumnCount = 1;
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        root.Controls.Add(txtDetails, 0, 0);
        root.Controls.Add(flowButtons, 0, 1);
        root.Dock = DockStyle.Fill;
        root.Name = "root";
        root.Padding = new Padding(14, 12, 14, 10);
        root.RowCount = 2;
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
        root.Size = new Size(480, 520);
        root.TabIndex = 0;
        // 
        // txtDetails
        // 
        txtDetails.BackColor = Color.White;
        txtDetails.Dock = DockStyle.Fill;
        txtDetails.Font = new Font("Consolas", 9.75F);
        txtDetails.Multiline = true;
        txtDetails.Name = "txtDetails";
        txtDetails.ReadOnly = true;
        txtDetails.ScrollBars = ScrollBars.Vertical;
        txtDetails.TabIndex = 0;
        // 
        // flowButtons
        // 
        flowButtons.Controls.Add(btnClose);
        flowButtons.Controls.Add(btnRoom);
        flowButtons.Controls.Add(btnGuest);
        flowButtons.Dock = DockStyle.Fill;
        flowButtons.FlowDirection = FlowDirection.RightToLeft;
        flowButtons.Location = new Point(14, 414);
        flowButtons.Name = "flowButtons";
        flowButtons.Padding = new Padding(0, 4, 0, 0);
        flowButtons.Size = new Size(452, 96);
        flowButtons.TabIndex = 1;
        flowButtons.WrapContents = true;
        // 
        // btnClose
        // 
        btnClose.AutoSize = true;
        btnClose.DialogResult = DialogResult.OK;
        btnClose.Name = "btnClose";
        btnClose.Padding = new Padding(12, 6, 12, 6);
        btnClose.Text = "Đóng";
        btnClose.UseVisualStyleBackColor = true;
        // 
        // btnRoom
        // 
        btnRoom.AutoSize = true;
        btnRoom.Name = "btnRoom";
        btnRoom.Padding = new Padding(12, 6, 12, 6);
        btnRoom.Text = "Lọc theo phòng";
        btnRoom.UseVisualStyleBackColor = true;
        // 
        // btnGuest
        // 
        btnGuest.AutoSize = true;
        btnGuest.Name = "btnGuest";
        btnGuest.Padding = new Padding(12, 6, 12, 6);
        btnGuest.Text = "Lọc theo khách";
        btnGuest.UseVisualStyleBackColor = true;
        // 
        // BookingViewDialog
        // 
        AcceptButton = btnClose;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnClose;
        ClientSize = new Size(480, 520);
        Controls.Add(root);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "BookingViewDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Chi tiết đặt phòng";
        root.ResumeLayout(false);
        root.PerformLayout();
        flowButtons.ResumeLayout(false);
        flowButtons.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel root;
    private TextBox txtDetails;
    private FlowLayoutPanel flowButtons;
    private Button btnClose;
    private Button btnRoom;
    private Button btnGuest;
}
