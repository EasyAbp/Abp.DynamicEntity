using System;
using System.Linq;
using System.Threading.Tasks;
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

        private readonly IModelDefinitionRepository _repository;

        public ModelDefinitionAppService(IModelDefinitionRepository repository) : base(repository)
        {
            _repository = repository;
        }

        protected override IQueryable<ModelDefinition> CreateFilteredQuery(GetListInput input)
        {
            if (!input.Filter.IsNullOrEmpty())
            {
                return _repository.WhereIf(!input.Filter.IsNullOrEmpty(),
                    fd => fd.Name.Contains(input.Filter) ||
                          fd.Type.Contains(input.Filter));
            }

            return base.CreateFilteredQuery(input);
        }

        protected override ModelDefinition MapToEntity(CreateUpdateModelDefinitionDto createInput)
        {
            var entity = base.MapToEntity(createInput);
            entity.Fields.Clear();
            int order = 1;
            foreach (var fieldId in createInput.FieldIds)
            {
                entity.AddField(fieldId, order++);
            }

            return entity;
        }
    }
}