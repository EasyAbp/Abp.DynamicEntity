using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.Dynamic.DynamicEntities.Dtos
{
    public class GetListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public Dictionary<string, string> FiledFilters { get; set; }
    }
}