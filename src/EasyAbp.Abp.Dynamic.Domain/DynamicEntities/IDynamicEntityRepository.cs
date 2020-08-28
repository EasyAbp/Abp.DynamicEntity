using System;
using System.Collections.Generic;
using System.Linq;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.Dynamic.DynamicEntities
{
    public interface IDynamicEntityRepository : IRepository<DynamicEntity, Guid>
    {
        IQueryable<DynamicEntity> GetQueryByFilter(IDictionary<string, string> filter);
    }
}