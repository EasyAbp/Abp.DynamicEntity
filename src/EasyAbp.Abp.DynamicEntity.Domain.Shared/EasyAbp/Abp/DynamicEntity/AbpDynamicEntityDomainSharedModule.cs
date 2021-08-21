using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using EasyAbp.Abp.DynamicEntity.Localization;
using EasyAbp.Abp.DynamicQuery;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.Abp.DynamicEntity
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    [DependsOn(typeof(AbpDynamicQueryDomainSharedModule))]
    public class AbpDynamicEntityDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpDynamicEntityDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<DynamicEntityResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("EasyAbp/Abp/DynamicEntity/Localization");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("EasyAbp.Abp.DynamicEntity", typeof(DynamicEntityResource));
            });
        }
    }
}
