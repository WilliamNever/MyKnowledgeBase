using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTestDoubleEFContext.Models
{
    public class DateTimeViewModel
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public DateTimeViewModel()
        {
        }
    }
}