using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ScreenShotCutLib.Functions
{
    public class ConvertClass
    {
        public static string CoverToJSON<T>(T obj)
        {
            var jss = new JavaScriptSerializer();
            return jss.Serialize(obj);
        }
    }
}
