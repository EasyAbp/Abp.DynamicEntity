using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Abp.Dynamic.Fields
{
    public class FieldDefinition : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        public string Name { get; protected set; }

        public string Type { get; protected set; }

        public int Order { get; protected set; }

        protected FieldDefinition()
        {
        }

        public FieldDefinition(
            Guid id, 
            Guid? tenantId, 
            string name, 
            string type, 
            int order
        ) : base(id)
        {
            TenantId = tenantId;
            Name = name;
            Type = type;
            Order = order;
        }
    }
}
