﻿using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions.Dtos;
using EasyAbp.Abp.DynamicEntity.Permissions;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicEntity.FieldDefinitions
{
    public class FieldDefinitionAppService : CrudAppService<FieldDefinition, FieldDefinitionDto, Guid, GetFieldDefinitionListInput, CreateFieldDefinitionDto, UpdateFieldDefinitionDto>,
        IFieldDefinitionAppService
    {
        protected override string GetPolicyName { get; set; } = DynamicEntityPermissions.FieldDefinition.Default;
        protected override string GetListPolicyName { get; set; } = DynamicEntityPermissions.FieldDefinition.Default;
        protected override string CreatePolicyName { get; set; } = DynamicEntityPermissions.FieldDefinition.Create;
        protected override string UpdatePolicyName { get; set; } = DynamicEntityPermissions.FieldDefinition.Update;
        protected override string DeletePolicyName { get; set; } = DynamicEntityPermissions.FieldDefinition.Delete;

        private readonly IFieldDefinitionRepository _repository;

        public FieldDefinitionAppService(IFieldDefinitionRepository repository) : base(repository)
        {
            _repository = repository;
        }

        protected override async Task<IQueryable<FieldDefinition>> CreateFilteredQueryAsync(GetFieldDefinitionListInput input)
        {
            if (!input.Filter.IsNullOrEmpty())
            {
                return (await _repository.GetQueryableAsync()).WhereIf(!input.Filter.IsNullOrEmpty(),
                    fd => fd.Name.Contains(input.Filter));
            }

            return await base.CreateFilteredQueryAsync(input);
        }

        public async Task<FieldDefinitionDto> GetByName(string name)
        {
            var entity = await _repository.GetAsync(fd => fd.Name == name);
            return await MapToGetOutputDtoAsync(entity);
        }

        public override async Task<FieldDefinitionDto> CreateAsync(CreateFieldDefinitionDto input)
        {
            await CheckDuplicateName(input);
            return await base.CreateAsync(input);
        }

        private async Task CheckDuplicateName(CreateFieldDefinitionDto input, Guid? id = null)
        {
            var existFieldDefinition = await _repository.GetByNameAsync(input.Name);
            if (existFieldDefinition != null && (id == null || id.Value != existFieldDefinition.Id))
            {
                throw new BusinessException(DynamicEntityErrorCodes.FieldDefinitionAlreadyExists)
                {
                    Data =
                    {
                        {"Name", input.Name}
                    }
                };
            }
        }
    }
}