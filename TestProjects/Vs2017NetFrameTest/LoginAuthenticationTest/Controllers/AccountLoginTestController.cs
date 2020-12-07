using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginAuthenticationTest.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace LoginAuthenticationTest.Controllers
{
    public class AccountLoginTestController : Controller
    {
        public IActionResult Index()
        {
            return View(new CommonPageInforViewModel("Index Page"));
        }

        public IActionResult NoAccessPage()
        {
            return View(new CommonPageInforViewModel("NoAccessPage"));
        }

        public async Task<IActionResult> Login()
        {
            //var str = await Task.Run(()=> { return 1; });

            var types = User.Identity.AuthenticationType;
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "halower", ClaimValueTypes.String, "https://www.cnblogs.com/rohelm"));
            claims.Add(new Claim("EmployeeNumber", "123456", ClaimValueTypes.String, "http://www.cnblogs.com/rohelm"));

            var userIdentity = new ClaimsIdentity("Admin");
            userIdentity.AddClaims(claims);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal
                ,
                new AuthenticationProperties
                {
                    //ExpiresUtc = DateTime.UtcNow.AddMinutes(20),

                    IsPersistent = false,
                    AllowRefresh = true,
                }
                );

            return View(new CommonPageInforViewModel("Login Page"));
        }

        [Authorize]
        public IActionResult LoginedPage()
        {
            return View(new CommonPageInforViewModel("Has Logined Page"));
        }

        [Authorize(Policy = "EmployeeOnly")]
        public IActionResult PolicyLoginedPage()
        {
            return View(new CommonPageInforViewModel("[Authorize(Policy = \"EmployeeOnly\")] Has Logined Page"));
        }

        public async Task<IActionResult> LogOut()
        {
            //var str = await Task.Run(() => { return 1; });

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return View(new CommonPageInforViewModel("LogOut Page"));
        }
    }
}