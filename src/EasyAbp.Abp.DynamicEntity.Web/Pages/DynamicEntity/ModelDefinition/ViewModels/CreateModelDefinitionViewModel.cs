﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.Abp.DynamicEntity.Web.Pages.DynamicEntity.ModelDefinition.ViewModels
{
    public class CreateModelDefinitionViewModel
    {
        [Required]
        [Display(Name = "ModelDefinitionName")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "ModelDefinitionDisplayName")]
        public string DisplayName { get; set; }

        [Required]
        [Display(Name = "ModelDefinitionType")]
        public string Type { get; set; }
        
        public List<SelectListItem> Fields { get; set; } = new();

        [SelectItems(nameof(Fields))]
        [Display(Name = "FieldDefinition")]
        public List<Guid> FieldIds { get; set; } = new();
        
        public CreatePermissionSetViewModel PermissionSet { get; set; } = new();
        
        [Display(
            Name = "TryCreateDynamicPermissions",
            Description = "TryCreateDynamicPermissionsDesc"
        )]
        public bool TryCreateDynamicPermissions { get; set; }
    }
}