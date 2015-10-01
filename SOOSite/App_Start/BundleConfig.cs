using System.Web.Optimization;

namespace SOOSite
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css")
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/ui-bootstrap-csp.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/Scripts/angular.min.js",
                         "~/Scripts/angular-route.min.js",
                         "~/Scripts/angular-strap.min.js",
                         "~/Scripts/angular-strap.tpl.min.js",
                         "~/Scripts/angular-ui/ui-bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/signalr")
                .Include("~/Scripts/jquery.signalR-{version}.js")
                .Include("~/Scripts/angular-signalr-hub.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include("~/app/app.js")
                .IncludeDirectory("~/app/controllers", "*.js")
                .IncludeDirectory("~/app/modules", "*.js")
                .IncludeDirectory("~/app/services", "*.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}