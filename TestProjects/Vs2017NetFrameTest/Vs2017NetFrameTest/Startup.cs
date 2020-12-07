using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleCoreTest.DBModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vs2017NetFrameTest.MiddleWares;
using Vs2017NetFrameTest.Models;
using Vs2017NetFrameTest.Services;

namespace Vs2017NetFrameTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _IHostingEnvironment = env;
        }

        public IConfiguration Configuration { get; private set; }
        public IHostingEnvironment _IHostingEnvironment { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 依赖注入 injection ， 注册需要注入的内容，可以是class,Func<>,etc.
        /// 
        /// 权重：
        /// AddSingleton → AddTransient → AddScoped
        /// AddSingleton的生命周期：
        /// 项目启动-项目关闭 相当于静态类  只会有一个
        /// AddScoped的生命周期：
        /// 请求开始-请求结束 在这次请求中获取的对象都是同一个
        /// AddTransient的生命周期：
        /// 请求获取-（GC回收-主动释放） 每一次获取的对象都不是同一个
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<MyDefines>(Configuration.GetSection("MyDefines"));
            services.AddSingleton(_IHostingEnvironment);

            services.AddSingleton(Configuration);

            services.AddSingleton<Microsoft.Extensions.Hosting.IHostedService, HostedService>();    //registering a host services

            services.AddDbContextPool<DBCTXTContext>(options => options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DBCTXT;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;user id=sa;password=sa"))
                .AddScoped(typeof(DBCTXTContext))
            .AddDbContextPool<DBCTXTContextX>(options => options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DBCTXT;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;user id=sa;password=sa"))
                .AddScoped(typeof(DBCTXTContextX))
                ;
            //services.AddScoped(typeof(InjectionDFunc));
            //services.AddTransient<InjectionDFunc>();
            //services.AddSingleton<InjectionDFunc>();

            services
            .AddTransient<IinJectDFunc, InjectionDFunc>()
            //.AddSingleton<IinJectDFunc, InjectionDFunc>()
            //.AddScoped<IinJectDFunc, InjectionDFunc>()



            //.AddTransient(typeof(DFServices))
            //.AddSingleton(typeof(DFServices))
            //.AddScoped(typeof(DFServices))

            .AddTransient<DFServices>()
            .AddTransient<IDFServ, DFServices>()

            //.AddTransient<IScnd, SecondService>()
            .AddSingleton<IScnd, SecondService>()
            //.AddScoped<IScnd, SecondService>()
            ;

            var sProvider = services.BuildServiceProvider();

            services.AddTransient(
                factory =>
                {
                    Func<string, IDFServ> func = (name) =>
                    {
                        return sProvider.GetService<DFServices>();
                    };
                    return func;
                }
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 注册中间件
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            #region 这块关于map的代码是真的没看明白了。
            /*
            //app.MapWhen(x=> {return x.Request.Path.Value.Contains("/Home/Contact"); },
            //appx =>
            //{
            //    appx.Use(async (context,next) =>
            //    {
            //        await next.Invoke();
            //        //await context.Response.WriteAsync("\nHello ,that is Handle Map!\n\n");
            //    });
            //    appx.Run(async (context) =>
            //    {
            //        await context.Response.WriteAsync("Manager.");
            //    });
            //}
            //);

            app.Map("/Home/Contact",
            appx =>
            {
                appx.Use(async (context, next) =>
                {
                    context.Response.Redirect("/Home/About");
                    await next.Invoke();

                    await context.Response.WriteAsync("\nHello ,that is Handle Map 1!\n\n");
                });

                appx.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Manager.");
                });
                
                appx.Use(async (context, next) =>
                {
                    await next.Invoke();

                    await context.Response.WriteAsync("\nHello ,that is Handle Map 2!\n\n");
                });
            }
            );
            */
            #endregion

            app.Use(async (context, next) =>
            {
                await next.Invoke();
                await context.Response.WriteAsync("\nHello ,that is Handle Map! Out\n\n");
            });
            app.UseMiddleware<FMWare>();
            //app.UseMiddleware<ScMWare>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Privacy}/{id?}");
            });
        }
    }
}
