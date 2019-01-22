using System.Web.Optimization;

namespace Pz3
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/wwwroot/lib/jquery/dist/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/wwwroot/lib/jquery-validation/dist/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/wwwroot/lib/bootstrap/dist/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/wwwroot/lib/bootstrap/dist/css/bootstrap.css"));
        }
    }
}