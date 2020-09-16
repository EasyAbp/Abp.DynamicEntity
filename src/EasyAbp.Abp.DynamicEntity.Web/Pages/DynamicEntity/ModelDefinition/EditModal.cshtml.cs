using System;
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
    public class EditModalModel : DynamicEntityPageModel
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