using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Log4NetRecordLog.ViewModels
{
    public class PageViewModel
    {
        public List<CheckValueClass> CheckValueList { get; set; }
        public string OpString { get; set; }
    }
}