using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.Abp.DynamicEntity.MongoDB
{
    [ConnectionStringName(DynamicEntityDbProperties.ConnectionStringName)]
    public class DynamicEntityMongoDbContext : AbpMongoDbContext, IDynamicEntityMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureAbpDynamicEntity();
        }
    }
}