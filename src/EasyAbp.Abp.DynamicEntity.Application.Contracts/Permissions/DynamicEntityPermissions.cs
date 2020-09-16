using Volo.Abp.Reflection;

namespace EasyAbp.Abp.DynamicEntity.Permissions
{
    public class DynamicEntityPermissions
    {
        public const string GroupName = "DynamicEntity";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(DynamicEntityPermissions));
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

        public class DynamicEntityEntity
        {
            public const string Default = GroupName + ".DynamicEntityEntity";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}