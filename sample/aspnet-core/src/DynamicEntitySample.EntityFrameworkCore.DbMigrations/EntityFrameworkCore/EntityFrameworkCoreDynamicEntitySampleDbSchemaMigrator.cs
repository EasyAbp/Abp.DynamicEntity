using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DynamicEntitySample.Data;
using Volo.Abp.DependencyInjection;

namespace DynamicEntitySample.EntityFrameworkCore
{
    public class EntityFrameworkCoreDynamicEntitySampleDbSchemaMigrator
        : IDynamicEntitySampleDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreDynamicEntitySampleDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the DynamicEntitySampleMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<DynamicEntitySampleMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}