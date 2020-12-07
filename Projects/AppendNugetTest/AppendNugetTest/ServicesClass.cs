using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendNugetTest
{
    public class ServicesClass
    {
        private string version;
        public ServicesClass()
        {
            version = "1.0";
        }
        public string GetVersion()
        {
            return version;
        }
    }
}
