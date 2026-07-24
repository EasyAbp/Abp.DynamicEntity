using EasyAbp.Abp.DynamicPermission;
using EasyAbp.Abp.DynamicQuery;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Mapperly;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace EasyAbp.Abp.DynamicEntity
{
    [DependsOn(
        typeof(AbpDynamicEntityDomainModule),
        typeof(AbpDynamicEntityApplicationContractsModule),
        typeof(AbpDynamicPermissionApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpMapperlyModule)
        )]
    [DependsOn(typeof(AbpDynamicQueryApplicationModule))]
    public class AbpDynamicEntityApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMapperlyObjectMapper<AbpDynamicEntityApplicationModule>();
        }
    }
}
