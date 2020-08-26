using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DynamicSample.Computers;
using DynamicSample.Computers.Dtos;
using DynamicSample.Web.Pages.Computers.Computer.ViewModels;

namespace DynamicSample.Web.Pages.Computers.Computer
{
    public class EditModalModel : DynamicSamplePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditComputerViewModel ViewModel { get; set; }

        private readonly IComputerAppService _service;

        public EditModalModel(IComputerAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<ComputerDto, CreateEditComputerViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditComputerViewModel, CreateUpdateComputerDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}