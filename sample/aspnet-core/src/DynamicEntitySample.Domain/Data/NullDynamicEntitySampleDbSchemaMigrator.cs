using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace DynamicEntitySample.Data
{
    /* This is used if database provider does't define
     * IDynamicEntitySampleDbSchemaMigrator implementation.
     */
    public class NullDynamicEntitySampleDbSchemaMigrator : IDynamicEntitySampleDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}