using System;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntityEntities
{
    public class DynamicEntityEntity : FullAuditedAggregateRoot<Guid>, IMultiTenant, IDynamicEntityModel
    {
        public virtual Guid? TenantId { get; protected set; }
        public virtual Guid? ModelDefinitionId { get; protected set; }
        public virtual ModelDefinition ModelDefinition { get; protected set; }

        protected DynamicEntityEntity()
        {
        }

        public DynamicEntityEntity(
            Guid id, 
            Guid? tenantId = null 
        ) : base(id)
        {
            TenantId = tenantId;
        }

        public DynamicEntityEntity SetModelDefinition(Guid? modelDefinitionId)
        {
            ModelDefinitionId = modelDefinitionId;
            return this;
        }
    }
}
