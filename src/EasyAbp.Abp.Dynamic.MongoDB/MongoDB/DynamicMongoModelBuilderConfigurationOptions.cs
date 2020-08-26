using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace EasyAbp.Abp.Dynamic.MongoDB
{
    public class DynamicMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public DynamicMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}