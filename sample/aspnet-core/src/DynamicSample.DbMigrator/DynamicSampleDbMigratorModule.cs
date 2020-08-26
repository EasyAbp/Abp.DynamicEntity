using DynamicSample.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace DynamicSample.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(DynamicSampleEntityFrameworkCoreDbMigrationsModule),
        typeof(DynamicSampleApplicationContractsModule)
        )]
    public class DynamicSampleDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
