using System;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using EasyAbp.Abp.DynamicQuery.Filters;
using JetBrains.Annotations;

namespace EasyAbp.Abp.DynamicEntity.Authorization
{
    public class DynamicEntityOperationInfoModel
    {
        [NotNull]
        public ModelDefinition ModelDefinition { get; set; }

        [CanBeNull]
        public DynamicEntities.DynamicEntity DynamicEntity { get; set; }

        [CanBeNull]
        public DynamicQueryGroup FilterGroup { get; set; }

        public DynamicEntityOperationInfoModel(
            [NotNull] ModelDefinition modelDefinition,
            [CanBeNull] DynamicEntities.DynamicEntity dynamicEntity = null,
            [CanBeNull] DynamicQueryGroup filterGroup = null)
        {
            ModelDefinition = modelDefinition;
            DynamicEntity = dynamicEntity;
            FilterGroup = filterGroup;
        }
    }
}