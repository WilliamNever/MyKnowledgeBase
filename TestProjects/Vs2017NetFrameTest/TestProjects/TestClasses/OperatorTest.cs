using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjects.TestClasses
{
    public class OperatorTest
    {
        public int AG { get; set; }
        public List<string> NamesCollections { get; set; }
        public int NCCount { get { return NamesCollections == null ? 0 : NamesCollections.Count; } }

        public OperatorTest()
        {
            InitClass();
        }
        public OperatorTest(int ag) : this()
        {
            AG = ag;
        }

        public static OperatorTest operator +(OperatorTest left, OperatorTest right)
        {
            var rValue = new OperatorTest
            {
                AG = left.AG + right.AG
            }
            ;
            rValue.NamesCollections.AddRange(left.NamesCollections);
            rValue.NamesCollections.AddRange(right.NamesCollections);
            return rValue;
        }

        protected virtual void InitClass()
        {
            NamesCollections = new List<string>();
        }
    }

    public class OperatorTestEx : OperatorTest
    {
        public string Message { get; private set; }
        public OperatorTestEx() : base()
        {

        }
        public OperatorTestEx(int ag) : base(ag)
        {

        }
        public static OperatorTestEx operator +(OperatorTestEx left, OperatorTestEx right)
        {
            var rValue = new OperatorTestEx
            {
                AG = left.AG + right.AG + 1000
            }
            ;
            rValue.NamesCollections.AddRange(left.NamesCollections);
            rValue.NamesCollections.AddRange(right.NamesCollections);
            rValue.Message = "Operator add +";
            return rValue;
        }
        protected override void InitClass()
        {
            base.InitClass();
        }
        public string GetOK()
        {
            return "OK";
        }
    }
    public class OpTEx : OperatorTestEx
    {
        protected override void InitClass()
        {
            base.InitClass();
        }
        public OpTEx() : base()
        {
        }
        public OpTEx(int ag) : base(ag)
        {

        }
    }
}
