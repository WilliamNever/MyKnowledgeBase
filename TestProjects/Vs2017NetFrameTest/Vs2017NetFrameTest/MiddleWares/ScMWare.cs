using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vs2017NetFrameTest.MiddleWares
{
    public class ScMWare
    {
        private readonly RequestDelegate next;

        public ScMWare(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                //await context.Response.WriteAsync("ScMWare MiddleWare Begin!\n");
                await next(context);
                await context.Response.WriteAsync("ScMWare MiddleWare End!\n");
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }


        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            return context.Response.WriteAsync("ScMWare Errors!");
        }
    }
}
