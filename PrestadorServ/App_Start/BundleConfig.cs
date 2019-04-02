using System.Web;
using System.Web.Optimization;

namespace PrestadorServ
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/style/angular").Include("~/Content/PrestadorServClient/styles.*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Content/PrestadorServClient/runtime.*",
                "~/Content/PrestadorServClient/es2015-*",
                "~/Content/PrestadorServClient/polyfills.*",
                "~/Content/PrestadorServClient/scripts.*",
                "~/Content/PrestadorServClient/main.*"
                ));
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
