using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetStandardLibrary.ConvertHelpers;
using StandardBaseInfors.TestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForFx461WithNetStandardLibrary.ConvertHelpers
{
    [TestClass]
    public class XMLConverterTest : TestBase
    {
        [TestMethod]
        public void XMLSerialDeserailTEST()
        {
            var mdc = GetModelClass();

            XMLConverter<ModelClass> xc = new XMLConverter<ModelClass>();
            string str = xc.Serializer(mdc);
            var obj = xc.DeSerailizer(str);

            Assert.AreEqual(mdc.Age, obj.Age);
            Assert.AreEqual(mdc.FirstName, obj.FirstName);
            Assert.AreEqual(mdc.LastName, obj.LastName);
            Assert.AreEqual(mdc.Memo, obj.Memo);
        }

    }
}
