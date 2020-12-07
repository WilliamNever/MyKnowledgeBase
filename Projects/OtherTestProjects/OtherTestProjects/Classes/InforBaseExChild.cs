using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherTestProjects.Classes
{
    public class InforBaseExChild : InforBase
    {
        public InforBaseExChild():base()
        {
            ClassName += $"{ClassName}/InforBaseExChild";
        }

        public override string GetClassName()
        {
            return $"This a child class, {base.GetClassName()}.";
        }
    }
}
