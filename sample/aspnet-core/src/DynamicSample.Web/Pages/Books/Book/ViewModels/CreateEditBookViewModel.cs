using System;

using System.ComponentModel.DataAnnotations;

namespace DynamicSample.Web.Pages.Books.Book.ViewModels
{
    public class CreateEditBookViewModel
    {
        [Display(Name = "BookName")]
        public string Name { get; set; }

        [Display(Name = "BookAuthor")]
        public string Author { get; set; }
    }
}