using DynamicEntitySample.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace DynamicEntitySample.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(DynamicEntitySampleEntityFrameworkCoreModule),
        typeof(DynamicEntitySampleApplicationContractsModule)
        )]
    public class DynamicEntitySampleDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
