using System;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions.Dtos;
using EasyAbp.Abp.DynamicEntity.Web.Pages.DynamicEntity.FieldDefinition.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.Abp.DynamicEntity.Web.Pages.DynamicEntity.FieldDefinition
{
    public class EditModalModel : DynamicEntityPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditFieldDefinitionViewModel ViewModel { get; set; }

        private readonly IFieldDefinitionAppService _service;

        public EditModalModel(IFieldDefinitionAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<FieldDefinitionDto, CreateEditFieldDefinitionViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditFieldDefinitionViewModel, CreateUpdateFieldDefinitionDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}