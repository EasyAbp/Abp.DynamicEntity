using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.DynamicEntities.Dtos;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities
{
    public class DynamicEntityAppService  : CrudAppService<DynamicEntity, DynamicEntityDto, Guid, GetListInput, CreateDynamicEntityDto, UpdateDynamicEntityDto>,
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

        protected override async Task<IQueryable<DynamicEntity>> CreateFilteredQueryAsync(GetListInput input)
        {
            var query = (await _repository.ExecuteDynamicQueryAsync(input.FilterGroup)).WhereIf(
                input.ModelDefinitionId.HasValue, x => x.ModelDefinitionId == input.ModelDefinitionId);

            if (!input.ModelName.IsNullOrWhiteSpace())
            {
                var modelDefinition = await _modelDefinitionRepository.GetAsync(x => x.Name == input.ModelName);

                query = query.Where(x => x.ModelDefinitionId == modelDefinition.Id);
            }

            return query;
        }
    }
}