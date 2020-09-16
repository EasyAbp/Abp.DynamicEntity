using System.ComponentModel.DataAnnotations;

namespace EasyAbp.Abp.DynamicEntity.Web.Pages.DynamicEntity.FieldDefinition.ViewModels
{
    public class CreateEditFieldDefinitionViewModel
    {
        [Display(Name = "FieldDefinitionName")]
        public string Name { get; set; }

        [Display(Name = "FieldDefinitionDisplayName")]
        public string DisplayName { get; set; }

        [Display(Name = "FieldDefinitionType")]
        public string Type { get; set; }
    }
}