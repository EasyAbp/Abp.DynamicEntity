using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions.Dtos
{
    [Serializable]
    public class UpdateModelDefinitionDto
    {
        [Required]
        public string DisplayName { get; set; }
        
        [Required]
        public List<Guid> FieldIds { get; set; } = new();
        
        public PermissionSetDto PermissionSet { get; set; } = new();
    }
}