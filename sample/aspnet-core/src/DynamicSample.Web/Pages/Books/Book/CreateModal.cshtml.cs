using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DynamicSample.Books;
using DynamicSample.Books.Dtos;
using DynamicSample.Web.Pages.Books.Book.ViewModels;

namespace DynamicSample.Web.Pages.Books.Book
{
    public class CreateModalModel : DynamicSamplePageModel
    {
        [BindProperty]
        public CreateEditBookViewModel ViewModel { get; set; }

        private readonly IBookAppService _service;

        public CreateModalModel(IBookAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditBookViewModel, CreateUpdateBookDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}