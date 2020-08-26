using System;
using System.ComponentModel;
using EasyAbp.Abp.Dynamic.Fields.Dtos;

namespace DynamicSample.Computers.Dtos
{
    [Serializable]
    public class CreateUpdateComputerDto
    {
        public Guid FieldDefinitionId { get; set; }

        public FieldDefinitionDto FieldDefinition { get; set; }
    }
}