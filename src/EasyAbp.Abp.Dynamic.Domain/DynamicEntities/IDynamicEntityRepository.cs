using System;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.Dynamic.DynamicEntities
{
    public interface IDynamicEntityRepository : IRepository<DynamicEntity, Guid>
    {
    }
}