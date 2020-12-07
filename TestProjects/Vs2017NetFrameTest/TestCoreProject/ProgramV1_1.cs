using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace TestCoreProject
{
    class ProgramV1_1
    {
        private static IServiceCollection services;
        
        static ProgramV1_1()
        {
            services = new ServiceCollection();

            services.AddTransient(x => new HttpClient() { BaseAddress = new Uri("http://www.SSSS.com") });

            services.AddTransient<IBossService, BossService>();

            services.AddTransient<PrintReqService>();
        }
        static void Main_ForInjectionTest(string[] args)
        {
            ServiceProvider provider = services.BuildServiceProvider();
            var printReq = provider.GetRequiredService<PrintReqService>();

            Console.WriteLine(printReq.Response().BaseAddress.AbsoluteUri);
            var xservice = services.FirstOrDefault(x => x.ServiceType == typeof(HttpClient));
            if (xservice != null)
                services.Remove(xservice);

            services.AddTransient(x => new HttpClient() { BaseAddress = new Uri("http://www.VVVV.com") });
            provider = services.BuildServiceProvider();
            Console.WriteLine(printReq.Response().BaseAddress.AbsoluteUri);

            var printReq1 = provider.GetRequiredService<PrintReqService>();
            Console.WriteLine(printReq1.Response().BaseAddress.AbsoluteUri);

            Console.ReadLine();
        }
    }

    public interface IBossService
    {
        HttpClient Response();
    }
    public class BossService:IBossService
    {
        public HttpClient Client;
        public IServiceProvider provider;
        public BossService(HttpClient client, IServiceProvider provider)
        {
            Client = client;
            this.provider = provider;
        }

        public HttpClient Response()
        {
            return Client;
        }
    }

    public class PrintReqService
    {
        public IServiceProvider provider;
        public PrintReqService(IServiceProvider provider)
        {
            this.provider = provider;
        }
        public HttpClient Response()
        {
            return provider.GetRequiredService<IBossService>().Response();
        }
    }
}
