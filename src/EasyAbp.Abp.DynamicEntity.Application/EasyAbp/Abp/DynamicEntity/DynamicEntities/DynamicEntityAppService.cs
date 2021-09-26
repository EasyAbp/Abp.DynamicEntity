using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.Authorization;
using EasyAbp.Abp.DynamicEntity.DynamicEntities.Dtos;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities
{
    public class DynamicEntityAppService : CrudAppService<DynamicEntity, DynamicEntityDto, Guid, GetDynamicEntityListInput, CreateDynamicEntityDto, UpdateDynamicEntityDto>,
        IDynamicEntityAppService
    {
        private readonly IModelDefinitionRepository _modelDefinitionRepository;
        private readonly IDynamicEntityRepository _repository;

        public DynamicEntityAppService(
            IModelDefinitionRepository modelDefinitionRepository,
            IDynamicEntityRepository repository) : base(repository)
        {
            _modelDefinitionRepository = modelDefinitionRepository;
            _repository = repository;
        }

        public override async Task<DynamicEntityDto> GetAsync(Guid id)
        {
            var entity = await GetEntityByIdAsync(id);
            
            var modelDefinition = await GetModelDefinitionAsync(entity.ModelDefinitionId);

            await AuthorizationService.CheckAsync(new DynamicEntityOperationInfoModel(modelDefinition, entity),
                new DynamicEntityOperationAuthorizationRequirement(DynamicEntityOperationAuthorizationRequirement
                    .GetName));
            
            return await MapToGetOutputDtoAsync(entity);
        }

        protected virtual async Task<ModelDefinition> GetModelDefinitionAsync(Guid? id)
        {
            if (!id.HasValue)
            {
                throw new ModelDefinitionIdHasNoValueException();
            }
            
            return await _modelDefinitionRepository.GetAsync(id.Value);
        }

        public override async Task<PagedResultDto<DynamicEntityDto>> GetListAsync(GetDynamicEntityListInput input)
        {
            var modelDefinition = input.ModelDefinitionId.HasValue
                ? await GetModelDefinitionAsync(input.ModelDefinitionId.Value)
                : await _modelDefinitionRepository.GetAsync(x => x.Name == input.ModelName);
            
            await AuthorizationService.CheckAsync(
                new DynamicEntityOperationInfoModel(modelDefinition, null, input.FilterGroup),
                new DynamicEntityOperationAuthorizationRequirement(DynamicEntityOperationAuthorizationRequirement
                    .GetListName));

            input.ModelDefinitionId = modelDefinition.Id;

            var query = await CreateFilteredQueryAsync(input);

            var totalCount = await AsyncExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncExecuter.ToListAsync(query);

            return new PagedResultDto<DynamicEntityDto>(
                totalCount,
                entities.Select(MapToGetListOutputDto).ToList()
            );
        }

        protected override async Task<IQueryable<DynamicEntity>> CreateFilteredQueryAsync(GetDynamicEntityListInput input)
        {
            var query = (await _repository.ExecuteDynamicQueryAsync(input.FilterGroup)).WhereIf(
                input.ModelDefinitionId.HasValue, x => x.ModelDefinitionId == input.ModelDefinitionId);

            return query;
        }

        public override async Task<DynamicEntityDto> CreateAsync(CreateDynamicEntityDto input)
        {
            var entity = await MapToEntityAsync(input);

            var modelDefinition = await GetModelDefinitionAsync(entity.ModelDefinitionId);

            await AuthorizationService.CheckAsync(new DynamicEntityOperationInfoModel(modelDefinition, entity),
                new DynamicEntityOperationAuthorizationRequirement(DynamicEntityOperationAuthorizationRequirement
                    .CreateName));
            
            await _repository.InsertAsync(entity, true);

            return await MapToGetOutputDtoAsync(entity);
        }

        public override async Task<DynamicEntityDto> UpdateAsync(Guid id, UpdateDynamicEntityDto input)
        {
            var entity = await GetEntityByIdAsync(id);
            
            await MapToEntityAsync(input, entity);
            
            var modelDefinition = await GetModelDefinitionAsync(entity.ModelDefinitionId);

            await AuthorizationService.CheckAsync(new DynamicEntityOperationInfoModel(modelDefinition, entity),
                new DynamicEntityOperationAuthorizationRequirement(DynamicEntityOperationAuthorizationRequirement
                    .UpdateName));
            
            await Repository.UpdateAsync(entity, true);

            return await MapToGetOutputDtoAsync(entity);
        }

        public override async Task DeleteAsync(Guid id)
        {
            var entity = await GetEntityByIdAsync(id);
            
            var modelDefinition = await GetModelDefinitionAsync(entity.ModelDefinitionId);

            await AuthorizationService.CheckAsync(new DynamicEntityOperationInfoModel(modelDefinition, entity),
                new DynamicEntityOperationAuthorizationRequirement(DynamicEntityOperationAuthorizationRequirement
                    .DeleteName));

            await Repository.DeleteAsync(entity, true);
        }
    }
}