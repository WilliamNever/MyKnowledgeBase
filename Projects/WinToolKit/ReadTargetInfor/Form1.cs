using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReadTargetInfor.ClassCodes;
using ReadTargetInfor.ClassCodes.Model;
using ReadTargetInfor.ClassCodes.DomainModel;
using CommonClasses.ClassesBase.Models;

namespace ReadTargetInfor
{
    public partial class MainForm : Form,ISaveForFile
    {
        private ServiceMain MainServices = null;
        private string resultFileName;
        private string SavedPath = Application.StartupPath + "\\TempData\\";
        private string HasSavedPath = "";
        public ChangeMenuItemName ChangeNameHandler = null;

        public MainForm()
        {
            this.MainServices = new ServiceMain();
            resultFileName = SavedPath + Guid.NewGuid().ToString() + ".txt";
            if (!Directory.Exists(SavedPath))
            {
                Directory.CreateDirectory(SavedPath);
            }
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            cmbBoxEncodingSelect.SelectedIndex = 0;
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            if (!this.MainServices.IsRunning)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowNewFolderButton = false;
                fbd.SelectedPath = this.txtPath.Text;
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.txtPath.Text = fbd.SelectedPath;
                }
            }
            else
            {
                MessageBox.Show(this, "Is in Searching process.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string itemValue;
            if (!string.IsNullOrEmpty(this.txtPath.Text))
            {
                SearchInforDomain SearchModel = new SearchInforDomain();
                SearchModel.Filter = this.txtFilter.Text;
                SearchModel.IsIncludeSub = this.cbkIncludeSub.Checked;
                SearchModel.IsOnlySearchFile = this.chkbOnlyFile.Checked;
                if (!SearchModel.IsOnlySearchFile)
                {
                    foreach (var item in this.cmbConditions.Items)
                    {
                        itemValue = item.ToString();
                        if (!string.IsNullOrEmpty(itemValue)
                            &&
                            SearchModel.TestAndAddReg(itemValue)
                            )
                        {
                            SearchModel.SearchInfor.Add(itemValue);
                        }
                        else
                        {
                            this.cmbConditions.SelectedItem = item;
                            MessageBox.Show(this, string.Format("Item \"{0}\" cannot creat Regex.", itemValue));
                            return;
                        }
                    }
                    SearchModel.OpenFileEncoding = GetOpenEncoding(cmbBoxEncodingSelect.SelectedIndex);
                }
                SearchModel.SearchPath = this.txtPath.Text;
                SearchModel.OutputFilePath = resultFileName;// "Report.txt";
                SearchModel.ShowMessage = new SearchInforDomain.ShowSearchingMessage(this.BackCall);
                if (!Directory.Exists(SearchModel.SearchPath))
                {
                    MessageBox.Show(this, "Directory does not exists.");
                    return;
                }
                if (!this.MainServices.IsRunning)
                {
                    this.txtInfors.Text = "";
                    this.MainServices.StartRun(this, SearchModel);
                }
                else
                {
                    MessageBox.Show(this, "Is in Searching process.");
                }
            }
            else
            {
                MessageBox.Show(this, "Please Select a path to search.");
            }
        }

        virtual protected Encoding GetOpenEncoding(int index)
        {
            Encoding ec = null;
            switch (index)
            {
                case 0:
                    ec = null;
                    break;
                case 1:
                    ec = Encoding.Default;
                    break;
                case 2:
                    ec = Encoding.UTF8;
                    break;
            }
            return ec;
        }

        public void BackCall(string info, EnStatus Status)
        {
            switch (Status)
            {
                case EnStatus.Begin:

                case EnStatus.Comment:

                case EnStatus.Error:
                    this.txtInfors.Text += info + "\r\n";
                    this.txtInfors.Select(this.txtInfors.Text.Length, 0);
                    this.txtInfors.ScrollToCaret();
                    break;
                case EnStatus.Close:
                    this.txtInfors.Text += info + "\r\n";
                    this.txtInfors.Select(this.txtInfors.Text.Length, 0);
                    this.txtInfors.ScrollToCaret();
                    MessageBox.Show(this, "Finished work.");
                    break;
                default:
                    break;
            }
        }

        private void btnAddCondition_Click(object sender, EventArgs e)
        {
            var item = this.cmbConditions.Text;
            if (!string.IsNullOrEmpty(item))
            {
                this.cmbConditions.Items.Add(item);
            }
            this.cmbConditions.Text = "";
        }

        private void btnDeleteCondition_Click(object sender, EventArgs e)
        {
            var index = this.cmbConditions.SelectedIndex;
            if (index > -1)
            {
                var itemS = this.cmbConditions.SelectedItem.ToString();
                this.cmbConditions.Items.RemoveAt(index);
                this.cmbConditions.Text = itemS;
            }
        }

        private void chkbOnlyFile_CheckedChanged(object sender, EventArgs e)
        {
            this.grpSearchConditions.Enabled = !this.chkbOnlyFile.Checked;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.MainServices.CloseAndExit();
            if (File.Exists(resultFileName))
            {
                try
                {
                    File.Delete(resultFileName);
                }
                catch
                {
                }
            }
        }

        private void btnExportResult_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "导出查询结果";
            sfd.Filter = "(.txt)|*.txt";
            sfd.FileName = "result.txt";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var ExpPath = sfd.FileName;
                SavedFile(ExpPath);
            }
        }

        private void SaveToHasSavedPath()
        {
            if (!string.IsNullOrWhiteSpace(HasSavedPath))
            {
                SavedFile(HasSavedPath);
            }
            else
            {
                btnExportResult.PerformClick();
            }
        }

        private void SavedFile(string ExpPath)
        {
            try
            {
                if (File.Exists(ExpPath))
                {
                    File.Delete(ExpPath);
                }
                if (File.Exists(resultFileName))
                {
                    File.Copy(resultFileName, ExpPath, true);
                    HasSavedPath = ExpPath;
                    this.Text = HasSavedPath;
                    BackCall("结果导出到文件：" + ExpPath, EnStatus.Comment);

                    Guid gid;
                    if (ChangeNameHandler != null && Guid.TryParse(Tag.ToString(), out gid))
                    {
                        ChangeNameHandler(HasSavedPath, gid);
                    }
                }
                else
                {
                    MessageBox.Show("没有可导出的结果！");
                }
            }
            catch (Exception ex)
            {
                BackCall(ex.Message, EnStatus.Error);
            }
        }

        #region ISaveForFile 成员

        void ISaveForFile.Save()
        {
            SaveToHasSavedPath();
        }

        void ISaveForFile.SaveAnother()
        {
            btnExportResult.PerformClick();
        }

        #endregion
    }
}
