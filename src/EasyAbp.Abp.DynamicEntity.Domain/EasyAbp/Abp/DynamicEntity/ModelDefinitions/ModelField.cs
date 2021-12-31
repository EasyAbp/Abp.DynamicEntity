using System;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;
using Volo.Abp.Domain.Entities.Auditing;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions
{
    public class ModelField : CreationAuditedEntity
    {
        public virtual Guid ModelDefinitionId { get; protected set; }
        public virtual Guid FieldDefinitionId { get; protected set; }
        public virtual FieldDefinition FieldDefinition { get; protected set; }

        public virtual int Order { get; protected set; }

        protected ModelField()
        {
        }

        public ModelField(Guid modelDefinitionId, FieldDefinition fieldDefinition, int order)
        {
            ModelDefinitionId = modelDefinitionId;
            FieldDefinitionId = fieldDefinition.Id;
            FieldDefinition = fieldDefinition;
            Order = order;
        }

        public override object[] GetKeys()
        {
            return new object[] { ModelDefinitionId, FieldDefinitionId };
        }
    }
}