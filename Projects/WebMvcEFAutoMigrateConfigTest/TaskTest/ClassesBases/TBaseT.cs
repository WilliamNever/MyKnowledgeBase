using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTest.ClassesBases
{
    public class TBaseT
    {
        public static IEnumerable<string> Generate(int count, string ruleSets = null)
        {
            return Enumerable.Range(1, count).Select<int, string>((Func<int, string>)((i) => Generate(ruleSets)));
        }
        public static string Generate(string ruleSets = null)
        {
            return ruleSets;
        }
    }
}
