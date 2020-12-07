using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormTESTForDragDrop.FunctionDataDialog;
using WinFormTESTForDragDrop.InterFace;

namespace WinFormTESTForDragDrop
{
    public partial class MainForm : Form, IFormFunctions
    {
        private readonly float defaultFontSize = 14;
        private float StepSizeFont = 0;
        private string MainFormTitle = "Main Form";
        private string SavedFilePath = "";
        private bool IsUseUtf8 = false;
        private Font defaultFont;
        public MainForm()
        {
            InitializeComponent();
        }

        private void txtPath_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void txtPath_DragDrop(object sender, DragEventArgs e)
        {
            ShowFilePath(e);
            OpenFile(txtPath.Text);
        }

        private void txtContents_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void txtContents_DragDrop(object sender, DragEventArgs e)
        {
            ShowFilePath(e);
            OpenFile(txtPath.Text);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPath.Text))
                OpenFile(txtPath.Text);
            else
                btnBrowse_Click(sender, e);
        }

        private void OpenFile(string txtPath)
        {
            if (!string.IsNullOrWhiteSpace(txtPath))
            {
                using (StreamReader srReader = new StreamReader(txtPath, true))
                {
                    txtContents.Text = srReader.ReadToEnd();
                    //IsUseUtf8 = srReader.CurrentEncoding == Encoding.UTF8;
                }
                SavedFilePath = txtPath;
                UpdateFormTitle(SavedFilePath);
            }
        }

        private void UpdateFormTitle(string SavedPath)
        {
            Text = $"{MainFormTitle}" +
                $" - [{SavedPath.Substring(SavedPath.LastIndexOf("\\") + 1)}]" +
                $" - [{(IsUseUtf8 ? "UTF8" : "System Default")}] Encoding";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Txt|*.txt|*.*|*.*";
            if (!string.IsNullOrWhiteSpace(txtPath.Text))
            {
                ofd.InitialDirectory = txtPath.Text.Substring(0, txtPath.Text.LastIndexOf('\\'));
            }
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofd.FileName;
                OpenFile(txtPath.Text);
            }
        }

        private void ShowFilePath(DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            txtPath.Text = files != null && files.Length > 0 ? files[0] : "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CloseFileWithoutSave();
        }

        private void CloseFileWithoutSave()
        {
            txtPath.Text = "";
            txtContents.Text = "";
            SavedFilePath = "";
            Text = $"{MainFormTitle}";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetDefaultFontForTxtContent();
        }
        private void SetFontSizeInTextContent(float FSize)
        {
            if (FSize < 1)
            {
                StepSizeFont++;
            }
            else
            {
                txtContents.Font = new Font(defaultFont.FontFamily, FSize,
                    (defaultFont.Bold ? FontStyle.Bold : FontStyle.Regular)
                    | (defaultFont.Italic ? FontStyle.Italic : FontStyle.Regular)
                    | (defaultFont.Strikeout ? FontStyle.Strikeout : FontStyle.Regular)
                    | (defaultFont.Underline ? FontStyle.Underline : FontStyle.Regular)
                    , defaultFont.Unit
                    /*GraphicsUnit.Point*/);
            }
        }

        private void btnFontDefault_Click(object sender, EventArgs e)
        {
            SetDefaultFontForTxtContent();
        }

        private void SetDefaultFontForTxtContent()
        {
            StepSizeFont = 0;
            defaultFont = new Font(FontFamily.GenericSerif, defaultFontSize, FontStyle.Regular, GraphicsUnit.Point);
            txtContents.ForeColor = Color.Black;
            SetFontSizeInTextContent(defaultFontSize);
        }

        private void btnFontBig_Click(object sender, EventArgs e)
        {
            SetFontSizeInTextContent(defaultFontSize + (++StepSizeFont));
        }

        private void btnFontSmall_Click(object sender, EventArgs e)
        {
            SetFontSizeInTextContent(defaultFontSize + (--StepSizeFont));
        }

        private void chbAutoWrap_CheckedChanged(object sender, EventArgs e)
        {
            txtContents.WordWrap = !txtContents.WordWrap;
            txtContents.ScrollBars = txtContents.WordWrap ? ScrollBars.Vertical : ScrollBars.Both;
        }

        private void TSMIToolsWindows_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            CloseAllMenu();
            switch (e.ClickedItem.Name)
            {
                case "MNIShowCharNumber":
                    FrmShowCharNumber frm = new FrmShowCharNumber(this);
                    frm.Show();
                    break;
            }
        }

        private void TSMIFile_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            CloseAllMenu();
            switch (e.ClickedItem.Name)
            {
                case "TSMISave":
                    Save();
                    break;
                case "TSMISaveAs":
                    SaveAnother(false);
                    break;
                case "tsmiSaveUTF8":
                    SaveAnother(true);
                    break;
                case "TSMIExit":
                    Close();
                    Application.Exit();
                    break;
            }
        }

        private void CloseAllMenu()
        {
            foreach (var item in MainMenu.Items)
            {
                if (item is ToolStripMenuItem tmp)
                {
                    tmp.DropDown.Close();
                }
            }
        }

        void IFormFunctions.CopyTextToForm(string txt, bool isAppend)
        {
            if (isAppend)
                txtContents.Text += txt;
            else
                txtContents.Text = txt;
        }



        #region Save to file

        private void Save(string fPath)
        {
            using (FileStream fs = new FileStream(fPath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, IsUseUtf8 ? Encoding.UTF8 : Encoding.Default))
                {
                    sw.Write(txtContents.Text);
                    sw.Flush();
                }
            }

            UpdateFormTitle(fPath);
        }

        private void Save()
        {
            if (!string.IsNullOrWhiteSpace(SavedFilePath))
            {
                Save(SavedFilePath);
            }
            else
            {
                SaveAnother(IsUseUtf8);
            }
        }

        private void SaveAnother(bool isutf8)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = $"Save As - [{(isutf8 ? "UTF8" : "Default")} Encoding]";
            sfd.Filter = "Txt|*.txt|*.*|*.*";
            if (string.IsNullOrEmpty(SavedFilePath))
                sfd.FileName = "Infors.txt";
            else
                sfd.FileName = SavedFilePath.Substring(SavedFilePath.LastIndexOf("\\") + 1);

            if (!string.IsNullOrEmpty(SavedFilePath))
                sfd.InitialDirectory = SavedFilePath.Substring(0,
                    SavedFilePath.LastIndexOf("\\"));

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                IsUseUtf8 = isutf8;
                SavedFilePath = sfd.FileName;
                Save(SavedFilePath);
            }
        }

        #endregion

        private void btnSelALL_Click(object sender, EventArgs e)
        {
            txtContents.Select();
            txtContents.SelectAll();
        }

        private void BtnCopySel_Click(object sender, EventArgs e)
        {
            txtContents.Copy();
            txtContents.Select();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                txtContents.Paste();
            }

            txtContents.Select();
        }

        private void TSMIEdit_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            CloseAllMenu();
            switch (e.ClickedItem.Name)
            {
                case "MNISelectALL":
                    btnSelALL_Click(sender, e);
                    break;
                case "MNICopy":
                    BtnCopySel_Click(sender, e);
                    break;
                case "MNIPaste":
                    btnPaste_Click(sender, e);
                    break;
                case "MNITrim":
                    txtContents.Text = TrimTexBox(txtContents.Text);
                    break;
                case "MNIFontSelect":
                    SetDefaultFont();
                    break;
            }
        }

        private void SetDefaultFont()
        {
            FontDialog fd = new FontDialog();
            fd.ShowEffects = true;
            fd.ShowColor = true;
            fd.AllowScriptChange = false;
            fd.ScriptsOnly = false;
            fd.Font = defaultFont;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                defaultFont = fd.Font;
                txtContents.Font = defaultFont;
                txtContents.ForeColor = fd.Color;
                StepSizeFont = defaultFont.Size - defaultFontSize;
            }
        }

        private string TrimTexBox(string text)
        {
            string breakStr = "\r\n";
            var lines =
                text.Split(new string[] { breakStr }, StringSplitOptions.None)?
                .Select(x => string.IsNullOrEmpty(x) ? "" : x.Trim());
            return string.Join(breakStr, lines);
        }
    }
}
