using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.Abp.Dynamic.MongoDB
{
    [ConnectionStringName(DynamicDbProperties.ConnectionStringName)]
    public interface IDynamicMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
