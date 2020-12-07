using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForNodeJSTest.SelfDefinedAttributes
{
    public class UAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                string currentRole = GetRole(httpContext.User.Identity.Name);
                if (Roles.Contains(currentRole))
                    return true;
            }
            return base.AuthorizeCore(httpContext);
        }
        private string GetRole(string name)
        {
            string role = "Fool";
            switch (name)
            {
                case "aaa": role = "User"; break;
                case "bbb": role = "Admin"; break;
                case "ccc": role = "God"; break;
                case "admin": role = "Administrators"; break;
                default: role = "Fool"; break;
            }
            return role;
        }
    }
}