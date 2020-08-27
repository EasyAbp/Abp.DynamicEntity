using System;
using System.Collections.Generic;
using EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions.Dtos
{
    [Serializable]
    public class ModelDefinitionDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Type { get; set; }
        
        public List<FieldDefinitionDto> Fields { get; set; }
    }
}