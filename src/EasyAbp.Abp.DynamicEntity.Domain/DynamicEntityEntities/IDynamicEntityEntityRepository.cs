using System;
using System.Collections.Generic;
using System.Linq;
using EasyAbp.Abp.DynamicQuery;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntityEntities
{
    public interface IDynamicEntityEntityRepository : IRepository<DynamicEntityEntity, Guid>
    {
        IQueryable<DynamicEntityEntity> GetQueryByFilter(IList<DynamicQueryFilter> filters);
        IQueryable<DynamicEntityEntity> GetQueryByFilter(string filter);
    }
}