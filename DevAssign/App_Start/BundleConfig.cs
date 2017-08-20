using System.Web;
using System.Web.Optimization;

namespace DevAssign
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/scr/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/scr/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/scr/bootstrap.js",
                      "~/Content/scr/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/user").Include(
                      "~/Content/scr/jquery-ui-1.12.1.min.js",
                "~/Content/scr/user.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/site.css",
                      "~/Content/css/jquery-ui.min.css",
                      "~/Content/themes/base/jquery-ui.min.css"));
        }
    }
}
