using System;
using EasyAbp.Abp.Dynamic.Fields;
using Volo.Abp.Domain.Entities.Auditing;

namespace EasyAbp.Abp.Dynamic.Domain
{
    public class Computer : FullAuditedAggregateRoot<Guid>, IDynamicField
    {
        public Guid FieldDefinitionId { get; }
        public FieldDefinition FieldDefinition { get; }
    }
}