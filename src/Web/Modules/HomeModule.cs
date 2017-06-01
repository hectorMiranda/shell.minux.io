using Nancy;

namespace Marcetux.Web
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", args => "Minux Server 0.0.1");
        }
    }
}