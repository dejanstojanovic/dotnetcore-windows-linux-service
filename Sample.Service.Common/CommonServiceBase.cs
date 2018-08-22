using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Service
{
    public abstract class CommonServiceBase : ICommonService
    {
        private IConfiguration configuration;
        private IHostingEnvironment environment;
        ILogger<CommonServiceBase> logger;

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
