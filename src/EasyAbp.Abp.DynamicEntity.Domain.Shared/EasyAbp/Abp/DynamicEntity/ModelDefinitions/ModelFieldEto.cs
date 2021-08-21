using System;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions
{
    [Serializable]
    public class ModelFieldEto
    {
        public Guid FieldDefinitionId { get; set; }
        
        public FieldDefinitionEto FieldDefinition { get; set; }

        public int Order { get; set; }
    }
}