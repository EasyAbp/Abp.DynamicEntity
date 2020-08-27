using EasyAbp.Abp.Dynamic.DynamicEntities;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using EasyAbp.Abp.Dynamic.ModelDefinitions;
using Microsoft.EntityFrameworkCore;
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
        DbSet<FieldDefinition> FieldDefinitions { get; set; }
        DbSet<ModelDefinition> ModelDefinitions { get; set; }
        DbSet<DynamicEntity> DynamicEntities { get; set; }
    }
}
