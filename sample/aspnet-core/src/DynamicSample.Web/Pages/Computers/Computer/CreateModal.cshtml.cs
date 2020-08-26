using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DynamicSample.Computers;
using DynamicSample.Computers.Dtos;
using DynamicSample.Web.Pages.Computers.Computer.ViewModels;

namespace DynamicSample.Web.Pages.Computers.Computer
{
    public class CreateModalModel : DynamicSamplePageModel
    {
        [BindProperty]
        public CreateEditComputerViewModel ViewModel { get; set; }

        private readonly IComputerAppService _service;

        public CreateModalModel(IComputerAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditComputerViewModel, CreateUpdateComputerDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}