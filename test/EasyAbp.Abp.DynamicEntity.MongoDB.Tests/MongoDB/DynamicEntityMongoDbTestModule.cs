using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicEntity.MongoDB
{
    [DependsOn(
        typeof(DynamicEntityTestBaseModule),
        typeof(DynamicEntityMongoDbModule)
        )]
    public class DynamicEntityMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var connectionString = MongoDbFixture.ConnectionString.EnsureEndsWith('/') +
                                   "Db_" +
                                    Guid.NewGuid().ToString("N");

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });
        }
    }
}