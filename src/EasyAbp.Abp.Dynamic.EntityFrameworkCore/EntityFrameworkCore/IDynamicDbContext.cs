using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.Dynamic.EntityFrameworkCore
{
    [ConnectionStringName(DynamicDbProperties.ConnectionStringName)]
    public interface IDynamicDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}