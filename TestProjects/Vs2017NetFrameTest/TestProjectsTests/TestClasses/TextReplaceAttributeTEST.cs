using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TestProjects.Models;

namespace TestProjects.TestClasses.Tests
{
    [TestClass]
    public class TextReplaceAttributeTEST
    {
        [TestMethod()]
        public void AttributeValid()
        {
            InforModel inm = new InforModel
            {
                Messages = "aaaa",
                Age = -1,
                Salary = -1M,
            };

            ValidationContext context = new ValidationContext(inm);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(inm, context, results, true);

            Assert.IsTrue(isValid);
        }

        [TestMethod()]
        public void PropertyValid()
        {
            InforModel inm = new InforModel { Messages = "aaaa" };

            ValidationContext context = new ValidationContext(inm);
            List<ValidationResult> results = new List<ValidationResult>();

            context.DisplayName = "Messages";
            context.MemberName = "Messages";
            bool isValid = Validator.TryValidateProperty(inm.Messages, context, results);

            Assert.IsTrue(isValid);
        }

        [TestMethod()]
        public void ComplexAttributeValid_Unfinished()
        {
            MainInforModel inm = new MainInforModel
            {
                Messages = "aa",
                InforModel = new InforModel
                {
                    Messages = "aaa4aaa",
                    Age = -11,
                    Salary = -12M,
                },
                InforModelB = new List<InforModel>(){
                    new InforModel
                    {
                        Messages = "aaaa",
                        Age = -11,
                        Salary = -12M,
                    },
                    new InforModel
                    {
                        Messages = "aaaa",
                        Age = -11,
                        Salary = -12M,
                    },null
                },
                InforModelC = new InforModel[]{
                    new InforModel
                    {
                        Messages = "aaaa",
                        Age = -11,
                        Salary = -12M,
                    },
                    new InforModel
                    {
                        Messages = "aaaa",
                        Age = -11,
                        Salary = -12M,
                    }
                    ,null
                },
                Jobs = new List<string>() { "Worker", "Teacher", "Programmer" },
                YearsEachJob = new List<int> { 5, 8, 13 }
            }
            ;

            ValidationContext context = new ValidationContext(inm);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(inm, context, results, true);

            //var validResult = Validate(inm);

            var listResults = ReflectValidateProperties(inm);

            Assert.IsTrue(isValid);
        }

        private List<ValidationResult> ReflectValidateProperties(object inm)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if (inm == null || inm.GetType().Equals(typeof(string)) || inm.GetType().IsValueType)
                return results;

            var Properties = inm.GetType().GetProperties(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .Where(x => x.PropertyType.IsClass && !typeof(string).Equals(x.PropertyType)).ToList()
                ;
            foreach (var prop in Properties)
            {
                var childObject = prop.GetValue(inm);
                if (childObject is IList childObjects)
                    foreach (var obj in childObjects)
                        results.AddRange(ReflectValidateProperties(obj));
                else
                    results.AddRange(ReflectValidateProperties(childObject));
            }
            ValidationContext context = new ValidationContext(inm);
            bool isValid = Validator.TryValidateObject(inm, context, results, true);
            return results;
        }

        /*
        private static ICollection<ValidationResult> Validate(object instance)
        {
            var validationResults = new List<ValidationResult>();
            MetadataTypeAttribute metaTypeAttr = instance.GetType().GetCustomAttributes(typeof(MetadataTypeAttribute), true)
            .OfType<MetadataTypeAttribute>().FirstOrDefault();

            if (metaTypeAttr == null) return validationResults;

            System.ComponentModel.TypeDescriptor.AddProvider(
            new AssociatedMetadataTypeTypeDescriptionProvider(instance.GetType(), metaTypeAttr.MetadataClassType),
            instance.GetType());

            ValidationContext vc = new ValidationContext(instance, null, null);
            Validator.TryValidateObject(instance, vc, validationResults, true);

            return validationResults;
        }
        */
    }
}
