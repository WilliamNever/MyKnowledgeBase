using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleTestForLog4Net.XMLTextReaderTest
{
    public class TestXMLReader:IDisposable
    {
        protected XmlDocument xd;
        protected System.Text.StringBuilder sb;
        protected System.Xml.XmlWriter xw;

        public TestXMLReader(string Path)
        {
            try
            {
                xd = new XmlDocument();
                xd.Load(Path);
            }
            catch (Exception ex)
            {
                log4net.LogManager.GetLogger(GetType()).Error("Init and Load XmlDocument Errors.", ex);
            }
            sb = new System.Text.StringBuilder();
            //var xmlSetting = new XmlWriterSettings();
            //xmlSetting.Encoding = Encoding.UTF8;
            //xw = System.Xml.XmlWriter.Create(sb, xmlSetting);
            xw = System.Xml.XmlWriter.Create(sb);
        }

        //public 

        void IDisposable.Dispose()
        {
            xw.Close();
        }

        public string ReadALL()
        {
            
            xd.WriteContentTo(xw);
            xw.Flush();
            

            return
               sb.ToString()
                ;
        }
    }
}
