using System.Threading.Tasks;

namespace DynamicEntitySample.Data
{
    public interface IDynamicEntitySampleDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
