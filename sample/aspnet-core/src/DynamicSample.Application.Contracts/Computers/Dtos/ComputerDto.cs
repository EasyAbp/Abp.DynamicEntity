using System;
using Volo.Abp.Application.Dtos;

namespace DynamicSample.Computers.Dtos
{
    [Serializable]
    public class ComputerDto : ExtensibleFullAuditedEntityDto<Guid>
    {
    }
}