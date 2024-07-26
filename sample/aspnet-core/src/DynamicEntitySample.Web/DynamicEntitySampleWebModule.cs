using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DynamicEntitySample.EntityFrameworkCore;
using DynamicEntitySample.Localization;
using DynamicEntitySample.MultiTenancy;
using DynamicEntitySample.Web.Menus;
using EasyAbp.Abp.DynamicEntity;
using EasyAbp.Abp.DynamicEntity.Web;
using EasyAbp.Abp.DynamicPermission.Web;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Data;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity.Web;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.Web;
using Volo.Abp.SettingManagement.Web;
using Volo.Abp.Swashbuckle;
using Volo.Abp.TenantManagement.Web;
using Volo.Abp.Threading;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.UI;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace DynamicEntitySample.Web
{
    [DependsOn(
        typeof(DynamicEntitySampleHttpApiModule),
        typeof(DynamicEntitySampleApplicationModule),
        typeof(DynamicEntitySampleEntityFrameworkCoreModule),
        typeof(AbpAutofacModule),
        typeof(AbpIdentityWebModule),
        typeof(AbpSettingManagementWebModule),
        typeof(AbpAccountWebIdentityServerModule),
        typeof(AbpAspNetCoreMvcUiLeptonXLiteThemeModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpTenantManagementWebModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpSwashbuckleModule),
        typeof(AbpDynamicEntityWebModule),
        typeof(AbpDynamicPermissionWebModule)
    )]
    public class DynamicEntitySampleWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(
                    typeof(DynamicEntitySampleResource),
                    typeof(DynamicEntitySampleDomainModule).Assembly,
                    typeof(DynamicEntitySampleDomainSharedModule).Assembly,
                    typeof(DynamicEntitySampleApplicationModule).Assembly,
                    typeof(DynamicEntitySampleApplicationContractsModule).Assembly,
                    typeof(DynamicEntitySampleWebModule).Assembly
                );
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ConfigureUrls(configuration);
            ConfigureBundles();
            ConfigureAuthentication(context, configuration);
            ConfigureAutoMapper();
            ConfigureVirtualFileSystem(hostingEnvironment);
            ConfigureLocalizationServices();
            ConfigureNavigationServices();
            ConfigureAutoApiControllers();
            ConfigureSwaggerServices(context.Services);
        }

        private void ConfigureUrls(IConfiguration configuration)
        {
            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            });
        }

        private void ConfigureBundles()
        {
            Configure<AbpBundlingOptions>(options =>
            {
                options.StyleBundles.Configure(
                    LeptonXLiteThemeBundles.Styles.Global,
                    bundle =>
                    {
                        bundle.AddFiles("/global-styles.css");
                    }
                );
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                    options.Audience = "DynamicEntitySample";
                });
        }

        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<DynamicEntitySampleWebModule>();
            });
        }

        private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    var septChar = Path.DirectorySeparatorChar;
                    var rootPath = hostingEnvironment.ContentRootPath;
                    
                    options.FileSets.ReplaceEmbeddedByPhysical<DynamicEntitySampleDomainSharedModule>(Path.Combine(rootPath, $"..{septChar}DynamicEntitySample.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<DynamicEntitySampleDomainModule>(Path.Combine(rootPath, $"..{septChar}DynamicEntitySample.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<DynamicEntitySampleApplicationContractsModule>(Path.Combine(rootPath, $"..{septChar}DynamicEntitySample.Application.Contracts"));
                    options.FileSets.ReplaceEmbeddedByPhysical<DynamicEntitySampleApplicationModule>(Path.Combine(rootPath, $"..{septChar}DynamicEntitySample.Application"));
                    options.FileSets.ReplaceEmbeddedByPhysical<DynamicEntitySampleWebModule>(rootPath);
                    
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpDynamicEntityDomainSharedModule>(Path.Combine(rootPath, $"..{septChar}..{septChar}..{septChar}..{septChar}src{septChar}EasyAbp.Abp.DynamicEntity.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpDynamicEntityDomainModule>(Path.Combine(rootPath, $"..{septChar}..{septChar}..{septChar}..{septChar}src{septChar}EasyAbp.Abp.DynamicEntity.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpDynamicEntityApplicationContractsModule>(Path.Combine(rootPath, $"..{septChar}..{septChar}..{septChar}..{septChar}src{septChar}EasyAbp.Abp.DynamicEntity.Application.Contracts"));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpDynamicEntityApplicationModule>(Path.Combine(rootPath, $"..{septChar}..{septChar}..{septChar}..{septChar}src{septChar}EasyAbp.Abp.DynamicEntity.Application"));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpDynamicEntityWebModule>(Path.Combine(rootPath, $"..{septChar}..{septChar}..{septChar}..{septChar}src{septChar}EasyAbp.Abp.DynamicEntity.Web"));
                });
            }
        }

        private void ConfigureLocalizationServices()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
                options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
                options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
                options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
                options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
                options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi"));
                options.Languages.Add(new LanguageInfo("it", "it", "Italian"));
                options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
                options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
                options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
                options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
                options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
                options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch"));
                options.Languages.Add(new LanguageInfo("es", "es", "Español"));
            });
        }

        private void ConfigureNavigationServices()
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new DynamicEntitySampleMenuContributor());
            });
        }

        private void ConfigureAutoApiControllers()
        {
            PreConfigure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(DynamicEntitySampleApplicationModule).Assembly);
            });
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddAbpSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "DynamicEntitySample API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                }
            );
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAbpRequestLocalization();

            if (!env.IsDevelopment())
            {
                app.UseErrorPage();
            }

            app.UseCorrelationId();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseJwtTokenMiddleware();

            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }

            app.UseUnitOfWork();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "DynamicEntitySample API");
            });
            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();
            
            using (var scope = context.ServiceProvider.CreateScope())
            {
                AsyncHelper.RunSync(async () =>
                {
                    await scope.ServiceProvider
                        .GetRequiredService<PermissionDataSeedContributor>()
                        .SeedAsync(new DataSeedContext());
                });
            }
        }
    }
}
