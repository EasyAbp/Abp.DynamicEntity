using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.Dynamic.DynamicEntities.Dtos
{
    public class GetListInput : PagedAndSortedResultRequestDto
    {
        public Dictionary<string, string> Filter { get; set; } 
    }
}