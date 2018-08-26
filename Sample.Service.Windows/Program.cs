using Sample.Service.Standard;
using Sample.Service.Standard.Implementation;
using System;
using System.Diagnostics;
using System.ServiceProcess;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace Sample.Service.Windows
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {

            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(provider =>
            {
                return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .Build();
            });
            services.AddLogging();
            services.AddSingleton(typeof(ICommonService), typeof(CommonSampleService));
            services.AddSingleton(typeof(ServiceBase), typeof(Service1));
            

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            if (Debugger.IsAttached)
            {
                //new Service1(commonService).StartService(args);

                var svc = serviceProvider.GetService<ServiceBase>() as Service1;
                svc.StartService(args);

                Console.ReadLine();
            }
            else
            {
                //Start servive  
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                //new Service1(commonService)
                serviceProvider.GetService<ServiceBase>()
                };
                ServiceBase.Run(ServicesToRun);
            }

           
        }
    }
}
