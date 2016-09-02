using System.Web.Mvc;
using System.Web.Routing;

namespace CashJobSite.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "JobPost",
                url: "Job/Post",
                defaults: new { controller = "Job", action = "Post" }
                );

            routes.MapRoute(
                name: "Job",
                url: "Job/{id}/{action}",
                defaults: new { controller = "Job", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
