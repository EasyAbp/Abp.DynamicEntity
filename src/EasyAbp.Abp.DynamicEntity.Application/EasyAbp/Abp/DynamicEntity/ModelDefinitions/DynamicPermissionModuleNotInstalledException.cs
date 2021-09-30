using Volo.Abp;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions
{
    public class DynamicPermissionModuleNotInstalledException : BusinessException
    {
        public DynamicPermissionModuleNotInstalledException() : base(
            "EasyAbp.Abp.DynamicEntity:DynamicPermissionModuleNotInstalledException")
        {
        }
    }
}