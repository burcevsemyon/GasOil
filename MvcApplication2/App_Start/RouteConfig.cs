using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GasOil
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "RequestCreate",
                url: "request/{typeId}",
                defaults: new { controller = "Requests", action = "Build", typeId = 1 }
            );

            routes.MapRoute(
                name: "ProductsShow",
                url: "products/show/{groupId}",
                defaults: new
                {
                    controller = "Products",
                    action = "Show",
                    groupId = (long?)null
                }
            );

            routes.MapRoute(
                name: "ProductsPassports",
                url: "products/passports/",
                defaults: new { controller = "Products", action = "Passports"}
            );

            routes.MapRoute(
                name: "ProductsCertificates",
                url: "products/certificates/",
                defaults: new { controller = "Products", action = "Certificates" }
            );

            routes.MapRoute(
                name: "Service",
                url: "service/",
                defaults: new { controller = "Service", action = "Index" }
            );

            routes.MapRoute(
                name: "Traffic",
                url: "traffic/",
                defaults: new { controller = "Traffic", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}