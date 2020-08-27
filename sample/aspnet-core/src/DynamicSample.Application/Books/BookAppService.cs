using System;
using DynamicSample.Books.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace DynamicSample.Books
{
    public class BookAppService : CrudAppService<Book, BookDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookDto, CreateUpdateBookDto>,
        IBookAppService
    {

        public BookAppService(IRepository<Book, Guid> repository) : base(repository)
        {
        }
    }
}
