using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DynamicEntitySample.Web.Pages.Computers.Computer.ViewModels;
using EasyAbp.Abp.DynamicEntity.DynamicEntities;
using EasyAbp.Abp.DynamicEntity.DynamicEntityEntities;

namespace DynamicEntitySample.Web.Pages.Computers.Computer
{
    public class CreateModalModel : DynamicEntitySamplePageModel
    {
        [BindProperty]
        public CreateEditComputerViewModel ViewModel { get; set; }

        private readonly IDynamicEntityAppService _service;

        public CreateModalModel(IDynamicEntityAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            /*var dto = ObjectMapper.Map<CreateEditComputerViewModel, CreateUpdateComputerDto>(ViewModel);
            await _service.CreateAsync(dto);*/
            return NoContent();
        }
    }
}