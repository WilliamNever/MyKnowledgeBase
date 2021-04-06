using System;
using System.Collections.Generic;
using System.Text;

namespace Core31TestProject.Models
{
    public class Base0
    {
        public virtual int Rec { get; set; }
        public List<Base1> b1List { get; set; }
    }

    public class Base1 : Base0
    {
        public int Acg { get; set; }
        public List<Base2> b2List { get; set; }
    }

    public class Base2 : Base1
    {
        public override int Rec { get; set; }
        public int Acx { get; set; }
    }
}
