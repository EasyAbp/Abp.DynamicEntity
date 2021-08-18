using System;
using Volo.Abp.ObjectExtending;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities.Dtos
{
    public class CreateDynamicEntityDto : ExtensibleObject
    {
        public virtual Guid? ModelDefinitionId { get; set; }
    }
}