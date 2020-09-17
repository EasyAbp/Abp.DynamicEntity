using EasyAbp.Abp.DynamicEntity.DynamicEntities;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using EasyAbp.Abp.DynamicQuery;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicEntity.EntityFrameworkCore
{
    [DependsOn(
        typeof(DynamicEntityDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    [DependsOn(typeof(DynamicQueryEntityFrameworkCoreModule))]

    public class DynamicEntityEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DynamicEntityDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<FieldDefinition, FieldDefinitionRepository>();
                options.AddRepository<ModelDefinition, ModelDefinitionRepository>();
                options.AddRepository<DynamicEntities.DynamicEntity, DynamicEntityRepository>();
            });
        }
    }
}
