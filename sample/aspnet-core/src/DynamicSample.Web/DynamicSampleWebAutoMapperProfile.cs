using DynamicSample.Computers.Dtos;
using DynamicSample.Web.Pages.Computers.Computer.ViewModels;
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
        }
    }
}
