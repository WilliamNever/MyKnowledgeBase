using KellermanSoftware.CompareNetObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCoreProject.Models
{
    public class BaseTestModel : IEqualityComparer<BaseTestModel>
    {
        public Guid Gid { get; set; } = Guid.NewGuid();
        public int Lid { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public bool Equals(BaseTestModel x, BaseTestModel y)
        {
            //return x.Age == y.Age && x.Lid == y.Lid && x.Name == y.Name;
            var compare = new CompareLogic();
            var result = compare.Compare(x, y);
            return result.AreEqual;
        }

        public int GetHashCode(BaseTestModel obj)
        {
            return this.GetHashCode();
        }
    }
}
