using EasyAbp.Abp.Dynamic.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.Dynamic
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(DynamicEntityFrameworkCoreTestModule)
        )]
    public class DynamicDomainTestModule : AbpModule
    {
        
    }
}
