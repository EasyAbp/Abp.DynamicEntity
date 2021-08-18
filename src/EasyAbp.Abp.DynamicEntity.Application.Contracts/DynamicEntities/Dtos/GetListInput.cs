using System;
using EasyAbp.Abp.DynamicQuery.Dtos;
using EasyAbp.Abp.DynamicQuery.Filters;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities.Dtos
{
    public class GetListInput : PagedAndSortedResultRequestDto, IDynamicQueryInput
    {
        public Guid ModelDefinitionId { get; set; }

        public DynamicQueryGroup FilterGroup { get; set; }
    }
}