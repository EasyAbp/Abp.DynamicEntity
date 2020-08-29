using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DynamicSample.Web.Pages.Computers.Computer.ViewModels;
using EasyAbp.Abp.Dynamic.DynamicEntities;

namespace DynamicSample.Web.Pages.Computers.Computer
{
    public class CreateModalModel : DynamicSamplePageModel
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