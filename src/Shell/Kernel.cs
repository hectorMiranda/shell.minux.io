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
        }
    }
}