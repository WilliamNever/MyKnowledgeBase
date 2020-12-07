using CoreTestProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace CoreTestProject
{
    public class CommonTest
    {
        [Fact]
        public void TestValidation()
        {
            var mtm = new FirstBaseClassEx
            {
                ATAge = 8
            };

            ValidationContext context = new ValidationContext(mtm);
            List<ValidationResult> results = new List<ValidationResult>();

            //context.MemberName = "ATAge";
            //context.DisplayName = "ATAge";

            //bool isValid = Validator.TryValidateProperty(mtm.ATAge, context, results);
            bool isValid = Validator.TryValidateObject(mtm, context, results, true);

            Assert.True(isValid);
        }
    }
}
