using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions
{
    [Serializable]
    public class ModelDefinitionEto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string DisplayName { get; set; }

        public string Type { get; set; }

        public List<ModelFieldEto> Fields { get; set; } = new();
    }
}