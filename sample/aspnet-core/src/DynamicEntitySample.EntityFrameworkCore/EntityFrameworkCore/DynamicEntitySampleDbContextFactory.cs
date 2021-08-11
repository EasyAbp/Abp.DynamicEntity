using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DynamicEntitySample.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class DynamicEntitySampleDbContextFactory : IDesignTimeDbContextFactory<DynamicEntitySampleDbContext>
    {
        public DynamicEntitySampleDbContext CreateDbContext(string[] args)
        {
            DynamicEntitySampleEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<DynamicEntitySampleDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new DynamicEntitySampleDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../DynamicEntitySample.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
