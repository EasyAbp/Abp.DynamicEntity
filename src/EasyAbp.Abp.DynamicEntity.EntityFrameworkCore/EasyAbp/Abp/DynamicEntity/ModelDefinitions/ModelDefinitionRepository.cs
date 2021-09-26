using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.EntityFrameworkCore;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions
{
    public class ModelDefinitionRepository : EfCoreRepository<IDynamicEntityDbContext, ModelDefinition, Guid>, IModelDefinitionRepository
    {
        public ModelDefinitionRepository(IDbContextProvider<IDynamicEntityDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        [CanBeNull]
        public override async Task<IQueryable<ModelDefinition>> WithDetailsAsync()
        {
            return (await GetQueryableAsync())
                .Include(md => md.Fields)
                .ThenInclude(mf => mf.FieldDefinition);
        }
    }
}