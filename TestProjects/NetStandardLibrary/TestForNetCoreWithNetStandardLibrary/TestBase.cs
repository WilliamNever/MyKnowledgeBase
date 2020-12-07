using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StandardBaseInfors.TestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestForNetCoreWithNetStandardLibrary
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

        public IOptionsMonitor<ConnectionStrings> GetConnectionStringsClass()
        {
            //return new MockConnectionStrings();

            IServiceCollection services = new ServiceCollection();
            var configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder().Build();

            services.Configure<ConnectionStrings>(
                option =>
                {
                    option.Darkseid_Connection = "aaaaaAAAAA";
                });

            var options = services.BuildServiceProvider().GetRequiredService<IOptionsMonitor<ConnectionStrings>>();
            return options;
        }
    }

    public class MockConnectionStrings : IOptionsMonitor<ConnectionStrings>, IDisposable
    {
        public ConnectionStrings CurrentValue => new ConnectionStrings
        {
            Darkseid_Connection = "DarkSeid_Connections"
        };

        public void Dispose()
        {
        }

        public ConnectionStrings Get(string name)
        {
            return CurrentValue;
        }

        public IDisposable OnChange(Action<ConnectionStrings, string> listener)
        {
            return this;
        }
    }
}
