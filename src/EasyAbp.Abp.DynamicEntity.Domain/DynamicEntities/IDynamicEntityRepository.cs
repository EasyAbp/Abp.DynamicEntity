using System;
using System.Linq;
using EasyAbp.Abp.DynamicQuery.Filters;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities
{
    public interface IDynamicEntityRepository : IRepository<DynamicEntity, Guid>
    {
        IQueryable<DynamicEntity> ExecuteDynamicQuery(DynamicQueryGroup group);
    }
}