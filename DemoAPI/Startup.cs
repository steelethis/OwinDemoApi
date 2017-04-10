using Owin;
using System.Web.Http;

namespace DemoAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            config.MapHttpAttributeRoutes();

            app.UseWebApi(config);
        }
    }
}