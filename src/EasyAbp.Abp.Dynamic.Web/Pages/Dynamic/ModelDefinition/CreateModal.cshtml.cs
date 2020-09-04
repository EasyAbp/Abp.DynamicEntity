using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using EasyAbp.Abp.Dynamic.ModelDefinitions;
using EasyAbp.Abp.Dynamic.ModelDefinitions.Dtos;
using EasyAbp.Abp.Dynamic.Web.Pages.Dynamic.ModelDefinition.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using GetListInput = EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos.GetListInput;

namespace EasyAbp.Abp.Dynamic.Web.Pages.Dynamic.ModelDefinition
{
    public class CreateModalModel : DynamicPageModel
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