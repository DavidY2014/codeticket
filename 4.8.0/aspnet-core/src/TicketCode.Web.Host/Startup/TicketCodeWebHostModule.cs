using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TicketCode.Configuration;

namespace TicketCode.Web.Host.Startup
{
    [DependsOn(
       typeof(TicketCodeWebCoreModule))]
    public class TicketCodeWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TicketCodeWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TicketCodeWebHostModule).GetAssembly());
        }
    }
}
