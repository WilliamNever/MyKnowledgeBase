//#define debug

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScreenShotCutLib.Models;
using ScreenShotCutLib;

namespace ScreenShotCut.BaseForms
{
    public partial class FrmShotSnap : Form, IFormSnap
    {
        private Image SnappedImage = null;
        private ScSCutDomain scsDomain;

        public FrmShotSnap()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
            scsDomain = new ScSCutDomain();
            this.BackgroundImage = scsDomain.ShotCut();
            this.Update();
        }

        private void FrmShotSnap_KeyPress(object sender, KeyPressEventArgs e)
        {
            ((IFormSnap)this).KeyPress(e.KeyChar);
        }

        public Image GetSnappedImage()
        {
            return SnappedImage;
        }

        void IFormSnap.SaveAndCloseForm(Point begin, Point end)
        {
            LogFile.Log(this, new { begin = begin, end = end }, string.Format("{0}/{1}/{2}/{3}", begin.X, begin.Y, end.X, end.Y), null, enLogLevel.Low);
            if (end.X < 0 && end.Y < 0)
            {
                SnappedImage = scsDomain.GetSnapImage();
            }
            else
            {
                SnappedImage = scsDomain.GetSnapImage(begin, end);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        void IFormSnap.KeyPress(char keyChar)
        {
            if (keyChar == 27)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void FrmShotSnap_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
#if debug
            TopMost = false;
            WindowState = FormWindowState.Normal;
#endif
        }
    }
}
