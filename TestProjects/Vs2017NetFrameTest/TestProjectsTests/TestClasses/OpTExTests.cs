using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProjects.TestClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjects.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TestProjects.TestClasses.Tests
{
    [TestClass()]
    public class OpTExTests
    {
        [TestMethod()]
        public void OpTExTest()
        {
            NullInClass nic = new NullInClass();

            var type = nic.GetType().GetProperty("multi", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            ValidationContext context = new ValidationContext(nic);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(nic, context, results, true);

            Assert.IsTrue(isValid);
        }

        [TestMethod()]
        public void OpTExTest(int ag)
        {
            //Assert.Fail();
        }
    }
}