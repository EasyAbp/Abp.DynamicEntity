using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.DynamicEntities.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities
{
    public class DynamicEntityAppService  : CrudAppService<DynamicEntity, DynamicEntityDto, Guid, GetListInput, CreateUpdateDynamicEntityDto, CreateUpdateDynamicEntityDto>,
        IDynamicEntityAppService
    {
        private readonly IDynamicEntityRepository _repository;

        public DynamicEntityAppService(IDynamicEntityRepository repository) : base(repository)
        {
            _repository = repository;
        }

        protected override async Task<IQueryable<DynamicEntity>> CreateFilteredQueryAsync(GetListInput input)
        {
            return await _repository.ExecuteDynamicQueryAsync(input.FilterGroup);
        }
    }
}