using System;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Validation;

namespace EasyAbp.Abp.DynamicEntity.FieldDefinitions
{
    public class FieldDefinition : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; protected set; }

        [NotNull]
        public virtual string DisplayName { get; protected set; }
        
        [NotNull]
        public virtual FieldDataType Type { get; protected set; }

        protected FieldDefinition()
        {
        }

        public FieldDefinition(
            Guid id,
            [NotNull] string name,
            [NotNull] string displayName,
            FieldDataType type 
        ) : base(id)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(Name), FieldDefinitionConsts.MaxNameLength);
            DisplayName = Check.NotNullOrWhiteSpace(displayName, nameof(displayName), FieldDefinitionConsts.MaxDisplayNameLength);
            Type = type;
            
            CheckName();
        }

        private void CheckName()
        {
            if (!Regex.IsMatch(Name, @"^[a-zA-Z_]\w*(\.[a-zA-Z_]\w*)*$"))
            {
                throw new AbpValidationException("Invalid field name.");
            }
        }
    }
}
