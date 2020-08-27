using System;
using EasyAbp.Abp.Dynamic.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions
{
    public class ModelDefinitionRepository : EfCoreRepository<IDynamicDbContext, ModelDefinition, Guid>, IModelDefinitionRepository
    {
        public ModelDefinitionRepository(IDbContextProvider<IDynamicDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}