using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetStandardLibrary.ReflectHelpers;
using StandardBaseInfors.TestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForFx461WithNetStandardLibrary.ReflectHelpers
{
    [TestClass]
    public class ReflectBaseClassTEST : TestBase
    {
        [TestMethod]
        public void GetInstanceFieldTEST()
        {
            var mdc = GetModelClass();

            ReflectBaseClass<ModelClass> rbc = new ReflectBaseClass<ModelClass>(mdc);
            var idc = rbc.GetInstanceFieldValue<string>("iDCard");

            Assert.AreEqual(mdc.IDCard, idc);
        }

        [TestMethod]
        public void GetStaticFieldValueTEST()
        {
            var mdc1 = GetModelClass();
            var mdc2 = GetModelClass();

            ReflectBaseClass<ModelClass> rbc = new ReflectBaseClass<ModelClass>(mdc1);
            var ModelClassNumber = rbc.GetStaticFieldValue<int>("ModelClassNumber");

            Assert.AreEqual(mdc2.GetModelClassNumber(), ModelClassNumber);
        }

        [TestMethod]
        public void GetPropertyValueTEST()
        {
            var mdc = GetModelClass();
            ReflectBaseClass<ModelClass> rbc = new ReflectBaseClass<ModelClass>(mdc);
            var fullName = rbc.GetPropertyValue<string>("Name");

            Assert.AreEqual(mdc.GetFullName(), fullName);
        }

        [TestMethod]
        public void RunPrivateFunctionTEST()
        {
            var mdc = GetModelClass();
            ReflectBaseClass<ModelClass> rbc = new ReflectBaseClass<ModelClass>(mdc);
            var nameWithAge = rbc.RunPrivateFunction<string>("GetNameWithAge", null);

            Assert.AreEqual(mdc.NameWithAge, nameWithAge);
        }

        [TestMethod]
        public void ClearControlEventTEST()
        {
            var mdc = GetModelClass();
            var memo = mdc.Memo;
            mdc.GoAction("Jumping");
            ReflectBaseClass<ModelClass> rbc = new ReflectBaseClass<ModelClass>(mdc);
            rbc.ClearControlEvent("EVENT_DOING", "Doing");
            memo = mdc.Memo;
            mdc.GoAction("Eating");

            Assert.AreEqual(memo, mdc.Memo);
        }
    }
}
