using System;
using EasyAbp.Abp.Dynamic.Fields.Dtos;
using Volo.Abp.Application.Dtos;

namespace DynamicSample.Computers.Dtos
{
    [Serializable]
    public class ComputerDto : FullAuditedEntityDto<Guid>
    {
        public Guid FieldDefinitionId { get; set; }

        public FieldDefinitionDto FieldDefinition { get; set; }
    }
}