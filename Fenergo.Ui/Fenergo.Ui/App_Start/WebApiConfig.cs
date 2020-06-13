using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Fenergo.Ui.Controllers.Api;
using Fenergo.Ui.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Unity;
using Unity.Lifetime;

namespace Fenergo.Ui
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //service registration
            var container = new UnityContainer();
            container.RegisterType<IHardwareRepository, HardwareRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IHardwareTypeRepository, HardwareTypeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPhotoRepository, PhotoRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

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
