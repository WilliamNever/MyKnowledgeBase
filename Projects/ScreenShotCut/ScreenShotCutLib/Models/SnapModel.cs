using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenShotCutLib.Models
{
    public class SnapModel
    {
        public bool IsFileSave { get; set; }
        public FileSaveParam FSavePam { get; set; }

        public SnapModel()
        {
            IsFileSave = false;
            FSavePam = new FileSaveParam();
        }

    }

    public class FileSaveParam
    {
        private int SequenceNum;
        private DateTime ndt;
        private string fileName;
        private string filePath;
        public bool IsAutoSave { get; set; }
        public string FileAutoPath { get {
                return filePath;
            } set {
                if (!string.IsNullOrWhiteSpace(value)) {
                filePath = value;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                } }
            } }
        public string FileAutoName { get {
                SequenceNum++;
                return string.Format("{0}{1}{2}{3}-{4}.Png", fileName, ndt.Year, ndt.Month, ndt.Day, SequenceNum.ToString().PadLeft(5, '0'));
            } set {
                fileName = value;
            } }

        public FileSaveParam()
        {
            fileName = "Img";
            SequenceNum = 0;
            ndt = DateTime.Now;
            IsAutoSave = false;
            FileAutoPath = System.Windows.Forms.Application.StartupPath + "\\SaveImages\\";//Environment.CurrentDirectory
            if (!Directory.Exists(FileAutoPath))
            {
                Directory.CreateDirectory(FileAutoPath);
            }
        }
    }
}
