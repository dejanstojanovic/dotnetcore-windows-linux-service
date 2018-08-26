using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Sample.Service.Standard.Implementation
{
    public class CommonSampleService : CommonServiceBase
    {
        public CommonSampleService(IConfiguration configuration, ILogger<CommonSampleService> logger) : base(configuration, logger)
        {
            logger.LogInformation("Class instatiated");
        }

        public override void OnStart()
        {
           this.Logger.LogInformation("CommonSampleService OnStart");
        }

        public override void OnStop()
        {
            this.Logger.LogInformation("CommonSampleService OnStop");
        }
    }
}
