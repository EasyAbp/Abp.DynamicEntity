using EasyAbp.Abp.DynamicEntity.DynamicEntityEntities;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.DynamicEntity.EntityFrameworkCore
{
    [ConnectionStringName(DynamicEntityDbProperties.ConnectionStringName)]
    public interface IDynamicEntityDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<FieldDefinition> FieldDefinitions { get; set; }
        DbSet<ModelDefinition> ModelDefinitions { get; set; }
        DbSet<DynamicEntityEntity> DynamicEntityEntities { get; set; }
    }
}
