using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aaASptest
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //System.Web.Security.SqlRoleProvider
            //System.Web.Security.SqlMembershipProvider
            //System.Web.Profile.SqlProfileProvider
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //System.Web.Security.Roles.CreateRole("TestRole");

            System.Web.Security.SqlMembershipProvider smp = new System.Web.Security.SqlMembershipProvider();
            //smp.Initialize("",

            System.Web.Security.SqlRoleProvider srp = new System.Web.Security.SqlRoleProvider();
            var nvc= new System.Collections.Specialized.NameValueCollection();
            nvc.Add("connectionStringName","DefaultConnection");
            nvc.Add("applicationName","at");
            srp.Initialize("DefaultRoleProvider",nvc);
            srp.CreateRole("atTest5");
            System.Web.Security.Roles.CreateRole("TestRole1");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            System.Web.Security.MembershipCreateStatus result;
            //System.Web.Security.Membership.CreateUser("user", "user", "aaa", null, null, false, out result);
            System.Web.Security.Membership.CreateUser("user1", "user1", "aaa1", null, null, false, out result);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //System.Web.Security.Roles.AddUsersToRole(new string[] { "user" }, "TestRole");
            Response.Write(System.Web.Security.Roles.IsUserInRole("user", "TestRole"));
            Response.Write("/");
            Response.Write(System.Web.Security.Roles.IsUserInRole("user1", "TestRole"));
        }
    }
}