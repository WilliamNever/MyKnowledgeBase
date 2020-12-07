using HostTest.InterFaces;
using HostTest.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HostTest.Services
{
    public class MainService : IMainService
    {
        private IHostApplicationLifetime appLifetime;
        private CommandLineParameters cmdParams;
        private AppSetting appSettings;
        public MainService(
            IHostApplicationLifetime appLifetime,
            IOptions<CommandLineParameters> cmdParams,
            IOptions<AppSetting> appSettings
            )
        {
            this.appLifetime = appLifetime;
            this.cmdParams = cmdParams.Value;
            this.appSettings = appSettings.Value;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine(appSettings.AreYouOK);

            Console.WriteLine(cmdParams.CompleteFile);
            Console.WriteLine(cmdParams.CustomerId);
            Console.WriteLine(cmdParams.PartialFile);

            Console.ReadLine();
            await StopAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            appLifetime.StopApplication();
            return Task.CompletedTask;
        }
    }
}
