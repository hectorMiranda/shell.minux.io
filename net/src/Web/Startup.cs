using Microsoft.AspNetCore.Builder;
using Nancy.Owin;

namespace Marcetux.Web
{
   public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(x => x.UseNancy());
        }
   }
}