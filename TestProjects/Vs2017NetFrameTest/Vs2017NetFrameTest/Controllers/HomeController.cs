using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Vs2017NetFrameTest.Models;
using Vs2017NetFrameTest.Services;

namespace Vs2017NetFrameTest.Controllers
{
    public class HomeController : Controller
    {
        public MyDefines myDefines;
        public MyDefines myMonitDefines;

        //private IinJectDFunc IDFuncService;

        private IinJectDFunc IDfuncInjection;
        private IDFServ dfService;

        private IMemoryCache cach;
        private IConfiguration config;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv;

        private Func<string, IDFServ> IinJect;
        private IScnd ScndService;

        public HomeController(IOptions<MyDefines> settings, IinJectDFunc ijctionDF, /*IinJectDFunc IdfuncService,*/ IDFServ dfs
            , IMemoryCache _cach, IConfiguration _config, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostEnv
            ,IOptionsMonitor<MyDefines> mSettings, Func<string, IDFServ> IinJect, IScnd scnd)
        {
            myDefines = settings.Value;
            //IDFuncService = IdfuncService;
            IDfuncInjection = ijctionDF;
            dfService = dfs;
            cach = _cach;
            config = _config;
            hostEnv = _hostEnv;
            myMonitDefines = mSettings.CurrentValue;
            this.IinJect = IinJect;
            ScndService = scnd;
        }
        public IActionResult Index()
        {
            var str = myDefines.LogUserCommonName;
            //var appName = IDFuncService.GetAPPName();
            var appN2 = IDfuncInjection.GetAPPName();
            var dfs = dfService;

            var monitLCName = myMonitDefines.LogUserCommonName;

            cach.Set("key", "num119");

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            ViewBag.MessageFor = cach.Get("key").ToString();

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            var str = myDefines.LogUserCommonName;

            var oper = IinJect("name");
            var opIDF = oper.GetIDF();
            var opIJ = oper.GetIJ();
            var guid = opIDF.GetAPPName();
            var appName = opIJ.GetAPPName();

            var sp = ScndService.Get();

            return View(new CommonPageModel {
                Messages = str,
                Information = config["MyDefines:LogUserCommonName"]
                , Environment=hostEnv.EnvironmentName
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
