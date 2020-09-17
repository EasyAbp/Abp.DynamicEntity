using System;
using System.Collections.Generic;
using System.Linq;
using EasyAbp.Abp.DynamicEntity.EntityFrameworkCore;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using EasyAbp.Abp.DynamicQuery;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntityEntities
{
    public class DynamicEntityEntityRepository : EfCoreRepository<IDynamicEntityDbContext, DynamicEntityEntity, Guid>, IDynamicEntityEntityRepository
    {
        public DynamicEntityEntityRepository(IDbContextProvider<IDynamicEntityDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override IQueryable<DynamicEntityEntity> WithDetails()
        {
            return GetQueryable()
                    .Include(de => de.ModelDefinition)
                    .ThenInclude(md => md.Fields)
                    .ThenInclude(mf => mf.FieldDefinition)
                ;
        }

        public IQueryable<DynamicEntityEntity> GetQueryByFilter(IList<DynamicQueryFilter> filters)
        {
            return DbContext.GetQueryByFilter<DynamicEntityEntity>(filters);
        }

        public IQueryable<DynamicEntityEntity> GetQueryByFilter(string filter)
        {
            return DbContext.GetQueryByFilter<DynamicEntityEntity>(filter);
        }
    }
}