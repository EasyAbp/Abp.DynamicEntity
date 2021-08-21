using System;

namespace EasyAbp.Abp.DynamicEntity.FieldDefinitions
{
    [Serializable]
    public class FieldDefinitionEto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }
        
        public FieldDataType Type { get; set; }
    }
}