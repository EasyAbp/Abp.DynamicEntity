using DynamicSample.Computers.Dtos;
using DynamicSample.Web.Pages.Computers.Computer.ViewModels;
using DynamicSample.Books.Dtos;
using DynamicSample.Web.Pages.Books.Book.ViewModels;
using AutoMapper;

namespace DynamicSample.Web
{
    public class DynamicSampleWebAutoMapperProfile : Profile
    {
        public DynamicSampleWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
            CreateMap<ComputerDto, CreateEditComputerViewModel>();
            CreateMap<CreateEditComputerViewModel, CreateUpdateComputerDto>();
            CreateMap<BookDto, CreateEditBookViewModel>();
            CreateMap<CreateEditBookViewModel, CreateUpdateBookDto>();
        }
    }
}
