using ScreenShotCutLib.Functions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShotCutLib
{
    public class LogFile
    {
        private static string logFileName;
        private static int logLevel;
        static LogFile()
        {
            logFileName = System.Windows.Forms.Application.StartupPath + "\\log.txt";
            logLevel = int.Parse(ConfigurationManager.AppSettings["LogLevel"]);
        }

        public static void Log<T,V>(T obj,V valueParam, string str, Exception ex, enLogLevel el)
        {
            if (((int)el) >= logLevel)
            {
                using (StreamWriter sw = new StreamWriter(logFileName, true))
                {
                    sw.WriteLine();
                    sw.WriteLine(DateTime.Now.ToString());
                    sw.WriteLine(string.Format("ErrorClass:{0}", obj.GetType().ToString()));
                    sw.WriteLine(string.Format("ErrorLevel:{0}", (int)el));
                    sw.WriteLine(str);
                    sw.WriteLine(ex == null ? "nothing" : ex.Message);
                    sw.WriteLine(valueParam == null ? "Param is Null." : ConvertClass.CoverToJSON(valueParam));
                }
                MessageBox.Show(ex == null ? "nothing" : ex.Message);
            }
        }
    }

    public enum enLogLevel
    {
        Lowest=1,
        Low=2,
        Normal=3,
        High=4,
        Highest=5

    }
}
