using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormTools.Models
{
    public class Configurations
    {
        public DBConfigurations DBConfigs { get; set; }
    }

    public class DBConfigurations
    { 
        public List<DBExecution> Executions { get; set; }
    }

    public class DBExecution
    {
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public List<DBExeCommand> Commands { get; set; }
        public override string ToString()
        {
            return ConnectionString;
        }
    }
    public class DBExeCommand
    {
        public string Name { get; set; }
        public string Command { get; set; }
        public override string ToString()
        {
            return Command;
        }
    }
}
