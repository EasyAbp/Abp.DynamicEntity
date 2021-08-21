using EasyAbp.Abp.DynamicEntity.DynamicEntities;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using EasyAbp.Abp.DynamicQuery;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicEntity
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpDddDomainModule),
        typeof(AbpDynamicEntityDomainSharedModule)
    )]
    [DependsOn(typeof(AbpDynamicQueryDomainModule))]
    public class AbpDynamicEntityDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpDynamicEntityDomainModule>();
            
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpDynamicEntityDomainModule>(validate: true);
            });
            
            Configure<AbpDistributedEntityEventOptions>(options =>
            {
                options.AutoEventSelectors.Add<ModelDefinition>();
                options.AutoEventSelectors.Add<FieldDefinition>();
                options.AutoEventSelectors.Add<DynamicEntities.DynamicEntity>();
                
                options.EtoMappings.Add<ModelDefinition, ModelDefinitionEto>();
                options.EtoMappings.Add<FieldDefinition, FieldDefinitionEto>();
                options.EtoMappings.Add<DynamicEntities.DynamicEntity, DynamicEntityEto>();
            });
        }
    }
}
