using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions.Dtos;
using EasyAbp.Abp.DynamicEntity.Web.Pages.DynamicEntity.ModelDefinition.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using GetListInput = EasyAbp.Abp.DynamicEntity.FieldDefinitions.Dtos.GetListInput;

namespace EasyAbp.Abp.DynamicEntity.Web.Pages.DynamicEntity.ModelDefinition
{
    public class CreateModalModel : DynamicEntityPageModel
    {
        [BindProperty]
        public CreateEditModelDefinitionViewModel ViewModel { get; set; } = new CreateEditModelDefinitionViewModel();

        private readonly IModelDefinitionAppService _modelDefinitionService;
        private readonly IFieldDefinitionAppService _fieldDefinitionService;

        public CreateModalModel(IModelDefinitionAppService modelDefinitionService, IFieldDefinitionAppService fieldDefinitionService)
        {
            _modelDefinitionService = modelDefinitionService;
            _fieldDefinitionService = fieldDefinitionService;
        }
        
        
        public virtual async Task OnGetAsync()
        {
            var output = await _fieldDefinitionService.GetListAsync(new GetListInput
            {
                MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount, // TODO: should use a modal form to select fields
            });

            ViewModel.Fields = output.Items.Select(fd => new SelectListItem(fd.Name, fd.Id.ToString())).ToList();
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditModelDefinitionViewModel, CreateUpdateModelDefinitionDto>(ViewModel);
            await _modelDefinitionService.CreateAsync(dto);
            return NoContent();
        }
    }
}