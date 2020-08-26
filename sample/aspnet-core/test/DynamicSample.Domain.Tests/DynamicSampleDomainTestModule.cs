using DynamicSample.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DynamicSample
{
    [DependsOn(
        typeof(DynamicSampleEntityFrameworkCoreTestModule)
        )]
    public class DynamicSampleDomainTestModule : AbpModule
    {

    }
}