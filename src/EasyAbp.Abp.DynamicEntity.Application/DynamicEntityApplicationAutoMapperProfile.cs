using System.Linq;
using AutoMapper;
using EasyAbp.Abp.DynamicEntity.DynamicEntityEntities;
using EasyAbp.Abp.DynamicEntity.DynamicEntityEntities.Dtos;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions.Dtos;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions.Dtos;
using Volo.Abp.AutoMapper;

namespace EasyAbp.Abp.DynamicEntity
{
    public class DynamicEntityApplicationAutoMapperProfile : Profile
    {
        public DynamicEntityApplicationAutoMapperProfile()
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
            
            CreateMap<DynamicEntityEntity, DynamicEntityEntityDto>();
            CreateMap<CreateUpdateDynamicEntityEntityDto, DynamicEntityEntity>(MemberList.Source);

            CreateMap<DynamicEntityEntities.Dtos.Filter, DynamicEntityEntities.Filter>();
        }
    }
}
