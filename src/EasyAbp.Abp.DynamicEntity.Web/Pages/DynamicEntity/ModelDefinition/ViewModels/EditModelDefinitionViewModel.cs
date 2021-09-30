using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.Abp.DynamicEntity.Web.Pages.DynamicEntity.ModelDefinition.ViewModels
{
    public class EditModelDefinitionViewModel
    {
        [Required]
        [Display(Name = "ModelDefinitionDisplayName")]
        public string DisplayName { get; set; }
        
        public List<SelectListItem> Fields { get; set; } = new();

        [SelectItems(nameof(Fields))]
        [Display(Name = "FieldDefinition")]
        public List<Guid> FieldIds { get; set; } = new();
        
        public EditPermissionSetViewModel PermissionSet { get; set; } = new();
    }
}