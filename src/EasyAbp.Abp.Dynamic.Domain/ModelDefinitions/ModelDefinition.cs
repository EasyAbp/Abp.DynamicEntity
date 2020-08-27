using System;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions
{
    public class ModelDefinition : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }
        
        [NotNull]
        public virtual string Name { get; protected set; }
        
        [NotNull]
        public virtual string Type { get; protected set; }
        
        public virtual Collection<ModelField> Fields { get; protected set; }

        protected ModelDefinition()
        {
        }

        public ModelDefinition(
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
