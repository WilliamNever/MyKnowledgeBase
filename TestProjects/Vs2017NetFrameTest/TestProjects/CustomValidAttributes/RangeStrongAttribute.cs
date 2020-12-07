using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjects.CustomValidAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class RangeStrongAttribute : RangeAttribute
    {
        public RangeStrongAttribute(int minimum, int maximum) 
            : base(minimum, maximum)
        { }
        public RangeStrongAttribute(double minimum, double maximum) 
            : base(minimum, maximum)
        { }
        public RangeStrongAttribute(Type type, string minimum, string maximum)
            : base(type, minimum, maximum)
        { }

        public override string FormatErrorMessage(string name)
        {
            return ErrorMessage;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (OperandType == typeof(decimal)||ErrorMessageResourceName.Equals("Age"))
            {
                if (int.TryParse(value.ToString(), out int tmp) && tmp == -1)
                {
                    return ValidationResult.Success;
                }
            }
            return base.IsValid(value, validationContext);
        }
    }
}
