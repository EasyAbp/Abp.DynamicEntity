using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.Dynamic.FieldDefinitions
{
    public interface IFieldDefinitionRepository : IRepository<FieldDefinition, Guid>
    {
    }
}