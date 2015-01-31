using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PracticeSession
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //routes.MapRoute("Custom", "{Results}/{id}", new { controller = "CustomURLRouting", action = "HandleResults", id = UrlParameter.Optional, anotherId = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "SignalRChat", action = "Chat", id = UrlParameter.Optional}
            );
        }
    }
}