using System;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities
{
    public class DynamicEntity : FullAuditedAggregateRoot<Guid>, IMultiTenant, IDynamicEntityModel
    {
        public virtual Guid? TenantId { get; protected set; }
        
        public virtual Guid? ModelDefinitionId { get; protected set; }
        
        public virtual ModelDefinition ModelDefinition { get; protected set; }
        
        protected DynamicEntity()
        {
        }

        public DynamicEntity(
            Guid id,
            Guid? tenantId,
            Guid? modelDefinitionId
        ) : base(id)
        {
            TenantId = tenantId;
            ModelDefinitionId = modelDefinitionId;
        }

        public void SetModelDefinition(Guid? modelDefinitionId)
        {
            ModelDefinitionId = modelDefinitionId;
        }
    }
}
