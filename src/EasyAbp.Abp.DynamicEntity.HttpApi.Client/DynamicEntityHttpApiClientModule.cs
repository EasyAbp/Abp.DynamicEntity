using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicEntity
{
    [DependsOn(
        typeof(DynamicEntityApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class DynamicEntityHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "DynamicEntity";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(DynamicEntityApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
