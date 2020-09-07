using System;
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
    public class EditModalModel : DynamicPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty] public CreateEditModelDefinitionViewModel ViewModel { get; set; }

        private readonly IModelDefinitionAppService _modelDefinitionService;
        private readonly IFieldDefinitionAppService _fieldDefinitionService;

        public EditModalModel(IModelDefinitionAppService modelDefinitionService, IFieldDefinitionAppService fieldDefinitionService)
        {
            _modelDefinitionService = modelDefinitionService;
            _fieldDefinitionService = fieldDefinitionService;
        }

        public virtual async Task OnGetAsync()
        {
            var modelDefinitionDto = await _modelDefinitionService.GetAsync(Id);
            ViewModel = ObjectMapper.Map<ModelDefinitionDto, CreateEditModelDefinitionViewModel>(modelDefinitionDto);

            var output = await _fieldDefinitionService.GetListAsync(new GetListInput
            {
                MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount, // TODO: should use a modal form to select fields
            });

            ViewModel.Fields = output.Items
                .OrderBy(fieldDefinition =>
                {
                    int index = modelDefinitionDto.Fields.FindIndex(fd => fd.Id == fieldDefinition.Id);
                    return index == -1 ? int.MaxValue : index;
                })
                .Select(fd => new SelectListItem(fd.DisplayName, fd.Id.ToString())).ToList();
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditModelDefinitionViewModel, CreateUpdateModelDefinitionDto>(ViewModel);
            await _modelDefinitionService.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}