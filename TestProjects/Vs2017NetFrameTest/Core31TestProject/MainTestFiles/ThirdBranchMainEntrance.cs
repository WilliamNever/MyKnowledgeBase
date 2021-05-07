using Core31TestProject.Models;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}
