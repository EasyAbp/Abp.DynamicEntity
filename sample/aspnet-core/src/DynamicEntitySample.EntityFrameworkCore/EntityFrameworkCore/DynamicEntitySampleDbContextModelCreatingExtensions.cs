using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace DynamicEntitySample.EntityFrameworkCore
{
    public static class DynamicEntitySampleDbContextModelCreatingExtensions
    {
        public static void ConfigureDynamicEntitySample(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(DynamicEntitySampleConsts.DbTablePrefix + "YourEntities", DynamicEntitySampleConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}
