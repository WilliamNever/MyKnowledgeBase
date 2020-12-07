using System.IO;
using System.Xml.Serialization;

namespace ProCure.MVCTests.Utilities
{
    public class XMLSerials<T>
    {
        private XmlSerializer serializer;

        public XMLSerials()
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

        public T DeSerailizer(string str)
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
