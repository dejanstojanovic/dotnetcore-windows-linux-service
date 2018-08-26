using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sample.Service.Standard;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Service.Linux
{
    public class ServiceHost : IHostedService
    {
        IApplicationLifetime appLifetime;
        ILogger<ServiceHost> logger;
        IHostingEnvironment environment;
        IConfiguration configuration;
        ICommonService commonService;
        public ServiceHost(
            IConfiguration configuration,
            IHostingEnvironment environment,
            ILogger<ServiceHost> logger,
            IApplicationLifetime appLifetime,
            ICommonService commonService)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.appLifetime = appLifetime;
            this.environment = environment;
            this.commonService = commonService;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("StartAsync method called.");

            this.appLifetime.ApplicationStarted.Register(OnStarted);
            this.appLifetime.ApplicationStopping.Register(OnStopping);
            this.appLifetime.ApplicationStopped.Register(OnStopped);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void OnStarted()
        {           
            this.commonService.OnStart();
        }

        private void OnStopping()
        {
        }

        private void OnStopped()
        {
            this.commonService.OnStop();
        }
    }
}
