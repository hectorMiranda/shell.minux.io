using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using static System.Console;
using System.Linq;


namespace Marcetux.Services
{
    using Interfaces;
    using Configuration;
    using Shell;
    public class MinuxService: IMinuxService
    {
        private readonly ILogger<MinuxService> _logger;
        private readonly AppSettings _config;

        public MinuxService(ILogger<MinuxService> logger,
        IOptions<AppSettings> config)
        {
            _logger = logger;
            _config = config.Value;

        }
    
        public void Run()
        {
            _logger.LogInformation($"Booting mode: {_config.InstanceType}");
            RunShellMode();
        }

        private void RunShellMode()
        {
            while (true)
            {
                Console.Write("#");
                try
                {
                    var input = ReadLine().Split(' ').ToList<string>();

                    WriteLine("{0}", Processor.Execute(input[0], input.Count > 1 ? input.Skip(1).ToArray() : new string[0]));
                }
                catch (CommandNotFoundException)
                {
                    WriteLine("Invalid command, type ? for help");
                }
                catch (IOException ex)
                {
                    _logger.LogCritical($"{ex.Message}@{ex.Source}");
                    break;
                }
            }
        }

    }
}