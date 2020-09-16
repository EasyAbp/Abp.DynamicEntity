using System;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions.Dtos;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntityEntities.Dtos
{
    public class DynamicEntityEntityDto : ExtensibleFullAuditedEntityDto<Guid>
    {
        public ModelDefinitionDto ModelDefinition { get; set; }
    }
}