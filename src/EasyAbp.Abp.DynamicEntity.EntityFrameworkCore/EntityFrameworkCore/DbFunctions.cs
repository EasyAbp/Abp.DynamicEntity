using System;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace EasyAbp.Abp.DynamicEntity.EntityFrameworkCore
{
    [DynamicLinqType]
    public static class DbFunctions
    {
        [DbFunction("JSON_VALUE", "")]
        public static string JsonValue(string column, [NotParameterized] string path)
        {
            throw new NotSupportedException();
        }
    }
}