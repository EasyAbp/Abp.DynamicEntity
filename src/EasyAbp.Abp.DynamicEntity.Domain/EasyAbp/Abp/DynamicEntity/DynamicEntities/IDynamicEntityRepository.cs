using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicQuery.Filters;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities
{
    public interface IDynamicEntityRepository : IRepository<DynamicEntity, Guid>
    {
        Task<IQueryable<DynamicEntity>> ExecuteDynamicQueryAsync(DynamicQueryGroup group);
    }
}