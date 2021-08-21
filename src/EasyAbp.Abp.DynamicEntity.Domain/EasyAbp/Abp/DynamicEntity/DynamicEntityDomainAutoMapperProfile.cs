using AutoMapper;
using EasyAbp.Abp.DynamicEntity.DynamicEntities;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;

namespace EasyAbp.Abp.DynamicEntity
{
    public class DynamicEntityDomainAutoMapperProfile : Profile
    {
        public DynamicEntityDomainAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<FieldDefinition, FieldDefinitionEto>();
            CreateMap<ModelDefinition, ModelDefinitionEto>();
            CreateMap<ModelField, ModelFieldEto>(MemberList.Destination);
            CreateMap<DynamicEntities.DynamicEntity, DynamicEntityEto>();
        }
    }
}
