using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Attributes;
using TestConsole.Models;

namespace TestConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region
            //ExtendInforsDB.ExtendInforsDBContext edb = new ExtendInforsDB.ExtendInforsDBContext();
            //var list = edb.OrdersInfors.ToList();
            //edb.OrdersInfors.Add(new ExtendInforsDB.OrdersInfors() {
            //    CheckedUserName ="dd"
            //    , OrderNumber="adf"
            //    , Status=9
            //    , StatusChangedDate=DateTime.Now
            //    , UserName="abc"
            //});
            //edb.SaveChanges();

            //UserInforsDB.UserInforsDBContext udb = new UserInforsDB.UserInforsDBContext();
            //var ulist = udb.UserInfors.ToList();
            #endregion

            TestAttributeClassExtendA tac = new TestAttributeClassExtendA();
            CustomizedAttribute attrs;

            foreach (var tmp in tac.GetType().GetCustomAttributes(typeof(CustomizedAttribute), true))
            {
                attrs = tmp as CustomizedAttribute;
                Console.Write("Class Attribute:");
                if (attrs != null)
                {
                    Console.Write(attrs.Name);
                    var ex = attrs.InvokeClass?.CreateDate;
                    if (ex.HasValue)
                    {
                        Console.Write("//" + ex.Value.ToString());
                    }
                }
                Console.WriteLine();
            }

            //Console.WriteLine();
            //var attribs = tac.GetType().GetProperties();
            //foreach (var propertyInfo in attribs)
            //{
            //    foreach (var tmp in propertyInfo.GetCustomAttributes(typeof(CustomizedAttribute), true))
            //    {
            //        attrs = tmp as CustomizedAttribute;
            //        Console.Write("Property Attribute:");
            //        if (attrs != null)
            //        {
            //            Console.Write(attrs.Name);
            //            var ex = attrs.InvokeClass?.CreateDate;
            //            if (ex.HasValue)
            //            {
            //                Console.Write("//" + ex.Value.ToString());
            //            }
            //        }
            //        Console.WriteLine();
            //    }
            //}

            //propertyInfo = tac.GetType().GetProperties()[1];
            //attrs = propertyInfo.GetCustomAttributes(typeof(CustomizedAttribute), true)[0] as CustomizedAttribute;
            //Console.Write("Property Attribute:");
            //if (attrs != null)
            //{
            //    Console.WriteLine(attrs.Name);
            //}

            //Console.WriteLine();
            //var MthdInfors = tac.GetType().GetMethods();
            //foreach (var MthdInfor in MthdInfors)
            //{
            //    var attrList = MthdInfor.GetCustomAttributes(typeof(CustomizedAttribute), true);
            //    foreach (var tmp in attrList)
            //    {
            //        attrs = tmp as CustomizedAttribute;
            //        Console.Write("Func/Method Attribute:");
            //        if (attrs != null)
            //        {
            //            Console.Write(attrs.Name);
            //            var ex = attrs.InvokeClass?.CreateDate;
            //            if (ex.HasValue)
            //            {
            //                Console.Write("//" + ex.Value.ToString());
            //            }
            //        }

            //        Console.WriteLine();
            //    }
            //    if (attrList.Length > 0)
            //    {
            //        tac.RunF();
            //    }
            //}

            Console.WriteLine();
            Console.WriteLine("That is all. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
