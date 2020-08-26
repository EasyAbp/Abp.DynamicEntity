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
    }
}