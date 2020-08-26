using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Abp.Dynamic.Fields
{
    public class FieldDefinition : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Order { get; set; }
    }
}