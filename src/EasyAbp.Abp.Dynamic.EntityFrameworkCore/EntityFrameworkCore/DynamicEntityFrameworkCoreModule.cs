using EasyAbp.Abp.Dynamic.FieldDefinitions;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.Dynamic.EntityFrameworkCore
{
    [DependsOn(
        typeof(DynamicDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class DynamicEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DynamicDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<FieldDefinition, FieldDefinitionRepository>();
            });
        }
    }
}
