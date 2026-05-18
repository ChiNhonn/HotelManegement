using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using HotelManagement.Interfaces; // Để dùng IUserService

namespace HotelManagement.Forms
{
    public partial class DoiMKForm : Form
    {
        private readonly IUserService _userService;

        // Các biến hứng dữ liệu từ Form Quên mật khẩu chuyển sang
        private string _targetEmail = "";
        private string _validOtp = "";
        private DateTime _otpExpiryTime;

        // Ép DI Container tự động bơm IUserService vào khi khởi tạo
        public DoiMKForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        /// <summary>
        /// Hàm Setup dùng để hứng thông tin từ ForgetPasswordForm truyền sang trước khi hiện Form này lên
        /// </summary>
        public void Setup(string email, string otp, DateTime expiryTime)
        {
            _targetEmail = email;
            _validOtp = otp;
            _otpExpiryTime = expiryTime;
        }

        // =======================================================
        // LÀM MỚI MẬT KHẨU KHI BẤM NÚT XÁC NHẬN
        // =======================================================
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string inputOtp = txtNhapMaOTP.Text.Trim();
            string newPassword = txtNhapMK.Text.Trim();
            string confirmPassword = txtNhaplaiMK.Text.Trim();

            // 1. Kiểm tra rỗng dữ liệu đầu vào
            if (string.IsNullOrEmpty(inputOtp) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả các trường thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra mã OTP nhập vào có khớp với mã hệ thống vừa gửi không
            if (inputOtp != _validOtp)
            {
                MessageBox.Show("Mã OTP không chính xác. Vui lòng kiểm tra lại!", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Kiểm tra mã OTP xem còn hạn 5 phút hay không
            if (DateTime.Now > _otpExpiryTime)
            {
                MessageBox.Show("Mã OTP đã hết hạn sử dụng. Vui lòng quay lại màn hình trước để nhận mã mới!", "Mã hết hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Kiểm tra xem mật khẩu mới và mật khẩu nhập lại có trùng nhau không
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không trùng khớp nhau!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 5. Mọi thứ hợp lệ -> Tiến hành cập nhật mật khẩu xuống Database
            try
            {
                // Gọi hàm update mật khẩu từ service (Bạn tùy biến tên hàm cho khớp với IUserService của bạn nhé)
                _userService.UpdatePassword(_targetEmail, newPassword);

                MessageBox.Show("Đặt lại mật khẩu thành công! Hệ thống sẽ đưa bạn về màn hình đăng nhập.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Đóng form này và mở lại Form đăng nhập
                this.Close();
                var loginForm = Program.ServiceProvider.GetRequiredService<LoginForm>();
                loginForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật mật khẩu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Các sự kiện thay đổi text (bạn có thể để trống hoặc xóa dòng liên kết trong Designer nếu không dùng)
        private void txtNhapMaOTP_TextChanged(object sender, EventArgs e) { }
        private void txtNhapMK_TextChanged(object sender, EventArgs e) { }
    }
}