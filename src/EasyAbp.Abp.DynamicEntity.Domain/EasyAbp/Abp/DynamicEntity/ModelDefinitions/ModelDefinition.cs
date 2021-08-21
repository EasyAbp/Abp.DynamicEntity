using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions
{
    public class ModelDefinition : FullAuditedAggregateRoot<Guid>
    {
        [NotNull] 
        public virtual string Name { get; protected set; }
        
        [NotNull]
        public virtual string DisplayName { get; protected set; }

        [NotNull]
        public virtual string Type { get; protected set; }

        public virtual List<ModelField> Fields { get; protected set; } = new();

        protected ModelDefinition()
        {
        }

        public ModelDefinition(
            Guid id,
            [NotNull] string name,
            [NotNull] string displayName,
            [NotNull] string type
        ) : base(id)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(Name), ModelDefinitionConsts.MaxNameLength);
            DisplayName = Check.NotNullOrWhiteSpace(displayName, nameof(displayName), ModelDefinitionConsts.MaxDisplayNameLength);
            Type = Check.NotNullOrWhiteSpace(type, nameof(Type), ModelDefinitionConsts.MaxTypeLength);;
            NormalizeName();
        }

        private void NormalizeName()
        {
            Name = Name.ToLower();
        }

        public virtual void AddField(Guid fieldDefinitionId, int order = Int32.MaxValue)
        {
            Fields.Add(new ModelField(Id, fieldDefinitionId, order));
        }

        public virtual void RemoveField(Guid fieldDefinitionId)
        {
            Fields.RemoveAll(f => f.FieldDefinitionId == fieldDefinitionId);
        }
    }
}