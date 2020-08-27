using System;
using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.Abp.Dynamic.Web.Pages.Dynamic.Fields.FieldDefinition.ViewModels;

namespace EasyAbp.Abp.Dynamic.Web.Pages.Dynamic.Fields.FieldDefinition
{
    public class EditModalModel : DynamicPageModel
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