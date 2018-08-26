using System.ServiceProcess;
using Sample.Service.Standard;

namespace Sample.Service.Windows
{
    public partial class Service1 : ServiceBase
    {
        ICommonService commonService;

        public Service1(ICommonService commonService)
        {
            this.commonService = commonService;

            InitializeComponent();
        }

        internal void StartService(string[] args)
        {
            this.commonService.OnStart();
        }

        protected override void OnStart(string[] args)
        {
            this.StartService(args);
        }

        protected override void OnStop()
        {
            this.commonService.OnStop();
        }
    }
}
