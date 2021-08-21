using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicEntity
{
    [DependsOn(
        typeof(AbpDynamicEntityHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class DynamicEntityConsoleApiClientModule : AbpModule
    {
        
    }
}
