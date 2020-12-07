using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcJqGridTest.ViewModel.JQPageModel
{
    public class JQGridPageModel
    {
        //_search=true&nd=1497238937254&rows=20&page=1&sidx=ID&sord=desc
        public bool _search { get; set; }
        public string nd { get; set; }
        public int rows { get; set; }
        public int page { get; set; }
        public string sidx { get; set; }
        public string sord { get; set; }
    }
}