using System.Threading.Tasks;

namespace DynamicSample.Data
{
    public interface IDynamicSampleDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
