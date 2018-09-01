using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;

namespace Sample.Service
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            IHost host = new HostBuilder()
                 .ConfigureHostConfiguration(configHost =>
                 {
                     configHost.SetBasePath(Directory.GetCurrentDirectory());
                     configHost.AddEnvironmentVariables(prefix: "ASPNETCORE_");
                     configHost.AddCommandLine(args);
                 })
                 .ConfigureAppConfiguration((hostContext, configApp) =>
                 {
                     configApp.SetBasePath(Directory.GetCurrentDirectory());
                     configApp.AddEnvironmentVariables(prefix: "ASPNETCORE_");
                     configApp.AddJsonFile($"appsettings.json", true);
                     configApp.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", true);
                     configApp.AddCommandLine(args);
                 })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging();
                    services.AddHostedService<ServiceHost>();
                })
                .ConfigureLogging((hostContext, configLogging) =>
                {
                    configLogging.AddSerilog(new LoggerConfiguration()
                              .ReadFrom.Configuration(hostContext.Configuration)
                              .CreateLogger());
                    configLogging.AddConsole();
                    configLogging.AddDebug();
                })
                .Build();

            await host.RunAsync();
        }
    }
}
