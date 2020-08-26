using EasyAbp.Abp.Dynamic.Fields;
using EasyAbp.Abp.Dynamic.Fields.Dtos;
using AutoMapper;

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
