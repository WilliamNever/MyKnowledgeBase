using RemoveHtmlTags.Core.Models;
using RemoveHtmlTags.Core.Services;
using RemoveHtmlTags.Core.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RemoveHtmlTags
{
    class Program
    {
        public static CommandArgs cmdArgs;
        public static AppSettingsModel AppSettings;

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
                Console.WriteLine($"{CommandArgs.BeginIndexCommand} process the files index that bigger than the value. it can be null or missed, if it is null or missed, the filter will be inactive.");
                Console.WriteLine($"{CommandArgs.OutputDirectoryCommand} the folder to Save Each processed file.");
                Console.WriteLine($"{CommandArgs.MergedFileFullNameCommand} the merged file that cotained all the processed files.");

                Console.WriteLine($"{CommandArgs.OutputDirectoryCommand} and {CommandArgs.MergedFileFullNameCommand} cannot be empty at same time.");
                return;
            }

            cmdArgs = new ReadCommandArgsService().ReadFromCommandArgs(args);
            AppSettings = new ReadAppConfigurationService().ReadAppConfig();

            var fileService = new FileOperationService();
            var files = fileService.GetFilesToProcess(cmdArgs);

            try
            {
                fileService.WriteOutputFile(files, cmdArgs, AppSettings);
                Console.WriteLine($"The listed files are processed!");
                Console.WriteLine($"{string.Join(";", files.Select(x => Path.GetFileName(x.FullFileName)))}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
            }
        }
    }
}
