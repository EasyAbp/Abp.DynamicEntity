using System;
using JetBrains.Annotations;
using Volo.Abp;
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
        public virtual string DisplayName { get; protected set; }
        
        [NotNull]
        public virtual string Type { get; protected set; }

        protected FieldDefinition()
        {
        }

        public FieldDefinition(
            Guid id, 
            [NotNull] string name, 
            [NotNull] string displayName, 
            [NotNull] string type, 
            Guid? tenantId = null 
        ) : base(id)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(Name), FieldDefinitionConsts.MaxNameLength);
            DisplayName = Check.NotNullOrWhiteSpace(displayName, nameof(displayName), FieldDefinitionConsts.MaxDisplayNameLength);
            Type = Check.NotNullOrWhiteSpace(type, nameof(Type), FieldDefinitionConsts.MaxTypeLength);;
            TenantId = tenantId;
            NormalizeName();
        }

        private void NormalizeName()
        {
            Name = Name.ToLower();
        }
    }
}
