using System;
using Volo.Abp.Data;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions
{
    public interface IDynamicModel : IHasExtraProperties
    {
        public Guid? ModelDefinitionId { get; }
        public ModelDefinition ModelDefinition { get; }
    }
}