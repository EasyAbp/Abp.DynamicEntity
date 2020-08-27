using System;
using EasyAbp.Abp.Dynamic.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.Dynamic.DynamicEntities
{
    public class DynamicEntityRepository: EfCoreRepository<IDynamicDbContext, DynamicEntity, Guid>, IDynamicEntityRepository
    {
        public DynamicEntityRepository(IDbContextProvider<IDynamicDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}