using System;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions
{
    public class ModelDefinition : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string Type { get; protected set; }
        public virtual Collection<ModelField> Fields { get; protected set; }
    }
}