using System;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using Microsoft.EntityFrameworkCore.Query;

namespace EasyAbp.Abp.DynamicEntity.EntityFrameworkCore
{
    [DynamicLinqType]
    public static class DbFunctions
    {
        public static string JsonValue([NotParameterized] string path)
        {
            throw new NotSupportedException();
        }
    }
}