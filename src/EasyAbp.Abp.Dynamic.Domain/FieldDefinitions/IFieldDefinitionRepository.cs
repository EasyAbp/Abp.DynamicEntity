using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.Dynamic.FieldDefinitions
{
    public interface IFieldDefinitionRepository : IRepository<FieldDefinition, Guid>
    {
        Task<FieldDefinition> GetByName(string name);
    }
}