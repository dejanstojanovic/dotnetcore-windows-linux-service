using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Service
{
    public class ServiceHost : IHostedService, IDisposable
    {
        IApplicationLifetime appLifetime;
        ILogger<ServiceHost> logger;
        IHostingEnvironment environment;
        IConfiguration configuration;

        bool disposing = false;

        public ServiceHost(
            IConfiguration configuration,
            IHostingEnvironment environment,
            ILogger<ServiceHost> logger,
            IApplicationLifetime appLifetime)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.appLifetime = appLifetime;
            this.environment = environment;
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
            this.logger.LogInformation("OnStarted method called.");
        }

        private void OnStopping()
        {
            this.logger.LogInformation("OnStopping method called.");
        }

        private void OnStopped()
        {
            this.logger.LogInformation("OnStopped method called.");
        }

        public void Dispose()
        {
            if (!disposing)
            {
                disposing = true;

                //Do the dispose here
                
            }

        }
    }
}
