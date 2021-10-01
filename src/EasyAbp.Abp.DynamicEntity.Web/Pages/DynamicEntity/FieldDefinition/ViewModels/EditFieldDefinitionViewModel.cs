using System.ComponentModel.DataAnnotations;

namespace EasyAbp.Abp.DynamicEntity.Web.Pages.DynamicEntity.FieldDefinition.ViewModels
{
    public class EditFieldDefinitionViewModel
    {
        [Display(Name = "FieldDefinitionDisplayName")]
        public string DisplayName { get; set; }
    }
}