using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestProjects.CustomValidAttributes
{
    /// <summary>
    /// Only Lowercase letters.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class TextReplaceAttribute : ValidationAttribute
    {
        private Regex regx;
        public TextReplaceAttribute()
        {
            regx = new Regex("^[a-z]*$");
        }

        /*
        public override string FormatErrorMessage(string name)
        {
            return $"{name} - The value is invlid.";
        }

        public override bool IsValid(object value)
        {
            return regx.IsMatch(value == null ? "" : value.ToString());
        }
        */

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            ValidationResult reslut = ValidationResult.Success;
            string val = value == null ? "" : value.ToString();
            reslut = regx.IsMatch(val) ?
                ValidationResult.Success
                : new ValidationResult($"{context.DisplayName} - The value is invlid.");
            if (reslut != ValidationResult.Success)
            {
                val = val.ToLower();
                val = new Regex("[^a-z]").Replace(val, "");
                value = val;//无法将新值回赋给字段
            }

            #region 通过反射可以把值回赋给属性/字段
            /*
            var obj = context.ObjectInstance;

            var members = obj.GetType().GetMember(context.MemberName);

            if (members.Length > 0)
            {
                if (members[0].MemberType == System.Reflection.MemberTypes.Property)
                {
                    var member = members[0] as System.Reflection.PropertyInfo;
                    member.SetValue(obj, val);
                }
                if (members[0].MemberType == System.Reflection.MemberTypes.Field)
                {
                    var member = members[0] as System.Reflection.FieldInfo;
                    member.SetValue(obj, val);
                }
            }
            */
            #endregion

            return reslut;
        }
    }
}
