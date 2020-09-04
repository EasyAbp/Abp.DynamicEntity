using System;
using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.Dynamic.FieldDefinitions
{
    public class FieldDefinitionRepository : EfCoreRepository<IDynamicDbContext, FieldDefinition, Guid>, IFieldDefinitionRepository
    {
        public FieldDefinitionRepository(IDbContextProvider<IDynamicDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<FieldDefinition> GetByName(string name)
        {
            return await DbSet.FirstOrDefaultAsync(fd => fd.Name == name);
        }
    }
}