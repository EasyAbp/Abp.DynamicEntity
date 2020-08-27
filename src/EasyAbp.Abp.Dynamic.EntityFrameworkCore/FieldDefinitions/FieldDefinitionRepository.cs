using System;
using EasyAbp.Abp.Dynamic.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.Dynamic.FieldDefinitions
{
    public class FieldDefinitionRepository : EfCoreRepository<IDynamicDbContext, FieldDefinition, Guid>, IFieldDefinitionRepository
    {
        public FieldDefinitionRepository(IDbContextProvider<IDynamicDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}