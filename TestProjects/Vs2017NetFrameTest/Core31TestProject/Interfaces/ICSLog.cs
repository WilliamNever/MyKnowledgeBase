using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core31TestProject.Interfaces
{
    public interface ICSLog
    {
        void ConsoleLog()
        {
            Console.WriteLine($"nothing in Interface");
        }
        public void ConsoleLogPub();
        public void ConSoleLogContents()
        {
            Console.WriteLine($"ICSLog Interface Default setting.");
        }

        public async Task<bool> GetTaskBoolResult() => default;
    }
}
