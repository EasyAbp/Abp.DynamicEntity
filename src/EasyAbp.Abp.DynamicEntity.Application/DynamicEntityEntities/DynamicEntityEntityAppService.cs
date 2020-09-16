using System;
using System.Collections.Generic;
using System.Linq;
using EasyAbp.Abp.DynamicEntity.DynamicEntityEntities.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntityEntities
{
    public class DynamicEntityEntityAppService  : CrudAppService<DynamicEntityEntity, DynamicEntityEntityDto, Guid, GetListInput, CreateUpdateDynamicEntityEntityDto, CreateUpdateDynamicEntityEntityDto>,
        IDynamicEntityEntityAppService
    {
        private readonly IDynamicEntityEntityRepository _repository;

        public DynamicEntityEntityAppService(IDynamicEntityEntityRepository repository) : base(repository)
        {
            _repository = repository;
        }

        protected override IQueryable<DynamicEntityEntity> CreateFilteredQuery(GetListInput input)
        {
            if (input.FieldFilters != null && input.FieldFilters.Count > 0)
            {
                return _repository.GetQueryByFilter(ObjectMapper.Map<IList<Dtos.Filter>, IList<Filter>>(input.FieldFilters));
            }
            
            if (!input.Filter.IsNullOrEmpty())
            {
                return _repository.GetQueryByFilter(input.Filter);
            }
            
            return base.CreateFilteredQuery(input);
        }
    }
}