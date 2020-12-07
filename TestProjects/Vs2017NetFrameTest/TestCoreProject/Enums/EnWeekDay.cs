using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TestCoreProject.Enums
{
    public enum EnWeekDay
    {
        Sunday = 0,
        [DescriptNames("Mon")]
        Monday,
        [DescriptNames("Tue")]
        [DescriptNames("Tus")]
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
    }

    public static class WeekDayExtensions
    {
        static WeekDayExtensions()
        {
        }
        public static string GetDayName(this EnWeekDay day)
        {
            return $"{day.ToString()} is workday, right?";
        }
    }

    [AttributeUsageAttribute(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public class DescriptNamesAttribute : DescriptionAttribute
    {
        public DescriptNamesAttribute():base()
        {

        }
        public DescriptNamesAttribute(string description):base(description)
        {

        }
    }
}
