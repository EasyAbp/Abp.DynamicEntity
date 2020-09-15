using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.Dynamic.DynamicEntities
{
    public interface IDynamicEntityRepository : IRepository<DynamicEntity, Guid>
    {
        IQueryable<DynamicEntity> GetQueryByFilter(IList<Filter> filters);
        IQueryable<DynamicEntity> GetQueryByFilter(string filter);
    }
}