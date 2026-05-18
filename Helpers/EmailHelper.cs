using System;
using System.Net;
using System.Net.Mail;

namespace HotelManagement.Helpers
{
    public static class EmailHelper
    {
        public static bool SendOtpEmail(string targetEmail, string otpCode)
        {
            try
            {
                var fromAddress = new MailAddress("duongtrinhan00@gmail.com", "HotelManagement");
                var toAddress = new MailAddress(targetEmail);
                const string fromPassword = "cluh dvsr isht olpf"; // Mật khẩu ứng dụng 16 ký tự của Google
                const string subject = "Mã OTP đặt lại mật khẩu";
                string body = $"<h3>Mã OTP của bạn là: <b style='color:red; font-size:20px;'>{otpCode}</b></h3>" +
                              "<p>Mã này có hiệu lực trong vòng 5 phút. Vui lòng không chia sẻ mã này cho bất kỳ ai.</p>";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587, 
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}