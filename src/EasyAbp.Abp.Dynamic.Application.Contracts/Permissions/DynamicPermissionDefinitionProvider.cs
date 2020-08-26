using EasyAbp.Abp.Dynamic.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.Abp.Dynamic.Permissions
{
    public class DynamicPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(DynamicPermissions.GroupName, L("Permission:Dynamic"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DynamicResource>(name);
        }
    }
}