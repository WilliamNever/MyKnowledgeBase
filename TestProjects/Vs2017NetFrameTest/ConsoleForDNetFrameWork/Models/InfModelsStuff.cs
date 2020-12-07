using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForDNetFrameWork.Models
{
    public class InfModelsStuffFrom
    {
        public string UserName { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string OtherMemo { get; set; }
    }

    public class InfModelsStuffTo
    {
        public string UserName { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int OtherMemo { get; set; }
    }
}
