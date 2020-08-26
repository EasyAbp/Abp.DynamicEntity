using Volo.Abp.Modularity;

namespace EasyAbp.Abp.Dynamic
{
    [DependsOn(
        typeof(DynamicDomainSharedModule)
        )]
    public class DynamicDomainModule : AbpModule
    {

    }
}
