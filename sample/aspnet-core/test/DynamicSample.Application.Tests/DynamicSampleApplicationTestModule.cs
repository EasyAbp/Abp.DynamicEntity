using Volo.Abp.Modularity;

namespace DynamicSample
{
    [DependsOn(
        typeof(DynamicSampleApplicationModule),
        typeof(DynamicSampleDomainTestModule)
        )]
    public class DynamicSampleApplicationTestModule : AbpModule
    {

    }
}