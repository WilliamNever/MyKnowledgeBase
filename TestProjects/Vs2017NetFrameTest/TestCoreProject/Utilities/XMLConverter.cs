using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace NetStandardLibrary.ConvertHelpers
{
    public class XMLConverter<T>
    {
        private XmlSerializer serializer;

        public XMLConverter()
        {
            serializer = new XmlSerializer(typeof(T));
        }

        public string Serializer(T obj)
        {
            StringWriter sw;
            string rValue = "";
            using (sw = new StringWriter())
            {
                serializer.Serialize(sw, obj);
                sw.Flush();
                rValue = sw.ToString();
                sw.Close();
            }
            return rValue;
        }

        public T DeSerializer(string str)
        {
            T rValue = default(T);
            StringReader sr;
            using (sr = new StringReader(str.Trim()))
            {
                var obj = serializer.Deserialize(sr);
                rValue = (T)obj;
            }
            return rValue;
        }
    }
}
