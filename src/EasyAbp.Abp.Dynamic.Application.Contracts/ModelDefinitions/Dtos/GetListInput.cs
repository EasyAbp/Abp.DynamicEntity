using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions.Dtos
{
    public class GetListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; } 
    }
}