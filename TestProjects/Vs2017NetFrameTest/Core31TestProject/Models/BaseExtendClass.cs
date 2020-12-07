using System;
using System.Collections.Generic;
using System.Text;

namespace Core31TestProject.Models
{
    public class BaseClass
    {
        public static bool IsTrue;
        static BaseClass()
        {
            IsTrue = false;
        }
    }

    public class ExFromBase : BaseClass
    {
        public static bool IsRunning;
        static ExFromBase()
        {
            IsTrue = true;
            IsRunning = false;
        }
    }
}
