using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute("CustomArray", "Results/{id}", new { controller = "CustomURLRouting", action = "Array", id = UrlParameter.Optional }, constraints: new { id = @"\d+" });

            //routes.MapRoute("CustomASPX", "{AspxResults}.aspx/{id}/{anotherId}", new { controller = "CustomURLRouting", action = "HandleAspxResults", id = UrlParameter.Optional, anotherId = UrlParameter.Optional });

            //routes.MapRoute("Custom", "{Results}/{id}/{anotherId}", new { controller = "CustomURLRouting", action = "HandleResults", id = UrlParameter.Optional, anotherId = UrlParameter.Optional });
                    

            
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{area}/{controller}/{action}/{id}",
            //    defaults: new { area= "MyArea", controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
