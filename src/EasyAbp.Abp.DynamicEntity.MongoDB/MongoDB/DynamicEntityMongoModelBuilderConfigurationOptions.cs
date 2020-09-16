using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace EasyAbp.Abp.DynamicEntity.MongoDB
{
    public class DynamicEntityMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public DynamicEntityMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}