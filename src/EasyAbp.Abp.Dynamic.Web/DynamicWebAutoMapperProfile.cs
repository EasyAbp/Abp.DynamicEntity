using AutoMapper;
using EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos;
using EasyAbp.Abp.Dynamic.Web.Pages.Dynamic.FieldDefinition.ViewModels;

namespace EasyAbp.Abp.Dynamic.Web
{
    public class DynamicWebAutoMapperProfile : Profile
    {
        public DynamicWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<FieldDefinitionDto, CreateEditFieldDefinitionViewModel>();
            CreateMap<CreateEditFieldDefinitionViewModel, CreateUpdateFieldDefinitionDto>();
        }
    }
}
