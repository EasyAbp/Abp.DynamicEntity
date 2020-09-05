using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.Dynamic.FieldDefinitions
{
    public interface IFieldDefinitionRepository : IRepository<FieldDefinition, Guid>
    {
        Task<FieldDefinition> GetByNameAsync(string name);
        Task<List<FieldDefinition>> GetByIds(List<Guid> ids);
    }
}