using System.Linq;
using AutoMapper;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions.Dtos;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions.Dtos;
using EasyAbp.Abp.DynamicEntity.Web.Pages.DynamicEntity.FieldDefinition.ViewModels;
using EasyAbp.Abp.DynamicEntity.Web.Pages.DynamicEntity.ModelDefinition.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AutoMapper;

namespace EasyAbp.Abp.DynamicEntity.Web
{
    public class DynamicEntityWebAutoMapperProfile : Profile
    {
        public DynamicEntityWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<FieldDefinitionDto, CreateEditFieldDefinitionViewModel>();
            CreateMap<CreateEditFieldDefinitionViewModel, CreateUpdateFieldDefinitionDto>();
            
            CreateMap<ModelDefinitionDto, EditModelDefinitionViewModel>()
                .Ignore(dest => dest.Fields)
                .ForMember(dest => dest.FieldIds, opt =>
                    opt.MapFrom(src => src.Fields.Select(fd => fd.Id)))
                ;
            CreateMap<CreateModelDefinitionViewModel, CreateModelDefinitionDto>();
            CreateMap<EditModelDefinitionViewModel, UpdateModelDefinitionDto>();
        }
    }
}
