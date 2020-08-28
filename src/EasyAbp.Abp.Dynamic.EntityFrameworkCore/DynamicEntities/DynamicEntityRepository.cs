using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.Dynamic.DynamicEntities
{
    public class DynamicEntityRepository: EfCoreRepository<IDynamicDbContext, DynamicEntity, Guid>, IDynamicEntityRepository
    {
        public DynamicEntityRepository(IDbContextProvider<IDynamicDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        
        // TODO: Extract to IDynamicModel extension method
        public IQueryable<DynamicEntity> GetQueryByFilter(IDictionary<string, string> filter)
        {
            if (filter == null || filter.Count == 0)
            {
                return GetQueryable();
            }

            string jsonFunction;
            switch (DbContext.Database.ProviderName)
            {
                case "Microsoft.EntityFrameworkCore.Sqlite":
                    jsonFunction = "JSON_EXTRACT";
                    break;
                default:
                    jsonFunction = "JSON_VALUE";
                    break;
            }
            
            var sbSql = new StringBuilder("SELECT * FROM DynamicDynamicEntities WHERE ");
            var parameters = new List<object>();
            int index = 0;
            foreach (var kv in filter)
            {
                if (index > 0)
                {
                    sbSql.Append(" AND ");
                }
                sbSql.Append($"{jsonFunction}(ExtraProperties, {{{index * 2}}}) LIKE {{{index * 2 + 1}}}");
                parameters.Add($"$.{kv.Key}");
                parameters.Add($"%{kv.Value}%");
                index++;
            }
            
            return DbSet.FromSqlRaw(sbSql.ToString(), parameters.ToArray());
        }
    }
}