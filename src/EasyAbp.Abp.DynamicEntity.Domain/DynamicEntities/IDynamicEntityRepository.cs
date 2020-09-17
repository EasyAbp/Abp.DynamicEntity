using System;
using System.Collections.Generic;
using System.Linq;
using EasyAbp.Abp.DynamicQuery;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities
{
    public interface IDynamicEntityRepository : IRepository<DynamicEntity, Guid>
    {
        IQueryable<DynamicEntity> GetQueryByFilter(IList<DynamicQueryFilter> filters);
        IQueryable<DynamicEntity> GetQueryByFilter(string filter);
    }
}