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
    [DependsOn(typeof(DynamicQueryDomainSharedModule))]
    public class DynamicEntityDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<DynamicEntityDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<DynamicEntityResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/DynamicEntity");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("DynamicEntity", typeof(DynamicEntityResource));
            });
        }
    }
}
