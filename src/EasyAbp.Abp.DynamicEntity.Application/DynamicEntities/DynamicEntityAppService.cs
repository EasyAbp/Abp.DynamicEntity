using System;
using System.Collections.Generic;
using System.Linq;
using EasyAbp.Abp.DynamicEntity.DynamicEntities.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities
{
    public class DynamicEntityAppService  : CrudAppService<DynamicEntities.DynamicEntity, DynamicEntityDto, Guid, GetListInput, CreateUpdateDynamicEntityDto, CreateUpdateDynamicEntityDto>,
        IDynamicEntityAppService
    {
        private readonly IDynamicEntityRepository _repository;

        public DynamicEntityAppService(IDynamicEntityRepository repository) : base(repository)
        {
            _repository = repository;
        }

        protected override IQueryable<DynamicEntities.DynamicEntity> CreateFilteredQuery(GetListInput input)
        {
            if (input.FieldFilters != null && input.FieldFilters.Count > 0)
            {
                return _repository.GetQueryByFilter(ObjectMapper.Map<IList<EasyAbp.Abp.DynamicQuery.Dtos.DynamicQueryFilter>, IList<DynamicQuery.DynamicQueryFilter>>(input.FieldFilters));
            }

            return base.CreateFilteredQuery(input);
        }
    }
}