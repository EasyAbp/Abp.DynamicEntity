using System.Collections.Generic;
using System.Linq;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions.Dtos;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions.Dtos;
using EasyAbp.Abp.DynamicEntity.Web.Pages.DynamicEntity.FieldDefinition.ViewModels;
using EasyAbp.Abp.DynamicEntity.Web.Pages.DynamicEntity.ModelDefinition.ViewModels;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.Abp.DynamicEntity.Web
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class FieldDefinitionDtoToEditFieldDefinitionViewModelMapper : MapperBase<FieldDefinitionDto, EditFieldDefinitionViewModel>
    {
        public override partial EditFieldDefinitionViewModel Map(FieldDefinitionDto source);

        public override partial void Map(FieldDefinitionDto source, EditFieldDefinitionViewModel destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CreateFieldDefinitionViewModelToCreateFieldDefinitionDtoMapper : MapperBase<CreateFieldDefinitionViewModel, CreateFieldDefinitionDto>
    {
        public override partial CreateFieldDefinitionDto Map(CreateFieldDefinitionViewModel source);

        public override partial void Map(CreateFieldDefinitionViewModel source, CreateFieldDefinitionDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class EditFieldDefinitionViewModelToUpdateFieldDefinitionDtoMapper : MapperBase<EditFieldDefinitionViewModel, UpdateFieldDefinitionDto>
    {
        public override partial UpdateFieldDefinitionDto Map(EditFieldDefinitionViewModel source);

        public override partial void Map(EditFieldDefinitionViewModel source, UpdateFieldDefinitionDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class ModelDefinitionDtoToEditModelDefinitionViewModelMapper : MapperBase<ModelDefinitionDto, EditModelDefinitionViewModel>
    {
        [MapperIgnoreTarget(nameof(EditModelDefinitionViewModel.Fields))]
        [MapperIgnoreTarget(nameof(EditModelDefinitionViewModel.FieldIds))]
        public override partial EditModelDefinitionViewModel Map(ModelDefinitionDto source);

        [MapperIgnoreTarget(nameof(EditModelDefinitionViewModel.Fields))]
        [MapperIgnoreTarget(nameof(EditModelDefinitionViewModel.FieldIds))]
        public override partial void Map(ModelDefinitionDto source, EditModelDefinitionViewModel destination);

        public override void AfterMap(ModelDefinitionDto source, EditModelDefinitionViewModel destination)
        {
            destination.FieldIds = source.Fields?.Select(fd => fd.Id).ToList() ?? new List<System.Guid>();
        }
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CreateModelDefinitionViewModelToCreateModelDefinitionDtoMapper : MapperBase<CreateModelDefinitionViewModel, CreateModelDefinitionDto>
    {
        public override partial CreateModelDefinitionDto Map(CreateModelDefinitionViewModel source);

        public override partial void Map(CreateModelDefinitionViewModel source, CreateModelDefinitionDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class EditModelDefinitionViewModelToUpdateModelDefinitionDtoMapper : MapperBase<EditModelDefinitionViewModel, UpdateModelDefinitionDto>
    {
        public override partial UpdateModelDefinitionDto Map(EditModelDefinitionViewModel source);

        public override partial void Map(EditModelDefinitionViewModel source, UpdateModelDefinitionDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CreatePermissionSetViewModelToPermissionSetDtoMapper : MapperBase<CreatePermissionSetViewModel, PermissionSetDto>
    {
        public override partial PermissionSetDto Map(CreatePermissionSetViewModel source);

        public override partial void Map(CreatePermissionSetViewModel source, PermissionSetDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class EditPermissionSetViewModelToPermissionSetDtoMapper : MapperBase<EditPermissionSetViewModel, PermissionSetDto>
    {
        public override partial PermissionSetDto Map(EditPermissionSetViewModel source);

        public override partial void Map(EditPermissionSetViewModel source, PermissionSetDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class PermissionSetDtoToEditPermissionSetViewModelMapper : MapperBase<PermissionSetDto, EditPermissionSetViewModel>
    {
        public override partial EditPermissionSetViewModel Map(PermissionSetDto source);

        public override partial void Map(PermissionSetDto source, EditPermissionSetViewModel destination);
    }
}
