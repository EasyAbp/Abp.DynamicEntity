using DynamicSample.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DynamicSample.Permissions
{
    public class DynamicSamplePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(DynamicSamplePermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(DynamicSamplePermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DynamicSampleResource>(name);
        }
    }
}
