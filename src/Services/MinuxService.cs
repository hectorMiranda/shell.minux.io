using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace Marcetux.Services
{
    using Interfaces;
    using Configuration;
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
            _logger.LogWarning($"Running minux service: {_config.Title}");
        }

    }
}