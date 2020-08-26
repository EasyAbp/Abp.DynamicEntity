using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace EasyAbp.Abp.Dynamic
{
    [DependsOn(
        typeof(DynamicDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class DynamicApplicationContractsModule : AbpModule
    {

    }
}
