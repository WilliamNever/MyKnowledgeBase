using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenShotCutLib.Models;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing.Drawing2D;

namespace ScreenShotCutLib
{
    public class ScSCutDomain
    {
        private Image Snapped;
        public Image ShotCutted { get; private set; }
        private float ScaleTransformTimes { get; set; }

        public ScSCutDomain()
        {
            ScaleTransformTimes = float.Parse(ConfigurationManager.AppSettings["ScaleTransformTimes"]);
        }

        private Image ShotCutImage()
        {
            Bitmap bitOri = new Bitmap((int)(Screen.PrimaryScreen.Bounds.Width * ScaleTransformTimes), (int)(Screen.PrimaryScreen.Bounds.Height * ScaleTransformTimes));
            Graphics g = Graphics.FromImage(bitOri);
            g.CompositingQuality = CompositingQuality.Default;
            g.SmoothingMode = SmoothingMode.Default;
            g.InterpolationMode = InterpolationMode.Default;
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), bitOri.Size);

            //Bitmap bit = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            //var gx = Graphics.FromImage(bit);
            //gx.CompositingQuality = CompositingQuality.HighQuality;
            //gx.SmoothingMode = SmoothingMode.None;
            //gx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //gx.DrawImage(bitOri,new Rectangle(new Point(0,0),bit.Size)
            //    ,0,0,bitOri.Width,bitOri.Height, GraphicsUnit.Pixel)
            //    ;
            return bitOri;
        }
        public Image ShotCut()
        {
            Snapped = ShotCutImage();

            ShotCutted = new Bitmap(Snapped.Width, Snapped.Height);
            Graphics g = Graphics.FromImage(ShotCutted);
            g.DrawImage(Snapped, 0, 0, new Rectangle(new Point(0, 0), Snapped.Size), GraphicsUnit.Pixel);
            return Snapped;
        }

        public Image GetSnapImage()
        {
            return ShotCutted;
        }

        public Image GetSnapImage(Point begin, Point end)
        {
            try
            {
                SwitchPoinValue(ref begin, ref end);
                if ((begin.X > -1 && begin.Y > -1) && (end.X - begin.X > 0 && end.Y - begin.Y > 0))
                {
                    Bitmap bit = new Bitmap((int)((end.X - begin.X) * ScaleTransformTimes), (int)((end.Y - begin.Y) * ScaleTransformTimes));
                    Graphics g = Graphics.FromImage(bit);
                    g.DrawImage(Snapped, 0, 0, new Rectangle(Convert.ToInt32(begin.X * ScaleTransformTimes), Convert.ToInt32(begin.Y * ScaleTransformTimes), (int)((end.X - begin.X) * ScaleTransformTimes), (int)((end.Y - begin.Y) * ScaleTransformTimes)), GraphicsUnit.Pixel);
                    ShotCutted = bit;
                }
            }
            catch (Exception ex)
            {
                LogFile.Log(this, new { begin = begin, end = end }, string.Format("{0}/{1}/{2}/{3}/{4}", this.GetType().ToString(), begin.X, begin.Y, end.X, end.Y), ex, enLogLevel.High);
            }
            return GetSnapImage();
        }
        private static void SwitchPoinValue(ref Point begin, ref Point end)
        {
            if (begin.X > end.X)
            {
                var tmp = begin.X;
                begin.X = end.X;
                end.X = tmp;
            }
            if (begin.Y > end.Y)
            {
                var tmp = begin.Y;
                begin.Y = end.Y;
                end.Y = tmp;
            }
        }
        public static Image CreatSelectArea(int Width, int Height, Point pbegin, Point pend)
        {
            SwitchPoinValue(ref pbegin, ref pend);

            Bitmap bit = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(bit);
            g.DrawRectangle(new Pen(Brushes.Red, 3F), new Rectangle(pbegin, new Size(pend.X - pbegin.X, pend.Y - pbegin.Y)));
            return bit;
        }
    }
}
