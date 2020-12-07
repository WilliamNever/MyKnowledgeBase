using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Models;

namespace TestConsole.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property| AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CustomizedAttribute : Attribute
    {
        public string Name { get; protected set; }
        public Type ObjType { get; private set; }

        public ExtendAttrInfor InvokeClass { get; private set; }

        public CustomizedAttribute(string name)
        {
            Name = name;

            //Console.WriteLine("Set the Name:" + name);
        }

        public CustomizedAttribute():this("No Name")
        {
        }

        public CustomizedAttribute(Type objType,string name):this(name)
        {
            ObjType = objType;
            InvokeClass = ObjType.Assembly.CreateInstance(ObjType.ToString()) as ExtendAttrInfor;
            InvokeClass.CreateDate = DateTime.Now;
        }
    }
}

