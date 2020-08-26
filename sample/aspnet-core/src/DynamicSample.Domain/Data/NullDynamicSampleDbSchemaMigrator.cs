using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace DynamicSample.Data
{
    /* This is used if database provider does't define
     * IDynamicSampleDbSchemaMigrator implementation.
     */
    public class NullDynamicSampleDbSchemaMigrator : IDynamicSampleDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}