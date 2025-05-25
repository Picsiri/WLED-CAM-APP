namespace WLED_CAM_APP
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxCamera = new PictureBox();
            buttonSend = new Button();
            comboBoxCameras = new ComboBox();
            label1 = new Label();
            trackBarZoom = new TrackBar();
            panelSettings = new Panel();
            buttonSetGamma = new Button();
            label13 = new Label();
            textBoxPayload = new TextBox();
            label12 = new Label();
            textBoxBrightness = new TextBox();
            label11 = new Label();
            textBoxSegmentID = new TextBox();
            label10 = new Label();
            textBoxIP4 = new TextBox();
            textBoxIP3 = new TextBox();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label6 = new Label();
            labelMaxZoom = new Label();
            label9 = new Label();
            buttonPreview = new Button();
            pixelBoxPreview = new PixelBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCamera).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarZoom).BeginInit();
            panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pixelBoxPreview).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxCamera
            // 
            pictureBoxCamera.Location = new Point(20, 20);
            pictureBoxCamera.Name = "pictureBoxCamera";
            pictureBoxCamera.Size = new Size(750, 750);
            pictureBoxCamera.TabIndex = 0;
            pictureBoxCamera.TabStop = false;
            pictureBoxCamera.Paint += pictureBoxCamera_Paint;
            // 
            // buttonSend
            // 
            buttonSend.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSend.Location = new Point(851, 618);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(292, 152);
            buttonSend.TabIndex = 1;
            buttonSend.Text = "Küldés ->";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // comboBoxCameras
            // 
            comboBoxCameras.FormattingEnabled = true;
            comboBoxCameras.Location = new Point(851, 59);
            comboBoxCameras.Name = "comboBoxCameras";
            comboBoxCameras.Size = new Size(292, 23);
            comboBoxCameras.TabIndex = 2;
            comboBoxCameras.SelectedIndexChanged += comboBoxCameras_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(851, 20);
            label1.Name = "label1";
            label1.Size = new Size(167, 21);
            label1.TabIndex = 3;
            label1.Text = "Kamera kiválasztása:";
            // 
            // trackBarZoom
            // 
            trackBarZoom.LargeChange = 2;
            trackBarZoom.Location = new Point(776, 44);
            trackBarZoom.Maximum = 50;
            trackBarZoom.Minimum = 10;
            trackBarZoom.Name = "trackBarZoom";
            trackBarZoom.Orientation = Orientation.Vertical;
            trackBarZoom.Size = new Size(45, 702);
            trackBarZoom.TabIndex = 4;
            trackBarZoom.TickStyle = TickStyle.TopLeft;
            trackBarZoom.Value = 10;
            trackBarZoom.Scroll += trackBarZoom_Scroll;
            // 
            // panelSettings
            // 
            panelSettings.BackColor = Color.IndianRed;
            panelSettings.BorderStyle = BorderStyle.FixedSingle;
            panelSettings.Controls.Add(buttonSetGamma);
            panelSettings.Controls.Add(label13);
            panelSettings.Controls.Add(textBoxPayload);
            panelSettings.Controls.Add(label12);
            panelSettings.Controls.Add(textBoxBrightness);
            panelSettings.Controls.Add(label11);
            panelSettings.Controls.Add(textBoxSegmentID);
            panelSettings.Controls.Add(label10);
            panelSettings.Controls.Add(textBoxIP4);
            panelSettings.Controls.Add(textBoxIP3);
            panelSettings.Controls.Add(label7);
            panelSettings.Controls.Add(label5);
            panelSettings.Controls.Add(label4);
            panelSettings.Controls.Add(label3);
            panelSettings.Controls.Add(label2);
            panelSettings.Location = new Point(851, 104);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(292, 263);
            panelSettings.TabIndex = 6;
            // 
            // buttonSetGamma
            // 
            buttonSetGamma.Location = new Point(186, 227);
            buttonSetGamma.Name = "buttonSetGamma";
            buttonSetGamma.Size = new Size(89, 24);
            buttonSetGamma.TabIndex = 14;
            buttonSetGamma.Text = "go to setting";
            buttonSetGamma.UseVisualStyleBackColor = true;
            buttonSetGamma.Click += buttonSetGamma_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F);
            label13.Location = new Point(42, 227);
            label13.Name = "label13";
            label13.Size = new Size(142, 21);
            label13.TabIndex = 12;
            label13.Text = "Gamma correction:";
            // 
            // textBoxPayload
            // 
            textBoxPayload.Location = new Point(186, 196);
            textBoxPayload.Name = "textBoxPayload";
            textBoxPayload.Size = new Size(39, 23);
            textBoxPayload.TabIndex = 11;
            textBoxPayload.Text = "256";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(42, 194);
            label12.Name = "label12";
            label12.Size = new Size(97, 21);
            label12.TabIndex = 10;
            label12.Text = "Payload size:";
            // 
            // textBoxBrightness
            // 
            textBoxBrightness.Location = new Point(186, 130);
            textBoxBrightness.Name = "textBoxBrightness";
            textBoxBrightness.Size = new Size(39, 23);
            textBoxBrightness.TabIndex = 9;
            textBoxBrightness.Text = "255";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(42, 128);
            label11.Name = "label11";
            label11.Size = new Size(86, 21);
            label11.TabIndex = 8;
            label11.Text = "Brightness:";
            // 
            // textBoxSegmentID
            // 
            textBoxSegmentID.Location = new Point(186, 163);
            textBoxSegmentID.Name = "textBoxSegmentID";
            textBoxSegmentID.Size = new Size(39, 23);
            textBoxSegmentID.TabIndex = 7;
            textBoxSegmentID.Text = "0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(42, 161);
            label10.Name = "label10";
            label10.Size = new Size(94, 21);
            label10.TabIndex = 6;
            label10.Text = "Segment ID:";
            // 
            // textBoxIP4
            // 
            textBoxIP4.Location = new Point(186, 95);
            textBoxIP4.Name = "textBoxIP4";
            textBoxIP4.Size = new Size(39, 23);
            textBoxIP4.TabIndex = 5;
            textBoxIP4.Text = "183";
            // 
            // textBoxIP3
            // 
            textBoxIP3.Location = new Point(139, 95);
            textBoxIP3.Name = "textBoxIP3";
            textBoxIP3.Size = new Size(39, 23);
            textBoxIP3.TabIndex = 5;
            textBoxIP3.Text = "3";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(224, 98);
            label7.Name = "label7";
            label7.Size = new Size(10, 15);
            label7.TabIndex = 4;
            label7.Text = ".";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(176, 98);
            label5.Name = "label5";
            label5.Size = new Size(10, 15);
            label5.TabIndex = 4;
            label5.Text = ".";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(84, 98);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 4;
            label4.Text = "192.168.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(42, 66);
            label3.Name = "label3";
            label3.Size = new Size(72, 21);
            label3.TabIndex = 3;
            label3.Text = "Target IP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(15, 12);
            label2.Name = "label2";
            label2.Size = new Size(219, 42);
            label2.TabIndex = 3;
            label2.Text = "Ezt a részt inkább csak Ricsi\r\nnyomkodja...";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(819, 265);
            label6.Name = "label6";
            label6.Size = new Size(23, 168);
            label6.TabIndex = 7;
            label6.Text = "N\r\na\r\ng\r\ny\r\ní\r\nt\r\ná\r\ns";
            // 
            // labelMaxZoom
            // 
            labelMaxZoom.AutoSize = true;
            labelMaxZoom.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelMaxZoom.Location = new Point(783, 20);
            labelMaxZoom.Name = "labelMaxZoom";
            labelMaxZoom.Size = new Size(28, 21);
            labelMaxZoom.TabIndex = 8;
            labelMaxZoom.Text = "5x";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label9.Location = new Point(783, 749);
            label9.Name = "label9";
            label9.Size = new Size(28, 21);
            label9.TabIndex = 8;
            label9.Text = "1x";
            // 
            // buttonPreview
            // 
            buttonPreview.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonPreview.Location = new Point(851, 392);
            buttonPreview.Name = "buttonPreview";
            buttonPreview.Size = new Size(66, 220);
            buttonPreview.TabIndex = 9;
            buttonPreview.Text = "Elő-\r\nnézet";
            buttonPreview.UseVisualStyleBackColor = true;
            buttonPreview.Click += buttonPreview_Click;
            // 
            // pixelBoxPreview
            // 
            pixelBoxPreview.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            pixelBoxPreview.Location = new Point(923, 392);
            pixelBoxPreview.Name = "pixelBoxPreview";
            pixelBoxPreview.OffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            pixelBoxPreview.Size = new Size(220, 220);
            pixelBoxPreview.SizeMode = PictureBoxSizeMode.StretchImage;
            pixelBoxPreview.TabIndex = 10;
            pixelBoxPreview.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 786);
            Controls.Add(pixelBoxPreview);
            Controls.Add(buttonPreview);
            Controls.Add(label9);
            Controls.Add(labelMaxZoom);
            Controls.Add(label6);
            Controls.Add(panelSettings);
            Controls.Add(trackBarZoom);
            Controls.Add(label1);
            Controls.Add(comboBoxCameras);
            Controls.Add(buttonSend);
            Controls.Add(pictureBoxCamera);
            Name = "MainForm";
            Text = "A világ legjobb appja 3000x. Éljen az ifjú pár! Amúgy ne ezt olvasgassd, hanem hajtsál tovább a bingó fődíjra!";
            FormClosing += MainForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBoxCamera).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarZoom).EndInit();
            panelSettings.ResumeLayout(false);
            panelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pixelBoxPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxCamera;
        private Button buttonSend;
        private ComboBox comboBoxCameras;
        private Label label1;
        private TrackBar trackBarZoom;
        private Panel panelSettings;
        private Label label3;
        private Label label2;
        private TextBox textBoxIP4;
        private TextBox textBoxIP3;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label label6;
        private Label labelMaxZoom;
        private Label label9;
        private Button buttonPreview;
        private PixelBox pixelBoxPreview;
        private TextBox textBoxSegmentID;
        private Label label10;
        private TextBox textBoxBrightness;
        private Label label11;
        private TextBox textBoxPayload;
        private Label label12;
        private Label label13;
        private Button buttonSetGamma;
    }
}
