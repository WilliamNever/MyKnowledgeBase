using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Vs2017NetFrameTest.Services
{
    public class HostedService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            return Task.Run(() => {

                while (!_cts.Token.IsCancellationRequested)
                {
                    Console.WriteLine(DateTime.Now.ToString());
                    Thread.Sleep(1000);
                }

            });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
