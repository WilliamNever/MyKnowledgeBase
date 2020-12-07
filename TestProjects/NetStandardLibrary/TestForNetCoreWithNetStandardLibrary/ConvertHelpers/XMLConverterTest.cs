using NetStandardLibrary.ConvertHelpers;
using StandardBaseInfors.TestModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestForNetCoreWithNetStandardLibrary.ConvertHelpers
{
    public class XMLConverterTest : TestBase
    {
        [Fact]
        private void XMLSerialDeserailTEST()
        {
            var mdc = GetModelClass();

            XMLConverter<ModelClass> xc = new XMLConverter<ModelClass>();
            string str = xc.Serializer(mdc);
            var obj = xc.DeSerailizer(str);

            Assert.Equal(mdc.Age, obj.Age);
            Assert.Equal(mdc.FirstName, obj.FirstName);
            Assert.Equal(mdc.LastName, obj.LastName);
            Assert.Equal(mdc.Memo, obj.Memo);
        }

    }
}
