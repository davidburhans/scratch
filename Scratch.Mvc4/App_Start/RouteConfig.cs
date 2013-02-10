using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Scratch.Core;

namespace Scratch.Mvc4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Entity",
                url: Constants.EntityRoute,
                defaults: new { id = RouteParameter.Optional, controller = "Entity", action = "Index" }
            );
            
            routes.MapHttpRoute(
                name: "EntityApi",
                routeTemplate: Constants.EntityApiRoute,
                defaults: new { id = RouteParameter.Optional, controller = "EntityApi" }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}