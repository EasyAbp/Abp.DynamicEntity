using EasyAbp.Abp.DynamicQuery;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace EasyAbp.Abp.DynamicEntity
{
    [DependsOn(
        typeof(AbpDynamicEntityDomainModule),
        typeof(AbpDynamicEntityApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    [DependsOn(typeof(AbpDynamicQueryApplicationModule))]
    public class AbpDynamicEntityApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpDynamicEntityApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpDynamicEntityApplicationModule>(validate: true);
            });
        }
    }
}
