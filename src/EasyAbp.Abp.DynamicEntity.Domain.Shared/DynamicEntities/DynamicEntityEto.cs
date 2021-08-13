using System;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities
{
    [Serializable]
    public class DynamicEntityEto : IMultiTenant
    {
        public Guid Id { get; set; }

        public Guid? TenantId { get; set; }
        
        public Guid? ModelDefinitionId { get; set; }
        
        public ModelDefinitionEto ModelDefinition { get; set; }
    }
}