using EasyAbp.Abp.DynamicQuery;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicEntity
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(DynamicEntityDomainSharedModule)
    )]
    [DependsOn(typeof(DynamicQueryDomainModule))]
    public class DynamicEntityDomainModule : AbpModule
    {

    }
}
