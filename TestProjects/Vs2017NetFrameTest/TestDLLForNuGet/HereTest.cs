using System;
using System.Collections.Generic;
using System.Text;

namespace TestDLLForNuGet
{
    public class HereTest
    {
        public string Version { get; private set; }

        public HereTest()
        {
            Version = "1.0.0.0";
        }
    }
}
