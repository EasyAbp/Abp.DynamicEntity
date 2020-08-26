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

            var fieldDefinitionPermission = myGroup.AddPermission(DynamicPermissions.FieldDefinition.Default, L("Permission:FieldDefinition"));
            fieldDefinitionPermission.AddChild(DynamicPermissions.FieldDefinition.Create, L("Permission:Create"));
            fieldDefinitionPermission.AddChild(DynamicPermissions.FieldDefinition.Update, L("Permission:Update"));
            fieldDefinitionPermission.AddChild(DynamicPermissions.FieldDefinition.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DynamicResource>(name);
        }
    }
}
