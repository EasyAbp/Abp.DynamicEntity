using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions
{
    public static class DynamicEntityModelRepositoryExtensions
    {
        /*public static IQueryable<T> GetQueryByFilter<T>(this IEfCoreDbContext dbContext, IList<Filter> filters) where T : class, IDynamicEntityModel
        {
            if (filters.IsNullOrEmpty())
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
            foreach (var filter in filters)
            {
                if (index > 0)
                {
                    sbSql.Append(" AND ");
                }
                sbSql.Append($"{jsonFunction}(ExtraProperties, '$.{filter.FieldName}') LIKE {{{index}}}");
                parameters.Add($"%{filter.Value}%");
                index++;
            }
            
            return dbContext.Set<T>().FromSqlRaw(sbSql.ToString(), parameters.ToArray());
        }
*/
        private static string GetTableName<T>(this IEfCoreDbContext dbContext) where T : class
        {
            var entityType = dbContext.Model.FindEntityType(typeof(T));
            return entityType.GetTableName();
        }
        
        
        public static IQueryable<T> GetQueryByFilter<T>(this IEfCoreDbContext dbContext, string filter) where  T : class, IDynamicEntityModel
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