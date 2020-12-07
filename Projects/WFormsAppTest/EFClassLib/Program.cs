using EFClassLib.ContentText;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFClassLib
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DBCTxt db = new DBCTxt())
            {
                var list = db.UserInfor;
                Console.WriteLine(list.Count());
            }
            Console.WriteLine("Over");
            Console.ReadLine();
        }
    }
}
