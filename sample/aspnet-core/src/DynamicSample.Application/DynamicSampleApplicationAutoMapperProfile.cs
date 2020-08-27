using DynamicSample.Computers;
using DynamicSample.Computers.Dtos;
using DynamicSample.Books;
using DynamicSample.Books.Dtos;
using AutoMapper;

namespace DynamicSample
{
    public class DynamicSampleApplicationAutoMapperProfile : Profile
    {
        public DynamicSampleApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Computer, ComputerDto>()
                ;
            CreateMap<CreateUpdateComputerDto, Computer>(MemberList.Source)
                ;
            CreateMap<Book, BookDto>();
            CreateMap<CreateUpdateBookDto, Book>(MemberList.Source);
        }
    }
}
