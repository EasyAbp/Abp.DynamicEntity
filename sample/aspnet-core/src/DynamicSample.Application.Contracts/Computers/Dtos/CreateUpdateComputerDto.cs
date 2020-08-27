using System;
using System.ComponentModel;
using EasyAbp.Abp.Dynamic.Fields.Dtos;
using Volo.Abp.Application.Dtos;

namespace DynamicSample.Computers.Dtos
{
    [Serializable]
    public class CreateUpdateComputerDto : ExtensibleEntityDto<Guid>
    {
    }
}