namespace WLED_CAM_APP
{
    using AForge.Video;
    using AForge.Video.DirectShow;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Diagnostics;
    using System.Drawing;
    using System.Net;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Windows.Forms;
    using static System.Net.Mime.MediaTypeNames;

    public partial class MainForm : Form
    {
        private FilterInfoCollection? videoDevices;
        private VideoCaptureDevice? videoSource;

        private Bitmap? currentFrame;
        private float zoomLevel = 1.0f;

        private Bitmap? squareFrame;
        private Bitmap? lowResFrame;
        private int squareSide = 44;

        public MainForm()
        {
            InitializeComponent();

            LoadVideoDevices();

            StartCamera();

            LoadSettings();
        }
        void LoadSettings()
        {
            string path = "settings.txt";
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);

                int numberOfSettings = 5;

                if (lines.Length >= numberOfSettings)
                {
                    textBoxIP3.Text = lines[0];
                    textBoxIP4.Text = lines[1];
                    textBoxBrightness.Text = lines[2];
                    textBoxSegmentID.Text = lines[3];
                    textBoxPayload.Text = lines[4];
                    int maxZoomx10 = Convert.ToInt32(lines[5]);
                    trackBarZoom.Maximum = maxZoomx10;
                    labelMaxZoom.Text = (maxZoomx10 / 10.0).ToString("0.0") + "X";
                }

            }
        }

        void SaveSettings()
        {
            var lines = new string[]
            {
                textBoxIP3.Text,
                textBoxIP4.Text,
                textBoxBrightness.Text,
                textBoxSegmentID.Text,
                textBoxPayload.Text,
                trackBarZoom.Maximum.ToString()
            };
            File.WriteAllLines("settings.txt", lines);
        }

        private void LoadVideoDevices()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            comboBoxCameras.Items.Clear();

            foreach (FilterInfo device in videoDevices)
            {
                comboBoxCameras.Items.Add(device.Name);
            }

            if (comboBoxCameras.Items.Count > 0)
            {
                comboBoxCameras.SelectedIndex = 0; // Select the first camera by default
            }
            else
            {
                comboBoxCameras.Items.Add("No cameras found");
                comboBoxCameras.Enabled = false;
            }
        }

        private void StartCamera()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }

            int index = comboBoxCameras.SelectedIndex;
            if (index >= 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices![index].MonikerString);
                videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();
            }
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();

            // Store frame for drawing (thread-safe update)
            lock (this)
            {
                currentFrame?.Dispose();
                currentFrame = frame;
            }

            pictureBoxCamera.Invalidate(); // Force redraw with zoom
        }

        private void comboBoxCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartCamera(); // Restart with selected camera
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cleanup
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }

            SaveSettings();
        }

        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            zoomLevel = trackBarZoom.Value / 10f;
            pictureBoxCamera.Invalidate();
        }

        private void pictureBoxCamera_Paint(object sender, PaintEventArgs e)
        {
            lock (this)
            {
                if (currentFrame == null) return;

                int frameW = currentFrame.Width;
                int frameH = currentFrame.Height;
                int squareSize = pictureBoxCamera.Width; // assuming square

                // 1x zoom scale = fit shorter side to square
                float baseScale = (float)squareSize / Math.Min(frameW, frameH);
                float scale = baseScale * zoomLevel;

                int newWidth = (int)(frameW * scale);
                int newHeight = (int)(frameH * scale);

                int x = (squareSize - newWidth) / 2;
                int y = (squareSize - newHeight) / 2;

                // Make sure squareFrame is allocated
                if (squareFrame == null)
                {
                    squareFrame?.Dispose();
                    squareFrame = new Bitmap(squareSize, squareSize);
                }

                using (Graphics g = Graphics.FromImage(squareFrame))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(currentFrame, x, y, newWidth, newHeight);
                }

                // Now draw the squareFrame onto the display
                e.Graphics.DrawImage(squareFrame, 0, 0, squareSize, squareSize);
            }
        }

        private bool makeLowResImage()
        {
            if (squareFrame == null) return false;

            // Make sure squareFrame is allocated
            if (lowResFrame == null)
            {
                lowResFrame?.Dispose();
                lowResFrame = new Bitmap(squareSide, squareSide);
            }

            using (Graphics g = Graphics.FromImage(lowResFrame))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                g.DrawImage(squareFrame, 0, 0, squareSide, squareSide);
            }

            return true;
        }

        void saveImages()
        {
            // Save low-resolution frame to "Previews"
            string previewsPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Previews");
            if (!Directory.Exists(previewsPath))
            {
                Directory.CreateDirectory(previewsPath);
            }

            string fileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
            string previewFullPath = Path.Combine(previewsPath, fileName);
            lowResFrame!.Save(previewFullPath, System.Drawing.Imaging.ImageFormat.Png);

            // Save high-resolution current frame to "HD"
            string hdPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "HD");
            if (!Directory.Exists(hdPath))
            {
                Directory.CreateDirectory(hdPath);
            }

            string hdFullPath = Path.Combine(hdPath, fileName);
            currentFrame?.Save(hdFullPath, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            if (!makeLowResImage()) return;

            pixelBoxPreview.Image = lowResFrame;

            saveImages();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (!makeLowResImage()) return;

            pixelBoxPreview.Image = lowResFrame;

            saveImages();

            string WLED_IP = "192.168." + textBoxIP3.Text + "." + textBoxIP4.Text;

            int bri = Convert.ToInt32(textBoxBrightness.Text);
            int seg = Convert.ToInt32(textBoxSegmentID.Text);
            int pay = Convert.ToInt32(textBoxPayload.Text);

            WLED_Sender.SendImageToWLED(lowResFrame!, WLED_IP, bri, seg, pay);
        }

        private async void buttonSetGamma_Click(object sender, EventArgs e)
        {
            string WLED_IP = "192.168." + textBoxIP3.Text + "." + textBoxIP4.Text;

            string url = $"http://{WLED_IP}/settings/leds#Use%20Gamma%20value:~:text=(not%20recommended)-,Use%20Gamma%20value%3A,-Brightness%20factor%3A";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
            /*
            string cfgTxt = await DownloadCfgJson(WLED_IP);

            dynamic cfg = JsonConvert.DeserializeObject(cfgTxt);
            double gamma = Convert.ToDouble(textBoxGamma.Text);
            cfg.light.gc.col = gamma;
            cfgTxt = JsonConvert.SerializeObject(cfg);

            await UploadCfgJson(WLED_IP, cfgTxt);
            */
        }

        async Task<string> DownloadCfgJson(string ip)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"http://{ip}/cfg.json";
                return await client.GetStringAsync(url);
            }
        }

        async Task UploadCfgJson(string ip, string jsonContent)
        {
            using (var client = new HttpClient())
            {
                var requestContent = new MultipartFormDataContent();

                // Create the file content
                var fileContent = new ByteArrayContent(Encoding.UTF8.GetBytes(jsonContent));
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                // Important: the field name must be "data", the filename must be "cfg.json"
                requestContent.Add(fileContent, "data", "cfg.json"); // e.g. "cfg.json"

                // Post to the /edit endpoint
                var response = await client.PostAsync($"http://{ip}/edit", requestContent);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Upload failed: {response.StatusCode} - {result}");
                }
            }
        }
    }
}
