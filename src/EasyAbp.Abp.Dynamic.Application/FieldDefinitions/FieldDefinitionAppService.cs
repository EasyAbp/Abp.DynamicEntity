using System;
using System.Linq;
using EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos;
using EasyAbp.Abp.Dynamic.Permissions;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.Dynamic.FieldDefinitions
{
    public class FieldDefinitionAppService : CrudAppService<FieldDefinition, FieldDefinitionDto, Guid, GetListInput, CreateUpdateFieldDefinitionDto, CreateUpdateFieldDefinitionDto>,
        IFieldDefinitionAppService
    {
        protected override string GetPolicyName { get; set; } = DynamicPermissions.FieldDefinition.Default;
        protected override string GetListPolicyName { get; set; } = DynamicPermissions.FieldDefinition.Default;
        protected override string CreatePolicyName { get; set; } = DynamicPermissions.FieldDefinition.Create;
        protected override string UpdatePolicyName { get; set; } = DynamicPermissions.FieldDefinition.Update;
        protected override string DeletePolicyName { get; set; } = DynamicPermissions.FieldDefinition.Delete;

        private readonly IFieldDefinitionRepository _repository;

        public FieldDefinitionAppService(IFieldDefinitionRepository repository) : base(repository)
        {
            _repository = repository;
        }

        protected override IQueryable<FieldDefinition> CreateFilteredQuery(GetListInput input)
        {
            if (!input.Filter.IsNullOrEmpty())
            {
                return _repository.WhereIf(!input.Filter.IsNullOrEmpty(),
                    fd => fd.Name.Contains(input.Filter) ||
                          fd.Type.Contains(input.Filter));         
            }

            return base.CreateFilteredQuery(input);
        }
    }
}