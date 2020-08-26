using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.Dynamic.Fields.Dtos
{
    [Serializable]
    public class FieldDefinitionDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Order { get; set; }
    }
}