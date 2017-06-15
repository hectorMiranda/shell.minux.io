using Nancy;

namespace Marcetux.Web
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", args => "Minux Server 0.0.1");

            Get("/echo", _ =>
            {
                var echo = new
                {
                    Server = "Minux Server 0.0.1 says",
                    this.Request.Headers,
                    this.Request.Query,
                    this.Request.Form,
                    this.Request.Method,
                    this.Request.Url,
                    this.Request.Path
                };

                return Response.AsJson(echo);
            });
        }
    }
}