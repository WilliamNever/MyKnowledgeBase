using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjects.TestClasses
{
    public class LstModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class CompareKey
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
    }

    public class CompContents : IEqualityComparer<LstModel>, IEqualityComparer<CompareKey>
    {
        bool IEqualityComparer<LstModel>.Equals(LstModel x, LstModel y)
        {
            return x.Age == y.Age && x.FirstName == y.FirstName;
        }

        int IEqualityComparer<LstModel>.GetHashCode(LstModel obj)
        {
            return 0;
        }

        bool IEqualityComparer<CompareKey>.Equals(CompareKey x, CompareKey y)
        {
            return x.Age == y.Age && x.FirstName == y.FirstName;
        }

        int IEqualityComparer<CompareKey>.GetHashCode(CompareKey obj)
        {
            return GetHashCode();
        }
    }
}
