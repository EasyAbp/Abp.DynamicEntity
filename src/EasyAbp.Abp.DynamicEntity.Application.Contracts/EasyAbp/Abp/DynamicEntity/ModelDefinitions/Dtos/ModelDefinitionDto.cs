using System;
using System.Collections.Generic;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions.Dtos;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions.Dtos
{
    [Serializable]
    public class ModelDefinitionDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Type { get; set; }

        public PermissionSetDto PermissionSet { get; set; } = new();

        public List<FieldDefinitionDto> Fields { get; set; }
    }
}