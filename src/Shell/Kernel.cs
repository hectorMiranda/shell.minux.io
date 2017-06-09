using System;
using System.IO;
using static System.Console;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Marcetux.Shell
{
    using Marcetux.Services.Interfaces;
    using Marcetux.Configuration;
    public class Kernel
    {
        private readonly IMinuxService _minuxService;
        private readonly ILogger<Kernel> _logger;
        private readonly AppSettings _config;
        public Kernel(IMinuxService minuxService, IOptions<AppSettings> config, ILogger<Kernel> logger)
        {
            _minuxService = minuxService;
            _logger = logger;
            _config = config.Value;
        }
    
        public void Run()
        {
            _minuxService.Run();

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
                    WriteLine("Invalid command, please use one of the following commands");
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