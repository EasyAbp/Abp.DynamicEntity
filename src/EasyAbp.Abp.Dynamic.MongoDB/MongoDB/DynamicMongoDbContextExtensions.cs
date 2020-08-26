using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace EasyAbp.Abp.Dynamic.MongoDB
{
    public static class DynamicMongoDbContextExtensions
    {
        public static void ConfigureDynamic(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new DynamicMongoModelBuilderConfigurationOptions(
                DynamicDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}