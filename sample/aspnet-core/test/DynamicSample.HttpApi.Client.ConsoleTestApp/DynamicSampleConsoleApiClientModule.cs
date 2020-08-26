using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace DynamicSample.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(DynamicSampleHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class DynamicSampleConsoleApiClientModule : AbpModule
    {
        
    }
}
