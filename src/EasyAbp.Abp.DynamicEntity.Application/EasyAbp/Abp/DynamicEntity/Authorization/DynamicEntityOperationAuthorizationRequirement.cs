using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace EasyAbp.Abp.DynamicEntity.Authorization
{
    public class DynamicEntityOperationAuthorizationRequirement : OperationAuthorizationRequirement
    {
        private const string NamePrefix = "DynamicEntity";
        public const string GetName = NamePrefix + ".Get";
        public const string GetListName = NamePrefix + ".GetList";
        public const string CreateName = NamePrefix + ".Create";
        public const string UpdateName = NamePrefix + ".Update";
        public const string DeleteName = NamePrefix + ".Delete";

        public DynamicEntityOperationAuthorizationRequirement([NotNull] string name)
        {
            Name = name;
        }
    }
}