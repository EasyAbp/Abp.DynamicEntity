using DynamicEntitySample.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DynamicEntitySample
{
    [DependsOn(
        typeof(DynamicEntitySampleEntityFrameworkCoreTestModule)
        )]
    public class DynamicEntitySampleDomainTestModule : AbpModule
    {

    }
}