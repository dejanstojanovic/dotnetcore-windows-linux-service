using Sample.Service.Standard;
using Sample.Service.Standard.Implementation;
using System;
using System.Diagnostics;
using System.ServiceProcess;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using Serilog;

namespace Sample.Service.Windows
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 



        static void Main(string[] args)
        {
            #region Dependecy injection setup
            ServiceCollection services = new ServiceCollection();

            //Create configuration builder
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");


            //Inject configuration
            services.AddSingleton<IConfiguration>(provider =>
            {
                return configurationBuilder.Build();
            });

            //Inject Serilog
            services.AddLogging(options =>
           {
               options.AddSerilog(
                   new LoggerConfiguration()
                              .ReadFrom.Configuration(configurationBuilder.Build())
                              .CreateLogger()
                   );           
           });           
            
            //Inject common service
            services.AddSingleton(typeof(ICommonService), typeof(CommonSampleService));

            //Inject concrete implementaion of the service
            services.AddSingleton(typeof(ServiceBase), typeof(Service1));

            //Build DI provider
            ServiceProvider serviceProvider = services.BuildServiceProvider();


            #endregion

            if (Debugger.IsAttached)
            {
                //Console Debug mode

                var svc = serviceProvider.GetService<ServiceBase>() as Service1;
                svc.StartService(args);

                Console.ReadLine();
            }
            else
            {
                //Start service
                
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    serviceProvider.GetService<ServiceBase>()
                };
                ServiceBase.Run(ServicesToRun);
            }

           
        }
    }
}
