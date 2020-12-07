using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace NetMVCWebSite.Filters
{

    /*
     * this file is an example for the authorization with the filters.
     */

    /// <summary>
    /// first run
    /// </summary>
    public class AuthenticFilterAttribute : IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            IPrincipal user;
            if (IsAuthenticated(filterContext, out user))
            {
                filterContext.Principal = user;
            }
            else
            {
                ProcessUnauthenticatedRequest(filterContext);
            }
        }

        private void ProcessUnauthenticatedRequest(AuthenticationContext filterContext)
        {
        }

        private bool IsAuthenticated(AuthenticationContext filterContext, out IPrincipal user)
        {
            user = filterContext.Principal;
            if (null != user && user.Identity.IsAuthenticated) { return true; }
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity("BearerIdentityServerAuthenticationIntrospection", "name", "role");
            //GenericIdentity identity = new GenericIdentity("name");
            claimsIdentity.AddClaim(new Claim("Accessors", "Hellen.Read"));
            //user = new GenericPrincipal(identity, new string[] { "Hellen.Read" });
            user = new ClaimsPrincipal(claimsIdentity);

            return true;
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }

    /// <summary>
    /// sencond run
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AuthorizedFilterAttribute : AuthorizeAttribute
    {
        public string Policy { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                //return httpContext.User.IsInRole(Policy);
                ClaimsPrincipal user = httpContext.User as ClaimsPrincipal;
                return user != null && user.HasClaim("Accessors", Policy);
            }

            return false;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }
    }

    //--------------------------------------------------------------------------------
    #region Demo code set
    /*
public class AuthenticateAttribute : FilterAttribute, IAuthenticationFilter
{
    public const string AuthorizationHeaderName = " Authorization";
    public const string WwwAuthenticationHeaderName = " WWW-Authenticate";
    public const string BasicAuthenticationScheme = " Basic";
    private static Dictionary<string, string> userAccounters;
    static AuthenticateAttribute()
    {
        userAccounters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { " Foo", "Password" },
            { " Bar", "Password" },
            { " Baz", "Password" }
        };
    }
    public void OnAuthentication(AuthenticationContext filterContext)
    {
        IPrincipal user;
        if (IsAuthenticated(filterContext, out user))
        { filterContext.Principal = user; }
        else
        { ProcessUnauthenticatedRequest(filterContext); }
    }
    protected virtual AuthenticationHeaderValue GetAuthenticationHeaderValue(AuthenticationContext filterContext)
    {
        string rawValue = filterContext.RequestContext.HttpContext.Request.Headers[AuthorizationHeaderName];
        if (string.IsNullOrEmpty(rawValue)) { return null; }
        string[] split = rawValue.Split(' '); if (split.Length != 2) { return null; }
        return new AuthenticationHeaderValue(split[0], split[1]);
    }
    protected virtual bool IsAuthenticated(AuthenticationContext filterContext, out IPrincipal user)
    {
        user = filterContext.Principal;
        if (null != user & user.Identity.IsAuthenticated) { return true; }
        AuthenticationHeaderValue token = this.GetAuthenticationHeaderValue(filterContext);
        if (null != token && token.Scheme == BasicAuthenticationScheme)
        {
            string credential = Encoding.Default.GetString(Convert.FromBase64String(token.Parameter));
            string[] split = credential.Split(':');
            if (split.Length == 2)
            {
                string userName = split[0];
                string password;
                if (userAccounters.TryGetValue(userName, out password))
                {
                    if (password == split[1])
                    {
                        GenericIdentity identity = new GenericIdentity(userName);
                        user = new GenericPrincipal(identity, new string[0]);
                        return true;
                    }
                }
            }
        }
        return false;
    }
    protected virtual void ProcessUnauthenticatedRequest(AuthenticationContext filterContext)
    {
        string parameter = string.Format(" realm=\"{0}\"", filterContext.RequestContext.HttpContext.Request.Url.DnsSafeHost);
        AuthenticationHeaderValue challenge = new AuthenticationHeaderValue(BasicAuthenticationScheme, parameter);
        filterContext.HttpContext.Response.Headers[WwwAuthenticationHeaderName] = challenge.ToString();
        filterContext.Result = new HttpUnauthorizedResult();
    }
    public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
    { }
}
*/

    /*
        //action sample
        //[Authorize]
        // [UserAuthorize(AuthorizationFailView = "Error")] //授权失败跳转Error视图
        // public ActionResult Welcome()
        //   {
        //       return View();
        //   } 
        public class UserAuthorize : AuthorizeAttribute
        {
            /// <summary>
            /// 授权失败时呈现的视图
            /// </summary>
            public string AuthorizationFailView { get; set; }

            /// <summary>
            /// 请求授权时执行
            /// </summary>
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    filterContext.HttpContext.Response.Redirect("/Account/LogOn");
                }

                //获得url请求里的controller和action：
                string controllerName = filterContext.RouteData.Values["controller"].ToString().ToLower();
                string actionName = filterContext.RouteData.Values["action"].ToString().ToLower();
                //string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                //string actionName = filterContext.ActionDescriptor.ActionName;

                //根据请求过来的controller和action去查询可以被哪些角色操作:
                Models.RoleWithControllerAction roleWithControllerAction =
                SampleData.roleWithControllerAndAction.Find(r => r.ControllerName.ToLower() == controllerName &&
                r.ActionName.ToLower() == actionName);

                if (roleWithControllerAction != null)
                {
                    this.Roles = roleWithControllerAction.RoleIds;     //有权限操作当前控制器和Action的角色id
                }

                base.OnAuthorization(filterContext);
            }
            /// <summary>
            /// 自定义授权检查（返回False则授权失败）
            /// </summary>
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {

                if (httpContext.User.Identity.IsAuthenticated)
                {
                    string userName = httpContext.User.Identity.Name;    //当前登录用户的用户名
                    Models.User user = SampleData.users.Find(u => u.UserName == userName);   //当前登录用户对象

                    if (user != null)
                    {
                        Models.Role role = SampleData.roles.Find(r => r.Id == user.RoleId);  //当前登录用户的角色
                        foreach (string roleid in Roles.Split(','))
                        {
                            if (role.Id.ToString() == roleid)
                                return true;
                        }
                        return false;
                    }
                    else
                        return false;
                }
                else
                {
                    return false;     //进入HandleUnauthorizedRequest 
                }

            }

            /// <summary>
            /// 处理授权失败的HTTP请求
            /// </summary>
            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {

                filterContext.Result = new ViewResult { ViewName = AuthorizationFailView };

            }
        }
     */
    #endregion
}