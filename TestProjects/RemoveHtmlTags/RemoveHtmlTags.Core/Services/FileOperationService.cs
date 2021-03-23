using RemoveHtmlTags.Core.Models;
using RemoveHtmlTags.Core.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RemoveHtmlTags.Core.Services
{
    public class FileOperationService
    {
        public FileOperationService()
        {

        }

        public IEnumerable<ProcessFileModel> GetFilesToProcess(CommandArgs cmdArgs)
        {
            var files = Directory.GetFiles(cmdArgs.Path, cmdArgs.PatternFilter)
                .Select(x =>
                new ProcessFileModel
                {
                    FullFileName = x,
                    Index = GetIndexFromFileName(Path.GetFileNameWithoutExtension(x))
                }
                ).Where(x => x.Index.HasValue);
            if (cmdArgs.BegingIndex.HasValue)
            {
                files = files.Where(x => x.Index.Value > cmdArgs.BegingIndex.Value);
            }
            files = files.OrderBy(x => x.Index);
            return files;
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

        public void WriteOutputFile(IEnumerable<ProcessFileModel> files, CommandArgs cmdArgs, AppSettingsModel AppSettings)
        {
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
                WriteFiles(files, sw, AppSettings, cmdArgs);
                //Console.WriteLine($"The listed files are processed!");
                //Console.WriteLine($"{string.Join(";", files.Select(x => Path.GetFileName(x.FullFileName)))}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sw != null) sw.Close();
                if (fsw != null) fsw.Close();
            }
        }
        private static void WriteFiles(IEnumerable<ProcessFileModel> files, StreamWriter sw, AppSettingsModel settings, CommandArgs cmdArgs)
        {
            Regex reg = new Regex(settings.MainRegx);//@"<[\w='"" /\.+\-:?!;]*>"
            Regex removeRN = new Regex(@"(\r\n)+");
            Regex removeBlank = new Regex(@"([\s]*\r\n)");
            foreach (var file in files)
            {
                using (var sr = new StreamReader(file.FullFileName, true))
                {
                    string fileText = sr.ReadToEnd();
                    var maches = reg.Matches(fileText);
                    var content = reg.Replace(fileText, "");
                    content = removeBlank.Replace(content, "\r\n");
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
    }
}
