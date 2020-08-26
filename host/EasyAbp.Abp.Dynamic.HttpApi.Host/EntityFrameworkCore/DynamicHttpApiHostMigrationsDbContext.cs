using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.Dynamic.EntityFrameworkCore
{
    public class DynamicHttpApiHostMigrationsDbContext : AbpDbContext<DynamicHttpApiHostMigrationsDbContext>
    {
        public DynamicHttpApiHostMigrationsDbContext(DbContextOptions<DynamicHttpApiHostMigrationsDbContext> options)
            : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureDynamic();
        }
    }
}
