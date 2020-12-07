using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace Core31TestProject.Models
{
    public class Employee : IEqualityComparer<string>, IEqualityComparer<int>, IEqualityComparer<Employee>
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public int Age { get; set; }
        public char Sex { get; set; }

        public async Task<string> ChangeValueForRefTest(string str)
        {
            string HeaderPrefix = "Hello ";
            str = $"{HeaderPrefix}{str}";
            return str;
        }
        public async Task<Employee> ChangeValueForRefTest(Employee emply)
        {
            emply.ID = -1000;
            emply.FName = "Error";
            return emply;
        }
        public async Task<NameContainer> ChangeValueForRefTest(NameContainer emply)
        {
            string HeaderPrefix = "Hello ";
            emply.Name = $"{HeaderPrefix}{emply.Name}";
            return emply;
        }

        #region inline interface
        bool IEqualityComparer<string>.Equals(string x, string y)
        {
            return x.Equals(y, StringComparison.OrdinalIgnoreCase);
        }
        int IEqualityComparer<string>.GetHashCode(string obj)
        {
            return this.GetHashCode();
        }
        bool IEqualityComparer<int>.Equals(int x, int y)
        {
            return x == y;
        }
        int IEqualityComparer<int>.GetHashCode(int obj)
        {
            return this.GetHashCode();
        }

        bool IEqualityComparer<Employee>.Equals(Employee x, Employee y)
        {
            return x.FName.Equals(y.FName, StringComparison.OrdinalIgnoreCase);
        }

        int IEqualityComparer<Employee>.GetHashCode(Employee obj)
        {
            return this.GetHashCode();
        }
        #endregion
    }

    public class NameContainer
    {
        public string Name { get; set; }
    }
}
