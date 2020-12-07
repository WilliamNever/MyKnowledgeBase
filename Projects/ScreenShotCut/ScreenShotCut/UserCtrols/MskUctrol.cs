using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScreenShotCutLib.Models;
using ScreenShotCutLib;

namespace ScreenShotCut.UserCtrols
{
    public partial class MskUctrol : UserControl
    {
        private Point pbegin;
        private Point pend;
        private bool isRecord;
        public MskUctrol()
        {
            InitializeComponent();
            isRecord = false;
            DoubleBuffered = true;
            pend = new Point(-1, -1);
        }

        private void MskUctrol_MouseDown(object sender, MouseEventArgs e)
        {
            pbegin = e.Location;
            isRecord = true;
        }

        private void MskUctrol_MouseUp(object sender, MouseEventArgs e)
        {
            isRecord = false;
            if (e.Button == MouseButtons.Left)
            {
                ((IFormSnap)ParentForm).SaveAndCloseForm(pbegin, pend);
            }
            else
            {
                ((IFormSnap)ParentForm).KeyPress((char) 27);
            }
        }

        private void MskUctrol_MouseMove(object sender, MouseEventArgs e)
        {
            if (isRecord)
            {
                pend = e.Location;
                BackgroundImage = ScSCutDomain.CreatSelectArea(Width, Height, pbegin, pend);
                Update();
            }
        }

        private void MskUctrol_KeyPress(object sender, KeyPressEventArgs e)
        {
            ((IFormSnap)ParentForm).KeyPress(e.KeyChar);
        }
    }
}
