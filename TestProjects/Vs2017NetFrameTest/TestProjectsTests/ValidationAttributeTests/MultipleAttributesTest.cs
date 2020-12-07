using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjects.Models;

namespace TestProjectsTests.ValidationAttributeTests
{
    [TestClass]
    public class MultipleAttributesTest
    {
        [TestMethod()]
        public void MultipleTest()
        {
            MultiAttrTestModel mtm = new MultiAttrTestModel
            {
                ProAge = 8 // null
            };

            ValidationContext context = new ValidationContext(mtm);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(mtm, context, results, true);

            Assert.IsTrue(isValid);
        }

        [TestMethod()]
        public void MultipleTestEx()
        {
            var mtm = new MultiAttrTestModelEx
            {
                ProAge = 8
            };

            ValidationContext context = new ValidationContext(mtm);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(mtm, context, results, true);

            Assert.IsTrue(isValid);
        }

        [TestMethod()]
        public void MultipleTestExNullable()
        {
            var mtm = new MultiAttrTestModelEx
            {
                //ProAge = 8,
                ExInt = 8
            };

            ValidationContext context = new ValidationContext(mtm);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(mtm, context, results, true);

            Assert.IsTrue(isValid);
        }
    }
}
