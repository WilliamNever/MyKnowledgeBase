using System.Web;
using System.Web.Optimization;
using System.Web.Optimization.React;

namespace React2TestForMvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //bundles.Add(new BabelBundle("~/bundles/main").Include(    //System.Web.Optimization.React
            //    "~/Scripts/Tutorial.jsx"
            //));
            bundles.Add(new BabelBundle("~/scripts/reactCustom/main")   //这个main在这还挺重要，改成其它字符串都会出错
                .Include("~/Scripts/reactCustom/*.jsx")
                );

            //BundleTable.EnableOptimizations = true;//强制压缩.js文件
        }
    }
}
