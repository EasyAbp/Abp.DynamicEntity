using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.Dynamic
{
    [DependsOn(
        typeof(DynamicApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class DynamicHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Dynamic";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(DynamicApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
