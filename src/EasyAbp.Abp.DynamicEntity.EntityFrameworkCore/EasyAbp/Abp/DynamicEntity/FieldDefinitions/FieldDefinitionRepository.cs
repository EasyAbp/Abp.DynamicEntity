using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.DynamicEntity.FieldDefinitions
{
    public class FieldDefinitionRepository : EfCoreRepository<IDynamicEntityDbContext, FieldDefinition, Guid>, IFieldDefinitionRepository
    {
        public FieldDefinitionRepository(IDbContextProvider<IDynamicEntityDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<FieldDefinition> GetByNameAsync(string name)
        {
            return await (await GetDbSetAsync()).FirstOrDefaultAsync(fd => fd.Name == name);
        }

        public async Task<List<FieldDefinition>> GetByIds(List<Guid> ids)
        {
            return await (await GetDbSetAsync()).Where(fd => ids.Contains(fd.Id))
                    .ToListAsync()
                ;
        }
    }
}