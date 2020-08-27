using System;
using EasyAbp.Abp.Dynamic.ModelDefinitions;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Abp.Dynamic.DynamicEntities
{
    public class DynamicEntity : FullAuditedAggregateRoot<Guid>, IMultiTenant, IDynamicModel
    {
        public virtual Guid? TenantId { get; protected set; }
        public virtual Guid? ModelDefinitionId { get; protected set; }
        public virtual ModelDefinition ModelDefinition { get; protected set; }

        protected DynamicEntity()
        {
        }

        public DynamicEntity(
            Guid id, 
            Guid? tenantId = null 
        ) : base(id)
        {
            TenantId = tenantId;
        }

        public DynamicEntity SetModelDefinition(Guid? modelDefinitionId)
        {
            ModelDefinitionId = modelDefinitionId;
            return this;
        }
    }
}
