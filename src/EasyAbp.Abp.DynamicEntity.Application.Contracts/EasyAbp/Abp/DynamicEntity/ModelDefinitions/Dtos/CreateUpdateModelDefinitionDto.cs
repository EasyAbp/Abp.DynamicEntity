using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions.Dtos
{
    [Serializable]
    public class CreateUpdateModelDefinitionDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Type { get; set; }
        
        [Required]
        public List<Guid> FieldIds { get; set; } = new List<Guid>();
    }
}