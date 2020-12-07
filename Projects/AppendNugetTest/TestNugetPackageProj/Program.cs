using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNugetPackageProj
{
    class Program
    {
        static void Main(string[] args)
        {
            AppendNugetTest.ServicesClass sc = new AppendNugetTest.ServicesClass();
            Console.WriteLine(sc.GetVersion());

            Console.ReadKey();
        }
    }
}
