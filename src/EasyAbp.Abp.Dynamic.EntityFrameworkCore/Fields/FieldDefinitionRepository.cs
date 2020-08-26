using System;
using EasyAbp.Abp.Dynamic.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.Dynamic.Fields
{
    public class FieldDefinitionRepository : EfCoreRepository<DynamicDbContext, FieldDefinition, Guid>, IFieldDefinitionRepository
    {
        public FieldDefinitionRepository(IDbContextProvider<DynamicDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}