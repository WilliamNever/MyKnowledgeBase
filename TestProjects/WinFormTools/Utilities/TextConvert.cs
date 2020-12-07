using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormTools.Utilities
{
    public class TextConvert
    {
        public static string PostManTestJsonConvert(string strOri, string strNewObjName)
        {
            string rValue = "";

            string txt = strOri.Replace("\r", "").Replace("\n", ";").Replace(";;", ";");

            var lines = txt.Split(new char[] { ';' }, StringSplitOptions.None);
            string[] words;
            string tmpLine;
            foreach (string line in lines)
            {
                if (line.IndexOf("===") < 0)
                {
                    rValue += line + Environment.NewLine;
                    continue;
                }

                tmpLine = line.Replace("\r", "").Replace("\n", "").Substring(0, line.LastIndexOf("=") + 1);

                words = tmpLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int x = 0; x < words.Length; x++)
                {
                    rValue += words[x] + " ";
                }
                string variableWord = words[words.Length - 1 - 1];
                rValue += strNewObjName + "." + variableWord.Substring(variableWord.IndexOf('.') + 1);
                rValue += ";" + Environment.NewLine;
            }
            return rValue;
        }
    }
}
