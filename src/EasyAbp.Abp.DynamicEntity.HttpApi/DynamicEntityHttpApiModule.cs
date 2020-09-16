using Localization.Resources.AbpUi;
using EasyAbp.Abp.DynamicEntity.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace EasyAbp.Abp.DynamicEntity
{
    [DependsOn(
        typeof(DynamicEntityApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class DynamicEntityHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(DynamicEntityHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<DynamicEntityResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
