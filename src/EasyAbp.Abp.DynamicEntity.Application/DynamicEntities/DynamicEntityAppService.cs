using System;
using System.Linq;
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

        protected override IQueryable<DynamicEntity> CreateFilteredQuery(GetListInput input)
        {
            return _repository.ExecuteDynamicQuery(input.FilterGroup);
        }
    }
}