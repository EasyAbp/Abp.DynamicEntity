using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Abp.Dynamic.FieldDefinitions
{
    public class FieldDefinition : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        [NotNull]
        public virtual string Name { get; protected set; }

        [NotNull]
        public virtual string Type { get; protected set; }

        protected FieldDefinition()
        {
        }

        public FieldDefinition(
            Guid id, 
            Guid? tenantId, 
            string name, 
            string type 
        ) : base(id)
        {
            TenantId = tenantId;
            Name = name;
            Type = type;
        }
    }
}
