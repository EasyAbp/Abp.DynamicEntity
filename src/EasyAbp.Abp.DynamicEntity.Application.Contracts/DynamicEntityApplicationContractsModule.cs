using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace EasyAbp.Abp.DynamicEntity
{
    [DependsOn(
        typeof(DynamicEntityDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class DynamicEntityApplicationContractsModule : AbpModule
    {

    }
}
