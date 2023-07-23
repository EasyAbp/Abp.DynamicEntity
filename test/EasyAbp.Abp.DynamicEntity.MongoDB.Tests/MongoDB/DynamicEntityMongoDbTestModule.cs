using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicEntity.MongoDB
{
    [DependsOn(
        typeof(DynamicEntityTestBaseModule),
        typeof(AbpDynamicEntityMongoDbModule)
        )]
    public class DynamicEntityMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = MongoDbFixture.GetRandomConnectionString();
            });
        }
    }
}