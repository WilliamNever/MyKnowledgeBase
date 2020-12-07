using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReadTargetInfor.ClassCodes.Model
{
    public class SearchInforModel
    {
        protected string filter;
        public bool IsOnlySearchFile { get; set; }
        public string Filter
        {
            get {
                string returnValue = "*.*";
                if (!string.IsNullOrEmpty(this.filter))
                {
                    returnValue = this.filter;
                }
                return returnValue;
            }
            set {
                this.filter = value;
            }
        }
        public List<string> SearchInfor { get; set; }
        public bool IsIncludeSub { get; set; }
        public string SearchPath { get; set; }

        public string OutputFilePath { get; set; }
        public Encoding OpenFileEncoding { get; set; }

        public delegate void ShowSearchingMessage(string infos,EnStatus Statu);
        public ShowSearchingMessage ShowMessage;

        public SearchInforModel()
        {
            this.ShowMessage = null;
            this.IsIncludeSub = true;
            this.SearchInfor = new List<string>();
        }
    }
}
