using DynamicEntitySample.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DynamicEntitySample.Permissions
{
    public class DynamicEntitySamplePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(DynamicEntitySamplePermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(DynamicEntitySamplePermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DynamicEntitySampleResource>(name);
        }
    }
}
