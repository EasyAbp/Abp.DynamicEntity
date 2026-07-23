using EasyAbp.Abp.DynamicEntity.DynamicEntities;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.Abp.DynamicEntity
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class FieldDefinitionToFieldDefinitionEtoMapper : MapperBase<FieldDefinition, FieldDefinitionEto>
    {
        public override partial FieldDefinitionEto Map(FieldDefinition source);

        public override partial void Map(FieldDefinition source, FieldDefinitionEto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class ModelDefinitionToModelDefinitionEtoMapper : MapperBase<ModelDefinition, ModelDefinitionEto>
    {
        public override partial ModelDefinitionEto Map(ModelDefinition source);

        public override partial void Map(ModelDefinition source, ModelDefinitionEto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class ModelFieldToModelFieldEtoMapper : MapperBase<ModelField, ModelFieldEto>
    {
        public override partial ModelFieldEto Map(ModelField source);

        public override partial void Map(ModelField source, ModelFieldEto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class DynamicEntityToDynamicEntityEtoMapper : MapperBase<DynamicEntities.DynamicEntity, DynamicEntityEto>
    {
        public override partial DynamicEntityEto Map(DynamicEntities.DynamicEntity source);

        public override partial void Map(DynamicEntities.DynamicEntity source, DynamicEntityEto destination);
    }
}
