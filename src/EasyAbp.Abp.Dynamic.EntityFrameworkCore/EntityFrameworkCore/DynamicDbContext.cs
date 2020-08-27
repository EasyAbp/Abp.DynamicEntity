using EasyAbp.Abp.Dynamic.FieldDefinitions;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.Abp.Dynamic.Fields;

namespace EasyAbp.Abp.Dynamic.EntityFrameworkCore
{
    [ConnectionStringName(DynamicDbProperties.ConnectionStringName)]
    public class DynamicDbContext : AbpDbContext<DynamicDbContext>, IDynamicDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<FieldDefinition> FieldDefinitions { get; set; }

        public DynamicDbContext(DbContextOptions<DynamicDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureDynamic();
        }
    }
}
