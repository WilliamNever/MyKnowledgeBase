using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Vs2017NetFrameTest.MiddleWares
{
    public class FMWare
    {
        private readonly RequestDelegate next;

        public FMWare(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                //await context.Response.WriteAsync("FMWare MiddleWare Begin!\n");
                if (!context.Request.Path.Value.Contains("/Home/Contact"))
                    await next(context);
                await context.Response.WriteAsync("FMWare MiddleWare End!\n");
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }


        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            return context.Response.WriteAsync("FMWare Errors!");
        }
    }
}
