using EasyAbp.Abp.DynamicEntity.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.Abp.DynamicEntity.Permissions
{
    public class DynamicEntityPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(DynamicEntityPermissions.GroupName, L("Permission:DynamicEntity"));

            var fieldDefinitionPermission = myGroup.AddPermission(DynamicEntityPermissions.FieldDefinition.Default, L("Permission:FieldDefinition"));
            fieldDefinitionPermission.AddChild(DynamicEntityPermissions.FieldDefinition.Create, L("Permission:Create"));
            fieldDefinitionPermission.AddChild(DynamicEntityPermissions.FieldDefinition.Update, L("Permission:Update"));
            fieldDefinitionPermission.AddChild(DynamicEntityPermissions.FieldDefinition.Delete, L("Permission:Delete"));

            var modelDefinitionPermission = myGroup.AddPermission(DynamicEntityPermissions.ModelDefinition.Default, L("Permission:ModelDefinition"));
            modelDefinitionPermission.AddChild(DynamicEntityPermissions.ModelDefinition.Create, L("Permission:Create"));
            modelDefinitionPermission.AddChild(DynamicEntityPermissions.ModelDefinition.Update, L("Permission:Update"));
            modelDefinitionPermission.AddChild(DynamicEntityPermissions.ModelDefinition.Delete, L("Permission:Delete"));
            
            var dynamicEntityPermission = myGroup.AddPermission(DynamicEntityPermissions.DynamicEntity.Default, L("Permission:DynamicEntity"));
            dynamicEntityPermission.AddChild(DynamicEntityPermissions.DynamicEntity.Create, L("Permission:Create"));
            dynamicEntityPermission.AddChild(DynamicEntityPermissions.DynamicEntity.Update, L("Permission:Update"));
            dynamicEntityPermission.AddChild(DynamicEntityPermissions.DynamicEntity.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DynamicEntityResource>(name);
        }
    }
}