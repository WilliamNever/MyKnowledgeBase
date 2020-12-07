using ScreenShotCut.BaseForms;
using ScreenShotCutLib;
using ScreenShotCutLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShotCut
{
    public partial class MainForm : BaseForm
    {
        private bool isClose = false;
        private SnapModel spm;
        private bool ToShotCut = false;
        public MainForm()
        {
            InitializeComponent();
            try
            {
                spm = new SnapModel();
            }
            catch (Exception ex)
            {
                LogFile.Log(this, new { Param = "Init SnapModel Error." }, "Init SnapModel Error.", ex, enLogLevel.High);
                Close();
            }
        }

        private void NotifyIconCMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var item = e.ClickedItem;
            if (item != null)
            {
                switch (item.Name)
                {
                    case "tsmToShotCutem":
                        //Doing Snap
                        ToShotCut = true;
                        break;
                    case "tsmShowConfigurations":
                        SwitchWForm();
                        break;
                    case "tsmOpenSavedFolder":
                        System.Diagnostics.Process.Start(spm.FSavePam.FileAutoPath);
                        break;
                    case "tsmitmExit":
                        isClose = true;
                        Close();
                        break;
                    
                    default:
                        break;
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClose)
            {
                e.Cancel = true;
                SwitchWForm();
            }
        }

        private void NotifyIconFunctions_DoubleClick(object sender, EventArgs e)
        {
            SwitchWForm();
        }

        private void SwitchWForm()
        {
            bool isMini = this.WindowState == FormWindowState.Minimized;
            if (!isMini)
            {
                //to set shotcut params
                try
                {
                    lock (spm)
                    {
                        spm = new SnapModel();
                        spm.IsFileSave = cbIsSaveToFile.Checked;
                        spm.FSavePam.IsAutoSave = cbIsAutoSave.Checked;
                        spm.FSavePam.FileAutoPath = txtAutoSavePath.Text;
                        spm.FSavePam.FileAutoName = txtAutoSavePreFileName.Text;
                    }
                }
                catch(Exception ex)
                {
                    LogFile.Log(this, new
                    {
                        IsFileSave = cbIsSaveToFile.Checked,
                        IsAutoSave = cbIsAutoSave.Checked,
                        FileAutoPath = txtAutoSavePath.Text,
                        FileAutoName = txtAutoSavePreFileName.Text
                    },"Errors in setting params for snapscreen.", ex, enLogLevel.High);
                }
            }
            this.Visible = !isMini ? false : true;
            this.WindowState = !isMini ? FormWindowState.Minimized : FormWindowState.Normal;
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            grbSaveFileOptions.Enabled = cbIsSaveToFile.Checked;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void NotifyIconCMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (ToShotCut)
            {
                ToShotCut = false;
                BeginToSnapShot();
            }
        }

        private void BeginToSnapShot()
        {
            using (FrmShotSnap fss = new FrmShotSnap())
            {
                if (fss.ShowDialog() == DialogResult.OK)
                {
                    var img = fss.GetSnappedImage();
                    LogFile.Log(this, new { }, "img is null?" + (img == null).ToString(), null, enLogLevel.Low);
                    if (!spm.IsFileSave)
                    {
                        try
                        {
                            //Clipboard.SetImage(img);
                            Clipboard.SetDataObject(img, true);
                        }
                        catch (Exception ex)
                        {
                            LogFile.Log(this, new { Width = img.Width, Height = img.Height }, string.Format("{0}/{1}/{2}", this.GetType().ToString(), img.Width, img.Height), ex, enLogLevel.High);
                        }
                    }
                    else
                    {
                        if (!spm.FSavePam.IsAutoSave)
                        {
                            SaveFileDialog sfd = new SaveFileDialog();
                            sfd.Filter = "*.Png|*.Png";
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                string fln = sfd.FileName;
                                img.Save(fln, ImageFormat.Png);
                            }
                        }
                        else
                        {
                            img.Save(spm.FSavePam.FileAutoPath + "\\" + spm.FSavePam.FileAutoName, ImageFormat.Png);
                        }
                    }
                }
            }
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtAutoSavePath.Text = fbd.SelectedPath;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SwitchWForm();
        }

        private void cbIsSaveToFile_CheckedChanged(object sender, EventArgs e)
        {
            var ob = sender as CheckBox;
            if (ob != null)
            {
                grbSaveFileOptions.Enabled = ob.Checked;
                grbAutoSaveOptions.Enabled = cbIsAutoSave.Checked;
            }
        }

        private void cbIsAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            var ob = sender as CheckBox;
            if (ob != null)
            {
                grbAutoSaveOptions.Enabled = ob.Checked;
            }
        }
    }
}
