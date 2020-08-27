using Volo.Abp.Reflection;

namespace EasyAbp.Abp.Dynamic.Permissions
{
    public class DynamicPermissions
    {
        public const string GroupName = "Dynamic";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(DynamicPermissions));
        }

        public class FieldDefinition
        {
            public const string Default = GroupName + ".FieldDefinition";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class ModelDefinition
        {
            public const string Default = GroupName + ".ModelDefinition";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class DynamicEntity
        {
            public const string Default = GroupName + ".DynamicEntity";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}