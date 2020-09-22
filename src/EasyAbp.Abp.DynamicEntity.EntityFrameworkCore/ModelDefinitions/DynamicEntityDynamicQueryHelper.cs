using EasyAbp.Abp.DynamicQuery;
using EasyAbp.Abp.DynamicQuery.Filters;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IDynamicQueryHelper))]
    public class DynamicEntityDynamicQueryHelper : DynamicQueryHelper
    {
        protected override string GetLeft(DynamicQueryCondition condition, int index)
        {
            return $"DbFunctions.JsonValue(\"$.{condition.FieldName}\")";
        }
    }
}