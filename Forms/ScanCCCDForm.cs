using AForge.Video;
using AForge.Video.DirectShow;
using HotelManagement.ViewModels;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.Forms
{
    public partial class ScanCCCDForm : Form
    {
        public CccdModel ExtractData { get; private set; } = null;

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private const string FPT_API_KEY = "6yf8SPaxet7jlBhH7A0S98vOKr2iHaBl";

        private bool isProcessing = false;

        public ScanCCCDForm()
        {
            InitializeComponent();
            picCamera.Width = 475;
            picCamera.Height = 300;
            picCamera.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void ScanCCCDForm_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
                videoSource.Start();
            }
            else
            {
                MessageBox.Show("Không tìm thấy Webcam kết nối với máy tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (picCamera.IsDisposed || isProcessing) return;

            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();

            picCamera.Invoke(new Action(() => {
                Image oldImage = picCamera.Image;
                picCamera.Image = bit;
                if (oldImage != null)
                {
                    oldImage.Dispose();
                }
            }));
        }

        private async void btnExtract_Click_1(object sender, EventArgs e)
        {
            if (picCamera.Image == null || isProcessing) return;
            Button currentButton = (Button)sender;

            try
            {
                isProcessing = true;
                currentButton.Enabled = false;
                currentButton.Text = "AI đang xử lý...";

                byte[] imageBytes;
                using (Bitmap bitmap = new Bitmap(picCamera.Image))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imageBytes = ms.ToArray();
                    }
                }

                // Gọi API FPT AI
                string jsonResult = await CallFptAiOcr(imageBytes);

                // Phân tích dữ liệu JSON trả về
                ExtractData = ParseJsonToModel(jsonResult);

                if (ExtractData != null)
                {
                    StopCamera();
                    this.DialogResult = DialogResult.OK;
                    this.Close(); // Đóng form và trả kết quả về InfoCustomerForm
                }
                else
                {
                    // 🌟 SỬA LỖI 2: Nếu không lấy được data, phải giải phóng nút bấm để người dùng quét lại
                    MessageBox.Show("Không tìm thấy dữ liệu CCCD hợp lệ. Vui lòng căn chỉnh thẻ rõ nét trước camera và thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isProcessing = false;
                    currentButton.Enabled = true;
                    currentButton.Text = "Xác nhận quét";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhận diện: " + ex.Message, "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isProcessing = false;
                currentButton.Enabled = true;
                currentButton.Text = "Xác nhận quét";
            }
        }

        private async Task<string> CallFptAiOcr(byte[] imageBytes)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(25);

                // 🌟 SỬA LỖI 1: Đổi "scancccd" thành "api_key" theo đúng quy định của FPT
                client.DefaultRequestHeaders.Add("api_key", FPT_API_KEY);

                using (var content = new MultipartFormDataContent())
                {
                    var byteContent = new ByteArrayContent(imageBytes);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                    content.Add(byteContent, "image", "cccd_capture.jpg");

                    string url = "https://api.fpt.ai/vision/idr/v3";
                    var response = await client.PostAsync(url, content);
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        private CccdModel ParseJsonToModel(string jsonString)
        {
            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                JsonElement root = doc.RootElement;

                if (root.TryGetProperty("errorCode", out JsonElement errCode) && errCode.GetInt32() != 0)
                {
                    string errMsg = root.TryGetProperty("errorMessage", out JsonElement msg) ? msg.GetString() : "Lỗi không xác định";
                    throw new Exception($"FPT AI phản hồi lỗi: {errMsg}");
                }

                if (root.TryGetProperty("data", out JsonElement dataArray) && dataArray.GetArrayLength() > 0)
                {
                    JsonElement cccdData = dataArray[0];
                    var model = new CccdModel();

                    if (cccdData.TryGetProperty("id", out JsonElement idElem)) model.Id = idElem.GetString() ?? "";
                    if (cccdData.TryGetProperty("name", out JsonElement nameElem)) model.FullName = nameElem.GetString() ?? "";
                    if (cccdData.TryGetProperty("dob", out JsonElement dobElem)) model.BirthDay = dobElem.GetString() ?? "";
                    if (cccdData.TryGetProperty("sex", out JsonElement sexElem)) model.Gender = sexElem.GetString() ?? "";
                    if (cccdData.TryGetProperty("precinct", out JsonElement xaElem)) model.Xa = xaElem.GetString() ?? "";
                    if (cccdData.TryGetProperty("district", out JsonElement huyenElem)) model.Huyen = huyenElem.GetString() ?? "";
                    if (cccdData.TryGetProperty("province", out JsonElement tinhElem)) model.Tinh = tinhElem.GetString() ?? "";

                    // Thêm mặc định tránh lỗi null ở Form cha
                    model.Country = "Việt Nam";

                    return model;
                }
            }
            return null;
        }

        private void StopCamera()
        {
            // 🌟 SỬA LỖI 3: Đưa việc tắt camera vào try-catch để nuốt lỗi hủy luồng (Thread Abort) trên .NET Core
            try
            {
                if (videoSource != null)
                {
                    videoSource.NewFrame -= VideoSource_NewFrame;
                    if (videoSource.IsRunning)
                    {
                        videoSource.SignalToStop();
                    }
                    videoSource = null;
                }
            }
            catch
            {
                // Bỏ qua lỗi xung đột luồng của AForge để Form đóng lại bình thường
            }
        }

        private void ScanCCCDForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
        }
    }
}