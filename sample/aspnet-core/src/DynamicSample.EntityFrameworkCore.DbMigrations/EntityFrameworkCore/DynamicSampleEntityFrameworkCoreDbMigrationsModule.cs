using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace DynamicSample.EntityFrameworkCore
{
    [DependsOn(
        typeof(DynamicSampleEntityFrameworkCoreModule)
        )]
    public class DynamicSampleEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DynamicSampleMigrationsDbContext>();
        }
    }
}
