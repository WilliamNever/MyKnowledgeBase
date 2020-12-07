using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherTestProjects.Classes
{
    public class InforBase
    {
        private string className;
        public string ClassName { get { return className; } set { className = value; } }
        public InforBase()
        {
            className = "InforBase";
        }
        public void Show()
        {
            Console.WriteLine($"Class Name is /{ClassName}/");
        }
        public virtual string GetClassName()
        {
            return ClassName;
        }
    }
}
