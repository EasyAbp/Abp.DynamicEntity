using System;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using Volo.Abp.Domain.Entities.Auditing;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions
{
    public class ModelField : CreationAuditedEntity
    {
        public virtual Guid ModelDefinitionId { get; protected set; }
        public virtual ModelDefinition ModelDefinition { get; protected set; }

        public virtual Guid FieldDefinitionId { get; protected set; }
        public virtual FieldDefinition FieldDefinition { get; protected set; }

        public virtual int Order { get; protected set; }

        protected ModelField()
        {
        }

        public ModelField(Guid modelDefinitionId, Guid fieldDefinitionId, int order)
        {
            ModelDefinitionId = modelDefinitionId;
            FieldDefinitionId = fieldDefinitionId;
            Order = order;
        }

        public override object[] GetKeys()
        {
            return new object[] { ModelDefinitionId, FieldDefinitionId };
        }
    }
}