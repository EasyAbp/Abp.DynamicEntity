using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.Abp.DynamicEntity.MongoDB
{
    [ConnectionStringName(DynamicEntityDbProperties.ConnectionStringName)]
    public interface IDynamicEntityMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
