using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions
{
    public static class DynamicModelRepositoryExtensions
    {
        public static IQueryable<T> GetQueryByFilter<T>(this IEfCoreDbContext dbContext, IDictionary<string, string> filter) where T : class, IDynamicModel
        {
            if (filter == null || filter.Count == 0)
            {
                return dbContext.Set<T>().AsQueryable();
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

            string tableName = dbContext.GetTableName<T>();
            var sbSql = new StringBuilder($"SELECT * FROM {tableName} WHERE ");
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

        private static string GetTableName<T>(this IEfCoreDbContext dbContext) where T : class
        {
            var entityType = dbContext.Model.FindEntityType(typeof(T));
            return entityType.GetTableName();
        }
        
        public static IQueryable<T> GetQueryByFilter<T>(this IEfCoreDbContext dbContext, string filter) where  T : class, IDynamicModel
        {
            var queryable = dbContext.Set<T>().AsQueryable();
            
            if (filter.IsNullOrEmpty())
            {
                return queryable;
            }

            string tableName = dbContext.GetTableName<T>();
            var sql = $"SELECT * FROM {tableName} WHERE ExtraProperties LIKE {{0}}";
            return dbContext.Set<T>().FromSqlRaw(sql, $"%{filter}%");
        }
    }
}