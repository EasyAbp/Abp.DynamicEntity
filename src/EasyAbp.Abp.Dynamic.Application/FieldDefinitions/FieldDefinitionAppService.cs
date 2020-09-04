using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos;
using EasyAbp.Abp.Dynamic.Permissions;
using Volo.Abp;
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

        public async Task<FieldDefinitionDto> GetByName(string name)
        {
            var entity = await _repository.GetAsync(fd => fd.Name == name);
            return MapToGetOutputDto(entity);
        }

        public override async Task<FieldDefinitionDto> CreateAsync(CreateUpdateFieldDefinitionDto input)
        {
            await CheckDuplicateName(input);
            return await base.CreateAsync(input);
        }

        public override async Task<FieldDefinitionDto> UpdateAsync(Guid id, CreateUpdateFieldDefinitionDto input)
        {
            await CheckDuplicateName(input);
            return await base.UpdateAsync(id, input);
        }

        private async Task CheckDuplicateName(CreateUpdateFieldDefinitionDto input)
        {
            var existFieldDefinition = await _repository.GetByName(input.Name);
            if (existFieldDefinition != null)
            {
                throw new BusinessException(DynamicErrorCodes.FieldDefinitionAlreadyExists)
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