using System;
using Volo.Abp.Data;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions
{
    public interface IDynamicEntityModel : IHasExtraProperties
    {
        public Guid? ModelDefinitionId { get; }
        public ModelDefinition ModelDefinition { get; }
    }
}