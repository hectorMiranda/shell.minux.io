using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Marcetux 
{
    using Shell;
    using Configuration;
    using Services.Interfaces;
    using Services;
    public class Program
    {
        public static void Main(string[] args)
        {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
 
        var serviceProvider = serviceCollection.BuildServiceProvider();
 
        serviceProvider.GetService<Kernel>().Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());
        
            serviceCollection.AddLogging(); 
        
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("app-settings.json", false)
                .Build();
            serviceCollection.AddOptions();
            serviceCollection.Configure<AppSettings>(configuration.GetSection("Configuration"));
        
            serviceCollection.AddTransient<IMinuxService, MinuxService>();
        
            serviceCollection.AddTransient<Kernel>();
        }


     }
}

