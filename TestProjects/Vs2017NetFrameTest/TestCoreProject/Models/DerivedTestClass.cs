using System;
using System.Collections.Generic;
using System.Text;

namespace TestCoreProject.Models
{
    //public abstract class DBaseClass<T> where T : class
    public interface IDBaseClass<T> where T : class
    {
        void Get(T obj);
    }

    public class DerivedClass : IDBaseClass<string>
    {
        public void Get(string obj)
        {
            throw new NotImplementedException();
        }
    }

    public class TestClass
    {
        private void Test()
        {
            DerivedClass derived = new DerivedClass();
            derived.Get("");
        }
    }

    public class TestFDeriveBase
    {
        public virtual void WriteInfor()
        {
            Console.WriteLine("TestFDeriveBase");
        }
    }
    public class TestFdBEx : TestFDeriveBase
    {
        public override void WriteInfor()
        {
            Console.WriteLine("TestFdBEx");
        }
    }
    public class TestFdEx1 : TestFdBEx
    {
        //public override void WriteInfor()
        //{
        //    Console.WriteLine("TestFdEx1");
        //}
    }
}
