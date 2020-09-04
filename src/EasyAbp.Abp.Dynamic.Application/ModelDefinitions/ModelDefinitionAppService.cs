using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using EasyAbp.Abp.Dynamic.ModelDefinitions.Dtos;
using EasyAbp.Abp.Dynamic.Permissions;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions
{
    public class ModelDefinitionAppService : CrudAppService<ModelDefinition, ModelDefinitionDto, Guid, GetListInput, CreateUpdateModelDefinitionDto, CreateUpdateModelDefinitionDto>, IModelDefinitionAppService
    {
        protected override string GetPolicyName { get; set; } = DynamicPermissions.ModelDefinition.Default;
        protected override string GetListPolicyName { get; set; } = DynamicPermissions.ModelDefinition.Default;
        protected override string CreatePolicyName { get; set; } = DynamicPermissions.ModelDefinition.Create;
        protected override string UpdatePolicyName { get; set; } = DynamicPermissions.ModelDefinition.Update;
        protected override string DeletePolicyName { get; set; } = DynamicPermissions.ModelDefinition.Delete;

        private readonly IModelDefinitionRepository _modelDefinitionRepository;
        private readonly IFieldDefinitionRepository _fieldDefinitionRepository;
        public ModelDefinitionAppService(IModelDefinitionRepository modelDefinitionRepository, IFieldDefinitionRepository fieldDefinitionRepository) : base(modelDefinitionRepository)
        {
            _modelDefinitionRepository = modelDefinitionRepository;
            _fieldDefinitionRepository = fieldDefinitionRepository;
        }

        protected override IQueryable<ModelDefinition> CreateFilteredQuery(GetListInput input)
        {
            if (!input.Filter.IsNullOrEmpty())
            {
                return _modelDefinitionRepository.WhereIf(!input.Filter.IsNullOrEmpty(),
                    fd => fd.Name.Contains(input.Filter) ||
                          fd.Type.Contains(input.Filter));
            }

            return base.CreateFilteredQuery(input);
        }

        protected virtual async Task SetFields(ModelDefinition modelDefinition, CreateUpdateModelDefinitionDto createInput)
        {
            var fields = (await _fieldDefinitionRepository.GetByIds(createInput.FieldIds))
                .ToDictionary(fd => fd.Id);
            
            modelDefinition.Fields.Clear();
            int order = 1;
            foreach (var fieldId in createInput.FieldIds)
            {
                modelDefinition.AddField(fields[fieldId].Id, order++);
            }
        }

        protected override ModelDefinition MapToEntity(CreateUpdateModelDefinitionDto createInput)
        {
            var entity = base.MapToEntity(createInput);
             SetFields(entity, createInput);
             return entity;
        }

        protected override void MapToEntity(CreateUpdateModelDefinitionDto updateInput, ModelDefinition entity)
        {
            base.MapToEntity(updateInput, entity);
            SetFields(entity, updateInput);
        }

        public async Task<ModelDefinitionDto> GetByName(string name)
        {
            var entity = await _modelDefinitionRepository.GetAsync(md => md.Name == name);
            return await MapToGetOutputDtoAsync(entity);
        }
    }
}