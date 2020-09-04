using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions
{
    public interface IModelDefinitionRepository : IRepository<ModelDefinition, Guid>
    {
    }
}