using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using EasyAbp.Abp.DynamicQuery;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions
{
    public static class DynamicEntityModelRepositoryExtensions
    {
        // TODO: Reuse the DynamicQuery extension class
        public static IQueryable<T> GetQueryByFilter<T>(this IEfCoreDbContext dbContext, IList<DynamicQueryFilter> filters) where T : class
        {
            if (filters.IsNullOrEmpty())
            {
                return dbContext.Set<T>().AsQueryable();
            }

            var sbWhere = new StringBuilder();
            int index = 0;
            foreach (var filter in filters)
            {
                if (index > 0)
                {
                    sbWhere.Append(" AND ");
                }

                sbWhere.Append(ConvertToCondition(filter, index));
                index++;
            }

            return dbContext.Set<T>()
                    .Where(sbWhere.ToString(), filters.Select(f => f.Value).ToArray())
                ;
        }

        private static string ConvertToCondition(DynamicQueryFilter filter, int index)
        {
            string columnName = GetColumnName(filter);
            string jsonValue = $"DbFunctions.JsonValue(ExtraProperties, \"$.{columnName}\")";
            switch (filter.Operator)
            {
                case DynamicQueryOperator.Equal:
                    return $"{jsonValue} = @{index}";
                case DynamicQueryOperator.NotEqual:
                    return $"{jsonValue} != @{index}";
                case DynamicQueryOperator.Greater:
                    return $"{jsonValue} > @{index}";
                case DynamicQueryOperator.GreaterOrEqual:
                    return $"{jsonValue} >= @{index}";
                case DynamicQueryOperator.Less:
                    return $"{jsonValue} < @{index}";
                case DynamicQueryOperator.LessOrEqual:
                    return $"{jsonValue} <= @{index}";
                case DynamicQueryOperator.StartWith:
                    return $"{jsonValue}.StartsWith(@{index})";
                case DynamicQueryOperator.NotStartWith:
                    return $"!{jsonValue}.StartsWith(@{index})";
                case DynamicQueryOperator.EndWith:
                    return $"{jsonValue}.EndsWith(@{index})";
                case DynamicQueryOperator.NotEndWith:
                    return $"!{jsonValue}.EndsWith(@{index})";
                case DynamicQueryOperator.Contain:
                    return $"{jsonValue}.Contains(@{index})";
                case DynamicQueryOperator.NotContain:
                    return $"!{jsonValue}.Contains(@{index})";
                default:
                    throw new InvalidOperationException($"Unknown dynamic query operator: {filter.Operator}");
            }
        }

        private static string GetColumnName(DynamicQueryFilter filter)
        {
            return filter.FieldName;
        }

        private static string GetTableName<T>(this IEfCoreDbContext dbContext) where T : class
        {
            var entityType = dbContext.Model.FindEntityType(typeof(T));
            return entityType.GetTableName();
        }


        public static IQueryable<T> GetQueryByFilter<T>(this IEfCoreDbContext dbContext, string filter) where T : class, IDynamicEntityModel
        {
            var queryable = dbContext.Set<T>().AsQueryable();

            if (filter.IsNullOrEmpty())
            {
                return queryable;
            }

            string tableName = dbContext.GetTableName<T>();
            var sql = $"SELECT * FROM {tableName} WHERE \"ExtraProperties\" LIKE {{0}}";
            return dbContext.Set<T>().FromSqlRaw(sql, $"%{filter}%");
        }
    }
}