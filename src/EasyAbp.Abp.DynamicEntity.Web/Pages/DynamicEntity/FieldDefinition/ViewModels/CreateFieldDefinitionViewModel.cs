using System.ComponentModel.DataAnnotations;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;

namespace EasyAbp.Abp.DynamicEntity.Web.Pages.DynamicEntity.FieldDefinition.ViewModels
{
    public class CreateFieldDefinitionViewModel
    {
        [Display(Name = "FieldDefinitionName")]
        public string Name { get; set; }

        [Display(Name = "FieldDefinitionDisplayName")]
        public string DisplayName { get; set; }

        [Display(Name = "FieldDefinitionType")]
        public FieldDataType Type { get; set; }
    }
}