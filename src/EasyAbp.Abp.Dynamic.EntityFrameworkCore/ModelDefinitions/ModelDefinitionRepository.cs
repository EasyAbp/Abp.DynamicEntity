using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions
{
    public class ModelDefinitionRepository : EfCoreRepository<IDynamicDbContext, ModelDefinition, Guid>, IModelDefinitionRepository
    {
        public ModelDefinitionRepository(IDbContextProvider<IDynamicDbContext> dbContextProvider) : base(dbContextProvider)
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