using Microsoft.EntityFrameworkCore;
using DynamicSample.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;
using DynamicSample.Computers;
using EasyAbp.Abp.Dynamic.ModelDefinitions;
using DynamicSample.Books;

namespace DynamicSample.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See DynamicSampleMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class DynamicSampleDbContext : AbpDbContext<DynamicSampleDbContext>
    {
        public DbSet<AppUser> Users { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside DynamicSampleDbContextModelCreatingExtensions.ConfigureDynamicSample
         */
        public DbSet<Computer> Computers { get; set; }
        public DbSet<ModelDefinition> ModelDefinitions { get; set; }
        public DbSet<Book> Books { get; set; }

        public DynamicSampleDbContext(DbContextOptions<DynamicSampleDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser
                
                b.ConfigureByConvention();
                b.ConfigureAbpUser();

                /* Configure mappings for your additional properties
                 * Also see the DynamicSampleEfCoreEntityExtensionMappings class
                 */
            });

            /* Configure your own tables/entities inside the ConfigureDynamicSample method */

            builder.ConfigureDynamicSample();
        }
    }
}
