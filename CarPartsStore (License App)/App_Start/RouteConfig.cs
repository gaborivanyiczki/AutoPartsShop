using CarPartsStore__License_App_.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarPartsStore__License_App_
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


           /* routes.Add("CartypeList", new SeoFriendlyRoute("{id}",
                new RouteValueDictionary(new { controller = "Shop", action = "GetCartype" }),
                new MvcRouteHandler()));

            routes.Add("CarmodelsList", new SeoFriendlyRoute("{id}",
                new RouteValueDictionary(new { controller = "Shop", action = "GetModel" }),
                new MvcRouteHandler()));

            routes.Add("CarengineList", new SeoFriendlyRoute("{id}",
                new RouteValueDictionary(new { controller = "Shop", action = "GetEngine" }),
                new MvcRouteHandler())); */


            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}/{beta}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, beta = UrlParameter.Optional }
           );

        }
    }
}
