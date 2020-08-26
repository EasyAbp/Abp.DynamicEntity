using Localization.Resources.AbpUi;
using EasyAbp.Abp.Dynamic.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace EasyAbp.Abp.Dynamic
{
    [DependsOn(
        typeof(DynamicApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class DynamicHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(DynamicHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<DynamicResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
