using System;
using System.IO;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DynamicSample.EntityFrameworkCore;
using DynamicSample.Localization;
using DynamicSample.MultiTenancy;
using DynamicSample.Web.Menus;
using EasyAbp.Abp.Dynamic;
using EasyAbp.Abp.Dynamic.Web;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity.Web;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.Web;
using Volo.Abp.TenantManagement.Web;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.UI;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace DynamicSample.Web
{
    [DependsOn(
        typeof(DynamicSampleHttpApiModule),
        typeof(DynamicSampleApplicationModule),
        typeof(DynamicSampleEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAutofacModule),
        typeof(AbpIdentityWebModule),
        typeof(AbpAccountWebIdentityServerModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpTenantManagementWebModule),
        typeof(AbpAspNetCoreSerilogModule)
    )]
    [DependsOn(typeof(DynamicWebModule))]
    public class DynamicSampleWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(
                    typeof(DynamicSampleResource),
                    typeof(DynamicSampleDomainModule).Assembly,
                    typeof(DynamicSampleDomainSharedModule).Assembly,
                    typeof(DynamicSampleApplicationModule).Assembly,
                    typeof(DynamicSampleApplicationContractsModule).Assembly,
                    typeof(DynamicSampleWebModule).Assembly
                );
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ConfigureUrls(configuration);
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
            Configure<AppUrlOptions>(options => { options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"]; });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication()
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "DynamicSample";
                });
        }

        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options => { options.AddMaps<DynamicSampleWebModule>(); });
        }

        private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    var septChar = Path.DirectorySeparatorChar;
                    var rootPath = hostingEnvironment.ContentRootPath;
                    options.FileSets.ReplaceEmbeddedByPhysical<DynamicSampleDomainSharedModule>(Path.Combine(rootPath, $"..{septChar}DynamicSample.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<DynamicSampleDomainModule>(Path.Combine(rootPath, $"..{septChar}DynamicSample.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<DynamicSampleApplicationContractsModule>(Path.Combine(rootPath, $"..{septChar}DynamicSample.Application.Contracts"));
                    options.FileSets.ReplaceEmbeddedByPhysical<DynamicSampleApplicationModule>(Path.Combine(rootPath, $"..{septChar}DynamicSample.Application"));
                    options.FileSets.ReplaceEmbeddedByPhysical<DynamicSampleWebModule>(rootPath);

                    options.FileSets.ReplaceEmbeddedByPhysical<DynamicDomainSharedModule>(Path.Combine(rootPath, $"..{septChar}..{septChar}src{septChar}DynamicSample.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<DynamicDomainModule>(Path.Combine(rootPath, $"..{septChar}..{septChar}src{septChar}DynamicSample.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<DynamicApplicationContractsModule>(Path.Combine(rootPath, $"..{septChar}..{septChar}src{septChar}DynamicSample.Application.Contracts"));
                    options.FileSets.ReplaceEmbeddedByPhysical<DynamicApplicationModule>(Path.Combine(rootPath, $"..{septChar}..{septChar}src{septChar}DynamicSample.Application"));
                    options.FileSets.ReplaceEmbeddedByPhysical<DynamicWebModule>(Path.Combine(rootPath, $"..{septChar}..{septChar}src{septChar}DynamicSample.Web"));
                });
            }
        }

        private void ConfigureLocalizationServices()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<DynamicSampleResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );

                options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
                options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
                options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
                options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
                options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            });
        }

        private void ConfigureNavigationServices()
        {
            Configure<AbpNavigationOptions>(options => { options.MenuContributors.Add(new DynamicSampleMenuContributor()); });
        }

        private void ConfigureAutoApiControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options => { options.ConventionalControllers.Create(typeof(DynamicSampleApplicationModule).Assembly); });
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo {Title = "DynamicSample API", Version = "v1"});
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
            else
            {
                app.UseErrorPage();
            }

            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseJwtTokenMiddleware();

            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }

            app.UseAbpRequestLocalization();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "DynamicSample API"); });
            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();
        }
    }
}