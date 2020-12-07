using Core31TestProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Core31TestProject.Models
{
    public class CSLog : ICSLog
    {
        [DisallowNull]
        public string NullAttrTest { get; set; } = null;
        private void ConsoleLog()
        {
            Console.WriteLine($"CSLog blank");
        }

        public void ConsoleLogPub()
        {
            Console.WriteLine($"CSLog ConsoleLogPub");
        }
        public virtual void ConSoleLogContents()
        {
            Console.WriteLine($"CSLog class Default setting.");
        }
        public void CSL()
        {
            ConsoleLog();
            (this as ICSLog).ConsoleLog();
        }

        public void DisableNullInput([DisallowNull] ref Employee info)
        {
            Console.WriteLine($"{info?.FName ?? "Null"} - Null?");
        }
    }
}
