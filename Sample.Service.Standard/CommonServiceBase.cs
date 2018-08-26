using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Sample.Service.Standard
{
    public abstract class CommonServiceBase : ICommonService
    {
        private IConfiguration configuration;
        ILogger<CommonServiceBase> logger;

        public IConfiguration Configuration => this.configuration;
        public ILogger<CommonServiceBase> Logger => this.logger;


        public CommonServiceBase(
            IConfiguration configuration,
            ILogger<CommonServiceBase> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public abstract void OnStart();

        public abstract void OnStop();
    }
}
