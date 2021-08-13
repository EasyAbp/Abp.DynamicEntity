using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.ObjectExtending;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities.Dtos
{
    public class CreateUpdateDynamicEntityDto : ExtensibleObject
    {
        public virtual Guid? ModelDefinitionId { get; set; }
    }
}