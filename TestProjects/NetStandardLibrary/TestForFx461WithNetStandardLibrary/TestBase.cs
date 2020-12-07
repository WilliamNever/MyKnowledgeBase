using StandardBaseInfors.TestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForFx461WithNetStandardLibrary
{
    public class TestBase
    {
        protected ModelClass GetModelClass()
        {
            var mdc =
                new ModelClass
                {
                    FirstName = "Helen",
                    LastName = "Shaw",
                    Age = 23,
                    Memo = "Memo Messages"
                };
            mdc.SetIDCard("1234567890");
            return mdc;
        }
    }
}
