using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAuthenticationTest.Models
{
    public class CommonPageInforViewModel
    {
        public string PageName { get; set; }
        public CommonPageInforViewModel()
        {
            PageName = "Undefine";
        }
        public CommonPageInforViewModel(string pageName)
        {
            PageName = pageName;
        }
    }
}
