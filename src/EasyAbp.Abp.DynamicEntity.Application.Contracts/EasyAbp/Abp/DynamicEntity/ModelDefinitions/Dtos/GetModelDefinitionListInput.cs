using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions.Dtos
{
    public class GetModelDefinitionListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; } 
    }
}