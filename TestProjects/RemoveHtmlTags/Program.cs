using RemoveHtmlTags.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RemoveHtmlTags
{
    class Program
    {
        public static CommandArgs cmdArgs;
        static void Main(string[] args)
        {
            if ((args?.Length ?? 0) == 0
                || args.FirstOrDefault(x => x.Equals(CommandArgs.PathCommand, StringComparison.OrdinalIgnoreCase)) == null
                || (
                    args.FirstOrDefault(x => x.Equals(CommandArgs.OutputDirectoryCommand, StringComparison.OrdinalIgnoreCase)) == null
                    && args.FirstOrDefault(x => x.Equals(CommandArgs.MergedFileFullNameCommand, StringComparison.OrdinalIgnoreCase)) == null
                  )
                )
            {
                Console.WriteLine($"RemoveHtmlTags.exe -p . -px *.* -i 0 -m aaa.txt");
                Console.WriteLine($"{CommandArgs.PathCommand} is required. the files in the path to process.");
                Console.WriteLine($"{CommandArgs.PatternFilterCommand} is required. the filter to pick up the files. default is *.* ");
                Console.WriteLine($"{CommandArgs.BeginIndexCommand} process the files index that bigger than the value. it can be null, if it is null, do not process the filter.");
                Console.WriteLine($"{CommandArgs.OutputDirectoryCommand} the folder to Save Each processed file.");
                Console.WriteLine($"{CommandArgs.MergedFileFullNameCommand} the merged file that cotained all the processed files.");

                Console.WriteLine($"{CommandArgs.OutputDirectoryCommand} and {CommandArgs.MergedFileFullNameCommand} cannot be empty at same time.");
            }
            cmdArgs = ReadArgs(args);

            var files = Directory.GetFiles(cmdArgs.Path, cmdArgs.PatternFilter)
                .Select(x =>
                new ProcessFileModel
                {
                    FullFileName = x,
                    index = GetIndexFromFileName(Path.GetFileNameWithoutExtension(x))
                }
                ).Where(x => x.index.HasValue);
            if (cmdArgs.BegingIndex.HasValue)
            {
                files = files.Where(x => x.index.Value > cmdArgs.BegingIndex.Value);
            }
            files = files.OrderBy(x => x.index);

            FileStream fsw = null;
            StreamWriter sw = null;
            try
            {
                if (!string.IsNullOrEmpty(cmdArgs.MergedFileFullName))
                {
                    var path = Path.GetDirectoryName(Path.GetFullPath(cmdArgs.MergedFileFullName));
                    if (!Directory.Exists(path)) 
                        Directory.CreateDirectory(path);
                    fsw = new FileStream(cmdArgs.MergedFileFullName, FileMode.Create, FileAccess.Write, FileShare.None);
                    sw = new StreamWriter(fsw, Encoding.UTF8);
                }
                WriteFiles(files, sw);
                Console.WriteLine($"The listed files are processed!");
                Console.WriteLine($"{string.Join(";", files.Select(x => Path.GetFileName(x.FullFileName)))}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sw != null) sw.Close();
                if (fsw != null) fsw.Close();
            }
        }

        private static void WriteFiles(IEnumerable<ProcessFileModel> files, StreamWriter sw)
        {
            StreamReader sr = null;
            Regex reg = new Regex(@"<[\w='"" /\.+\-:?!;\r\n]*>");
            Regex removeRN = new Regex(@"(\r\n)+");
            foreach (var file in files)
            {
                using (sr = new StreamReader(file.FullFileName, true))
                {
                    string fileText = sr.ReadToEnd();
                    var maches = reg.Matches(fileText);
                    var content = reg.Replace(fileText, "");
                    content = removeRN.Replace(content, "\r\n");

                    if (!string.IsNullOrEmpty(cmdArgs.OutputDirectory))
                    {
                        if (!Directory.Exists(cmdArgs.OutputDirectory)) Directory.CreateDirectory(cmdArgs.OutputDirectory);
                        WriteEachFile(content, $"{cmdArgs.OutputDirectory}\\{Path.GetFileName(file.FullFileName)}");
                    }
                    if (sw != null)
                        WriteMergedFile(content, sw);
                }
            }
        }

        private static void WriteEachFile(string content, string fullfileName)
        {
            using (FileStream fsw = new FileStream(fullfileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(fsw, Encoding.UTF8))
                {
                    WriteMergedFile(content, sw);
                    sw.Flush();
                }
            }
        }

        private static void WriteMergedFile(string content, StreamWriter sw)
        {
            sw.WriteLine(content);
        }

        private static int? GetIndexFromFileName(string fn)
        {
            int? rslt;
            Regex reg = new Regex("[^\\d-]");
            string index = reg.Replace(fn, "");
            if (!int.TryParse(index, out int rs))
            {
                rslt = null;
            }
            else
            {
                rslt = rs;
            }
            return rslt;
        }

        private static CommandArgs ReadArgs(string[] args)
        {
            CommandArgs rs = new CommandArgs();
            var index = Array.FindIndex(args, x => x.Equals(CommandArgs.PatternFilterCommand, StringComparison.OrdinalIgnoreCase));
            if (index > -1 && (index + 1) < args.Length) rs.PatternFilter = args[index + 1];
            index = Array.FindIndex(args, x => x.Equals(CommandArgs.PathCommand, StringComparison.OrdinalIgnoreCase));
            if (index > -1 && (index + 1) < args.Length) rs.Path = args[index + 1];
            index = Array.FindIndex(args, x => x.Equals(CommandArgs.BeginIndexCommand, StringComparison.OrdinalIgnoreCase));
            if (index > -1 && (index + 1) < args.Length) rs.BegingIndex = int.Parse(args[index + 1]);
            index = Array.FindIndex(args, x => x.Equals(CommandArgs.OutputDirectoryCommand, StringComparison.OrdinalIgnoreCase));
            if (index > -1 && (index + 1) < args.Length) rs.OutputDirectory = args[index + 1];
            index = Array.FindIndex(args, x => x.Equals(CommandArgs.MergedFileFullNameCommand, StringComparison.OrdinalIgnoreCase));
            if (index > -1 && (index + 1) < args.Length) rs.MergedFileFullName = args[index + 1];
            return rs;
        }
    }
}
