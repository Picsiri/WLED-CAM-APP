namespace WLED_CAM_APP
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class PixelBox : PictureBox
    {
        public InterpolationMode InterpolationMode { get; set; } = InterpolationMode.NearestNeighbor;
        public PixelOffsetMode OffsetMode { get; set; } = PixelOffsetMode.Half;

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            g.InterpolationMode = this.InterpolationMode;

            // Fix half-pixel shift on NearestNeighbor
            if (this.InterpolationMode == InterpolationMode.NearestNeighbor)
                g.PixelOffsetMode = PixelOffsetMode.Half;

            base.OnPaint(pe);
        }
    }
}