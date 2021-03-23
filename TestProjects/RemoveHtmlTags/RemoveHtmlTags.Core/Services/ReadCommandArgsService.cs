using RemoveHtmlTags.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveHtmlTags.Core.Services
{
    public class ReadCommandArgsService
    {
        public ReadCommandArgsService()
        {

        }
        public CommandArgs ReadFromCommandArgs(string[] args)
        {
            CommandArgs rs = new CommandArgs();
            var index = Array.FindIndex(args, x => x.Equals(CommandArgs.PatternFilterCommand, StringComparison.OrdinalIgnoreCase));
            if (index > -1 && (index + 1) < args.Length) rs.PatternFilter = args[index + 1];
            index = Array.FindIndex(args, x => x.Equals(CommandArgs.PathCommand, StringComparison.OrdinalIgnoreCase));
            if (index > -1 && (index + 1) < args.Length) rs.Path = args[index + 1];
            index = Array.FindIndex(args, x => x.Equals(CommandArgs.BeginIndexCommand, StringComparison.OrdinalIgnoreCase));
            if (index > -1 && (index + 1) < args.Length) rs.BegingIndex = int.TryParse(args[index + 1], out int bid) ? bid : (int?)null;
            index = Array.FindIndex(args, x => x.Equals(CommandArgs.OutputDirectoryCommand, StringComparison.OrdinalIgnoreCase));
            if (index > -1 && (index + 1) < args.Length) rs.OutputDirectory = args[index + 1];
            index = Array.FindIndex(args, x => x.Equals(CommandArgs.MergedFileFullNameCommand, StringComparison.OrdinalIgnoreCase));
            if (index > -1 && (index + 1) < args.Length) rs.MergedFileFullName = args[index + 1];
            return rs;
        }
    }
}
