using System.Linq;
using AutoMapper;
using EasyAbp.Abp.Dynamic.DynamicEntities;
using EasyAbp.Abp.Dynamic.DynamicEntities.Dtos;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos;
using EasyAbp.Abp.Dynamic.ModelDefinitions;
using EasyAbp.Abp.Dynamic.ModelDefinitions.Dtos;
using Volo.Abp.AutoMapper;

namespace EasyAbp.Abp.Dynamic
{
    public class DynamicApplicationAutoMapperProfile : Profile
    {
        public DynamicApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<FieldDefinition, FieldDefinitionDto>();
            CreateMap<CreateUpdateFieldDefinitionDto, FieldDefinition>(MemberList.Source);
            
            CreateMap<ModelDefinition, ModelDefinitionDto>()
                .ForMember(dest => dest.Fields, opt =>
                {
                    opt.MapFrom(src => src.Fields.OrderBy(f => f.Order));
                })
                ;
            CreateMap<ModelField, FieldDefinitionDto>(MemberList.None)
                .ConstructUsing((src, ctx) => ctx.Mapper.Map<FieldDefinitionDto>(src.FieldDefinition))
                ;
            
            CreateMap<CreateUpdateModelDefinitionDto, ModelDefinition>(MemberList.None)
                .Ignore(x => x.Fields)
                ;
            
            CreateMap<DynamicEntity, DynamicEntityDto>();
            CreateMap<CreateUpdateDynamicEntityDto, DynamicEntity>(MemberList.Source);
        }
    }
}
