using System;
using Volo.Abp.Data;

namespace EasyAbp.Abp.Dynamic.Fields
{
    public interface IDynamicField : IHasExtraProperties
    {
        public Guid FieldDefinitionId { get; }
        public FieldDefinition FieldDefinition { get; }
    }
}