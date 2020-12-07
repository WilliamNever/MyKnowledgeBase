using HostTest.Models;
using HostTest.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HostTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = new HostBuilder()
            .ConfigureLogging((hostContext, factory) =>
            {
            })
            .ConfigureHostConfiguration(hostConfig =>
            {
                var switchMappings = new System.Collections.Generic.Dictionary<string, string>()
                {
                    { $"-{Commands.CompleteFile}", Commands.CompleteFile },
                    { $"-{Commands.PartialFile}", Commands.PartialFile },
                    { $"-{Commands.Customer}", Commands.Customer },
                };
                hostConfig.SetBasePath(Directory.GetCurrentDirectory());
                hostConfig.AddCommandLine(args, switchMappings);
            })
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath);
                config.AddJsonFile("appSetting.json", true, true);
            })

            .ConfigureServices((hostContext, services) =>
            {
                services.Configure<CommandLineParameters>(
                    x =>
                    {
                        x.CompleteFile = hostContext.Configuration.GetValue<string>(Commands.CompleteFile);
                        x.PartialFile = hostContext.Configuration.GetValue<string>(Commands.PartialFile);
                        x.CustomerId = hostContext.Configuration.GetValue<string>(Commands.Customer);
                    }
                    );

                services
                .Configure<AppSetting>(hostContext.Configuration.GetSection(nameof(AppSetting)))
                ;
                //var val = hostContext.Configuration.GetSection(nameof(AppSetting)).Get<AppSetting>();

                services
                .AddHostedService<MainService>();
            })
            .UseConsoleLifetime()
            .Build();

            await host.RunAsync();
        }
    }
}
