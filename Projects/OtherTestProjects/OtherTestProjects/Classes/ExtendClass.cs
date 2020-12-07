using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherTestProjects.Classes
{
    public static class ExtendClass
    {
        private static string ClassName;
        static ExtendClass()
        {
            ClassName = "ExtendClass";
        }
        public static void ToShow(this InforBase IB)
        {
            Console.WriteLine($"Class Name is /{IB.ClassName} - {ClassName}/");
        }
        public static void ToShow(this InforBaseA IBA)
        {
            Console.WriteLine($"Class Name is /{IBA.ClassName} - {ClassName}/");
        }
    }
}
