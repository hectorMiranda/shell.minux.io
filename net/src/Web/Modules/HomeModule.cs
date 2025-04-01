using Nancy;
using System.Collections.Generic;

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


            Get("/schedule", _ => {
                return Response.AsJson( new Dictionary<string, string>{
                    {"Piano", "5:30am"}, {"Guitar", "8:00pm"}, {"Muay thai", "6:00am"}, {"DuoLingo", "5:00am"}, {"Code commit","7:30am"}, {"Drawing","8:00pm"}, {"Photography","6:00pm"}, {"Marcetux","9:00pm"}
                });
            });
        }





    }
}