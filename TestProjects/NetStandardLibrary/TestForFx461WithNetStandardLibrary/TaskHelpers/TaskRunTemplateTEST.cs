using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetStandardLibrary.TaskHelpers;

namespace TestForFx461WithNetStandardLibrary.TaskHelpers
{
    [TestClass]
    public class TaskRunTemplateTEST
    {
        [TestMethod]
        [DataRow("Hello World!")]
        public void RunAsyncTEST(string data)
        {
            var CmpValue = TaskRunTemplate.RunAsync(
                () => {
                    return data;
                }
                ).Result;
            Assert.AreEqual(data, CmpValue);
        }
    }
}
