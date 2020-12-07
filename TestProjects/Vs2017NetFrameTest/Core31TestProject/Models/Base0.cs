using System;
using System.Collections.Generic;
using System.Text;

namespace Core31TestProject.Models
{
    public class Base0
    {
        public int Rec { get; set; }
        public List<Base1> b1List { get; set; }
    }

    public class Base1{
        public int Acg { get; set; }
        public List<Base2> b2List { get; set; }
    }

    public class Base2
    {
        public int Acx { get; set; }
    }
}
