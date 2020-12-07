using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Models
{
    [Serializable]
    //[Attributes.Customized("TestAttributeClass")]
    [Attributes.Customized(typeof(ExtendAttrInfor), "TestAttributeClass")]
    public class TestAttributeClass
    {
        //[Attributes.Customized("Name")]
        [Attributes.Customized(typeof(ExtendAttrInfor), "Name")]
        public virtual string Name { get; set; }
        [Attributes.Customized(typeof(ExtendAttrInfor), "ColumnName")]
        public virtual string ColumnName { get; set; }
        [Attributes.Customized(typeof(ExtendAttrInfor),"Age")]
        public virtual int Age { get; set; }
        [Attributes.Customized("Base_RunF")]
        public virtual void RunF()
        {
            Console.WriteLine("To Run Function!");
        }
    }

    [Attributes.Customized(typeof(ExtendAttrInfor), "TestAttributeClassExtendA")]
    public class TestAttributeClassExtendA : TestAttributeClass
    {
        [Attributes.Customized(typeof(ExtendAttrInfor), "Derived_Name")]
        public override string Name
        {
            get
            {
                return base.Name;
            }

            set
            {
                base.Name = value;
            }
        }

        [Attributes.Customized("Derived_RunF")]
        //[Attributes.Customized(typeof(ExtendAttrInfor), "Derived_RunF")]
        public override void RunF()
        {
            Console.WriteLine("To Run Derived Function!");
        }
    }

    public class ExtendAttrInfor
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
