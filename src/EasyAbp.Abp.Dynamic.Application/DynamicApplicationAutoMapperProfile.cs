using AutoMapper;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos;

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
        }
    }
}
