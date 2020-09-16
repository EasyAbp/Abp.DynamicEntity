using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.Abp.DynamicEntity.EntityFrameworkCore
{
    public class DynamicEntityModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public DynamicEntityModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}