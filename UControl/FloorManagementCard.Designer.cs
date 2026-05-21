namespace HotelManagement.CustomControls;

partial class FloorManagementCard
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
        lblStatus = new Label();
        lblMeta = new Label();
        btnToggle = new Button();
        SuspendLayout();
        // 
        // lblName
        // 
        lblName.Dock = DockStyle.Top;
        lblName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblName.ForeColor = Color.FromArgb(15, 23, 42);
        lblName.Location = new Point(14, 12);
        lblName.Name = "lblName";
        lblName.Size = new Size(292, 28);
        lblName.TabIndex = 0;
        lblName.Text = "Tầng";
        // 
        // lblStatus
        // 
        lblStatus.Dock = DockStyle.Top;
        lblStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblStatus.ForeColor = Color.FromArgb(71, 85, 105);
        lblStatus.Location = new Point(14, 40);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(292, 24);
        lblStatus.TabIndex = 1;
        lblStatus.Text = "Trạng thái";
        // 
        // lblMeta
        // 
        lblMeta.Dock = DockStyle.Top;
        lblMeta.Font = new Font("Segoe UI", 9F);
        lblMeta.ForeColor = Color.FromArgb(100, 116, 139);
        lblMeta.Location = new Point(14, 64);
        lblMeta.Name = "lblMeta";
        lblMeta.Size = new Size(292, 40);
        lblMeta.TabIndex = 2;
        lblMeta.Text = "Meta";
        // 
        // btnToggle
        // 
        btnToggle.Cursor = Cursors.Hand;
        btnToggle.Dock = DockStyle.Bottom;
        btnToggle.FlatStyle = FlatStyle.Flat;
        btnToggle.ForeColor = Color.White;
        btnToggle.Location = new Point(14, 100);
        btnToggle.Name = "btnToggle";
        btnToggle.Size = new Size(292, 34);
        btnToggle.TabIndex = 3;
        btnToggle.Text = "Khóa / Mở";
        btnToggle.UseVisualStyleBackColor = true;
        btnToggle.Click += btnToggle_Click;
        // 
        // FloorManagementCard
        // 
        BackColor = Color.White;
        Controls.Add(btnToggle);
        Controls.Add(lblMeta);
        Controls.Add(lblStatus);
        Controls.Add(lblName);
        Cursor = Cursors.Hand;
        Margin = new Padding(8);
        Name = "FloorManagementCard";
        Padding = new Padding(14, 12, 14, 12);
        Size = new Size(320, 148);
        Click += FloorManagementCard_Click;
        ResumeLayout(false);
    }

    private Label lblName;
    private Label lblStatus;
    private Label lblMeta;
    private Button btnToggle;
}
