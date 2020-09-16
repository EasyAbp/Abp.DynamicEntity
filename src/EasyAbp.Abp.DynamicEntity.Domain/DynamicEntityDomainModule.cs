using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicEntity
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(DynamicEntityDomainSharedModule)
    )]
    public class DynamicEntityDomainModule : AbpModule
    {

    }
}
