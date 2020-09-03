using System;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos
{
    [Serializable]
    public class CreateUpdateFieldDefinitionDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]

        public string DisplayName { get; set; }

        [Required]
        public string Type { get; set; }
    }
}