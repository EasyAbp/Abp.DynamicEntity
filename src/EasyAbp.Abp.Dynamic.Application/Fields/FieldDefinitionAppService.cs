using System;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using EasyAbp.Abp.Dynamic.Permissions;
using EasyAbp.Abp.Dynamic.Fields.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.Dynamic.Fields
{
    public class FieldDefinitionAppService : CrudAppService<FieldDefinition, FieldDefinitionDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateFieldDefinitionDto, CreateUpdateFieldDefinitionDto>,
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
    }
}
