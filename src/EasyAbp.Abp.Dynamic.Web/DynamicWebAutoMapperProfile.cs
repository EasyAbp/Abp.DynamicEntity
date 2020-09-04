using System.Linq;
using AutoMapper;
using EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos;
using EasyAbp.Abp.Dynamic.ModelDefinitions.Dtos;
using EasyAbp.Abp.Dynamic.Web.Pages.Dynamic.FieldDefinition.ViewModels;
using EasyAbp.Abp.Dynamic.Web.Pages.Dynamic.ModelDefinition.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AutoMapper;

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
            
            CreateMap<ModelDefinitionDto, CreateEditModelDefinitionViewModel>()
                .Ignore(dest => dest.Fields)
                .ForMember(dest => dest.FieldIds, opt =>
                    opt.MapFrom(src => src.Fields.Select(fd => fd.Id)))
                ;
            CreateMap<CreateEditModelDefinitionViewModel, CreateUpdateModelDefinitionDto>();
        }
    }
}
