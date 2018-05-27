using System.Web.Mvc;
using System.Web.Routing;

namespace Lb3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Companies", action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}