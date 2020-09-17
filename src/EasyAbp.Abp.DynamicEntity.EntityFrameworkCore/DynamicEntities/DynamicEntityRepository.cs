using System;
using System.Collections.Generic;
using System.Linq;
using EasyAbp.Abp.DynamicEntity.EntityFrameworkCore;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using EasyAbp.Abp.DynamicQuery;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities
{
    public class DynamicEntityRepository : EfCoreRepository<IDynamicEntityDbContext, DynamicEntity, Guid>, IDynamicEntityRepository
    {
        public DynamicEntityRepository(IDbContextProvider<IDynamicEntityDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override IQueryable<DynamicEntity> WithDetails()
        {
            return GetQueryable()
                    .Include(de => de.ModelDefinition)
                    .ThenInclude(md => md.Fields)
                    .ThenInclude(mf => mf.FieldDefinition)
                ;
        }

        public IQueryable<DynamicEntity> GetQueryByFilter(IList<DynamicQueryFilter> filters)
        {
            return DynamicEntityModelRepositoryExtensions.GetQueryByFilter<DynamicEntity>(DbContext, filters);
        }

        public IQueryable<DynamicEntity> GetQueryByFilter(string filter)
        {
            return DbContext.GetQueryByFilter<DynamicEntity>(filter);
        }
    }
}