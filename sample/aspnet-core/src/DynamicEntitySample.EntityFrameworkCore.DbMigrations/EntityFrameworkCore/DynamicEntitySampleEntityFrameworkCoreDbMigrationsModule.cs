using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace DynamicEntitySample.EntityFrameworkCore
{
    [DependsOn(
        typeof(DynamicEntitySampleEntityFrameworkCoreModule)
        )]
    public class DynamicEntitySampleEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DynamicEntitySampleMigrationsDbContext>();
        }
    }
}
