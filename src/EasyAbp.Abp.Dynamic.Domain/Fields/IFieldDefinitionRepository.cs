using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.Dynamic.Fields
{
    public interface IFieldDefinitionRepository : IRepository<FieldDefinition, Guid>
    {
    }
}