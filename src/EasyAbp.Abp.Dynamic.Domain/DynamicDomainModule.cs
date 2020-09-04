using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.Dynamic
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(DynamicDomainSharedModule)
    )]
    public class DynamicDomainModule : AbpModule
    {

    }
}
