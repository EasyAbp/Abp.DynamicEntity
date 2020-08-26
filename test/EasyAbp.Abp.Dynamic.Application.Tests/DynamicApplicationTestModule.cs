using Volo.Abp.Modularity;

namespace EasyAbp.Abp.Dynamic
{
    [DependsOn(
        typeof(DynamicApplicationModule),
        typeof(DynamicDomainTestModule)
        )]
    public class DynamicApplicationTestModule : AbpModule
    {

    }
}
