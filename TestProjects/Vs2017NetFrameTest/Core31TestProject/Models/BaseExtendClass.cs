using System;
using System.Collections.Generic;
using System.Text;

namespace Core31TestProject.Models
{
    public interface IBCI
    {
        void Done();
    }
    public class BaseClass : IBCI
    {
        public static bool IsTrue;
        static BaseClass()
        {
            IsTrue = false;
        }

        public void Done()
        {
            throw new NotImplementedException();
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
