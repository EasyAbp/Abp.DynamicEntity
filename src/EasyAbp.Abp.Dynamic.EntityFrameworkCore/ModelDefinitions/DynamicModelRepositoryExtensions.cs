using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions
{
    public static class DynamicModelRepositoryExtensions
    {
        public static IQueryable<T> GetQueryByFilter<T>(this IQueryable<T> queryable, IDictionary<string, string> filter, IEfCoreDbContext dbContext) where T : class, IDynamicModel
        {
            if (filter == null || filter.Count == 0)
            {
                return queryable;
            }

            string jsonFunction;
            switch (dbContext.Database.ProviderName)
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
            
            return dbContext.Set<T>().FromSqlRaw(sbSql.ToString(), parameters.ToArray());
        }

    }
}