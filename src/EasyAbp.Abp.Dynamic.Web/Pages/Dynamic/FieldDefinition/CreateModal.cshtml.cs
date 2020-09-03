using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos;
using EasyAbp.Abp.Dynamic.Web.Pages.Dynamic.FieldDefinition.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.Abp.Dynamic.Web.Pages.Dynamic.FieldDefinition
{
    public class CreateModalModel : DynamicPageModel
    {
        [BindProperty]
        public CreateEditFieldDefinitionViewModel ViewModel { get; set; }

        private readonly IFieldDefinitionAppService _service;

        public CreateModalModel(IFieldDefinitionAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditFieldDefinitionViewModel, CreateUpdateFieldDefinitionDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}