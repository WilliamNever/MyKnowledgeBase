using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveHtmlTags.Core.Models
{
    public class CommandArgs
    {
        public string Path { get; set; }
        public string PatternFilter { get; set; } = "*.*";
        public string OutputDirectory { get; set; }
        public string MergedFileFullName { get; set; }
        public int? BegingIndex { get; set; } = null;

        public static string PathCommand { get; set; } = "-p";
        public static string PatternFilterCommand { get; set; } = "-px";
        public static string BeginIndexCommand { get; set; } = "-i";
        public static string OutputDirectoryCommand { get; set; } = "-o";
        public static string MergedFileFullNameCommand { get; set; } = "-m";
    }
}
