using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Sample.Service.Standard
{
    public abstract class CommonServiceBase : ICommonService
    {
        private IConfiguration configuration;
        private IHostingEnvironment environment;
        ILogger<CommonServiceBase> logger;


        public IConfiguration Configuration => this.configuration;
        public IHostingEnvironment Environment => this.Environment;
        public ILogger<CommonServiceBase> Logger => this.logger;


        public CommonServiceBase(
            IConfiguration configuration,
            IHostingEnvironment environment,
            ILogger<CommonServiceBase> logger)
        {
            this.configuration = configuration;
            this.environment = environment;
            this.logger = logger;
        }

        public abstract void OnStart();

        public abstract void OnStop();
    }
}
