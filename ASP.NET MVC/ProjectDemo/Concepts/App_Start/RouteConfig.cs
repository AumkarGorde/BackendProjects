using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Concepts
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            

            routes.MapRoute(
               name: "Variables",
               url: "Variables",
               defaults: new { controller = "Home", action = "Variables" }
               );

            routes.MapRoute(
              name: "Variables2",
              url: "Variables2",
              defaults: new { controller = "Home", action = "Variables2" }
              );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }

    //Key Points
    //1. By Default if you write controller name and action name it will route to that particular page even if it is not present in the route config class
    //2. If you want a unique url then you can add that to this routes collection list as the Sample added above.
}
