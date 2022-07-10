using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicEntity.Web.Bundling
{
    [DependsOn(typeof(SharedThemeGlobalScriptContributor))]
    public class DynamicEntityScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddRange(new[]
            {
                "/easy-abp/easy-abp-dynamic.js"
            });
        }
    }
}