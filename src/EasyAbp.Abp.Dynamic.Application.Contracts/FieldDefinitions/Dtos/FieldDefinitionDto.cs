using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos
{
    [Serializable]
    public class FieldDefinitionDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        
        public string DisplayName { get; set; }

        public string Type { get; set; }
    }
}