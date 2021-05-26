using System;
using System.Collections.Generic;
using System.Text;

namespace Core31TestProject.Models
{
    public static class StaticExtendTestClass
    {
        public static string GetFullName(this NameContainer nameContainer)
        {
            return nameContainer.ToString();
        }
    }
}
