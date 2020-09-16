using System.ComponentModel.DataAnnotations;

namespace EasyAbp.Abp.Dynamic.DynamicEntities.Dtos
{
    public class Filter
    {
        [Required]
        public string FieldName { get; set; }
        
        [Required]
        public Operator Operator { get; set; }
        
        [Required]
        public string Value { get; set; }
    }
}