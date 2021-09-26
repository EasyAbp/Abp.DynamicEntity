using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicEntity.FieldDefinitions.Dtos
{
    public class GetFieldDefinitionListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; } 
    }
}