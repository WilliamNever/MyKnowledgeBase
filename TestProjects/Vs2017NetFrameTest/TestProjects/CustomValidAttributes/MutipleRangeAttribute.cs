using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjects.Models;

namespace TestProjects.CustomValidAttributes
{
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
            if (value == null) return result;

            int tmp = (int)value;
            if (WeekDay == EnWeekDay.Sunday)
            {
                result = base.IsValid(value, validationContext);
                if (result != ValidationResult.Success)
                    result.ErrorMessage = string.Format(ErrorPattern, typeid.ToString(), validationContext.MemberName, value.ToString());
            }
            /*
            if (WeekDay == EnWeekDay.Monday)
            {
                result = base.IsValid(value, validationContext);
                if (result != ValidationResult.Success)
                    result.ErrorMessage = string.Format(ErrorPattern, typeid.ToString(), validationContext.MemberName);
            }
            if (WeekDay == EnWeekDay.Tuesday)
            {
                result = base.IsValid(value, validationContext);
                if (result != ValidationResult.Success)
                    result.ErrorMessage = string.Format(ErrorPattern, typeid.ToString(), validationContext.MemberName);
            }
            if (WeekDay == EnWeekDay.Wednesday)
            {
                result = base.IsValid(value, validationContext);
                if (result != ValidationResult.Success)
                    result.ErrorMessage = string.Format(ErrorPattern, typeid.ToString(), validationContext.MemberName);
            }
            if (WeekDay == EnWeekDay.Thursday)
            {
                result = base.IsValid(value, validationContext);
                if (result != ValidationResult.Success)
                    result.ErrorMessage = string.Format(ErrorPattern, typeid.ToString(), validationContext.MemberName);
            }
            if (WeekDay == EnWeekDay.Friday)
            {
                result = base.IsValid(value, validationContext);
                if (result != ValidationResult.Success)
                    result.ErrorMessage = string.Format(ErrorPattern, typeid.ToString(), validationContext.MemberName);
            }
            if (WeekDay == EnWeekDay.Saturday)
            {
                result = base.IsValid(value, validationContext);
                if (result != ValidationResult.Success)
                    result.ErrorMessage = string.Format(ErrorPattern, typeid.ToString(), validationContext.MemberName);
            }
            */
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
}
