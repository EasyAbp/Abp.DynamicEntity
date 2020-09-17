using System.Collections.Generic;
using EasyAbp.Abp.DynamicQuery;
using EasyAbp.Abp.DynamicQuery.Dtos;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntityEntities.Dtos
{
    public class GetListInput : PagedAndSortedResultRequestDto, IDynamicQueryInput
    {
        public List<DynamicQueryFilter> FieldFilters { get; set; }
    }
}