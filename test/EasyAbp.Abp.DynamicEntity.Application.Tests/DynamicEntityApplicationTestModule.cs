using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicEntity
{
    [DependsOn(
        typeof(DynamicEntityApplicationModule),
        typeof(DynamicEntityDomainTestModule)
        )]
    public class DynamicEntityApplicationTestModule : AbpModule
    {

    }
}
