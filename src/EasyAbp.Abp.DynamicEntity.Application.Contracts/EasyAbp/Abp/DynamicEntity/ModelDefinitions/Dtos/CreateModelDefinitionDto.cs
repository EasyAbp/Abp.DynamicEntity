using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions.Dtos
{
    [Serializable]
    public class CreateModelDefinitionDto : UpdateModelDefinitionDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Type { get; set; }
        
        public bool TryCreateDynamicPermissions { get; set; }
    }
}