
using System;
using EasyAbp.Abp.Dynamic.Fields;
using Volo.Abp.Domain.Entities.Auditing;

namespace DynamicSample.Computers
{
    public class Computer : FullAuditedAggregateRoot<Guid>, IDynamicField
    {
        public Guid FieldDefinitionId { get; }
        public virtual FieldDefinition FieldDefinition { get; }

        protected Computer()
        {
        }

        public Computer(
            Guid id, 
            Guid fieldDefinitionId 
        ) : base(id)
        {
            FieldDefinitionId = fieldDefinitionId;
        }
    }
}
