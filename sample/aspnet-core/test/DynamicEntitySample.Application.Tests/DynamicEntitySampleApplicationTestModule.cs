using Volo.Abp.Modularity;

namespace DynamicEntitySample
{
    [DependsOn(
        typeof(DynamicEntitySampleApplicationModule),
        typeof(DynamicEntitySampleDomainTestModule)
        )]
    public class DynamicEntitySampleApplicationTestModule : AbpModule
    {

    }
}