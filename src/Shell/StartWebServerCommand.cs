using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Marcetux.Web;


namespace Marcetux.Shell
{
    internal class StartWebServerCommand : ICommand
    {
        public string Name => "startwebserver";

        public string[] Aliases => new string[]{"wsstart"};

        public string Description => "Starts a webserver exposing operational endpoints";
        public string Help => "StartWebServerCommand help";




        public string Execute(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Starting minux web server...");

            try{
             var host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            host.Run();
            }catch (Exception ex)
            {
                Console.WriteLine($"Exit:{ex.Message}");
            }
            return null;
        }
    }
}
