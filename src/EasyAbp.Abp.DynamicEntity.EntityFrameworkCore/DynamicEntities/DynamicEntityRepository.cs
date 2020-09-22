using System;
using System.Linq;
using EasyAbp.Abp.DynamicEntity.EntityFrameworkCore;
using EasyAbp.Abp.DynamicQuery;
using EasyAbp.Abp.DynamicQuery.Filters;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities
{
    public class DynamicEntityRepository : EfCoreRepository<IDynamicEntityDbContext, DynamicEntity, Guid>, IDynamicEntityRepository
    {
        private readonly IDynamicQueryHelper _dynamicQueryHelper;

        public DynamicEntityRepository(IDbContextProvider<IDynamicEntityDbContext> dbContextProvider, IDynamicQueryHelper dynamicQueryHelper) : base(dbContextProvider)
        {
            _dynamicQueryHelper = dynamicQueryHelper;
        }

        public override IQueryable<DynamicEntity> WithDetails()
        {
            return GetQueryable()
                    .Include(de => de.ModelDefinition)
                    .ThenInclude(md => md.Fields)
                    .ThenInclude(mf => mf.FieldDefinition)
                ;
        }
        
        public IQueryable<DynamicEntity> ExecuteDynamicQuery(DynamicQueryGroup group)
        {
            return _dynamicQueryHelper.ExecuteDynamicQuery(DbSet.AsQueryable(), group);
        }
    }
}