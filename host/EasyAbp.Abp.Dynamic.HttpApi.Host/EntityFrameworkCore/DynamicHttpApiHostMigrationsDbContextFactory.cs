using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EasyAbp.Abp.Dynamic.EntityFrameworkCore
{
    public class DynamicHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<DynamicHttpApiHostMigrationsDbContext>
    {
        public DynamicHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<DynamicHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Dynamic"));

            return new DynamicHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
