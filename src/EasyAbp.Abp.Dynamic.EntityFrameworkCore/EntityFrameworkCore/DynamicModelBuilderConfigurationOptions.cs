using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.Abp.Dynamic.EntityFrameworkCore
{
    public class DynamicModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public DynamicModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}