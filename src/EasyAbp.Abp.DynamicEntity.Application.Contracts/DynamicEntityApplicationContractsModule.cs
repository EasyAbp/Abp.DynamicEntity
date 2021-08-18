using EasyAbp.Abp.DynamicQuery;
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
    [DependsOn(typeof(DynamicQueryApplicationContractsModule))]
    public class DynamicEntityApplicationContractsModule : AbpModule
    {
    }
}
