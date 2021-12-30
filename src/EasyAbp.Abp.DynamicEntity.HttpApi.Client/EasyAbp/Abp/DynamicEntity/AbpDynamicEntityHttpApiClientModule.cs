using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.Abp.DynamicEntity
{
    [DependsOn(
        typeof(AbpDynamicEntityApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class AbpDynamicEntityHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = AbpDynamicEntityRemoteServiceConsts.RemoteServiceName;

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AbpDynamicEntityApplicationContractsModule).Assembly,
                RemoteServiceName
            );
            
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpDynamicEntityApplicationContractsModule>();
            });
        }
    }
}
