using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ReadTargetInfor.ClassCodes.Model;
using ReadTargetInfor.ClassCodes.DomainModel;

namespace ReadTargetInfor.ClassCodes.Utilities
{
    public class IOFileDirectoryUtility
    {
        private WriteReportLog writeReportLog;
        private SearchInforDomain searchInforModel;
        private Form InvokeForm;
        private List<Regex> regs;

        public bool CanRunning { get; private set; }

        public IOFileDirectoryUtility(WriteReportLog writeReportLog, SearchInforDomain searchInforModel)
        {
            this.writeReportLog = writeReportLog;
            this.searchInforModel = searchInforModel;
            this.regs = searchInforModel.Regs;
        }

        public void Search(Form BackCallForm)
        {
            this.CanRunning = true;
            InvokeForm = BackCallForm;
            string[] paths = new string[] { searchInforModel.SearchPath };
            this.SearchDirectories(paths);
        }

        private void SearchDirectories(string[] SearchDirectories)
        {
            string[] files = null;
            string[] directories = null;
            string searchFolder;

            foreach (var path in SearchDirectories)
            {
                files = null;
                directories = null;
                searchFolder = path;

                try
                {
                    files = Directory.GetFiles(searchFolder, searchInforModel.Filter);
                    this.WriteSearchFile(files);
                }
                catch
                {
                    this.InvokeForm.Invoke(this.searchInforModel.ShowMessage
                        , new object[] { 
                        string.Format("Cannot read files from {0}." , searchFolder)
                        , EnStatus.Error });
                }
                if (!CanRunning)
                {
                    break;
                }
                if (searchInforModel.IsIncludeSub)
                {
                    try
                    {
                        directories = Directory.GetDirectories(searchFolder);
                        this.SearchDirectories(directories);
                    }
                    catch
                    {
                        this.InvokeForm.Invoke(this.searchInforModel.ShowMessage
                            , new object[] { 
                        string.Format("Cannot read directories from {0}." , searchFolder)
                        , EnStatus.Error });
                    }
                }
            }
        }

        private void WriteSearchFile(string[] files)
        {
            foreach (var file in files)
            {
                if (!this.searchInforModel.IsOnlySearchFile)
                {
                    try
                    {
                        this.writeReportLog.ReNewMemoryStream();
                        WriteSingleFile(file);
                        if (this.writeReportLog.HasContentsInMemoryStream)
                        {
                            this.writeReportLog.WriteLine(
                                string.Format("File:{0}", file));
                            this.writeReportLog.WriteLine("-----------------------------------------------------");
                            this.writeReportLog.WriteMemoryStreamToFile();
                            this.writeReportLog.WriteLine("*****************************************************");
                            this.writeReportLog.WriteLine("");
                        }
                        this.writeReportLog.CloseMemoryStream();
                        this.writeReportLog.Flush();
                    }
                    catch
                    {
                        this.InvokeForm.Invoke(this.searchInforModel.ShowMessage
                                , new object[] { 
                        string.Format("Cannot read {0}." , file)
                        , EnStatus.Error });
                    }
                }
                else
                {
                    this.writeReportLog.WriteLine(file);
                }
            }
        }

        private void WriteSingleFile(string file)
        {
            var fEncoding = this.searchInforModel.OpenFileEncoding;
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader srd;
            if (fEncoding == null)
            {
                srd = new StreamReader(fs, true);
            }
            else
            {
                srd = new StreamReader(fs, fEncoding);
            }
            int i = 1;
            string line;
            while (!srd.EndOfStream)
            {
                line = "";
                line = srd.ReadLine();
                if (IsMathLineTxt(line))
                {
                    WriteToReport(i, line);
                }
                i++;
            }
            srd.Close();
            this.writeReportLog.FlushMemoryStream();
        }

        private bool IsMathLineTxt(string line)
        {
            bool returnValue = false;
            foreach (var reg in this.regs)
            {
                if (reg.IsMatch(line))
                {
                    returnValue = true;
                    break;
                }
            }
            return returnValue;
        }

        private void WriteToReport(int i, string line)
        {
            this.writeReportLog.WriteMemoryStream(string.Format(
                "line:{0}", i));
            this.writeReportLog.WriteMemoryStream(line);
            this.writeReportLog.WriteMemoryStream("");
        }


        public void ExitRun()
        {
            this.CanRunning = false;
        }
    }
}
