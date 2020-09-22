using System.Collections.Generic;
using EasyAbp.Abp.DynamicQuery;
using EasyAbp.Abp.DynamicQuery.Dtos;
using EasyAbp.Abp.DynamicQuery.Filters;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities.Dtos
{
    public class GetListInput : PagedAndSortedResultRequestDto, IDynamicQueryInput
    {
        public DynamicQueryGroup FilterGroup { get; set; }
    }
}