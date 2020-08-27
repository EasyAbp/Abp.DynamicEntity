using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DynamicSample.Books;
using DynamicSample.Books.Dtos;
using DynamicSample.Web.Pages.Books.Book.ViewModels;

namespace DynamicSample.Web.Pages.Books.Book
{
    public class EditModalModel : DynamicSamplePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditBookViewModel ViewModel { get; set; }

        private readonly IBookAppService _service;

        public EditModalModel(IBookAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<BookDto, CreateEditBookViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditBookViewModel, CreateUpdateBookDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}