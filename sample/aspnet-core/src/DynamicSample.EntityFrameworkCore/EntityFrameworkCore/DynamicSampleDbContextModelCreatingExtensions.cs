using DynamicSample.Computers;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DynamicSample.EntityFrameworkCore
{
    public static class DynamicSampleDbContextModelCreatingExtensions
    {
        public static void ConfigureDynamicSample(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(DynamicSampleConsts.DbTablePrefix + "YourEntities", DynamicSampleConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});


            builder.Entity<Computer>(b =>
            {
                b.ToTable(DynamicSampleConsts.DbTablePrefix + "Computers", DynamicSampleConsts.DbSchema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });
        }
    }
}
