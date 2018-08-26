using Sample.Service.Standard;
using Sample.Service.Standard.Implementation;
using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace Sample.Service.Windows
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            ICommonService commonService = new CommonSampleService(
                logger:null,
                environment:null,
                configuration:null
                );


            if (Debugger.IsAttached)
            {

                new Service1(commonService).StartService(args);
                Console.ReadLine();
            }
            else
            {
                //Start servive  
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new Service1(commonService)
                };
                ServiceBase.Run(ServicesToRun);
            }

           
        }
    }
}
