using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicEntity
{
    [DependsOn(
        typeof(AbpDynamicEntityApplicationModule),
        typeof(DynamicEntityDomainTestModule)
        )]
    public class DynamicEntityApplicationTestModule : AbpModule
    {

    }
}
