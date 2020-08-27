using System;
using DynamicSample.Books.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DynamicSample.Books
{
    public interface IBookAppService :
        ICrudAppService< 
            BookDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateBookDto,
            CreateUpdateBookDto>
    {

    }
}