using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using EasyAbp.Abp.DynamicEntity.EntityFrameworkCore;

namespace EasyAbp.Abp.DynamicEntity.DynamicLINQ
{
    public class MyCustomTypeProvider : AbstractDynamicLinqCustomTypeProvider, IDynamicLinkCustomTypeProvider
    {
        public HashSet<Type> GetCustomTypes()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var set = new HashSet<Type>(FindTypesMarkedWithDynamicLinqTypeAttribute(assemblies));

            set.Add(typeof(DbFunctions));

            return set;
        }

        public Type ResolveType(string typeName)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            return ResolveType(assemblies, typeName);
        }

        public Type ResolveTypeBySimpleName(string simpleTypeName)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            return ResolveTypeBySimpleName(assemblies, simpleTypeName);
        }
    }
}