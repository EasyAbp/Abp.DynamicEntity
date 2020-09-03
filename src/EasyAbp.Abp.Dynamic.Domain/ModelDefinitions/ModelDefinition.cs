using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions
{
    public class ModelDefinition : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        [NotNull] public virtual string Name { get; protected set; }

        [NotNull] public virtual string Type { get; protected set; }

        public virtual Collection<ModelField> Fields { get; protected set; } = new Collection<ModelField>();

        protected ModelDefinition()
        {
        }

        public ModelDefinition(
            Guid id,
            [NotNull] string name,
            [NotNull] string type,
            Guid? tenantId = null
        ) : base(id)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(Name), ModelDefinitionConsts.MaxNameLength);
            Type = Check.NotNullOrWhiteSpace(type, nameof(Type), ModelDefinitionConsts.MaxTypeLength);;
            TenantId = tenantId;
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