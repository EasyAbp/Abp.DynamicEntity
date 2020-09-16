using EasyAbp.Abp.DynamicEntity.DynamicEntityEntities;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.DynamicEntity.EntityFrameworkCore
{
    [ConnectionStringName(DynamicEntityDbProperties.ConnectionStringName)]
    public class DynamicEntityDbContext : AbpDbContext<DynamicEntityDbContext>, IDynamicEntityDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<FieldDefinition> FieldDefinitions { get; set; }
        public DbSet<ModelDefinition> ModelDefinitions { get; set; }
        public DbSet<DynamicEntityEntity> DynamicEntityEntities { get; set; }

        public DynamicEntityDbContext(DbContextOptions<DynamicEntityDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureDynamicEntity();
        }
    }
}
