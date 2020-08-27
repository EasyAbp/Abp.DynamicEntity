using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions
{
    public class ModelField : CreationAuditedEntity
    {
        public virtual Guid ModelDefinitionId { get; protected set; }

        public virtual Guid FieldDefinitionId { get; protected set; }

        public virtual int Order { get; protected set; }
        

        public override object[] GetKeys()
        {
            return new object[] { ModelDefinitionId, FieldDefinitionId };
        }
    }
}