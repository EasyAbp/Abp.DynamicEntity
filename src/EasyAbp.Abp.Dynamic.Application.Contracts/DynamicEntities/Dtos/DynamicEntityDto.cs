using System;
using EasyAbp.Abp.Dynamic.ModelDefinitions.Dtos;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.Dynamic.DynamicEntities.Dtos
{
    public class DynamicEntityDto : ExtensibleFullAuditedEntityDto<Guid>
    {
        public ModelDefinitionDto ModelDefinition { get; set; }
    }
}