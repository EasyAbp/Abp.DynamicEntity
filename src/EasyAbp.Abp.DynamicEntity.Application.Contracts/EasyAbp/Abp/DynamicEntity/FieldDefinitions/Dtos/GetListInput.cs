using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicEntity.FieldDefinitions.Dtos
{
    public class GetListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; } 
    }
}