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
        internal CccdModel ExtractData { get; private set; } = null;

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private const string FPT_API_KEY = "6yf8SPaxet7jlBhH7A0S98vOKr2iHaBl";

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
            if (picCamera.IsDisposed) return;
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            picCamera.Image = bit;
        }

        private async void btnExtract_Click_1(object sender, EventArgs e)
        {
            if (picCamera.Image == null) return;

            Button currentButton = (Button)sender;

            try
            {
                currentButton.Enabled = false;
                currentButton.Text = "AI đang xử lý...";

                Bitmap bitmap = new Bitmap(picCamera.Image);
                byte[] imageBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageBytes = ms.ToArray();
                }

                StopCamera();

                string jsonResult = await CallFptAiOcr(imageBytes);

                ExtractData = ParseJsonToModel(jsonResult);

                if (ExtractData != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhận diện: " + ex.Message, "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ScanCCCDForm_Load(null, null);
                currentButton.Enabled = true;
                currentButton.Text = "Xác nhận quét";
            }
        }

        private async Task<string> CallFptAiOcr(byte[] imageBytes)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("api-key", FPT_API_KEY);
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
                    throw new Exception("AI không đọc được hình ảnh. Hãy giữ chắc tay và chụp lại rõ nét hơn!");
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

                    if (string.IsNullOrEmpty(model.Xa) && cccdData.TryGetProperty("address", out JsonElement addrElem))
                    {
                        string fullAddress = addrElem.GetString() ?? "";
                        if (!string.IsNullOrEmpty(fullAddress))
                        {
                            string[] addressParts = fullAddress.Split(',');
                            if (addressParts.Length >= 3)
                            {
                                model.Xa = addressParts[addressParts.Length - 3].Trim();
                                model.Huyen = addressParts[addressParts.Length - 2].Trim();
                                model.Tinh = addressParts[addressParts.Length - 1].Trim();
                            }
                            else
                            {
                                model.Tinh = fullAddress;
                            }
                        }
                    }
                    return model;
                }
            }
            return null;
        }

        private void StopCamera()
        {
            if (videoSource != null)
            {
                if (videoSource.IsRunning)
                {
                    videoSource.Stop(); 
                }
                videoSource.NewFrame -= VideoSource_NewFrame;
                videoSource = null;
            }
        }

        private void ScanCCCDForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera(); 
        }
    }
}