using Core31TestProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core31TestProject.MainTestFiles
{
    public class ThirdBranchMainEntrance : TestBaseForMainEntrance
    {
        public override void MainRun()
        {
            Task.WaitAll(FirstTest());
        }

        private async Task FirstTest()
        {
            string ssst = "aaa";
            ssst ??= new string("Hello");
            Console.WriteLine(DateTime.UtcNow.ToString("yyyyMMdd").Substring(1));
            string str = "_ssss";
            var indexOf = str.IndexOf('_');
            var subStr = str.Substring(0, indexOf);
            var flist = Directory.GetFiles("D:\\TmpDocs");
            var fn = Path.GetFileName(flist[0]);
        }
    }
}
