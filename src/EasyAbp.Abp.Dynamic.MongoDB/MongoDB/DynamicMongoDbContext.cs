using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.Abp.Dynamic.MongoDB
{
    [ConnectionStringName(DynamicDbProperties.ConnectionStringName)]
    public class DynamicMongoDbContext : AbpMongoDbContext, IDynamicMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureDynamic();
        }
    }
}