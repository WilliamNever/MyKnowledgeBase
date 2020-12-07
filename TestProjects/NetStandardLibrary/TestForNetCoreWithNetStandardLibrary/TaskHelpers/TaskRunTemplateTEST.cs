using NetStandardLibrary.TaskHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestForNetCoreWithNetStandardLibrary.TaskHelpers
{
    public class TaskRunTemplateTEST
    {
        [Theory]
        [InlineData("Hello World!")]
        public async void RunAsyncTEST(string data)
        {
            var CmpValue = await TaskRunTemplate.RunAsync(
                () => {
                    return data;
                }
                );
            Assert.Equal(data, CmpValue);
        }
    }
}
