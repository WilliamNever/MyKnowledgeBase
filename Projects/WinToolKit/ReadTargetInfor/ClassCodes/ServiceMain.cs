using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ReadTargetInfor.ClassCodes.Model;
using ReadTargetInfor.ClassCodes.Utilities;
using ReadTargetInfor.ClassCodes.DomainModel;

namespace ReadTargetInfor.ClassCodes
{
    public class ServiceMain
    {
        private SearchInforDomain SearchModel;
        private Form InvokeForm;
        private IOFileDirectoryUtility FileTree;
        private WriteReportLog WriteRpt;

        public bool IsRunning { get; private set; }

        private Thread WorkThread = null;

        public ServiceMain()
        {
            this.IsRunning = false;
        }

        public bool StartRun(Form BackCallForm, SearchInforDomain searchInforModel)
        {
            bool returnValue = false;
            if (!this.IsRunning)
            {
                this.IsRunning = true;
                this.InvokeForm = BackCallForm;
                this.SearchModel = searchInforModel;

                this.WorkThread = new Thread(new ThreadStart(this.WorkRun));
                this.WorkThread.IsBackground = true;
                this.WorkThread.Start();
                returnValue = true;
            }
            return returnValue;
        }

        private void WorkRun()
        {
            this.InvokeForm.Invoke(this.SearchModel.ShowMessage, new object[] { "StartRun", EnStatus.Begin });

            this.WriteRpt = new WriteReportLog(this.SearchModel.OutputFilePath);
            this.WriteRpt.Open();

            #region write search conditions
            this.WriteRpt.WriteLine("************************************************************************************");
            this.WriteRpt.WriteLine("Search Conditions:");
            this.WriteRpt.WriteLine("------------------------------------------------------------------------------------");
            this.WriteRpt.WriteLine(string.Format("Is only search file name: {0}", this.SearchModel.IsOnlySearchFile));
            this.WriteRpt.WriteLine(string.Format("Search Path: {0}", this.SearchModel.SearchPath));
            this.WriteRpt.WriteLine(string.Format("File filter: {0}", this.SearchModel.Filter));
            this.WriteRpt.WriteLine(string.Format("Include sub folders: {0}", this.SearchModel.IsIncludeSub));
            this.WriteRpt.WriteLine(string.Format("Report file: {0}", this.SearchModel.OutputFilePath));
            if (!this.SearchModel.IsOnlySearchFile)
            {
                this.WriteRpt.WriteLine("Search Contents:");
                foreach (var str in this.SearchModel.SearchInfor)
                {
                    this.WriteRpt.WriteLine(string.Format("{0}",str));
                }
            }
            this.WriteRpt.WriteLine("************************************************************************************");
            this.WriteRpt.WriteLine("");
            #endregion

            this.FileTree = new IOFileDirectoryUtility(this.WriteRpt,this.SearchModel);
            this.FileTree.Search(this.InvokeForm);

            this.WriteRpt.Close();
            this.WorkThread = null;
            this.IsRunning = false;
            if (this.FileTree.CanRunning)
            {
                this.InvokeForm.Invoke(this.SearchModel.ShowMessage, new object[] { "Finished!", EnStatus.Close });
            }
        }

        public void CloseAndExit()
        {
            if (this.WorkThread != null)
            {
                lock (this.FileTree)
                {
                    this.FileTree.ExitRun();
                    this.WorkThread.Join();
                    this.WriteRpt.Close();
                }
            }
        }
    }
}
