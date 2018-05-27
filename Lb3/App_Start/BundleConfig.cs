using System.Web.Optimization;

namespace Lb3
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/node_modules/jquery/dist/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/node_modules/jquery-validation/dist/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/node_modules/bootstrap/dist/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/node_modules/bootstrap/dist/css/bootstrap.css"));
        }
    }
}