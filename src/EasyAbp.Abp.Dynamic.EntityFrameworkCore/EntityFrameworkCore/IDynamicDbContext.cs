using EasyAbp.Abp.Dynamic.FieldDefinitions;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.Abp.Dynamic.Fields;

namespace EasyAbp.Abp.Dynamic.EntityFrameworkCore
{
    [ConnectionStringName(DynamicDbProperties.ConnectionStringName)]
    public interface IDynamicDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<FieldDefinition> FieldDefinitions { get; set; }
    }
}
