using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.Dynamic
{
    [DependsOn(
        typeof(DynamicHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class DynamicConsoleApiClientModule : AbpModule
    {
        
    }
}
