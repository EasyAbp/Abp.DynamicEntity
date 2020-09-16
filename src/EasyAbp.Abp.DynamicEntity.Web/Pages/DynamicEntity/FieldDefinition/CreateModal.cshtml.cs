using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions.Dtos;
using EasyAbp.Abp.DynamicEntity.Web.Pages.DynamicEntity.FieldDefinition.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.Abp.DynamicEntity.Web.Pages.DynamicEntity.FieldDefinition
{
    public class CreateModalModel : DynamicEntityPageModel
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