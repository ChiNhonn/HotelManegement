using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net; 

namespace HotelManagement.Forms
{
    public partial class PaymentByBankForm : Form
    {
        public PaymentByBankForm()
        {
            InitializeComponent();
        }

        private void PaymentByBankForm_Load(object sender, EventArgs e)
        {
            try
            {
                string maNganHang = "Vietcombank";
                string soTaiKhoan = "1049867988"; 
                string tenChuTaiKhoan = "TRAN DIEU HUY";

                decimal tongTien = 1500000;
                string noiDungTT = "Thanh toan phong 101"; 

                string encodedNoiDung = Uri.EscapeDataString(noiDungTT);
                string encodedTen = Uri.EscapeDataString(tenChuTaiKhoan);

                string apiUrl = $"https://img.vietqr.io/image/{maNganHang}-{soTaiKhoan}-compact2.png?amount={tongTien}&addInfo={encodedNoiDung}&accountName={encodedTen}";

                picQRCode.LoadAsync(apiUrl);

                MessageBox.Show("Đã tạo mã QR thành công! Vui lòng đưa khách quét mã.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo QR: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
