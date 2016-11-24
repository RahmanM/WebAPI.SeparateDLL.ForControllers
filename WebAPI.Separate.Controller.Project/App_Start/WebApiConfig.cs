using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace WebAPI.Separate.Controller.Project
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Services.Replace(typeof(IAssembliesResolver), new CustomAssembliesResolver());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }


    }

}
