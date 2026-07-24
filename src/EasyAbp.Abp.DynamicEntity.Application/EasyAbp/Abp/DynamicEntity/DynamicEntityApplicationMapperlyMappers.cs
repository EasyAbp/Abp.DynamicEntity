using System.Linq;
using EasyAbp.Abp.DynamicEntity.DynamicEntities.Dtos;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions.Dtos;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions.Dtos;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.Abp.DynamicEntity
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class FieldDefinitionToFieldDefinitionDtoMapper : MapperBase<FieldDefinition, FieldDefinitionDto>
    {
        public override partial FieldDefinitionDto Map(FieldDefinition source);

        public override partial void Map(FieldDefinition source, FieldDefinitionDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class ModelDefinitionToModelDefinitionDtoMapper : MapperBase<ModelDefinition, ModelDefinitionDto>
    {
        [MapperIgnoreTarget(nameof(ModelDefinitionDto.Fields))]
        public override partial ModelDefinitionDto Map(ModelDefinition source);

        [MapperIgnoreTarget(nameof(ModelDefinitionDto.Fields))]
        public override partial void Map(ModelDefinition source, ModelDefinitionDto destination);

        public override void AfterMap(ModelDefinition source, ModelDefinitionDto destination)
        {
            // The DTO exposes each model field as the underlying field definition, ordered by Order.
            destination.Fields = source.Fields
                .OrderBy(f => f.Order)
                .Select(f => MapFieldDefinitionToDto(f.FieldDefinition))
                .ToList();
        }

        private partial FieldDefinitionDto MapFieldDefinitionToDto(FieldDefinition fieldDefinition);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class ModelFieldToFieldDefinitionDtoMapper : MapperBase<ModelField, FieldDefinitionDto>
    {
        // A model field is projected to the DTO of its underlying field definition.
        public override FieldDefinitionDto Map(ModelField source)
        {
            return MapFieldDefinitionToDto(source.FieldDefinition);
        }

        public override void Map(ModelField source, FieldDefinitionDto destination)
        {
            MapFieldDefinitionToDto(source.FieldDefinition, destination);
        }

        private partial FieldDefinitionDto MapFieldDefinitionToDto(FieldDefinition fieldDefinition);

        private partial void MapFieldDefinitionToDto(FieldDefinition fieldDefinition, FieldDefinitionDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class DynamicEntityToDynamicEntityDtoMapper : MapperBase<DynamicEntities.DynamicEntity, DynamicEntityDto>
    {
        public override partial DynamicEntityDto Map(DynamicEntities.DynamicEntity source);

        public override partial void Map(DynamicEntities.DynamicEntity source, DynamicEntityDto destination);

        // Reused by Mapperly for the nested ModelDefinition.Fields collection element mapping.
        private FieldDefinitionDto MapModelFieldToDto(ModelField modelField)
        {
            return MapFieldDefinitionToDto(modelField.FieldDefinition);
        }

        private partial FieldDefinitionDto MapFieldDefinitionToDto(FieldDefinition fieldDefinition);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class PermissionSetValueObjectToPermissionSetDtoMapper : MapperBase<PermissionSetValueObject, PermissionSetDto>
    {
        public override partial PermissionSetDto Map(PermissionSetValueObject source);

        public override partial void Map(PermissionSetValueObject source, PermissionSetDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class PermissionSetDtoToPermissionSetValueObjectMapper : MapperBase<PermissionSetDto, PermissionSetValueObject>
    {
        public override partial PermissionSetValueObject Map(PermissionSetDto source);

        public override partial void Map(PermissionSetDto source, PermissionSetValueObject destination);
    }
}
