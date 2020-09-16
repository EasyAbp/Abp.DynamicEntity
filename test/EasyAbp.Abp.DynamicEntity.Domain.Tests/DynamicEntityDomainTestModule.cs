using EasyAbp.Abp.DynamicEntity.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicEntity
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(DynamicEntityEntityFrameworkCoreTestModule)
        )]
    public class DynamicEntityDomainTestModule : AbpModule
    {
        
    }
}
