using EasyAbp.Abp.DynamicQuery;
using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace EasyAbp.Abp.DynamicEntity
{
    [DependsOn(
        typeof(AbpDynamicEntityDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    [DependsOn(typeof(AbpDynamicQueryApplicationContractsModule))]
    public class AbpDynamicEntityApplicationContractsModule : AbpModule
    {
    }
}
