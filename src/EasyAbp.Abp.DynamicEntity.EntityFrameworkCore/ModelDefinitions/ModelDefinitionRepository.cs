using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.EntityFrameworkCore;
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

        public override IQueryable<ModelDefinition> WithDetails()
        {
            return GetQueryable()
                .Include(md => md.Fields)
                .ThenInclude(mf => mf.FieldDefinition);
        }
        
    }
}