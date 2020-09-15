using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.EntityFrameworkCore;
using EasyAbp.Abp.Dynamic.ModelDefinitions;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.Dynamic.DynamicEntities
{
    public class DynamicEntityRepository : EfCoreRepository<IDynamicDbContext, DynamicEntity, Guid>, IDynamicEntityRepository
    {
        public DynamicEntityRepository(IDbContextProvider<IDynamicDbContext> dbContextProvider) : base(dbContextProvider)
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

        public IQueryable<DynamicEntity> GetQueryByFilter(IList<Filter> filters)
        {
            return DbContext.GetQueryByFilter<DynamicEntity>(filters);
        }

        public IQueryable<DynamicEntity> GetQueryByFilter(string filter)
        {
            return DbContext.GetQueryByFilter<DynamicEntity>(filter);
        }
    }
}