using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos
{
    public class GetListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; } 
    }
}