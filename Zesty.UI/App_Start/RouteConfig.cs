using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Zesty.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes(); //Enables Attribute Routing

            //routes.IgnoreRoute("blogue/*");
            //routes.IgnoreRoute("aide/*");

            //routes.RouteExistingFiles = true;
            routes.AppendTrailingSlash = false;
            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Zesty.UI.Controllers" }
            ) ;
        }
    }
}
