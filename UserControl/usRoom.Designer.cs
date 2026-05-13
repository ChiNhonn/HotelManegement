namespace QuanLyKhachSan.Views
{
    partial class usRoom
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usRoom));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            tabContainerPhong = new TabControl();
            tabPhong = new TabPage();
            grpDanhSach = new GroupBox();
            dgvDSPhong = new DataGridView();
            grpTimkiem = new GroupBox();
            btnXoaPhong = new Button();
            btnLamMoi = new Button();
            btnChinhSua = new Button();
            btnThemPhong = new Button();
            cboLocTrangThai = new ComboBox();
            txtTimKiem = new TextBox();
            cboLocLoaiPhong = new ComboBox();
            tabLoaiPhong = new TabPage();
            pnlContainerLoaiPhong = new Panel();
            grpDanhSachLoaiPhong = new GroupBox();
            dgvDSLoaiPhong = new DataGridView();
            grpChucNang = new GroupBox();
            cboLoaiPhong = new ComboBox();
            btnXoa2 = new Button();
            btnThem2 = new Button();
            btnLamMoi2 = new Button();
            btnSua2 = new Button();
            grpThanhTimKiem = new GroupBox();
            groupBox1 = new GroupBox();
            btnLocTheoGia = new Button();
            lblDen = new Label();
            lblTu = new Label();
            numGiaMax = new NumericUpDown();
            numGiaMin = new NumericUpDown();
            cboSapXep = new ComboBox();
            txtThanhTimKiem2 = new TextBox();
            tabContainerPhong.SuspendLayout();
            tabPhong.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDSPhong).BeginInit();
            grpTimkiem.SuspendLayout();
            tabLoaiPhong.SuspendLayout();
            pnlContainerLoaiPhong.SuspendLayout();
            grpDanhSachLoaiPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDSLoaiPhong).BeginInit();
            grpChucNang.SuspendLayout();
            grpThanhTimKiem.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numGiaMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGiaMin).BeginInit();
            SuspendLayout();
            // 
            // tabContainerPhong
            // 
            tabContainerPhong.Controls.Add(tabPhong);
            tabContainerPhong.Controls.Add(tabLoaiPhong);
            tabContainerPhong.Dock = DockStyle.Fill;
            tabContainerPhong.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            tabContainerPhong.Location = new Point(0, 0);
            tabContainerPhong.Name = "tabContainerPhong";
            tabContainerPhong.SelectedIndex = 0;
            tabContainerPhong.Size = new Size(1300, 759);
            tabContainerPhong.TabIndex = 1;
            // 
            // tabPhong
            // 
            tabPhong.Controls.Add(grpDanhSach);
            tabPhong.Controls.Add(grpTimkiem);
            tabPhong.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            tabPhong.Location = new Point(4, 34);
            tabPhong.Name = "tabPhong";
            tabPhong.Padding = new Padding(3);
            tabPhong.Size = new Size(1292, 721);
            tabPhong.TabIndex = 0;
            tabPhong.Text = "Danh sách phòng";
            tabPhong.UseVisualStyleBackColor = true;
            // 
            // grpDanhSach
            // 
            grpDanhSach.Controls.Add(dgvDSPhong);
            grpDanhSach.Dock = DockStyle.Fill;
            grpDanhSach.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            grpDanhSach.Location = new Point(3, 137);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Size = new Size(1286, 581);
            grpDanhSach.TabIndex = 33;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "Danh sách phòng";
            // 
            // dgvDSPhong
            // 
            dgvDSPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDSPhong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDSPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDSPhong.DefaultCellStyle = dataGridViewCellStyle2;
            dgvDSPhong.Dock = DockStyle.Fill;
            dgvDSPhong.EnableHeadersVisualStyles = false;
            dgvDSPhong.Location = new Point(3, 34);
            dgvDSPhong.Name = "dgvDSPhong";
            dgvDSPhong.ReadOnly = true;
            dgvDSPhong.RowHeadersWidth = 51;
            dgvDSPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSPhong.Size = new Size(1280, 544);
            dgvDSPhong.TabIndex = 28;
            dgvDSPhong.MouseDown += dgvDSPhong_MouseDown;
            // 
            // grpTimkiem
            // 
            grpTimkiem.Controls.Add(btnXoaPhong);
            grpTimkiem.Controls.Add(btnLamMoi);
            grpTimkiem.Controls.Add(btnChinhSua);
            grpTimkiem.Controls.Add(btnThemPhong);
            grpTimkiem.Controls.Add(cboLocTrangThai);
            grpTimkiem.Controls.Add(txtTimKiem);
            grpTimkiem.Controls.Add(cboLocLoaiPhong);
            grpTimkiem.Dock = DockStyle.Top;
            grpTimkiem.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            grpTimkiem.Location = new Point(3, 3);
            grpTimkiem.Name = "grpTimkiem";
            grpTimkiem.Size = new Size(1286, 134);
            grpTimkiem.TabIndex = 31;
            grpTimkiem.TabStop = false;
            grpTimkiem.Text = "Thanh tìm kiếm";
            // 
            // btnXoaPhong
            // 
            btnXoaPhong.BackColor = Color.FromArgb(255, 128, 128);
            btnXoaPhong.Cursor = Cursors.Hand;
            btnXoaPhong.FlatAppearance.BorderSize = 0;
            btnXoaPhong.FlatStyle = FlatStyle.Flat;
            btnXoaPhong.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnXoaPhong.ForeColor = Color.White;
            btnXoaPhong.Image = (Image)resources.GetObject("btnXoaPhong.Image");
            btnXoaPhong.Location = new Point(1058, 53);
            btnXoaPhong.Name = "btnXoaPhong";
            btnXoaPhong.Size = new Size(90, 48);
            btnXoaPhong.TabIndex = 20;
            btnXoaPhong.TabStop = false;
            btnXoaPhong.Text = "Xóa";
            btnXoaPhong.TextAlign = ContentAlignment.MiddleRight;
            btnXoaPhong.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnXoaPhong.UseVisualStyleBackColor = false;
            btnXoaPhong.Click += btnXoaPhong_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = SystemColors.MenuHighlight;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Image = (Image)resources.GetObject("btnLamMoi.Image");
            btnLamMoi.Location = new Point(1154, 53);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(126, 48);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.TabStop = false;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.TextAlign = ContentAlignment.MiddleRight;
            btnLamMoi.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnChinhSua
            // 
            btnChinhSua.BackColor = Color.FromArgb(192, 192, 255);
            btnChinhSua.Cursor = Cursors.Hand;
            btnChinhSua.FlatAppearance.BorderSize = 0;
            btnChinhSua.FlatStyle = FlatStyle.Flat;
            btnChinhSua.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnChinhSua.ForeColor = Color.White;
            btnChinhSua.Image = (Image)resources.GetObject("btnChinhSua.Image");
            btnChinhSua.Location = new Point(962, 53);
            btnChinhSua.Name = "btnChinhSua";
            btnChinhSua.Size = new Size(90, 48);
            btnChinhSua.TabIndex = 19;
            btnChinhSua.TabStop = false;
            btnChinhSua.Text = "Sửa";
            btnChinhSua.TextAlign = ContentAlignment.MiddleRight;
            btnChinhSua.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnChinhSua.UseVisualStyleBackColor = false;
            btnChinhSua.Click += btnChinhSua_Click;
            // 
            // btnThemPhong
            // 
            btnThemPhong.BackColor = Color.Lime;
            btnThemPhong.Cursor = Cursors.Hand;
            btnThemPhong.FlatAppearance.BorderSize = 0;
            btnThemPhong.FlatStyle = FlatStyle.Flat;
            btnThemPhong.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnThemPhong.ForeColor = Color.White;
            btnThemPhong.Image = (Image)resources.GetObject("btnThemPhong.Image");
            btnThemPhong.Location = new Point(866, 53);
            btnThemPhong.Name = "btnThemPhong";
            btnThemPhong.Size = new Size(90, 48);
            btnThemPhong.TabIndex = 18;
            btnThemPhong.TabStop = false;
            btnThemPhong.Text = "Thêm";
            btnThemPhong.TextAlign = ContentAlignment.MiddleRight;
            btnThemPhong.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThemPhong.UseVisualStyleBackColor = false;
            btnThemPhong.Click += btnThemPhong_Click;
            // 
            // cboLocTrangThai
            // 
            cboLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocTrangThai.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            cboLocTrangThai.FormattingEnabled = true;
            cboLocTrangThai.Location = new Point(657, 53);
            cboLocTrangThai.Name = "cboLocTrangThai";
            cboLocTrangThai.Size = new Size(203, 43);
            cboLocTrangThai.TabIndex = 7;
            cboLocTrangThai.SelectedIndexChanged += cboLocTrangThai_SelectedIndexChanged;
            // 
            // txtTimKiem
            // 
            txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            txtTimKiem.Font = new Font("Segoe UI", 18F, FontStyle.Italic, GraphicsUnit.Point, 163);
            txtTimKiem.Location = new Point(22, 51);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tìm kiếm theo số phòng hoặc mô tả ";
            txtTimKiem.Size = new Size(400, 47);
            txtTimKiem.TabIndex = 17;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // cboLocLoaiPhong
            // 
            cboLocLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocLoaiPhong.DropDownWidth = 200;
            cboLocLoaiPhong.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            cboLocLoaiPhong.FormattingEnabled = true;
            cboLocLoaiPhong.Items.AddRange(new object[] { "Tiêu chuẩn", "Hạng sang", "VIP" });
            cboLocLoaiPhong.Location = new Point(440, 53);
            cboLocLoaiPhong.Name = "cboLocLoaiPhong";
            cboLocLoaiPhong.Size = new Size(211, 43);
            cboLocLoaiPhong.TabIndex = 6;
            cboLocLoaiPhong.SelectedIndexChanged += cboLocLoaiPhong_SelectedIndexChanged;
            // 
            // tabLoaiPhong
            // 
            tabLoaiPhong.Controls.Add(pnlContainerLoaiPhong);
            tabLoaiPhong.Controls.Add(grpThanhTimKiem);
            tabLoaiPhong.Location = new Point(4, 34);
            tabLoaiPhong.Name = "tabLoaiPhong";
            tabLoaiPhong.Padding = new Padding(3);
            tabLoaiPhong.Size = new Size(1292, 721);
            tabLoaiPhong.TabIndex = 1;
            tabLoaiPhong.Text = "Danh sách loại phòng";
            tabLoaiPhong.UseVisualStyleBackColor = true;
            // 
            // pnlContainerLoaiPhong
            // 
            pnlContainerLoaiPhong.Controls.Add(grpDanhSachLoaiPhong);
            pnlContainerLoaiPhong.Controls.Add(grpChucNang);
            pnlContainerLoaiPhong.Dock = DockStyle.Fill;
            pnlContainerLoaiPhong.Location = new Point(3, 146);
            pnlContainerLoaiPhong.Name = "pnlContainerLoaiPhong";
            pnlContainerLoaiPhong.Size = new Size(1286, 572);
            pnlContainerLoaiPhong.TabIndex = 3;
            // 
            // grpDanhSachLoaiPhong
            // 
            grpDanhSachLoaiPhong.Controls.Add(dgvDSLoaiPhong);
            grpDanhSachLoaiPhong.Dock = DockStyle.Fill;
            grpDanhSachLoaiPhong.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDanhSachLoaiPhong.Location = new Point(0, 0);
            grpDanhSachLoaiPhong.Name = "grpDanhSachLoaiPhong";
            grpDanhSachLoaiPhong.Size = new Size(1065, 572);
            grpDanhSachLoaiPhong.TabIndex = 3;
            grpDanhSachLoaiPhong.TabStop = false;
            grpDanhSachLoaiPhong.Text = "Danh sách loại phòng";
            // 
            // dgvDSLoaiPhong
            // 
            dgvDSLoaiPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSLoaiPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvDSLoaiPhong.DefaultCellStyle = dataGridViewCellStyle3;
            dgvDSLoaiPhong.Dock = DockStyle.Fill;
            dgvDSLoaiPhong.Location = new Point(3, 34);
            dgvDSLoaiPhong.Name = "dgvDSLoaiPhong";
            dgvDSLoaiPhong.ReadOnly = true;
            dgvDSLoaiPhong.RowHeadersWidth = 51;
            dgvDSLoaiPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSLoaiPhong.Size = new Size(1059, 535);
            dgvDSLoaiPhong.TabIndex = 4;
            // 
            // grpChucNang
            // 
            grpChucNang.Controls.Add(cboLoaiPhong);
            grpChucNang.Controls.Add(btnXoa2);
            grpChucNang.Controls.Add(btnThem2);
            grpChucNang.Controls.Add(btnLamMoi2);
            grpChucNang.Controls.Add(btnSua2);
            grpChucNang.Dock = DockStyle.Right;
            grpChucNang.Location = new Point(1065, 0);
            grpChucNang.Name = "grpChucNang";
            grpChucNang.Size = new Size(221, 572);
            grpChucNang.TabIndex = 2;
            grpChucNang.TabStop = false;
            grpChucNang.Text = "Chức năng";
            // 
            // cboLoaiPhong
            // 
            cboLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiPhong.DropDownWidth = 200;
            cboLoaiPhong.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 163);
            cboLoaiPhong.FormattingEnabled = true;
            cboLoaiPhong.Items.AddRange(new object[] { "Tiêu chuẩn", "Hạng sang", "VIP" });
            cboLoaiPhong.Location = new Point(12, 57);
            cboLoaiPhong.Name = "cboLoaiPhong";
            cboLoaiPhong.Size = new Size(203, 43);
            cboLoaiPhong.TabIndex = 21;
            cboLoaiPhong.SelectedIndexChanged += cboLoaiPhong_SelectedIndexChanged;
            // 
            // btnXoa2
            // 
            btnXoa2.BackColor = Color.FromArgb(255, 128, 128);
            btnXoa2.Cursor = Cursors.Hand;
            btnXoa2.FlatAppearance.BorderSize = 0;
            btnXoa2.FlatStyle = FlatStyle.Flat;
            btnXoa2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnXoa2.ForeColor = Color.White;
            btnXoa2.Image = (Image)resources.GetObject("btnXoa2.Image");
            btnXoa2.Location = new Point(50, 343);
            btnXoa2.Name = "btnXoa2";
            btnXoa2.Size = new Size(129, 48);
            btnXoa2.TabIndex = 24;
            btnXoa2.TabStop = false;
            btnXoa2.Text = "Xóa";
            btnXoa2.TextAlign = ContentAlignment.MiddleRight;
            btnXoa2.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnXoa2.UseVisualStyleBackColor = false;
            btnXoa2.Click += btnXoa2_Click;
            // 
            // btnThem2
            // 
            btnThem2.BackColor = Color.Lime;
            btnThem2.Cursor = Cursors.Hand;
            btnThem2.FlatAppearance.BorderSize = 0;
            btnThem2.FlatStyle = FlatStyle.Flat;
            btnThem2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnThem2.ForeColor = Color.White;
            btnThem2.Image = (Image)resources.GetObject("btnThem2.Image");
            btnThem2.Location = new Point(50, 177);
            btnThem2.Name = "btnThem2";
            btnThem2.Size = new Size(129, 48);
            btnThem2.TabIndex = 22;
            btnThem2.TabStop = false;
            btnThem2.Text = "Thêm";
            btnThem2.TextAlign = ContentAlignment.MiddleRight;
            btnThem2.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThem2.UseVisualStyleBackColor = false;
            btnThem2.Click += btnThem2_Click;
            // 
            // btnLamMoi2
            // 
            btnLamMoi2.BackColor = SystemColors.MenuHighlight;
            btnLamMoi2.FlatAppearance.BorderSize = 0;
            btnLamMoi2.FlatStyle = FlatStyle.Flat;
            btnLamMoi2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnLamMoi2.ForeColor = Color.White;
            btnLamMoi2.Image = (Image)resources.GetObject("btnLamMoi2.Image");
            btnLamMoi2.Location = new Point(50, 435);
            btnLamMoi2.Name = "btnLamMoi2";
            btnLamMoi2.Size = new Size(129, 48);
            btnLamMoi2.TabIndex = 21;
            btnLamMoi2.TabStop = false;
            btnLamMoi2.Text = "Làm mới";
            btnLamMoi2.TextAlign = ContentAlignment.MiddleRight;
            btnLamMoi2.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLamMoi2.UseVisualStyleBackColor = false;
            btnLamMoi2.Click += btnLamMoi2_Click;
            // 
            // btnSua2
            // 
            btnSua2.BackColor = Color.FromArgb(192, 192, 255);
            btnSua2.Cursor = Cursors.Hand;
            btnSua2.FlatAppearance.BorderSize = 0;
            btnSua2.FlatStyle = FlatStyle.Flat;
            btnSua2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnSua2.ForeColor = Color.White;
            btnSua2.Image = (Image)resources.GetObject("btnSua2.Image");
            btnSua2.Location = new Point(50, 258);
            btnSua2.Name = "btnSua2";
            btnSua2.Size = new Size(129, 48);
            btnSua2.TabIndex = 23;
            btnSua2.TabStop = false;
            btnSua2.Text = "Sửa";
            btnSua2.TextAlign = ContentAlignment.MiddleRight;
            btnSua2.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSua2.UseVisualStyleBackColor = false;
            btnSua2.Click += btnSua2_Click;
            // 
            // grpThanhTimKiem
            // 
            grpThanhTimKiem.Controls.Add(groupBox1);
            grpThanhTimKiem.Controls.Add(cboSapXep);
            grpThanhTimKiem.Controls.Add(txtThanhTimKiem2);
            grpThanhTimKiem.Dock = DockStyle.Top;
            grpThanhTimKiem.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            grpThanhTimKiem.Location = new Point(3, 3);
            grpThanhTimKiem.Name = "grpThanhTimKiem";
            grpThanhTimKiem.Size = new Size(1286, 143);
            grpThanhTimKiem.TabIndex = 2;
            grpThanhTimKiem.TabStop = false;
            grpThanhTimKiem.Text = "Thanh tìm kiếm";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLocTheoGia);
            groupBox1.Controls.Add(lblDen);
            groupBox1.Controls.Add(lblTu);
            groupBox1.Controls.Add(numGiaMax);
            groupBox1.Controls.Add(numGiaMin);
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox1.Location = new Point(657, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(587, 102);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm theo giá";
            // 
            // btnLocTheoGia
            // 
            btnLocTheoGia.BackColor = Color.Gold;
            btnLocTheoGia.FlatAppearance.BorderSize = 0;
            btnLocTheoGia.FlatStyle = FlatStyle.Flat;
            btnLocTheoGia.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnLocTheoGia.ForeColor = Color.White;
            btnLocTheoGia.Image = (Image)resources.GetObject("btnLocTheoGia.Image");
            btnLocTheoGia.Location = new Point(408, 29);
            btnLocTheoGia.Name = "btnLocTheoGia";
            btnLocTheoGia.Size = new Size(163, 52);
            btnLocTheoGia.TabIndex = 30;
            btnLocTheoGia.Text = "Tìm theo giá ";
            btnLocTheoGia.TextAlign = ContentAlignment.MiddleRight;
            btnLocTheoGia.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLocTheoGia.UseVisualStyleBackColor = false;
            btnLocTheoGia.Click += btnLocTheoGia_Click;
            // 
            // lblDen
            // 
            lblDen.AutoSize = true;
            lblDen.Location = new Point(217, 44);
            lblDen.Name = "lblDen";
            lblDen.Size = new Size(47, 23);
            lblDen.TabIndex = 29;
            lblDen.Text = "Đến:";
            // 
            // lblTu
            // 
            lblTu.AutoSize = true;
            lblTu.Location = new Point(19, 45);
            lblTu.Name = "lblTu";
            lblTu.Size = new Size(36, 23);
            lblTu.TabIndex = 28;
            lblTu.Text = "Từ:";
            // 
            // numGiaMax
            // 
            numGiaMax.Location = new Point(270, 42);
            numGiaMax.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numGiaMax.Name = "numGiaMax";
            numGiaMax.Size = new Size(116, 30);
            numGiaMax.TabIndex = 27;
            numGiaMax.ThousandsSeparator = true;
            // 
            // numGiaMin
            // 
            numGiaMin.Location = new Point(61, 43);
            numGiaMin.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numGiaMin.Name = "numGiaMin";
            numGiaMin.Size = new Size(116, 30);
            numGiaMin.TabIndex = 26;
            numGiaMin.ThousandsSeparator = true;
            // 
            // cboSapXep
            // 
            cboSapXep.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSapXep.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            cboSapXep.FormattingEnabled = true;
            cboSapXep.Location = new Point(449, 54);
            cboSapXep.Name = "cboSapXep";
            cboSapXep.Size = new Size(181, 43);
            cboSapXep.TabIndex = 19;
            cboSapXep.SelectedIndexChanged += cboSapXep_SelectedIndexChanged;
            // 
            // txtThanhTimKiem2
            // 
            txtThanhTimKiem2.BorderStyle = BorderStyle.FixedSingle;
            txtThanhTimKiem2.Font = new Font("Segoe UI", 18F, FontStyle.Italic, GraphicsUnit.Point, 163);
            txtThanhTimKiem2.Location = new Point(17, 55);
            txtThanhTimKiem2.Name = "txtThanhTimKiem2";
            txtThanhTimKiem2.PlaceholderText = "Tìm kiếm theo tên loại phòng hoặc mô tả ";
            txtThanhTimKiem2.Size = new Size(400, 47);
            txtThanhTimKiem2.TabIndex = 18;
            txtThanhTimKiem2.TextChanged += txtThanhTimKiem2_TextChanged;
            // 
            // usPhong
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(tabContainerPhong);
            Name = "usPhong";
            Size = new Size(1300, 759);
            Load += usPhong_Load;
            tabContainerPhong.ResumeLayout(false);
            tabPhong.ResumeLayout(false);
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDSPhong).EndInit();
            grpTimkiem.ResumeLayout(false);
            grpTimkiem.PerformLayout();
            tabLoaiPhong.ResumeLayout(false);
            pnlContainerLoaiPhong.ResumeLayout(false);
            grpDanhSachLoaiPhong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDSLoaiPhong).EndInit();
            grpChucNang.ResumeLayout(false);
            grpThanhTimKiem.ResumeLayout(false);
            grpThanhTimKiem.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numGiaMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGiaMin).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlThongTinPhong;
        private TabControl tabContainerPhong;
        private TabPage tabPhong;
        private TabPage tabLoaiPhong;
        private GroupBox grpTimkiem;
        private ComboBox cboLocTrangThai;
        private TextBox txtTimKiem;
        private ComboBox cboLocLoaiPhong;
        private Button btnLamMoi;
        private Button btnThemPhong;
        private Button btnChinhSua;
        private Button btnXoaPhong;
        private GroupBox grpDanhSach;
        private DataGridView dgvDSPhong;
        private GroupBox grpThanhTimKiem;
        private ComboBox cboSapXepMax;
        private TextBox txtThanhTimKiem2;
        private ComboBox cboLoaiPhong;
        private Panel pnlContainerLoaiPhong;
        private GroupBox grpChucNang;
        private Button btnXoa2;
        private Button btnThem2;
        private Button btnLamMoi2;
        private Button btnSua2;
        private GroupBox grpDanhSachLoaiPhong;
        private DataGridView dgvDSLoaiPhong;
        private ComboBox cboSapXep;
        private GroupBox groupBox1;
        private Label lblDen;
        private Label lblTu;
        private NumericUpDown numGiaMax;
        private NumericUpDown numGiaMin;
        private Button btnLocTheoGia;
    }
}
