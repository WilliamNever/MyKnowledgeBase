using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProjects.TestClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjects.TestClasses.Tests
{
    [TestClass()]
    public class OperatorTestExTests
    {
        [TestMethod()]
        public void GetOKTest()
        {
            OperatorTestEx ote = new OperatorTestEx();
            Assert.AreEqual(ote.GetOK(), "Ok", true, "isSame");
            //Assert.Fail();
        }
    }
}