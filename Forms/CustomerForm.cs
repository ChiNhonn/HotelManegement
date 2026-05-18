using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.Forms
{
    public partial class CustomerForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private BindingList<Customer> _customersList;
        public CustomerForm(IMyDbContext dbContext, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            SetupDataGridView();
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SetupDataGridView()
        {
            dgvCustomer.AutoGenerateColumns = false;
            dgvCustomer.ScrollBars = ScrollBars.Both;

            // 1. Cấu hình các thuộc tính chung cho Grid
            dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomer.ReadOnly = true;
            dgvCustomer.AllowUserToAddRows = false;
            dgvCustomer.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // 2. TẠO CÁC CỘT DỮ LIỆU BẰNG CODE

            // Cột Id (Ẩn)
            var colId = new DataGridViewTextBoxColumn();
            colId.Name = "Id";
            colId.DataPropertyName = "Id"; 
            colId.Visible = false;
            dgvCustomer.Columns.Add(colId);

            // Cột Số CCCD
            var colNo = new DataGridViewTextBoxColumn();
            colNo.Name = "No";
            colNo.DataPropertyName = "No";
            colNo.HeaderText = "Số CCCD";
            colNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCustomer.Columns.Add(colNo);

            // Cột Họ và tên
            var colFullName = new DataGridViewTextBoxColumn();
            colFullName.Name = "FullName";
            colFullName.DataPropertyName = "FullName";
            colFullName.HeaderText = "Họ và tên";
            colFullName.Width = 150; 
            dgvCustomer.Columns.Add(colFullName);

            // Cột Ngày sinh
            var colBirthDay = new DataGridViewTextBoxColumn();
            colBirthDay.Name = "BirthDay";
            colBirthDay.DataPropertyName = "BirthDay";
            colBirthDay.HeaderText = "Ngày sinh";
            dgvCustomer.Columns.Add(colBirthDay);

            // Cột Giới tính
            var colGender = new DataGridViewTextBoxColumn();
            colGender.Name = "Gender";
            colGender.DataPropertyName = "Gender";
            colGender.HeaderText = "Giới tính";
            dgvCustomer.Columns.Add(colGender);

            // Cột Xã
            var colXa = new DataGridViewTextBoxColumn();
            colXa.Name = "Xa";
            colXa.DataPropertyName = "Xa";
            colXa.HeaderText = "Xã";
            dgvCustomer.Columns.Add(colXa);

            // Cột Huyện
            var colHuyen = new DataGridViewTextBoxColumn();
            colHuyen.Name = "Huyen";
            colHuyen.DataPropertyName = "Huyen";
            colHuyen.HeaderText = "Huyện";
            dgvCustomer.Columns.Add(colHuyen);

            // Cột Tỉnh
            var colTinh = new DataGridViewTextBoxColumn();
            colTinh.Name = "Tinh";
            colTinh.DataPropertyName = "Tinh";
            colTinh.HeaderText = "Tỉnh";
            dgvCustomer.Columns.Add(colTinh);

            // Cột Quốc tịch
            var colCountry = new DataGridViewTextBoxColumn();
            colCountry.Name = "Country";
            colCountry.DataPropertyName = "Country";
            colCountry.HeaderText = "Quốc tịch";
            dgvCustomer.Columns.Add(colCountry);

            // Cột Trạng thái
            var colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "Status";
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "Trạng thái";
            dgvCustomer.Columns.Add(colStatus);

            // Cột VIP
            var colVip = new DataGridViewTextBoxColumn();
            colVip.Name = "Vip";
            colVip.DataPropertyName = "Vip";
            colVip.HeaderText = "VIP";
            dgvCustomer.Columns.Add(colVip);


            // 3. THÊM CÁC CỘT NÚT BẤM THAO TÁC
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.Name = "btnEdit"; 
            btnEdit.HeaderText = "Thao tác sửa";
            btnEdit.Text = "Sửa";
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.Width = 60;
            dgvCustomer.Columns.Add(btnEdit);

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "btnSoftDelete"; 
            btnDelete.HeaderText = "Thao tác xóa";
            btnDelete.Text = "Xóa";
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.Width = 60;
            dgvCustomer.Columns.Add(btnDelete);
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dgvCustomer.Columns[e.ColumnIndex].Name;

            if (columnName == "btnEdit")
            {
                MessageBox.Show("Bạn vừa bấm SỬA ở dòng thứ " + e.RowIndex);
            }
            else if (columnName == "btnSoftDelete")
            {
                MessageBox.Show("Bạn vừa bấm XÓA ở dòng thứ " + e.RowIndex);
            }
        }

        private async Task LoadData()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<IMyDbContext>())
                {
                    var customers = await context.Customers.Where(c => c.SoftDelete == null).ToListAsync();

                    _customersList = new BindingList<Customer>(customers);

                    dgvCustomer.DataSource = _customersList;
                }
            }
        }
    }
}
