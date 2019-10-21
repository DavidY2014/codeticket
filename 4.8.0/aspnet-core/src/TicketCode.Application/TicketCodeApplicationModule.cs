using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TicketCode.Authorization;

namespace TicketCode
{
    [DependsOn(
        typeof(TicketCodeCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TicketCodeApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TicketCodeAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TicketCodeApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
