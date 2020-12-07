using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjects.Models
{
    public class InforBaseClass
    {
        public InforBaseClass()
        {
            Age = new MapperOriModel();
        }
        public MapperOriModel Age { get; set; }
    }

    public class InforBaseExClass : InforBaseClass
    {
        public InforBaseExClass() : base()
        {
            Age = new InforModel();
        }
        public new InforModel Age { get; set; }
    }
}
