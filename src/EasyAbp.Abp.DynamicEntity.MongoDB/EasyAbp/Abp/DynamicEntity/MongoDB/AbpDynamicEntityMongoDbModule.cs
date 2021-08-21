using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace EasyAbp.Abp.DynamicEntity.MongoDB
{
    [DependsOn(
        typeof(AbpDynamicEntityDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class AbpDynamicEntityMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<DynamicEntityMongoDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
            });
        }
    }
}
