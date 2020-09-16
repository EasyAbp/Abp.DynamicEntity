using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntityEntities
{
    public interface IDynamicEntityEntityRepository : IRepository<DynamicEntityEntity, Guid>
    {
        IQueryable<DynamicEntityEntity> GetQueryByFilter(IList<Filter> filters);
        IQueryable<DynamicEntityEntity> GetQueryByFilter(string filter);
    }
}