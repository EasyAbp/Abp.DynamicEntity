using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicEntity.FieldDefinitions.Dtos
{
    [Serializable]
    public class FieldDefinitionDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        
        public string DisplayName { get; set; }

        public FieldDataType Type { get; set; }
    }
}