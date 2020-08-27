using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions
{
    public interface IModelDefinitionRepository : IRepository<ModelDefinition, Guid>
    {
        
    }
}