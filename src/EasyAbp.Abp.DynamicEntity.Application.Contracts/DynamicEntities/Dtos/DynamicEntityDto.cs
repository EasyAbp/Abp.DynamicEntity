using System;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions.Dtos;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities.Dtos
{
    public class DynamicEntityDto : ExtensibleFullAuditedEntityDto<Guid>
    {
        public ModelDefinitionDto ModelDefinition { get; set; }
    }
}