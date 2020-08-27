using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.Abp.Dynamic.Fields;
using EasyAbp.Abp.Dynamic.Web.Pages.Dynamic.Fields.FieldDefinition.ViewModels;

namespace EasyAbp.Abp.Dynamic.Web.Pages.Dynamic.Fields.FieldDefinition
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