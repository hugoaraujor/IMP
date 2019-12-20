using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IMPSOR
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        
            routes.MapRoute(
               name: "Default2",
               url: "{controller}/{action}/{metodo}/{pozoid}/{page}",
               defaults: new { controller = "Procesar", action = "Index", metodo = UrlParameter.Optional ,pozoid = UrlParameter.Optional,page= UrlParameter.Optional }
           );
            
        }
    }
}
