using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DynamicSample.Data;
using Volo.Abp.DependencyInjection;

namespace DynamicSample.EntityFrameworkCore
{
    public class EntityFrameworkCoreDynamicSampleDbSchemaMigrator
        : IDynamicSampleDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreDynamicSampleDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the DynamicSampleMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<DynamicSampleMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}