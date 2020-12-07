using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonClasses.ClassesBase.Models;
using System.IO;

namespace WinToolKit.ExtendedForms
{
    public partial class Base64DeEncodersExt : Base64DeEncoders.Base64DeEncoders, ISaveForFile
    {
        private string SavedPath = "";
        public ChangeMenuItemName ChangeNameHandler = null;

        public Base64DeEncodersExt():base()
        {
            InitializeComponent();
        }
        public void InitExtForm()
        {
            var rfl = new ReflectClass.ReflectBaseClass<Base64DeEncoders.Base64DeEncoders>(this);
            var btn = rfl.GetInstanceField<Button>("btnExit");
            btn.Enabled = false;
            btn.Visible = false;

            var rflBase = new ReflectClass.ReflectBaseClass<Form>(this);
            rflBase.ClearControlEvent("EVENT_CLOSING", "Closing");
        }

        public void Save(string fPath)
        {
            //导出存储内容
            var rfl = new ReflectClass.ReflectBaseClass<Base64DeEncoders.Base64DeEncoders>(this);
            var isUseUtf8 = rfl.GetInstanceField<CheckBox>("chkBtnUTF8");
            var txtBox = rfl.GetInstanceField<TextBox>("txtBox");
            FileStream fs = new FileStream(fPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, isUseUtf8.Checked ? Encoding.UTF8 : Encoding.Default);
            sw.Write(txtBox.Text);
            sw.Flush();
            sw.Close();
            fs.Close();
            //更新主窗口菜单名称
            Guid gid;
            if (ChangeNameHandler != null && Guid.TryParse(Tag.ToString(), out gid))
            {
                ChangeNameHandler(fPath, gid);
            }
        }

        #region ISaveForFile 成员

        void ISaveForFile.Save()
        {
            if (!string.IsNullOrWhiteSpace(SavedPath))
            {
                Save(SavedPath);
            }
            else
            {
                var ISave = this as ISaveForFile;
                if (ISave != null)
                {
                    ISave.SaveAnother();
                }
            }
        }

        void ISaveForFile.SaveAnother()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "另存为";
            sfd.Filter = "(.txt)|*.txt";
            sfd.FileName = "Infors.txt";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Text = sfd.FileName;
                SavedPath = sfd.FileName;
                Save(SavedPath);
            }
        }

        #endregion
    }
}
