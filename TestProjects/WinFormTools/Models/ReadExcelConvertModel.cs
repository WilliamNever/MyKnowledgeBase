using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormTools.Models
{
    public class ReadExcelConvertModel
    {
        public string CSVPath { get; set; }
        public string ConvertPattern { get; set; }
        public int NumberOfParamPerLine { get; set; }
        public bool IsIncludeHeaderLine { get; set; }
    }
}
