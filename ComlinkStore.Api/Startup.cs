using Microsoft.Owin.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Web.Http;

namespace ComlinkStore.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            ConfigureWebApi(config);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public static void ConfigureWebApi(HttpConfiguration config)
        {
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
                = ReferenceLoopHandling.Ignore;
            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling
                = PreserveReferencesHandling.None;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
        }
    }
}