using NetStandardLibrary.ReflectHelpers;
using StandardBaseInfors.TestModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestForNetCoreWithNetStandardLibrary.ReflectHelpers
{
    public class ReflectBaseClassTEST : TestBase
    {
        [Fact]
        private void GetInstanceFieldValueTEST()
        {
            var mdc = GetModelClass();

            ReflectBaseClass<ModelClass> rbc = new ReflectBaseClass<ModelClass>(mdc);
            var idc = rbc.GetInstanceFieldValue<string>("iDCard");

            Assert.Equal(mdc.IDCard, idc);
        }

        [Fact]
        private void GetStaticFieldValueTEST()
        {
            var mdc1 = GetModelClass();
            var mdc2 = GetModelClass();

            ReflectBaseClass<ModelClass> rbc = new ReflectBaseClass<ModelClass>(mdc1);
            var ModelClassNumber = rbc.GetStaticFieldValue<int>("ModelClassNumber");

            Assert.Equal(mdc2.GetModelClassNumber(), ModelClassNumber);
        }

        [Fact]
        private void GetPropertyValueTEST()
        {
            var mdc = GetModelClass();
            ReflectBaseClass<ModelClass> rbc = new ReflectBaseClass<ModelClass>(mdc);
            var fullName = rbc.GetPropertyValue<string>("Name");

            Assert.Equal(mdc.GetFullName(), fullName);
        }

        [Fact]
        private void RunPrivateFunctionTEST()
        {
            var mdc = GetModelClass();
            ReflectBaseClass<ModelClass> rbc = new ReflectBaseClass<ModelClass>(mdc);
            var nameWithAge = rbc.RunPrivateFunction<string>("GetNameWithAge", null);

            Assert.Equal(mdc.NameWithAge, nameWithAge);
        }

        [Fact]
        private void ClearControlEventTEST()
        {
            var mdc = GetModelClass();
            var memo = mdc.Memo;
            mdc.GoAction("Jumping");
            ReflectBaseClass<ModelClass> rbc = new ReflectBaseClass<ModelClass>(mdc);
            rbc.ClearControlEvent("EVENT_DOING", "Doing");
            memo = mdc.Memo;
            mdc.GoAction("Eating");

            Assert.Equal(memo, mdc.Memo);
        }
    }
}
