using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace EasyAbp.Abp.DynamicEntity.MongoDB
{
    public static class DynamicEntityMongoDbContextExtensions
    {
        public static void ConfigureDynamicEntity(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new DynamicEntityMongoModelBuilderConfigurationOptions(
                DynamicEntityDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}