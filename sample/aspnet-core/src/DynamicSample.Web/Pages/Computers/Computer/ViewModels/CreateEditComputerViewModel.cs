using System;

using System.ComponentModel.DataAnnotations;
using EasyAbp.Abp.Dynamic.Fields.Dtos;

namespace DynamicSample.Web.Pages.Computers.Computer.ViewModels
{
    public class CreateEditComputerViewModel
    {
        [Display(Name = "ComputerFieldDefinitionId")]
        public Guid FieldDefinitionId { get; set; }

        [Display(Name = "ComputerFieldDefinition")]
        public FieldDefinitionDto FieldDefinition { get; set; }
    }
}