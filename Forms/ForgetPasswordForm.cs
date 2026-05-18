using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using HotelManagement.Interfaces;
using HotelManagement.Helpers;

namespace HotelManagement.Forms
{
    public partial class ForgetPasswordForm : Form
    {
        private readonly IUserService _userService;

        // Bơm DI UserService vào Constructor
        public ForgetPasswordForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void QuenMKForm_Load(object sender, EventArgs e)
        {
            txtNhapEmail.Focus();
        }

        private void btnQuayVeLogin_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = Program.ServiceProvider.GetRequiredService<LoginForm>();
            loginForm.Show();
        }

        private void btnGuiOTP_Click(object sender, EventArgs e)
        {
            string email = txtNhapEmail.Text.Trim();

            // 1. Validate định dạng Email rỗng
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ Email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra xem Email có tồn tại trên hệ thống không
            if (!_userService.CheckEmailExists(email))
            {
                MessageBox.Show("Email này không tồn tại trong hệ thống tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Tạo mã OTP ngẫu nhiên gồm 6 chữ số
            Random rand = new Random();
            string otpCode = rand.Next(100000, 999999).ToString();
            DateTime expiryTime = DateTime.Now.AddMinutes(5); // Hết hạn sau 5 phút

            // 4. Tiến hành gửi Email
            this.Cursor = Cursors.WaitCursor; // Đổi con trỏ chuột sang trạng thái chờ khi gửi mail
            bool isSent = EmailHelper.SendOtpEmail(email, otpCode);
            this.Cursor = Cursors.Default;

            if (isSent)
            {
                MessageBox.Show("Mã OTP đã được gửi tới Email của bạn. Vui lòng kiểm tra hộp thư!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 5. Khởi tạo DoiMKForm từ DI Container và chuyển dữ liệu sang
                var doiMKForm = Program.ServiceProvider.GetRequiredService<DoiMKForm>();
                doiMKForm.Setup(email, otpCode, expiryTime);

                // Ẩn form hiện tại đi và hiện form đổi mật khẩu lên
                this.Hide();
                doiMKForm.ShowDialog();

                // Sau khi đổi mật khẩu xong hoặc đóng form đổi mật khẩu thì đóng luôn form quên MK này
                this.Close();
            }
            else
            {
                MessageBox.Show("Gửi Email thất bại! Vui lòng kiểm tra lại kết nối mạng hoặc cấu hình SMTP.", "Lỗi gửi Mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}