using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiWaterJug
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{x}/{y}/{z}",
                defaults: new { x = RouteParameter.Optional, y = RouteParameter.Optional, z = RouteParameter.Optional }
            );
        }
    }
}
