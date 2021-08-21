using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using EasyAbp.Abp.DynamicEntity.Localization;
using EasyAbp.Abp.DynamicEntity.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using EasyAbp.Abp.DynamicEntity.Permissions;
using EasyAbp.Abp.DynamicEntity.Web.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;

namespace EasyAbp.Abp.DynamicEntity.Web
{
    [DependsOn(
        typeof(AbpDynamicEntityHttpApiModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpAutoMapperModule)
        )]
    public class AbpDynamicEntityWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(DynamicEntityResource), typeof(AbpDynamicEntityWebModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpDynamicEntityWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new DynamicEntityMenuContributor());
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpDynamicEntityWebModule>();
            });

            context.Services.AddAutoMapperObjectMapper<AbpDynamicEntityWebModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpDynamicEntityWebModule>(validate: true);
            });

            Configure<RazorPagesOptions>(options =>
            {
                //Configure authorization.
            });
            
            
            Configure<AbpBundlingOptions>(options =>
            {
                options
                    .ScriptBundles
                    .Add(DynamicEntityBundles.Scripts.DynamicEntity, bundleOptions => bundleOptions.AddContributors(typeof(DynamicEntityScriptContributor)));
            });
        }
    }
}
