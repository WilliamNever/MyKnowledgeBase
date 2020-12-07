using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreTestProject.Models
{
    public class FirstBaseClass
    {
        [MutipleRange(3, 5, EnWeekDay.Sunday, "{0} {1} {2} is wrong in Base.")]
        public virtual int ATAge { get; set; }
    }

    public class FirstBaseClassEx : FirstBaseClass
    {
        [MutipleRange(3, 5, EnWeekDay.Sunday, "{0} {1} {2} is wrong in Base Ex.")]
        public new int? ATAge { get; set; }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class MutipleRangeAttribute : RangeAttribute
    {
        private EnWeekDay WeekDay;
        private string ErrorPattern;
        public MutipleRangeAttribute(int minimum, int maximum, EnWeekDay weekday, string ErrorPattern)
            : base(minimum, maximum)
        {
            WeekDay = weekday;
            this.ErrorPattern = ErrorPattern;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var result = ValidationResult.Success;
            if (value == null) return new ValidationResult(string.Format(ErrorPattern, TypeId.ToString(), validationContext.MemberName, "NULL"));

            int tmp = (int)value;
            if (WeekDay == EnWeekDay.Sunday)
            {
                result = base.IsValid(value, validationContext);
                if (result != ValidationResult.Success)
                {
                    result.ErrorMessage = string.Format(ErrorPattern, TypeId.ToString(), validationContext.MemberName, value.ToString());
                    //validationContext.Items.Add(new KeyValuePair<object, object>("err-"+validationContext.MemberName, value));
                }
            }
            return result;
        }
        private object typeid;
        public override object TypeId
        {
            get
            {
                typeid = typeid ?? WeekDay.ToString();
                return typeid;
            }
        }
    }

    public enum EnWeekDay
    {
        Sunday = 0,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
    }
}
